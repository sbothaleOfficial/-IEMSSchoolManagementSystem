using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IEMS.Infrastructure.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly ApplicationDbContext _context;

    public StaffRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Staff?> GetByIdAsync(int id)
    {
        return await _context.Staff.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Staff>> GetAllAsync()
    {
        return await _context.Staff
            .OrderBy(s => s.Department)
            .ThenBy(s => s.Position)
            .ThenBy(s => s.LastName)
            .ToListAsync();
    }

    public async Task<Staff> AddAsync(Staff entity)
    {
        _context.Staff.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Staff entity)
    {
        _context.Staff.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var staff = await _context.Staff.FindAsync(id);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Staff?> GetStaffByEmployeeIdAsync(string employeeId)
    {
        return await _context.Staff.FirstOrDefaultAsync(s => s.EmployeeId == employeeId);
    }

    public async Task<IEnumerable<Staff>> GetStaffByDepartmentAsync(string department)
    {
        return await _context.Staff
            .Where(s => s.Department == department)
            .OrderBy(s => s.Position)
            .ThenBy(s => s.LastName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Staff>> GetStaffByPositionAsync(string position)
    {
        return await _context.Staff
            .Where(s => s.Position == position)
            .OrderBy(s => s.LastName)
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetDepartmentsAsync()
    {
        return await _context.Staff
            .Select(s => s.Department)
            .Distinct()
            .Where(d => !string.IsNullOrEmpty(d))
            .OrderBy(d => d)
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetPositionsAsync()
    {
        return await _context.Staff
            .Select(s => s.Position)
            .Distinct()
            .Where(p => !string.IsNullOrEmpty(p))
            .OrderBy(p => p)
            .ToListAsync();
    }

    public async Task<int> GetActiveStaffCountAsync()
    {
        return await _context.Staff.CountAsync(s => s.Status == "Active");
    }
}