using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class FeePaymentDto
{
    public int Id { get; set; }
    public string ReceiptNumber { get; set; } = string.Empty;
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string ParentMobileNumber { get; set; } = string.Empty;
    public FeeType FeeType { get; set; }
    public string FeeTypeDisplay => FeeType.ToString();
    public decimal AmountPaid { get; set; }
    public string AmountPaidFormatted => $"₹{AmountPaid:F2}";
    public PaymentMethod PaymentMethod { get; set; }
    public string PaymentMethodDisplay => PaymentMethod.ToString();
    public string? TransactionId { get; set; }
    public string? ChequeNumber { get; set; }
    public string? BankName { get; set; }
    public string? PaymentNotes { get; set; }
    public decimal PreviousBalance { get; set; }
    public decimal RemainingBalance { get; set; }
    public string RemainingBalanceFormatted => $"₹{RemainingBalance:F2}";
    public decimal LateFee { get; set; }
    public decimal Discount { get; set; }
    public int? InstallmentNumber { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string? NextDueDateFormatted => NextDueDate?.ToString("dd/MM/yyyy");
    public string AcademicYear { get; set; } = string.Empty;
    public string GeneratedBy { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
    public string PaymentDateFormatted => PaymentDate.ToString("dd/MM/yyyy");
    public string AmountInWords { get; set; } = string.Empty;
}

public class CreateFeePaymentDto
{
    public int StudentId { get; set; }
    public FeeType FeeType { get; set; }
    public decimal AmountPaid { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? ChequeNumber { get; set; }
    public string? BankName { get; set; }
    public string? PaymentNotes { get; set; }
    public decimal LateFee { get; set; }
    public decimal Discount { get; set; }
    public int? InstallmentNumber { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public string GeneratedBy { get; set; } = string.Empty;
}