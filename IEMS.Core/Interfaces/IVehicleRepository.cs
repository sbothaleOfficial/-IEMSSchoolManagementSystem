using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
    Task<Vehicle?> GetVehicleByIdAsync(int id);
    Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
    Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    Task DeleteVehicleAsync(int id);
    Task<bool> VehicleNumberExistsAsync(string vehicleNumber, int? excludeId = null);
}