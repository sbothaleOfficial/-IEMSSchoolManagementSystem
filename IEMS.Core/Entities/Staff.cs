namespace IEMS.Core.Entities;

public class Staff
{
    public int Id { get; set; }
    public string EmployeeId { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty; // Male/Female
    public string Address { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty; // Peon, Driver, Clerk
    public decimal Salary { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}