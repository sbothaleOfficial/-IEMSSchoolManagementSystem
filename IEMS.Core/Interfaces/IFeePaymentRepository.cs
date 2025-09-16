using IEMS.Core.Entities;
using IEMS.Core.Enums;

namespace IEMS.Core.Interfaces;

public interface IFeePaymentRepository
{
    Task<IEnumerable<FeePayment>> GetAllAsync();
    Task<FeePayment?> GetByIdAsync(int id);
    Task<FeePayment?> GetByReceiptNumberAsync(string receiptNumber);
    Task<IEnumerable<FeePayment>> GetByStudentIdAsync(int studentId);
    Task<IEnumerable<FeePayment>> GetByStudentIdAndFeeTypeAsync(int studentId, FeeType feeType);
    Task<IEnumerable<FeePayment>> GetByAcademicYearAsync(string academicYear);
    Task<IEnumerable<FeePayment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate);
    Task<FeePayment> AddAsync(FeePayment feePayment);
    Task UpdateAsync(FeePayment feePayment);
    Task DeleteAsync(int id);
    Task<string> GenerateReceiptNumberAsync();
    Task<decimal> GetTotalPaidAmountByStudentAsync(int studentId, FeeType feeType);
    Task<decimal> GetPendingAmountByStudentAsync(int studentId, FeeType feeType);
}