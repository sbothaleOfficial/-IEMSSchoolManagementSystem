using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IEMS.Infrastructure.Repositories;

public class FeePaymentRepository : IFeePaymentRepository
{
    private readonly ApplicationDbContext _context;

    public FeePaymentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeePayment>> GetAllAsync()
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .OrderByDescending(fp => fp.PaymentDate)
            .ToListAsync();
    }

    public async Task<FeePayment?> GetByIdAsync(int id)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .FirstOrDefaultAsync(fp => fp.Id == id);
    }

    public async Task<FeePayment?> GetByReceiptNumberAsync(string receiptNumber)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .FirstOrDefaultAsync(fp => fp.ReceiptNumber == receiptNumber);
    }

    public async Task<IEnumerable<FeePayment>> GetByStudentIdAsync(int studentId)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .Where(fp => fp.StudentId == studentId)
            .OrderByDescending(fp => fp.PaymentDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeePayment>> GetByStudentIdAndFeeTypeAsync(int studentId, FeeType feeType)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .Where(fp => fp.StudentId == studentId && fp.FeeType == feeType)
            .OrderByDescending(fp => fp.PaymentDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeePayment>> GetByAcademicYearAsync(string academicYear)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .Where(fp => fp.AcademicYear == academicYear)
            .OrderByDescending(fp => fp.PaymentDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeePayment>> GetByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await _context.FeePayments
            .Include(fp => fp.Student)
                .ThenInclude(s => s.Class)
            .Where(fp => fp.PaymentDate.Date >= fromDate.Date && fp.PaymentDate.Date <= toDate.Date)
            .OrderByDescending(fp => fp.PaymentDate)
            .ToListAsync();
    }

    public async Task<FeePayment> AddAsync(FeePayment feePayment)
    {
        _context.FeePayments.Add(feePayment);
        await _context.SaveChangesAsync();
        return feePayment;
    }

    public async Task UpdateAsync(FeePayment feePayment)
    {
        feePayment.UpdatedAt = DateTime.UtcNow;
        _context.FeePayments.Update(feePayment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var feePayment = await GetByIdAsync(id);
        if (feePayment != null)
        {
            _context.FeePayments.Remove(feePayment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<string> GenerateReceiptNumberAsync()
    {
        var lastReceipt = await _context.FeePayments
            .OrderByDescending(fp => fp.Id)
            .FirstOrDefaultAsync();

        int nextNumber = 1;
        if (lastReceipt != null && int.TryParse(lastReceipt.ReceiptNumber, out int lastNumber))
        {
            nextNumber = lastNumber + 1;
        }

        return nextNumber.ToString("D6");
    }

    public async Task<decimal> GetTotalPaidAmountByStudentAsync(int studentId, FeeType feeType)
    {
        var payments = await _context.FeePayments
            .Where(fp => fp.StudentId == studentId && fp.FeeType == feeType)
            .ToListAsync();

        return payments.Sum(fp => fp.AmountPaid);
    }

    public async Task<decimal> GetPendingAmountByStudentAsync(int studentId, FeeType feeType)
    {
        var lastPayment = await _context.FeePayments
            .Where(fp => fp.StudentId == studentId && fp.FeeType == feeType)
            .OrderByDescending(fp => fp.PaymentDate)
            .FirstOrDefaultAsync();

        return lastPayment?.RemainingBalance ?? 0;
    }
}