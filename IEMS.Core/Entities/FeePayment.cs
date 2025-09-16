using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class FeePayment
{
    public int Id { get; set; }
    public string ReceiptNumber { get; set; } = string.Empty;
    public int StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public FeeType FeeType { get; set; }
    public decimal AmountPaid { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? ChequeNumber { get; set; }
    public string? BankName { get; set; }
    public string? PaymentNotes { get; set; }
    public decimal PreviousBalance { get; set; }
    public decimal RemainingBalance { get; set; }
    public decimal LateFee { get; set; }
    public decimal Discount { get; set; }
    public int? InstallmentNumber { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public string GeneratedBy { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; } = DateTime.Now;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}