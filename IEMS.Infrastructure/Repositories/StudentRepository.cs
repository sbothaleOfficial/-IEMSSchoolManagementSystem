using Microsoft.EntityFrameworkCore;
using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Infrastructure.Data;

namespace IEMS.Infrastructure.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.Class)
            .ToListAsync();
    }

    public async Task<Student> AddAsync(Student entity)
    {
        _context.Students.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(Student entity)
    {
        _context.Students.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Student>> GetStudentsByClassIdAsync(int classId)
    {
        return await _context.Students
            .Include(s => s.Class)
            .Where(s => s.ClassId == classId)
            .ToListAsync();
    }

    public async Task<Student?> GetStudentByStudentNumberAsync(string studentNumber)
    {
        return await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.StudentNumber == studentNumber);
    }
}