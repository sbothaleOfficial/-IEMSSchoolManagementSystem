namespace IEMS.Application.DTOs;

public class AcademicYearDto
{
    public int Id { get; set; }
    public string Year { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsCurrent { get; set; }
    public string DisplayName => IsCurrent ? $"{Year} (Current)" : Year;
    public string Period => $"{StartDate:MMM yyyy} - {EndDate:MMM yyyy}";
}