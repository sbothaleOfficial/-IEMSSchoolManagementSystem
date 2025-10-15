using System;
using IEMS.Core.Enums;

namespace IEMS.Core.Entities;

public class FeeStructure
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; } = null!;
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }

    // NEW: Foreign key to AcademicYear table
    public int AcademicYearId { get; set; }
    public virtual AcademicYear AcademicYear { get; set; } = null!;

    // DEPRECATED: Legacy string field - will be removed in future migration
    // Kept temporarily for backward compatibility during migration
    [Obsolete("Use AcademicYearId instead. This field will be removed in a future version.")]
    public string? AcademicYearString { get; set; }

    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}