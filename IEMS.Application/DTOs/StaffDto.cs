namespace IEMS.Application.DTOs;

public class StaffDto
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Status { get; set; } = string.Empty;
    public string EmergencyContact { get; set; } = string.Empty;
    public string EmergencyContactPhone { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty;
    public string Remarks { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Computed properties for UI
    public string FullName => $"{FirstName} {LastName}";
    public string FormattedDateOfBirth => DateOfBirth.ToString("dd/MM/yyyy");
    public string FormattedHireDate => HireDate.ToString("dd/MM/yyyy");
    public string FormattedSalary => $"₹{Salary:N2}";
    public int Age => DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
    public string ServiceYears
    {
        get
        {
            var years = DateTime.Now.Year - HireDate.Year;
            var months = DateTime.Now.Month - HireDate.Month;
            if (months < 0)
            {
                years--;
                months += 12;
            }
            return years > 0 ? $"{years}y {months}m" : $"{months}m";
        }
    }
}