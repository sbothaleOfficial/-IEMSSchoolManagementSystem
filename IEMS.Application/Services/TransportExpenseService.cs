using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;

namespace IEMS.Application.Services;

public class TransportExpenseService
{
    private readonly ITransportExpenseRepository _expenseRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public TransportExpenseService(ITransportExpenseRepository expenseRepository, IVehicleRepository vehicleRepository)
    {
        _expenseRepository = expenseRepository;
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<TransportExpenseDto>> GetAllExpensesAsync()
    {
        var expenses = await _expenseRepository.GetAllExpensesAsync();
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<TransportExpenseDto>> GetExpensesByVehicleIdAsync(int vehicleId)
    {
        var expenses = await _expenseRepository.GetExpensesByVehicleIdAsync(vehicleId);
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<TransportExpenseDto>> GetExpensesByCategoryAsync(ExpenseCategory category)
    {
        var expenses = await _expenseRepository.GetExpensesByCategoryAsync(category);
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<TransportExpenseDto>> GetExpensesByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        var expenses = await _expenseRepository.GetExpensesByDateRangeAsync(fromDate, toDate);
        return expenses.Select(MapToDto);
    }

    public async Task<TransportExpenseDto?> GetExpenseByIdAsync(int id)
    {
        var expense = await _expenseRepository.GetExpenseByIdAsync(id);
        return expense != null ? MapToDto(expense) : null;
    }

    public async Task<TransportExpenseDto> CreateExpenseAsync(CreateTransportExpenseDto createDto)
    {
        // Validate vehicle exists
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(createDto.VehicleId);
        if (vehicle == null)
        {
            throw new InvalidOperationException($"Vehicle with ID {createDto.VehicleId} not found.");
        }

        // Validate quantity for price calculation
        if (createDto.Quantity <= 0)
        {
            throw new InvalidOperationException("Quantity must be greater than zero for price calculation.");
        }

        var expense = new TransportExpense
        {
            VehicleId = createDto.VehicleId,
            Category = createDto.Category,
            FuelType = createDto.FuelType,
            Amount = createDto.Amount,
            Quantity = createDto.Quantity,
            ExpenseDate = createDto.ExpenseDate,
            DriverName = createDto.DriverName,
            Description = createDto.Description,
            InvoiceNumber = createDto.InvoiceNumber
        };

        var createdExpense = await _expenseRepository.CreateExpenseAsync(expense);

        // Reload with navigation properties
        var expenseWithVehicle = await _expenseRepository.GetExpenseByIdAsync(createdExpense.Id);
        return MapToDto(expenseWithVehicle!);
    }

    public async Task<TransportExpenseDto> UpdateExpenseAsync(UpdateTransportExpenseDto updateDto)
    {
        var existingExpense = await _expenseRepository.GetExpenseByIdAsync(updateDto.Id);
        if (existingExpense == null)
        {
            throw new InvalidOperationException($"Expense with ID {updateDto.Id} not found.");
        }

        // Validate vehicle exists
        var vehicle = await _vehicleRepository.GetVehicleByIdAsync(updateDto.VehicleId);
        if (vehicle == null)
        {
            throw new InvalidOperationException($"Vehicle with ID {updateDto.VehicleId} not found.");
        }

        // Validate quantity for price calculation
        if (updateDto.Quantity <= 0)
        {
            throw new InvalidOperationException("Quantity must be greater than zero for price calculation.");
        }

        existingExpense.VehicleId = updateDto.VehicleId;
        existingExpense.Category = updateDto.Category;
        existingExpense.FuelType = updateDto.FuelType;
        existingExpense.Amount = updateDto.Amount;
        existingExpense.Quantity = updateDto.Quantity;
        existingExpense.ExpenseDate = updateDto.ExpenseDate;
        existingExpense.DriverName = updateDto.DriverName;
        existingExpense.Description = updateDto.Description;
        existingExpense.InvoiceNumber = updateDto.InvoiceNumber;

        var updatedExpense = await _expenseRepository.UpdateExpenseAsync(existingExpense);

        // Reload with navigation properties
        var expenseWithVehicle = await _expenseRepository.GetExpenseByIdAsync(updatedExpense.Id);
        return MapToDto(expenseWithVehicle!);
    }

    public async Task DeleteExpenseAsync(int id)
    {
        var expense = await _expenseRepository.GetExpenseByIdAsync(id);
        if (expense == null)
        {
            throw new InvalidOperationException($"Expense with ID {id} not found.");
        }

        await _expenseRepository.DeleteExpenseAsync(id);
    }

    public async Task<decimal> GetTotalExpensesByVehicleAsync(int vehicleId)
    {
        return await _expenseRepository.GetTotalExpensesByVehicleAsync(vehicleId);
    }

    public async Task<decimal> GetTotalExpensesByCategoryAsync(ExpenseCategory category)
    {
        return await _expenseRepository.GetTotalExpensesByCategoryAsync(category);
    }

    public async Task<decimal> GetMonthlyExpensesByVehicleAsync(int vehicleId, int year, int month)
    {
        return await _expenseRepository.GetMonthlyExpensesByVehicleAsync(vehicleId, year, month);
    }

    private static TransportExpenseDto MapToDto(TransportExpense expense)
    {
        return new TransportExpenseDto
        {
            Id = expense.Id,
            VehicleId = expense.VehicleId,
            VehicleNumber = expense.Vehicle?.VehicleNumber ?? "",
            Category = expense.Category,
            FuelType = expense.FuelType,
            Amount = expense.Amount,
            Quantity = expense.Quantity,
            PricePerUnit = expense.PricePerUnit,
            ExpenseDate = expense.ExpenseDate,
            DriverName = expense.DriverName,
            Description = expense.Description,
            InvoiceNumber = expense.InvoiceNumber,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt
        };
    }
}