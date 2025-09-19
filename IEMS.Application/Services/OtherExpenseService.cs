using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;

namespace IEMS.Application.Services;

public class OtherExpenseService
{
    private readonly IOtherExpenseRepository _repository;

    public OtherExpenseService(IOtherExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<OtherExpenseDto>> GetAllAsync()
    {
        var expenses = await _repository.GetAllAsync();
        return expenses.Select(MapToDto);
    }

    public async Task<OtherExpenseDto?> GetByIdAsync(int id)
    {
        var expense = await _repository.GetByIdAsync(id);
        return expense != null ? MapToDto(expense) : null;
    }

    public async Task<IEnumerable<OtherExpenseDto>> GetByCategoryAsync(OtherExpenseCategory category)
    {
        var expenses = await _repository.GetByCategory(category);
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<OtherExpenseDto>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        var expenses = await _repository.GetByDateRangeAsync(fromDate, toDate);
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<OtherExpenseDto>> GetByYearAsync(int year)
    {
        var expenses = await _repository.GetByYearAsync(year);
        return expenses.Select(MapToDto);
    }

    public async Task<IEnumerable<OtherExpenseDto>> GetByMonthYearAsync(int month, int year)
    {
        var expenses = await _repository.GetByMonthYearAsync(month, year);
        return expenses.Select(MapToDto);
    }

    public async Task<decimal> GetTotalAmountByCategoryAsync(OtherExpenseCategory category)
    {
        return await _repository.GetTotalAmountByCategoryAsync(category);
    }

    public async Task<decimal> GetTotalAmountByYearAsync(int year)
    {
        return await _repository.GetTotalAmountByYearAsync(year);
    }

    public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await _repository.GetTotalAmountByDateRangeAsync(fromDate, toDate);
    }

    public async Task<decimal> GetTotalAmountByMonthYearAsync(int month, int year)
    {
        return await _repository.GetTotalAmountByMonthYearAsync(month, year);
    }

    public async Task<OtherExpenseDto> CreateAsync(OtherExpenseDto expenseDto)
    {
        var expense = MapToEntity(expenseDto);
        expense.CreatedAt = DateTime.UtcNow;
        expense.UpdatedAt = DateTime.UtcNow;

        var createdExpense = await _repository.AddAsync(expense);
        return MapToDto(createdExpense);
    }

    public async Task<OtherExpenseDto> UpdateAsync(OtherExpenseDto expenseDto)
    {
        var existingExpense = await _repository.GetByIdAsync(expenseDto.Id);
        if (existingExpense == null)
        {
            throw new ArgumentException("Other expense not found");
        }

        existingExpense.Category = expenseDto.Category;
        existingExpense.ExpenseType = expenseDto.ExpenseType;
        existingExpense.Description = expenseDto.Description;
        existingExpense.Amount = expenseDto.Amount;
        existingExpense.ExpenseDate = expenseDto.ExpenseDate;
        existingExpense.PaymentMethod = expenseDto.PaymentMethod;
        existingExpense.TransactionId = expenseDto.TransactionId;
        existingExpense.BankName = expenseDto.BankName;
        existingExpense.ChequeNumber = expenseDto.ChequeNumber;
        existingExpense.Notes = expenseDto.Notes;
        existingExpense.InvoiceNumber = expenseDto.InvoiceNumber;
        existingExpense.VendorName = expenseDto.VendorName;
        existingExpense.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(existingExpense);
        return MapToDto(existingExpense);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    private static OtherExpenseDto MapToDto(OtherExpense expense)
    {
        return new OtherExpenseDto
        {
            Id = expense.Id,
            Category = expense.Category,
            ExpenseType = expense.ExpenseType,
            Description = expense.Description,
            Amount = expense.Amount,
            ExpenseDate = expense.ExpenseDate,
            PaymentMethod = expense.PaymentMethod,
            TransactionId = expense.TransactionId,
            BankName = expense.BankName,
            ChequeNumber = expense.ChequeNumber,
            Notes = expense.Notes,
            InvoiceNumber = expense.InvoiceNumber,
            VendorName = expense.VendorName,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt
        };
    }

    private static OtherExpense MapToEntity(OtherExpenseDto dto)
    {
        return new OtherExpense
        {
            Id = dto.Id,
            Category = dto.Category,
            ExpenseType = dto.ExpenseType,
            Description = dto.Description,
            Amount = dto.Amount,
            ExpenseDate = dto.ExpenseDate,
            PaymentMethod = dto.PaymentMethod,
            TransactionId = dto.TransactionId,
            BankName = dto.BankName,
            ChequeNumber = dto.ChequeNumber,
            Notes = dto.Notes,
            InvoiceNumber = dto.InvoiceNumber,
            VendorName = dto.VendorName,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt
        };
    }
}