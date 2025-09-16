using IEMS.Core.Entities;
using IEMS.Core.Interfaces;
using IEMS.Application.DTOs;

namespace IEMS.Application.Services;

public class StudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        var studentDtos = new List<StudentDto>();

        foreach (var student in students)
        {
            var classEntity = await _classRepository.GetByIdAsync(student.ClassId);
            studentDtos.Add(new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                RollNumber = student.RollNumber,
                ClassId = student.ClassId,
                ClassName = classEntity?.Name ?? "Unknown"
            });
        }

        return studentDtos;
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        if (student == null) return null;

        var classEntity = await _classRepository.GetByIdAsync(student.ClassId);
        return new StudentDto
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            DateOfBirth = student.DateOfBirth,
            RollNumber = student.RollNumber,
            ClassId = student.ClassId,
            ClassName = classEntity?.Name ?? "Unknown"
        };
    }

    public async Task<Student> AddStudentAsync(StudentDto studentDto)
    {
        var student = new Student
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email,
            DateOfBirth = studentDto.DateOfBirth,
            RollNumber = studentDto.RollNumber,
            ClassId = studentDto.ClassId
        };

        return await _studentRepository.AddAsync(student);
    }

    public async Task UpdateStudentAsync(StudentDto studentDto)
    {
        var student = await _studentRepository.GetByIdAsync(studentDto.Id);
        if (student != null)
        {
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;
            student.Email = studentDto.Email;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.RollNumber = studentDto.RollNumber;
            student.ClassId = studentDto.ClassId;
            student.UpdatedAt = DateTime.UtcNow;

            await _studentRepository.UpdateAsync(student);
        }
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _studentRepository.DeleteAsync(id);
    }
}