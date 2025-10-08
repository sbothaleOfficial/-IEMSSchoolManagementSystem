using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class FeeReceiptDto
{
    // School information loaded dynamically from System Settings
    public string SchoolName { get; set; } = string.Empty;
    public string SchoolAddress { get; set; } = string.Empty;
    public string SchoolPhone { get; set; } = string.Empty;
    public string SchoolEmail { get; set; } = string.Empty;

    public string ReceiptNumber { get; set; } = string.Empty;
    public DateTime ReceiptDate { get; set; }
    public string AcademicYear { get; set; } = string.Empty;

    public string StudentName { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string ParentPhone { get; set; } = string.Empty;

    public FeeType FeeType { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? ChequeNumber { get; set; }
    public string? BankName { get; set; }

    public decimal AmountPaid { get; set; }
    public string AmountInWords { get; set; } = string.Empty;
    public decimal TotalFees { get; set; }
    public decimal PreviousBalance { get; set; }
    public decimal RemainingBalance { get; set; }
    public decimal LateFee { get; set; }
    public decimal Discount { get; set; }
    public int? InstallmentNumber { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string? PaymentNotes { get; set; }

    public string GeneratedBy { get; set; } = string.Empty;
    public DateTime GenerationDateTime { get; set; } = DateTime.Now;

    public string TermsAndConditions { get; set; } =
        "a. Fees once paid will not be refunded\n" +
        "b. Please keep this receipt for future reference\n" +
        "c. For any queries, contact school office";
}