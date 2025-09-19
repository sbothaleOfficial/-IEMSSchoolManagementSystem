using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class OtherExpense
{
    public int Id { get; set; }
    public OtherExpenseCategory Category { get; set; }
    public string ExpenseType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? BankName { get; set; }
    public string? ChequeNumber { get; set; }
    public string? Notes { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? VendorName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public string FormattedExpenseDate => ExpenseDate.ToString("dd/MM/yyyy");
    public string CategoryDisplay => Category.ToString().Replace("_", " ");
}