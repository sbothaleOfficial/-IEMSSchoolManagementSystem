using Microsoft.EntityFrameworkCore;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Core.Enums;
using IEMS.Infrastructure.Data;

namespace IEMS.Infrastructure.Repositories;

public class OtherExpenseRepository : IOtherExpenseRepository
{
    private readonly ApplicationDbContext _context;

    public OtherExpenseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OtherExpense?> GetByIdAsync(int id)
    {
        return await _context.OtherExpenses.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<OtherExpense>> GetAllAsync()
    {
        return await _context.OtherExpenses.OrderByDescending(e => e.ExpenseDate).ToListAsync();
    }

    public async Task<OtherExpense> AddAsync(OtherExpense entity)
    {
        _context.OtherExpenses.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(OtherExpense entity)
    {
        _context.OtherExpenses.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var expense = await _context.OtherExpenses.FindAsync(id);
        if (expense != null)
        {
            _context.OtherExpenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<OtherExpense>> GetByCategory(OtherExpenseCategory category)
    {
        return await _context.OtherExpenses
            .Where(e => e.Category == category)
            .OrderByDescending(e => e.ExpenseDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<OtherExpense>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate >= fromDate && e.ExpenseDate <= toDate)
            .OrderByDescending(e => e.ExpenseDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<OtherExpense>> GetByYearAsync(int year)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate.Year == year)
            .OrderByDescending(e => e.ExpenseDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<OtherExpense>> GetByMonthYearAsync(int month, int year)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate.Month == month && e.ExpenseDate.Year == year)
            .OrderByDescending(e => e.ExpenseDate)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalAmountByCategoryAsync(OtherExpenseCategory category)
    {
        return await _context.OtherExpenses
            .Where(e => e.Category == category)
            .SumAsync(e => e.Amount);
    }

    public async Task<decimal> GetTotalAmountByYearAsync(int year)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate.Year == year)
            .SumAsync(e => e.Amount);
    }

    public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate >= fromDate && e.ExpenseDate <= toDate)
            .SumAsync(e => e.Amount);
    }

    public async Task<decimal> GetTotalAmountByMonthYearAsync(int month, int year)
    {
        return await _context.OtherExpenses
            .Where(e => e.ExpenseDate.Month == month && e.ExpenseDate.Year == year)
            .SumAsync(e => e.Amount);
    }
}