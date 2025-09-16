using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class TransportExpenseDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public ExpenseCategory Category { get; set; }
    public string CategoryName => Category.ToString();
    public FuelType? FuelType { get; set; }
    public string FuelTypeName => FuelType?.ToString() ?? "";
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public decimal PricePerUnit { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CreateTransportExpenseDto
{
    public int VehicleId { get; set; }
    public ExpenseCategory Category { get; set; }
    public FuelType? FuelType { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
}

public class UpdateTransportExpenseDto
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public ExpenseCategory Category { get; set; }
    public FuelType? FuelType { get; set; }
    public decimal Amount { get; set; }
    public decimal Quantity { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string InvoiceNumber { get; set; } = string.Empty;
}