using IEMS.Core.Entities;

namespace IEMS.Core.Interfaces;

public interface IElectricityBillRepository : IRepository<ElectricityBill>
{
    Task<ElectricityBill?> GetByBillNumberAsync(string billNumber);
    Task<ElectricityBill?> GetByMonthYearAsync(int month, int year);
    Task<IEnumerable<ElectricityBill>> GetUnpaidBillsAsync();
    Task<IEnumerable<ElectricityBill>> GetBillsByYearAsync(int year);
    Task<IEnumerable<ElectricityBill>> GetBillsByDateRangeAsync(DateTime fromDate, DateTime toDate);
    Task<decimal> GetTotalAmountByYearAsync(int year);
    Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate);
}