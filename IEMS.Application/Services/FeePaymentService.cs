using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class FeePaymentService
{
    private readonly IFeePaymentRepository _feePaymentRepository;
    private readonly IFeeStructureRepository _feeStructureRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public FeePaymentService(
        IFeePaymentRepository feePaymentRepository,
        IFeeStructureRepository feeStructureRepository,
        IStudentRepository studentRepository,
        IClassRepository classRepository)
    {
        _feePaymentRepository = feePaymentRepository;
        _feeStructureRepository = feeStructureRepository;
        _studentRepository = studentRepository;
        _classRepository = classRepository;
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
        var effectiveAmount = createDto.AmountPaid - createDto.Discount + createDto.LateFee;
        var newRemainingBalance = Math.Max(0, previousBalance + totalFeeAmount - effectiveAmount);

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
            PaymentNotes = createDto.PaymentNotes,
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

        return new FeeReceiptDto
        {
            ReceiptNumber = feePayment.ReceiptNumber,
            ReceiptDate = feePayment.PaymentDate,
            AcademicYear = feePayment.AcademicYear,
            StudentName = $"{feePayment.Student.FirstName} {feePayment.Student.Surname}",
            ClassName = feePayment.Student.Class?.Name + " - " + feePayment.Student.Class?.Section,
            StudentNumber = feePayment.Student.StudentNumber,
            ParentPhone = feePayment.Student.ParentMobileNumber,
            FeeType = feePayment.FeeType,
            PaymentMethod = feePayment.PaymentMethod,
            TransactionId = feePayment.TransactionId,
            ChequeNumber = feePayment.ChequeNumber,
            BankName = feePayment.BankName,
            AmountPaid = feePayment.AmountPaid,
            AmountInWords = ConvertAmountToWords(feePayment.AmountPaid),
            TotalFees = feeStructure?.Amount ?? 0,
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
        var totalPending = currentYearPayments.Sum(fp => fp.RemainingBalance);

        // Students with pending fees
        var studentsWithPending = currentYearPayments
            .Where(fp => fp.RemainingBalance > 0)
            .Select(fp => fp.StudentId)
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

            var studentsWithPending = classPayments
                .Where(fp => fp.RemainingBalance > 0)
                .Select(fp => fp.StudentId)
                .Distinct()
                .Count();

            var totalPending = classPayments.Sum(fp => fp.RemainingBalance);
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
                var totalPending = g.Sum(fp => fp.RemainingBalance);
                var studentsWithPending = g.Where(fp => fp.RemainingBalance > 0).Select(fp => fp.StudentId).Distinct().Count();
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

    public async Task<List<StudentFeeStatusDto>> GetStudentsWithPendingFeesAsync(string academicYear, int? classId = null)
    {
        var allFeePayments = await _feePaymentRepository.GetAllAsync();
        var currentYearPayments = allFeePayments.Where(fp => fp.AcademicYear == academicYear).ToList();

        var studentsWithPending = currentYearPayments
            .Where(fp => fp.RemainingBalance > 0)
            .GroupBy(fp => fp.StudentId)
            .Select(g =>
            {
                var student = g.First().Student;
                if (classId.HasValue && student.ClassId != classId.Value)
                    return null;

                var totalPending = g.Sum(fp => fp.RemainingBalance);
                var lastPayment = g.OrderByDescending(fp => fp.PaymentDate).FirstOrDefault();
                var daysSinceLastPayment = lastPayment != null ?
                    (DateTime.Now - lastPayment.PaymentDate).Days : 0;

                return new StudentFeeStatusDto
                {
                    StudentId = student.Id,
                    StudentName = student.FullName,
                    ClassName = student.Class?.Name + " - " + student.Class?.Section,
                    StudentNumber = student.StudentNumber,
                    ParentPhone = student.ParentMobileNumber,
                    TotalPendingAmount = totalPending,
                    LastPaymentDate = lastPayment?.PaymentDate,
                    DaysSinceLastPayment = daysSinceLastPayment,
                    PendingByFeeType = g.GroupBy(fp => fp.FeeType)
                        .Where(ft => ft.Sum(fp => fp.RemainingBalance) > 0)
                        .Select(ft => new FeeTypePendingDto
                        {
                            FeeType = ft.Key,
                            PendingAmount = ft.Sum(fp => fp.RemainingBalance),
                            LastPaid = ft.OrderByDescending(fp => fp.PaymentDate).FirstOrDefault()?.PaymentDate,
                            OverdueDays = ft.OrderByDescending(fp => fp.PaymentDate).FirstOrDefault()?.PaymentDate != null ?
                                (DateTime.Now - ft.OrderByDescending(fp => fp.PaymentDate).First().PaymentDate).Days : 0
                        }).ToList()
                };
            })
            .Where(s => s != null)
            .OrderByDescending(s => s!.TotalPendingAmount)
            .Cast<StudentFeeStatusDto>()
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
            ClassName = feePayment.Student.Class?.Name + " - " + feePayment.Student.Class?.Section ?? "",
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