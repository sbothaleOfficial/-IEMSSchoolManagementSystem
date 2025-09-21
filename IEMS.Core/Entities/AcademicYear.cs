namespace IEMS.Core.Entities;

public class AcademicYear
{
    public int Id { get; set; }
    public string Year { get; set; } = string.Empty; // e.g., "2024-25"
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}