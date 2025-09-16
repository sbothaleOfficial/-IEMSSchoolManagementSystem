using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IEMS.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
    {
        return await _context.Vehicles
            .Include(v => v.TransportExpenses)
            .OrderBy(v => v.VehicleNumber)
            .ToListAsync();
    }

    public async Task<Vehicle?> GetVehicleByIdAsync(int id)
    {
        return await _context.Vehicles
            .Include(v => v.TransportExpenses)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
    {
        vehicle.CreatedAt = DateTime.UtcNow;
        vehicle.UpdatedAt = DateTime.UtcNow;

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
    {
        vehicle.UpdatedAt = DateTime.UtcNow;

        _context.Entry(vehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> VehicleNumberExistsAsync(string vehicleNumber, int? excludeId = null)
    {
        return await _context.Vehicles
            .AnyAsync(v => v.VehicleNumber == vehicleNumber && (excludeId == null || v.Id != excludeId));
    }
}