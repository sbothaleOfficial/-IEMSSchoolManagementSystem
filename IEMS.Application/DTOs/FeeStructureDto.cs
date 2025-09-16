using IEMS.Core.Enums;

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
    public string AcademicYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public class CreateFeeStructureDto
{
    public int ClassId { get; set; }
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}