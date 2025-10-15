using IEMS.Core.Enums;
using System;

namespace IEMS.Application.DTOs;

public class FeeStructureDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public FeeType FeeType { get; set; }
    public string FeeTypeDisplay => FeeType.ToString();
    public decimal Amount { get; set; }
    public string AmountFormatted => $"₹{Amount:F2}";

    // NEW: Foreign key to AcademicYear table
    public int AcademicYearId { get; set; }
    public string AcademicYearDisplay { get; set; } = string.Empty;

    // DEPRECATED: Legacy string field
    [Obsolete("Use AcademicYearId and AcademicYearDisplay instead. This field will be removed in a future version.")]
    public string AcademicYear { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class CreateFeeStructureDto
{
    public int ClassId { get; set; }
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }

    // NEW: Foreign key to AcademicYear table
    public int AcademicYearId { get; set; }

    // DEPRECATED: Legacy string field (optional for backward compatibility)
    [Obsolete("Use AcademicYearId instead. This field will be removed in a future version.")]
    public string? AcademicYear { get; set; }

    public string Description { get; set; } = string.Empty;
}