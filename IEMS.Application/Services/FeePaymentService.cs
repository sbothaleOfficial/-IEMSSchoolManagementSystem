using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;
using IEMS.Application.Interfaces;
using IEMS.Core.Services;

namespace IEMS.Application.Services;

public class FeePaymentService
{
    private readonly IFeePaymentRepository _feePaymentRepository;
    private readonly IFeeStructureRepository _feeStructureRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;
    private readonly FeeCalculationService _feeCalculationService;
    private readonly AmountToWordsService _amountToWordsService;
    private readonly ISystemSettingsService _systemSettingsService;

    public FeePaymentService(
        IFeePaymentRepository feePaymentRepository,
        IFeeStructureRepository feeStructureRepository,
        IStudentRepository studentRepository,
        IClassRepository classRepository,
        FeeCalculationService feeCalculationService,
        AmountToWordsService amountToWordsService,
        ISystemSettingsService systemSettingsService)
    {
        _feePaymentRepository = feePaymentRepository;
        _feeStructureRepository = feeStructureRepository;
        _studentRepository = studentRepository;
        _classRepository = classRepository;
        _feeCalculationService = feeCalculationService;
        _amountToWordsService = amountToWordsService;
        _systemSettingsService = systemSettingsService;
    }

    public async Task<IEnumerable<FeePaymentDto>> GetAllFeePaymentsAsync()
    {
        var feePayments = await _feePaymentRepository.GetAllAsync();
        return feePayments.Select(MapToDto);
    }

    public async Task<FeePaymentDto?> GetFeePaymentByIdAsync(int id)
    {
        var feePayment = await _feePaymentRepository.GetByIdAsync(id);
        return feePayment != null ? MapToDto(feePayment) : null;
    }

    public async Task<FeePaymentDto?> GetFeePaymentByReceiptNumberAsync(string receiptNumber)
    {
        var feePayment = await _feePaymentRepository.GetByReceiptNumberAsync(receiptNumber);
        return feePayment != null ? MapToDto(feePayment) : null;
    }

    public async Task<IEnumerable<FeePaymentDto>> GetFeePaymentsByStudentIdAsync(int studentId)
    {
        var feePayments = await _feePaymentRepository.GetByStudentIdAsync(studentId);
        return feePayments.Select(MapToDto);
    }

