using IEMS.Core.Entities;
using IEMS.Core.Enums;

namespace IEMS.Core.Interfaces;

public interface IOtherExpenseRepository : IRepository<OtherExpense>
{
    Task<IEnumerable<OtherExpense>> GetByCategory(OtherExpenseCategory category);
    Task<IEnumerable<OtherExpense>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
    Task<IEnumerable<OtherExpense>> GetByYearAsync(int year);
    Task<IEnumerable<OtherExpense>> GetByMonthYearAsync(int month, int year);
    Task<decimal> GetTotalAmountByCategoryAsync(OtherExpenseCategory category);
    Task<decimal> GetTotalAmountByYearAsync(int year);
    Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate);
    Task<decimal> GetTotalAmountByMonthYearAsync(int month, int year);
}