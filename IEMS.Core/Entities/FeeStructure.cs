using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class FeeStructure
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}