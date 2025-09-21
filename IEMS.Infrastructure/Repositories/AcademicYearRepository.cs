using Microsoft.EntityFrameworkCore;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;

namespace IEMS.Infrastructure.Repositories;

public class AcademicYearRepository : IAcademicYearRepository
{
    private readonly ApplicationDbContext _context;

    public AcademicYearRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AcademicYear?> GetByIdAsync(int id)
    {
        return await _context.AcademicYears.FindAsync(id);
    }

    public async Task<IEnumerable<AcademicYear>> GetAllAsync()
    {
        return await _context.AcademicYears
            .OrderByDescending(ay => ay.StartDate)
            .ToListAsync();
    }

    public async Task<AcademicYear> AddAsync(AcademicYear entity)
    {
        _context.AcademicYears.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(AcademicYear entity)
    {
        _context.AcademicYears.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var academicYear = await _context.AcademicYears.FindAsync(id);
        if (academicYear != null)
        {
            _context.AcademicYears.Remove(academicYear);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<AcademicYear?> GetCurrentAcademicYearAsync()
    {
        return await _context.AcademicYears
            .FirstOrDefaultAsync(ay => ay.IsCurrent);
    }

    public async Task<IEnumerable<AcademicYear>> GetRecentAcademicYearsAsync(int count = 5)
    {
        return await _context.AcademicYears
            .OrderByDescending(ay => ay.StartDate)
            .Take(count)
            .ToListAsync();
    }

    public async Task SetCurrentAcademicYearAsync(int academicYearId)
    {
        // Set all academic years to not current
        var allAcademicYears = await _context.AcademicYears.ToListAsync();
        foreach (var ay in allAcademicYears)
        {
            ay.IsCurrent = false;
            ay.UpdatedAt = DateTime.UtcNow;
        }

        // Set the specified academic year as current
        var targetYear = await _context.AcademicYears.FindAsync(academicYearId);
        if (targetYear != null)
        {
            targetYear.IsCurrent = true;
            targetYear.UpdatedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();
    }
}