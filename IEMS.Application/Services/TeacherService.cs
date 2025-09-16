using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class TeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IClassRepository _classRepository;

    public TeacherService(ITeacherRepository teacherRepository, IClassRepository classRepository)
    {
        _teacherRepository = teacherRepository;
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<TeacherDto>> GetAllTeachersAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();
        var teacherDtos = new List<TeacherDto>();

        foreach (var teacher in teachers)
        {
            var classes = await _classRepository.GetClassesByTeacherIdAsync(teacher.Id);
            teacherDtos.Add(new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                EmployeeId = teacher.EmployeeId,
                Subject = teacher.Subject,
                ClassCount = classes.Count()
            });
        }

        return teacherDtos;
    }

    public async Task<TeacherDto?> GetTeacherByIdAsync(int id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher == null) return null;

        var classes = await _classRepository.GetClassesByTeacherIdAsync(teacher.Id);
        return new TeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            EmployeeId = teacher.EmployeeId,
            Subject = teacher.Subject,
            ClassCount = classes.Count()
        };
    }

    public async Task<Teacher> AddTeacherAsync(TeacherDto teacherDto)
    {
        var teacher = new Teacher
        {
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            Email = teacherDto.Email,
            EmployeeId = teacherDto.EmployeeId,
            Subject = teacherDto.Subject
        };

        return await _teacherRepository.AddAsync(teacher);
    }

    public async Task UpdateTeacherAsync(TeacherDto teacherDto)
    {
        var teacher = await _teacherRepository.GetByIdAsync(teacherDto.Id);
        if (teacher != null)
        {
            teacher.FirstName = teacherDto.FirstName;
            teacher.LastName = teacherDto.LastName;
            teacher.Email = teacherDto.Email;
            teacher.EmployeeId = teacherDto.EmployeeId;
            teacher.Subject = teacherDto.Subject;
            teacher.UpdatedAt = DateTime.UtcNow;

            await _teacherRepository.UpdateAsync(teacher);
        }
    }

    public async Task DeleteTeacherAsync(int id)
    {
        var classes = await _classRepository.GetClassesByTeacherIdAsync(id);
        if (classes.Any())
        {
            throw new InvalidOperationException("Cannot delete teacher who is assigned to classes. Please reassign classes first.");
        }

        await _teacherRepository.DeleteAsync(id);
    }

    public async Task<bool> IsEmployeeIdUniqueAsync(string employeeId, int? excludeTeacherId = null)
    {
        var existingTeacher = await _teacherRepository.GetTeacherByEmployeeIdAsync(employeeId);
        return existingTeacher == null || (excludeTeacherId.HasValue && existingTeacher.Id == excludeTeacherId.Value);
    }

    public async Task<IEnumerable<TeacherDto>> GetTeachersBySubjectAsync(string subject)
    {
        var teachers = await _teacherRepository.GetTeachersBySubjectAsync(subject);
        var teacherDtos = new List<TeacherDto>();

        foreach (var teacher in teachers)
        {
            var classes = await _classRepository.GetClassesByTeacherIdAsync(teacher.Id);
            teacherDtos.Add(new TeacherDto
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                EmployeeId = teacher.EmployeeId,
                Subject = teacher.Subject,
                ClassCount = classes.Count()
            });
        }

        return teacherDtos;
    }
}