namespace IEMS.Application.DTOs;

public class TeacherDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmployeeId { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public int ClassCount { get; set; }
}