using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class Vehicle
{
    public int Id { get; set; }
    public string VehicleNumber { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
    public string DriverName { get; set; } = string.Empty;
    public string DriverPhone { get; set; } = string.Empty;
    public string Route { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual ICollection<TransportExpense> TransportExpenses { get; set; } = new List<TransportExpense>();
}