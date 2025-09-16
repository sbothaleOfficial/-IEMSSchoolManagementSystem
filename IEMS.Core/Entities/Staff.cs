namespace IEMS.Core.Entities;

public class Staff
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty; // Male/Female
    public string Address { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty; // Driver, Peon, Security, Cleaner, etc.
    public string Department { get; set; } = string.Empty; // Transport, Maintenance, Security, etc.
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Status { get; set; } = "Active"; // Active/Inactive/On Leave
    public string EmergencyContact { get; set; } = string.Empty;
    public string EmergencyContactPhone { get; set; } = string.Empty;
    public string Qualifications { get; set; } = string.Empty;
    public string Experience { get; set; } = string.Empty; // Years of experience
    public string Remarks { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}