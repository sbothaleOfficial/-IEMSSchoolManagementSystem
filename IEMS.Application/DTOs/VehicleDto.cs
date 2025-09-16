using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class VehicleDto
{
    public int Id { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public string VehicleTypeName => VehicleType.ToString();
    public string DriverName { get; set; } = string.Empty;
    public string DriverPhone { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int ExpenseCount { get; set; }
    public decimal TotalExpenses { get; set; }
}

public class CreateVehicleDto
{
    public string VehicleNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string DriverPhone { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
}

public class UpdateVehicleDto
{
    public int Id { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string DriverPhone { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
}