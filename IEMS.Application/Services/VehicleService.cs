using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;

namespace IEMS.Application.Services;

public class VehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ITransportExpenseRepository _expenseRepository;

    public VehicleService(IVehicleRepository vehicleRepository, ITransportExpenseRepository expenseRepository)
    {
        _vehicleRepository = vehicleRepository;
        _expenseRepository = expenseRepository;
    }

    public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
    {
        var vehicles = await _vehicleRepository.GetAllVehiclesAsync();
        var vehicleDtos = new List<VehicleDto>();

        foreach (var vehicle in vehicles)
        {
            var totalExpenses = await _expenseRepository.GetTotalExpensesByVehicleAsync(vehicle.Id);

            vehicleDtos.Add(new VehicleDto
            {
                Id = vehicle.Id,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                DriverName = vehicle.DriverName,
                DriverPhone = vehicle.DriverPhone,
                Route = vehicle.Route,
                CreatedAt = vehicle.CreatedAt,
                UpdatedAt = vehicle.UpdatedAt,
                ExpenseCount = vehicle.TransportExpenses.Count,
                TotalExpenses = totalExpenses
            });
        }

        return vehicleDtos;
    }

    public async Task<VehicleDto?> GetVehicleByIdAsync(int id)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
        if (vehicle == null) return null;

        var totalExpenses = await _expenseRepository.GetTotalExpensesByVehicleAsync(vehicle.Id);

        return new VehicleDto
        {
            Id = vehicle.Id,
            VehicleNumber = vehicle.VehicleNumber,
            VehicleType = vehicle.VehicleType,
            DriverName = vehicle.DriverName,
            DriverPhone = vehicle.DriverPhone,
            Route = vehicle.Route,
            CreatedAt = vehicle.CreatedAt,
            UpdatedAt = vehicle.UpdatedAt,
            ExpenseCount = vehicle.TransportExpenses.Count,
            TotalExpenses = totalExpenses
        };
    }

    public async Task<VehicleDto> CreateVehicleAsync(CreateVehicleDto createDto)
    {
        // Validate vehicle number uniqueness
        var vehicleNumberExists = await _vehicleRepository.VehicleNumberExistsAsync(createDto.VehicleNumber);
        if (vehicleNumberExists)
        {
            throw new InvalidOperationException($"Vehicle number '{createDto.VehicleNumber}' already exists.");
        }

        var vehicle = new Vehicle
        {
            VehicleNumber = createDto.VehicleNumber,
            VehicleType = createDto.VehicleType,
            DriverName = createDto.DriverName,
            DriverPhone = createDto.DriverPhone,
            Route = createDto.Route
        };

        var createdVehicle = await _vehicleRepository.CreateVehicleAsync(vehicle);

        return new VehicleDto
        {
            Id = createdVehicle.Id,
            VehicleNumber = createdVehicle.VehicleNumber,
            VehicleType = createdVehicle.VehicleType,
            DriverName = createdVehicle.DriverName,
            DriverPhone = createdVehicle.DriverPhone,
            Route = createdVehicle.Route,
            CreatedAt = createdVehicle.CreatedAt,
            UpdatedAt = createdVehicle.UpdatedAt,
            ExpenseCount = 0,
            TotalExpenses = 0
        };
    }

    public async Task<VehicleDto> UpdateVehicleAsync(UpdateVehicleDto updateDto)
    {
        var existingVehicle = await _vehicleRepository.GetVehicleByIdAsync(updateDto.Id);
        if (existingVehicle == null)
        {
            throw new InvalidOperationException($"Vehicle with ID {updateDto.Id} not found.");
        }

        // Validate vehicle number uniqueness (excluding current vehicle)
        var vehicleNumberExists = await _vehicleRepository.VehicleNumberExistsAsync(updateDto.VehicleNumber, updateDto.Id);
        if (vehicleNumberExists)
        {
            throw new InvalidOperationException($"Vehicle number '{updateDto.VehicleNumber}' already exists.");
        }

        existingVehicle.VehicleNumber = updateDto.VehicleNumber;
        existingVehicle.VehicleType = updateDto.VehicleType;
        existingVehicle.DriverName = updateDto.DriverName;
        existingVehicle.DriverPhone = updateDto.DriverPhone;
        existingVehicle.Route = updateDto.Route;

        var updatedVehicle = await _vehicleRepository.UpdateVehicleAsync(existingVehicle);
        var totalExpenses = await _expenseRepository.GetTotalExpensesByVehicleAsync(updatedVehicle.Id);

        return new VehicleDto
        {
            Id = updatedVehicle.Id,
            VehicleNumber = updatedVehicle.VehicleNumber,
            VehicleType = updatedVehicle.VehicleType,
            DriverName = updatedVehicle.DriverName,
            DriverPhone = updatedVehicle.DriverPhone,
            Route = updatedVehicle.Route,
            CreatedAt = updatedVehicle.CreatedAt,
            UpdatedAt = updatedVehicle.UpdatedAt,
            ExpenseCount = updatedVehicle.TransportExpenses.Count,
            TotalExpenses = totalExpenses
        };
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
        if (vehicle == null)
        {
            throw new InvalidOperationException($"Vehicle with ID {id} not found.");
        }

        // Check if vehicle has expenses
        if (vehicle.TransportExpenses.Any())
        {
            throw new InvalidOperationException("Cannot delete vehicle with existing expenses. Please delete all expenses first.");
        }

        await _vehicleRepository.DeleteVehicleAsync(id);
    }

    public async Task<bool> VehicleNumberExistsAsync(string vehicleNumber, int? excludeId = null)
    {
        return await _vehicleRepository.VehicleNumberExistsAsync(vehicleNumber, excludeId);
    }
}