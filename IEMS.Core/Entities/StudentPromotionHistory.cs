using System;

namespace IEMS.Core.Entities;

public class StudentPromotionHistory
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public int FromClassId { get; set; }
    public string FromClassName { get; set; } = string.Empty;
    public int ToClassId { get; set; }
    public string ToClassName { get; set; } = string.Empty;

    // NEW: Foreign key to AcademicYear table
    public int AcademicYearId { get; set; }
    public virtual AcademicYear AcademicYear { get; set; } = null!;

    // DEPRECATED: Legacy string field
    [Obsolete("Use AcademicYearId instead. This field will be removed in a future version.")]
    public string? AcademicYearString { get; set; }

    public DateTime PromotionDate { get; set; }
    public string PromotedBy { get; set; } = string.Empty;  // Username of the person who promoted
    public string? Remarks { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Student? Student { get; set; }
    public virtual Class? FromClass { get; set; }
    public virtual Class? ToClass { get; set; }
}
