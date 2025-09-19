using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;

namespace IEMS.Application.Services;

public class ElectricityBillService
{
    private readonly IElectricityBillRepository _repository;

    public ElectricityBillService(IElectricityBillRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ElectricityBillDto>> GetAllAsync()
    {
        var bills = await _repository.GetAllAsync();
        return bills.Select(MapToDto);
    }

    public async Task<ElectricityBillDto?> GetByIdAsync(int id)
    {
        var bill = await _repository.GetByIdAsync(id);
        return bill != null ? MapToDto(bill) : null;
    }

    public async Task<ElectricityBillDto?> GetByBillNumberAsync(string billNumber)
    {
        var bill = await _repository.GetByBillNumberAsync(billNumber);
        return bill != null ? MapToDto(bill) : null;
    }

    public async Task<ElectricityBillDto?> GetByMonthYearAsync(int month, int year)
    {
        var bill = await _repository.GetByMonthYearAsync(month, year);
        return bill != null ? MapToDto(bill) : null;
    }

    public async Task<IEnumerable<ElectricityBillDto>> GetUnpaidBillsAsync()
    {
        var bills = await _repository.GetUnpaidBillsAsync();
        return bills.Select(MapToDto);
    }

    public async Task<IEnumerable<ElectricityBillDto>> GetBillsByYearAsync(int year)
    {
        var bills = await _repository.GetBillsByYearAsync(year);
        return bills.Select(MapToDto);
    }

    public async Task<IEnumerable<ElectricityBillDto>> GetBillsByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        var bills = await _repository.GetBillsByDateRangeAsync(fromDate, toDate);
        return bills.Select(MapToDto);
    }

    public async Task<decimal> GetTotalAmountByYearAsync(int year)
    {
        return await _repository.GetTotalAmountByYearAsync(year);
    }

    public async Task<decimal> GetTotalAmountByDateRangeAsync(DateTime fromDate, DateTime toDate)
    {
        return await _repository.GetTotalAmountByDateRangeAsync(fromDate, toDate);
    }

    public async Task<ElectricityBillDto> CreateAsync(ElectricityBillDto billDto)
    {
        var bill = MapToEntity(billDto);
        bill.CreatedAt = DateTime.UtcNow;
        bill.UpdatedAt = DateTime.UtcNow;

        var createdBill = await _repository.AddAsync(bill);
        return MapToDto(createdBill);
    }

    public async Task<ElectricityBillDto> UpdateAsync(ElectricityBillDto billDto)
    {
        var existingBill = await _repository.GetByIdAsync(billDto.Id);
        if (existingBill == null)
        {
            throw new ArgumentException("Electricity bill not found");
        }

        existingBill.BillNumber = billDto.BillNumber;
        existingBill.BillMonth = billDto.BillMonth;
        existingBill.BillYear = billDto.BillYear;
        existingBill.Amount = billDto.Amount;
        existingBill.DueDate = billDto.DueDate;
        existingBill.PaidDate = billDto.PaidDate;
        existingBill.Units = billDto.Units;
        existingBill.UnitsRate = billDto.UnitsRate;
        existingBill.PaymentMethod = billDto.PaymentMethod;
        existingBill.TransactionId = billDto.TransactionId;
        existingBill.BankName = billDto.BankName;
        existingBill.ChequeNumber = billDto.ChequeNumber;
        existingBill.Notes = billDto.Notes;
        existingBill.IsPaid = billDto.IsPaid;
        existingBill.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(existingBill);
        return MapToDto(existingBill);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    private static ElectricityBillDto MapToDto(ElectricityBill bill)
    {
        return new ElectricityBillDto
        {
            Id = bill.Id,
            BillNumber = bill.BillNumber,
            BillMonth = bill.BillMonth,
            BillYear = bill.BillYear,
            Amount = bill.Amount,
            DueDate = bill.DueDate,
            PaidDate = bill.PaidDate,
            Units = bill.Units,
            UnitsRate = bill.UnitsRate,
            PaymentMethod = bill.PaymentMethod,
            TransactionId = bill.TransactionId,
            BankName = bill.BankName,
            ChequeNumber = bill.ChequeNumber,
            Notes = bill.Notes,
            IsPaid = bill.IsPaid,
            CreatedAt = bill.CreatedAt,
            UpdatedAt = bill.UpdatedAt
        };
    }

    private static ElectricityBill MapToEntity(ElectricityBillDto dto)
    {
        return new ElectricityBill
        {
            Id = dto.Id,
            BillNumber = dto.BillNumber,
            BillMonth = dto.BillMonth,
            BillYear = dto.BillYear,
            Amount = dto.Amount,
            DueDate = dto.DueDate,
            PaidDate = dto.PaidDate,
            Units = dto.Units,
            UnitsRate = dto.UnitsRate,
            PaymentMethod = dto.PaymentMethod,
            TransactionId = dto.TransactionId,
            BankName = dto.BankName,
            ChequeNumber = dto.ChequeNumber,
            Notes = dto.Notes,
            IsPaid = dto.IsPaid,
            CreatedAt = dto.CreatedAt,
            UpdatedAt = dto.UpdatedAt
        };
    }
}