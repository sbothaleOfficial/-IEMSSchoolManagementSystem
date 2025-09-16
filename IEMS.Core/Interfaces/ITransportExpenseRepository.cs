using IEMS.Core.Entities;
using IEMS.Core.Enums;

namespace IEMS.Core.Interfaces;

public interface ITransportExpenseRepository
{
    Task<IEnumerable<TransportExpense>> GetAllExpensesAsync();
    Task<IEnumerable<TransportExpense>> GetExpensesByVehicleIdAsync(int vehicleId);
    Task<IEnumerable<TransportExpense>> GetExpensesByCategoryAsync(ExpenseCategory category);
    Task<IEnumerable<TransportExpense>> GetExpensesByDateRangeAsync(DateTime fromDate, DateTime toDate);
    Task<TransportExpense?> GetExpenseByIdAsync(int id);
    Task<TransportExpense> CreateExpenseAsync(TransportExpense expense);
    Task<TransportExpense> UpdateExpenseAsync(TransportExpense expense);
    Task DeleteExpenseAsync(int id);
    Task<decimal> GetTotalExpensesByVehicleAsync(int vehicleId);
    Task<decimal> GetTotalExpensesByCategoryAsync(ExpenseCategory category);
    Task<decimal> GetMonthlyExpensesByVehicleAsync(int vehicleId, int year, int month);
}