using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class TransportExpense
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public ExpenseCategory Category { get; set; }
    public FuelType? FuelType { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public decimal PricePerUnit => Quantity != 0 ? Amount / Quantity : 0;
    public DateTime ExpenseDate { get; set; } = DateTime.Today;
    public string DriverName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Vehicle Vehicle { get; set; } = null!;
}