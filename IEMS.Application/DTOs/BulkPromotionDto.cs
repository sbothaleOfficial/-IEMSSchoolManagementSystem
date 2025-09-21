namespace IEMS.Application.DTOs;

public class BulkPromotionRequest
{
    public int FromClassId { get; set; }
    public int ToClassId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public List<int> ExcludedStudentIds { get; set; } = new();
    public string Reason { get; set; } = string.Empty;
}

public class BulkPromotionResult
{
    public int TotalStudents { get; set; }
    public int PromotedStudents { get; set; }
    public int FailedPromotions { get; set; }
    public List<PromotionError> Errors { get; set; } = new();
    public bool IsSuccess => FailedPromotions == 0;
    public DateTime PromotionDate { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
}

public class PromotionError
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string Error { get; set; } = string.Empty;
}

public class StudentPromotionDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string CurrentClass { get; set; } = string.Empty;
    public string TargetClass { get; set; } = string.Empty;
    public bool IsEligible { get; set; }
    public string IneligibilityReason { get; set; } = string.Empty;
    public bool HasPendingFees { get; set; }
    public decimal PendingAmount { get; set; }
}