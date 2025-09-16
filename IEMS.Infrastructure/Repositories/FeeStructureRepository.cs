using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IEMS.Infrastructure.Repositories;

public class FeeStructureRepository : IFeeStructureRepository
{
    private readonly ApplicationDbContext _context;

    public FeeStructureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeeStructure>> GetAllAsync()
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .Where(fs => fs.IsActive)
            .OrderBy(fs => fs.Class.Name)
            .ThenBy(fs => fs.FeeType)
            .ToListAsync();
    }

    public async Task<FeeStructure?> GetByIdAsync(int id)
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .FirstOrDefaultAsync(fs => fs.Id == id);
    }

    public async Task<IEnumerable<FeeStructure>> GetByClassIdAsync(int classId)
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .Where(fs => fs.ClassId == classId && fs.IsActive)
            .OrderBy(fs => fs.FeeType)
            .ToListAsync();
    }

    public async Task<IEnumerable<FeeStructure>> GetByClassIdAndAcademicYearAsync(int classId, string academicYear)
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .Where(fs => fs.ClassId == classId && fs.AcademicYear == academicYear && fs.IsActive)
            .OrderBy(fs => fs.FeeType)
            .ToListAsync();
    }

    public async Task<FeeStructure?> GetByClassIdFeeTypeAndAcademicYearAsync(int classId, FeeType feeType, string academicYear)
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .FirstOrDefaultAsync(fs => fs.ClassId == classId && fs.FeeType == feeType && fs.AcademicYear == academicYear && fs.IsActive);
    }

    public async Task<IEnumerable<FeeStructure>> GetByAcademicYearAsync(string academicYear)
    {
        return await _context.FeeStructures
            .Include(fs => fs.Class)
            .Where(fs => fs.AcademicYear == academicYear && fs.IsActive)
            .OrderBy(fs => fs.Class.Name)
            .ThenBy(fs => fs.FeeType)
            .ToListAsync();
    }

    public async Task<FeeStructure> AddAsync(FeeStructure feeStructure)
    {
        _context.FeeStructures.Add(feeStructure);
        await _context.SaveChangesAsync();
        return feeStructure;
    }

    public async Task UpdateAsync(FeeStructure feeStructure)
    {
        feeStructure.UpdatedAt = DateTime.UtcNow;
        _context.FeeStructures.Update(feeStructure);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var feeStructure = await GetByIdAsync(id);
        if (feeStructure != null)
        {
            feeStructure.IsActive = false;
            feeStructure.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}