    public async Task<StudentFeeStatusDto> GetStudentFeeStatusAsync(int studentId, string academicYear)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student == null) throw new ArgumentException("Student not found");

        var studentClass = await _classRepository.GetByIdAsync(student.ClassId);
        if (studentClass == null) throw new ArgumentException("Student class not found");

        // Get all fee structures for this student's class and academic year
        var feeStructures = await _feeStructureRepository.GetByClassIdAndAcademicYearAsync(student.ClassId, academicYear);

        // Get all payments for this student and academic year
        var allPayments = await _feePaymentRepository.GetByStudentIdAsync(studentId);
        var paymentsThisYear = allPayments.Where(p => p.AcademicYear == academicYear).ToList();

        var feeTypeStatuses = new List<StudentFeeTypeStatusDto>();
        decimal totalOutstanding = 0;

        // Process each fee type that has a structure
        foreach (var feeStructure in feeStructures)
        {
            var feeTypePayments = paymentsThisYear.Where(p => p.FeeType == feeStructure.FeeType).ToList();
            var totalPaid = feeTypePayments.Sum(p => p.AmountPaid);
            var lastPayment = feeTypePayments.OrderByDescending(p => p.PaymentDate).FirstOrDefault();

            // FIXED: Use the RemainingBalance from the latest payment instead of recalculating
            // This ensures late fees, discounts, and previous balances are properly accounted for
            var outstandingForType = lastPayment?.RemainingBalance ?? feeStructure.Amount;
            totalOutstanding += outstandingForType;

            feeTypeStatuses.Add(new StudentFeeTypeStatusDto
            {
                FeeType = feeStructure.FeeType,
                FeeTypeName = GetFeeTypeDisplayName(feeStructure.FeeType),
                FeeStructureAmount = feeStructure.Amount,
                TotalPaid = totalPaid,
                OutstandingAmount = outstandingForType,
                LastPaidAmount = lastPayment?.AmountPaid ?? 0,
                LastPaymentDate = lastPayment?.PaymentDate,
                PaymentCount = feeTypePayments.Count
            });
        }

        // Get recent payments (last 5)
        var recentPayments = paymentsThisYear
            .OrderByDescending(p => p.PaymentDate)
            .Take(5)
            .Select(MapToDto)
            .ToList();

        return new StudentFeeStatusDto
        {
            StudentId = studentId,
            StudentName = $"{student.FirstName} {student.Surname}",
            StudentNumber = student.StudentNumber ?? "",
            ClassName = $"{studentClass.Name} - {studentClass.Section}",
            AcademicYear = academicYear,
            TotalOutstandingBalance = totalOutstanding,
            FeeTypeStatuses = feeTypeStatuses,
            RecentPayments = recentPayments
        };
    }

    public async Task<decimal> GetStudentOutstandingBalanceAsync(int studentId, string academicYear)
    {
        var feeStatus = await GetStudentFeeStatusAsync(studentId, academicYear);
        return feeStatus.TotalOutstandingBalance;
    }

    private string GetFeeTypeDisplayName(FeeType feeType)
    {
        return feeType switch
        {
            FeeType.TUITION => "Tuition Fee",
            FeeType.ADMISSION => "Admission Fee",
            FeeType.LIBRARY => "Library Fee",
            FeeType.EXAM => "Examination Fee",
            FeeType.SPORTS => "Sports Fee",
            FeeType.TRANSPORT => "Transport Fee",
            FeeType.UNIFORM => "Uniform Fee",
            FeeType.MISCELLANEOUS => "Miscellaneous Fee",
            _ => feeType.ToString()
        };
    }

    public async Task<IEnumerable<FeePaymentDto>> GetFeePaymentsByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        var feePayments = await _feePaymentRepository.GetByDateRangeAsync(fromDate, toDate);
        return feePayments.Select(MapToDto);
    }

    public async Task<FeePaymentDto> CreateFeePaymentAsync(CreateFeePaymentDto createDto)
    {
        var student = await _studentRepository.GetByIdAsync(createDto.StudentId);
        if (student == null)
            throw new ArgumentException("Student not found");

        var receiptNumber = await _feePaymentRepository.GenerateReceiptNumberAsync();

        var previousBalance = await _feePaymentRepository.GetPendingAmountByStudentAsync(createDto.StudentId, createDto.FeeType);

        var feeStructure = await _feeStructureRepository.GetByClassIdFeeTypeAndAcademicYearAsync(
            student.ClassId, createDto.FeeType, createDto.AcademicYear);

        var totalFeeAmount = feeStructure?.Amount ?? 0;

        // CORRECT CALCULATION:
        // Total owed = previousBalance + feeAmount + lateFee - discount
        // Remaining = totalOwed - amountPaid
        var totalOwed = previousBalance + totalFeeAmount + createDto.LateFee - createDto.Discount;
        var newRemainingBalance = Math.Max(0, totalOwed - createDto.AmountPaid);

        // FIXED BUG #7: Track overpayment in payment notes
        var paymentNotes = createDto.PaymentNotes ?? "";
        if (createDto.AmountPaid > totalOwed)
        {
            var overpayment = createDto.AmountPaid - totalOwed;
            var overpaymentNote = $"[OVERPAYMENT: ₹{overpayment:F2} excess paid. Total owed was ₹{totalOwed:F2}]";

            // Add overpayment note to payment notes
            paymentNotes = string.IsNullOrWhiteSpace(paymentNotes)
                ? overpaymentNote
                : $"{paymentNotes}\n{overpaymentNote}";

            // Log warning for financial reconciliation
            System.Diagnostics.Debug.WriteLine($"WARNING: Overpayment detected - Student {student.StudentNumber}, Receipt {receiptNumber}, Overpayment: ₹{overpayment:F2}");
        }

        var feePayment = new FeePayment
        {
            ReceiptNumber = receiptNumber,
            StudentId = createDto.StudentId,
            FeeType = createDto.FeeType,
            AmountPaid = createDto.AmountPaid,
            PaymentMethod = createDto.PaymentMethod,
            TransactionId = createDto.TransactionId,
            ChequeNumber = createDto.ChequeNumber,
            BankName = createDto.BankName,
            PaymentNotes = paymentNotes,
            PreviousBalance = previousBalance,
            RemainingBalance = newRemainingBalance,
            LateFee = createDto.LateFee,
            Discount = createDto.Discount,
            InstallmentNumber = createDto.InstallmentNumber,
            NextDueDate = createDto.NextDueDate,
            AcademicYear = createDto.AcademicYear,
            GeneratedBy = createDto.GeneratedBy,
            PaymentDate = DateTime.Now
        };

        var createdPayment = await _feePaymentRepository.AddAsync(feePayment);

        var createdPaymentWithIncludes = await _feePaymentRepository.GetByIdAsync(createdPayment.Id);
        return MapToDto(createdPaymentWithIncludes!);
    }

    public async Task<FeeReceiptDto> GenerateReceiptAsync(int feePaymentId)
    {
        var feePayment = await _feePaymentRepository.GetByIdAsync(feePaymentId);
        if (feePayment == null)
            throw new ArgumentException("Fee payment not found");

        var feeStructure = await _feeStructureRepository.GetByClassIdFeeTypeAndAcademicYearAsync(
            feePayment.Student.ClassId, feePayment.FeeType, feePayment.AcademicYear);

        // FIXED BUG #9: Throw exception if fee structure not found instead of silently setting to 0
        if (feeStructure == null)
            throw new InvalidOperationException($"Fee structure not found for {feePayment.FeeType} in class {feePayment.Student.Class?.Name ?? "Unknown"} for academic year {feePayment.AcademicYear}");

        // Load school information from system settings
        var schoolName = await _systemSettingsService.GetSettingValueAsync("School.Name") ?? "INSPIRE ENGLISH MEDIUM SCHOOL, MARDI";
        var schoolAddress = await _systemSettingsService.GetSettingValueAsync("School.AddressLine1") ?? "Tah. Maregaon, Dist. Yavatmal (Maharashtra)";
        var schoolPinCode = await _systemSettingsService.GetSettingValueAsync("School.PinCode") ?? "445303";
        var schoolPhone = await _systemSettingsService.GetSettingValueAsync("School.Phone") ?? "8483949981";
        var schoolEmail = await _systemSettingsService.GetSettingValueAsync("School.Email") ?? "inspire.mardi@gmail.com";

        // Format school address with pin code
        var fullAddress = $"{schoolAddress} – {schoolPinCode}";
        var formattedPhone = $"+91 {schoolPhone}";

        return new FeeReceiptDto
        {
            SchoolName = schoolName.ToUpper(),
            SchoolAddress = fullAddress,
            SchoolPhone = formattedPhone,
            SchoolEmail = schoolEmail,
            ReceiptNumber = feePayment.ReceiptNumber,
            ReceiptDate = feePayment.PaymentDate,
            AcademicYear = feePayment.AcademicYear,
            StudentName = $"{feePayment.Student.FirstName} {feePayment.Student.Surname}",
            ClassName = feePayment.Student.Class != null
                ? $"{feePayment.Student.Class.Name} - {feePayment.Student.Class.Section}"
                : "No Class Assigned",
            StudentNumber = feePayment.Student.StudentNumber,
            ParentPhone = feePayment.Student.ParentMobileNumber,
            FeeType = feePayment.FeeType,
            PaymentMethod = feePayment.PaymentMethod,
            TransactionId = feePayment.TransactionId,
            ChequeNumber = feePayment.ChequeNumber,
            BankName = feePayment.BankName,
            AmountPaid = feePayment.AmountPaid,
            AmountInWords = ConvertAmountToWords(feePayment.AmountPaid),
            TotalFees = feeStructure.Amount,
            PreviousBalance = feePayment.PreviousBalance,
            RemainingBalance = feePayment.RemainingBalance,
            LateFee = feePayment.LateFee,
            Discount = feePayment.Discount,
            InstallmentNumber = feePayment.InstallmentNumber,
            NextDueDate = feePayment.NextDueDate,
            PaymentNotes = feePayment.PaymentNotes,
            GeneratedBy = feePayment.GeneratedBy,
            GenerationDateTime = DateTime.Now
        };
    }

    public async Task<decimal> GetPendingAmountAsync(int studentId, FeeType feeType)
    {
        return await _feePaymentRepository.GetPendingAmountByStudentAsync(studentId, feeType);
    }

    public async Task<decimal> GetTotalPaidAmountAsync(int studentId, FeeType feeType)
    {
        return await _feePaymentRepository.GetTotalPaidAmountByStudentAsync(studentId, feeType);
    }

    public async Task DeleteFeePaymentAsync(int id)
    {
        await _feePaymentRepository.DeleteAsync(id);
    }

    public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        var feePayments = await _feePaymentRepository.GetByDateRangeAsync(fromDate, toDate);
        return feePayments.ToList().Sum(f => f.AmountPaid);
    }

    public async Task<FeeAnalyticsDto> GetFeeAnalyticsAsync(string academicYear)
    {
        var allStudents = await _studentRepository.GetAllAsync();
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        // Calculate basic analytics
        var totalCollection = currentYearPayments.Sum(fp => fp.AmountPaid);

        // Calculate total pending correctly - take the LATEST payment's remaining balance per student per fee type
        var totalPending = currentYearPayments
            .GroupBy(fp => new { fp.StudentId, fp.FeeType })
            .Select(g => g.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance)
            .Sum();

        // Students with pending fees
        var studentsWithPending = currentYearPayments
            .GroupBy(fp => new { fp.StudentId, fp.FeeType })
            .Where(g => g.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance > 0)
            .Select(g => g.Key.StudentId)
            .Distinct()
            .Count();

        var totalStudents = allStudents.Count();
        var completionPercentage = totalStudents > 0 ? ((decimal)(totalStudents - studentsWithPending) / totalStudents) * 100 : 0;

        // Class-wise analysis
        var classWiseData = await GetClassWiseFeeAnalyticsAsync(academicYear);

        // Monthly collections
        var monthlyCollections = await GetMonthlyCollectionsAsync(academicYear);

        // Fee type analytics
        var feeTypeAnalytics = await GetFeeTypeAnalyticsAsync(academicYear);

        return new FeeAnalyticsDto
        {
            TotalCollection = totalCollection,
            PendingFees = totalPending,
            StudentsWithPendingFees = studentsWithPending,
            TotalStudents = totalStudents,
            CompletionPercentage = completionPercentage,
            ClassWisePendingFees = classWiseData,
            MonthlyCollections = monthlyCollections,
            FeeTypeAnalytics = feeTypeAnalytics
        };
    }

    public async Task<List<ClassWiseFeeDto>> GetClassWiseFeeAnalyticsAsync(string academicYear)
    {
        var allClasses = await _classRepository.GetAllAsync();
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        var classWiseData = new List<ClassWiseFeeDto>();

        foreach (var classItem in allClasses)
        {
            var classStudents = classItem.Students.ToList();
            var classPayments = currentYearPayments.Where(fp => classStudents.Any(s => s.Id == fp.StudentId)).ToList();

            // Calculate total pending correctly - take the LATEST payment's remaining balance per student per fee type
            var totalPending = classPayments
                .GroupBy(fp => new { fp.StudentId, fp.FeeType })
                .Select(g => g.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance)
                .Sum();

            var studentsWithPending = classPayments
                .GroupBy(fp => new { fp.StudentId, fp.FeeType })
                .Where(g => g.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance > 0)
                .Select(g => g.Key.StudentId)
                .Distinct()
                .Count();

            var totalCollected = classPayments.Sum(fp => fp.AmountPaid);
            var collectionPercentage = (totalCollected + totalPending) > 0 ?
                (totalCollected / (totalCollected + totalPending)) * 100 : 0;

            classWiseData.Add(new ClassWiseFeeDto
            {
                ClassId = classItem.Id,
                ClassName = classItem.Name,
                Section = classItem.Section ?? "",
                TotalStudents = classStudents.Count,
                StudentsWithPendingFees = studentsWithPending,
                TotalPendingAmount = totalPending,
                AveragePendingPerStudent = classStudents.Count > 0 ? totalPending / classStudents.Count : 0,
                CollectionPercentage = collectionPercentage
            });
        }

        return classWiseData.OrderBy(c => c.ClassName).ToList();
    }

    public async Task<List<MonthlyCollectionDto>> GetMonthlyCollectionsAsync(string academicYear)
    {
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        var monthlyData = currentYearPayments
            .GroupBy(fp => new { fp.PaymentDate.Year, fp.PaymentDate.Month })
            .Select(g => new MonthlyCollectionDto
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                MonthName = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy"),
                TotalCollection = g.Sum(fp => fp.AmountPaid),
                NumberOfPayments = g.Count(),
                AveragePaymentAmount = g.Average(fp => fp.AmountPaid),
                ByFeeType = g.GroupBy(fp => fp.FeeType)
                    .Select(ft => new FeeTypeCollectionDto
                    {
                        FeeType = ft.Key,
                        Amount = ft.Sum(fp => fp.AmountPaid),
                        PaymentCount = ft.Count()
                    }).ToList()
            })
            .OrderBy(m => m.Year)
            .ThenBy(m => m.Month)
            .ToList();

        return monthlyData;
    }

    public async Task<List<FeeTypeAnalyticsDto>> GetFeeTypeAnalyticsAsync(string academicYear)
    {
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        var feeTypeData = currentYearPayments
            .GroupBy(fp => fp.FeeType)
            .Select(g =>
            {
                var totalCollected = g.Sum(fp => fp.AmountPaid);

                // FIXED: Take only the latest payment's RemainingBalance per student
                // instead of summing all remaining balances (which double/triple counts)
                var totalPending = g
                    .GroupBy(fp => fp.StudentId)
                    .Select(studentGroup => studentGroup.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance)
                    .Sum();

                var studentsWithPending = g
                    .GroupBy(fp => fp.StudentId)
                    .Where(studentGroup => studentGroup.OrderByDescending(fp => fp.PaymentDate).First().RemainingBalance > 0)
                    .Count();

                var collectionRate = (totalCollected + totalPending) > 0 ? (totalCollected / (totalCollected + totalPending)) * 100 : 0;

                return new FeeTypeAnalyticsDto
                {
                    FeeType = g.Key,
                    FeeTypeName = g.Key.ToString(),
                    TotalCollected = totalCollected,
                    TotalPending = totalPending,
                    StudentsWithPending = studentsWithPending,
                    CollectionRate = collectionRate
                };
            })
            .OrderBy(ft => ft.FeeTypeName)
            .ToList();

        return feeTypeData;
    }

    public async Task<List<StudentFeeAnalyticsDto>> GetStudentsWithPendingFeesAsync(string academicYear, int? classId = null)
    {
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        var studentsWithPending = currentYearPayments
            .GroupBy(fp => fp.StudentId)
            .Select(g =>
            {
                var student = g.First().Student;
                if (classId.HasValue && student.ClassId != classId.Value)
                    return null;

                // FIXED: Calculate total pending using only the latest payment per fee type
                var latestPaymentsByFeeType = g
                    .GroupBy(fp => fp.FeeType)
                    .Select(feeTypeGroup => feeTypeGroup.OrderByDescending(fp => fp.PaymentDate).First())
                    .ToList();

                var totalPending = latestPaymentsByFeeType.Sum(fp => fp.RemainingBalance);

                // Only include students who actually have pending fees
                if (totalPending <= 0)
                    return null;

                var lastPayment = g.OrderByDescending(fp => fp.PaymentDate).FirstOrDefault();
                var daysSinceLastPayment = lastPayment != null ?
                    (DateTime.Now - lastPayment.PaymentDate).Days : 0;

                return new StudentFeeAnalyticsDto
                {
                    StudentId = student.Id,
                    StudentName = student.FullName,
                    ClassName = student.Class?.Name + " - " + student.Class?.Section,
                    StudentNumber = student.StudentNumber,
                    ParentPhone = student.ParentMobileNumber,
                    TotalPendingAmount = totalPending,
                    LastPaymentDate = lastPayment?.PaymentDate,
                    DaysSinceLastPayment = daysSinceLastPayment,
                    PendingByFeeType = latestPaymentsByFeeType
                        .Where(fp => fp.RemainingBalance > 0)
                        .Select(fp => new FeeTypePendingDto
                        {
                            FeeType = fp.FeeType,
                            PendingAmount = fp.RemainingBalance,
                            LastPaid = fp.PaymentDate,
                            OverdueDays = (DateTime.Now - fp.PaymentDate).Days
                        }).ToList()
                };
            })
            .Where(s => s != null)
            .OrderByDescending(s => s!.TotalPendingAmount)
            .Cast<StudentFeeAnalyticsDto>()
            .ToList();

        return studentsWithPending;
    }

    private static FeePaymentDto MapToDto(FeePayment feePayment)
    {
        return new FeePaymentDto
        {
            Id = feePayment.Id,
            ReceiptNumber = feePayment.ReceiptNumber,
            StudentId = feePayment.StudentId,
            StudentName = $"{feePayment.Student.FirstName} {feePayment.Student.Surname}",
            ClassName = feePayment.Student.Class != null
                ? $"{feePayment.Student.Class.Name} - {feePayment.Student.Class.Section}"
                : "No Class Assigned",
            StudentNumber = feePayment.Student.StudentNumber,
            ParentMobileNumber = feePayment.Student.ParentMobileNumber,
            FeeType = feePayment.FeeType,
            AmountPaid = feePayment.AmountPaid,
            PaymentMethod = feePayment.PaymentMethod,
            TransactionId = feePayment.TransactionId,
            ChequeNumber = feePayment.ChequeNumber,
            BankName = feePayment.BankName,
            PaymentNotes = feePayment.PaymentNotes,
            PreviousBalance = feePayment.PreviousBalance,
            RemainingBalance = feePayment.RemainingBalance,
            LateFee = feePayment.LateFee,
            Discount = feePayment.Discount,
            InstallmentNumber = feePayment.InstallmentNumber,
            NextDueDate = feePayment.NextDueDate,
            AcademicYear = feePayment.AcademicYear,
            GeneratedBy = feePayment.GeneratedBy,
            PaymentDate = feePayment.PaymentDate,
            AmountInWords = ConvertAmountToWords(feePayment.AmountPaid)
        };
    }

    private static string ConvertAmountToWords(decimal amount)
    {
        if (amount == 0) return "Zero Rupees Only";

        string[] ones = {"", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
        string[] teens = {"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        string[] tens = {"", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};

        int rupees = (int)amount;
        int paise = (int)((amount - rupees) * 100);

        string result = ConvertNumberToWords(rupees, ones, teens, tens);

        if (!string.IsNullOrEmpty(result))
        {
            result += " Rupee" + (rupees > 1 ? "s" : "");
        }

        if (paise > 0)
        {
            if (!string.IsNullOrEmpty(result))
                result += " and ";
            result += ConvertNumberToWords(paise, ones, teens, tens) + " Paise";
        }

        return result + " Only";
    }

    private static string ConvertNumberToWords(int number, string[] ones, string[] teens, string[] tens)
    {
        if (number == 0) return "";

        string result = "";

        if (number >= 10000000)
        {
            result += ConvertNumberToWords(number / 10000000, ones, teens, tens) + " Crore ";
            number %= 10000000;
        }

        if (number >= 100000)
        {
            result += ConvertNumberToWords(number / 100000, ones, teens, tens) + " Lakh ";
            number %= 100000;
        }

        if (number >= 1000)
        {
            result += ConvertNumberToWords(number / 1000, ones, teens, tens) + " Thousand ";
            number %= 1000;
        }

        if (number >= 100)
        {
            result += ones[number / 100] + " Hundred ";
            number %= 100;
        }

        if (number >= 20)
        {
            result += tens[number / 10];
            if (number % 10 > 0)
                result += " " + ones[number % 10];
        }
        else if (number >= 10)
        {
            result += teens[number - 10];
        }
        else if (number > 0)
        {
            result += ones[number];
        }

        return result.Trim();
    }
}