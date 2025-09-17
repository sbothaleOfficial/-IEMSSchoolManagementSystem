namespace IEMS.Application.DTOs;

public class TeacherDto
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public DateTime JoiningDate { get; set; } = DateTime.UtcNow;
    public decimal MonthlySalary { get; set; } = 0;

    public string? Email { get; set; }
    public string? BankAccountNumber { get; set; }
    public string? AadharNumber { get; set; }
    public string? PANNumber { get; set; }

    public string FullName => $"{FirstName} {LastName}";
    public int ClassCount { get; set; }
}