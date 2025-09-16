namespace IEMS.Application.DTOs;

public class StaffDto
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Computed properties for UI
    public string FullName => $"{FirstName} {LastName}";
    public string FormattedDateOfBirth => DateOfBirth.ToString("dd/MM/yyyy");
    public string FormattedSalary => $"₹{Salary:N2}";
    public int Age => DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
}