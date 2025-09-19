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