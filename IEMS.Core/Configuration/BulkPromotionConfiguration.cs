namespace IEMS.Core.Configuration;

public class BulkPromotionConfiguration
{
    public const string SectionName = "BulkPromotion";

    public EligibilityRulesConfiguration EligibilityRules { get; set; } = new();
    public ClassProgressionConfiguration ClassProgression { get; set; } = new();
    public AuditConfiguration Audit { get; set; } = new();
}

public class EligibilityRulesConfiguration
{
    public decimal MaxPendingFees { get; set; } = 1000m;
    public int MinAttendancePercentage { get; set; } = 75;
    public bool RequireTeacherApproval { get; set; } = false;
    public bool AllowPromotionWithPendingFees { get; set; } = false;
}

public class ClassProgressionConfiguration
{
    public bool AllowSameGradePromotion { get; set; } = true;
    public bool AllowSkipGrade { get; set; } = false;
    public bool StrictProgressionOnly { get; set; } = true;
    public List<string> RequireParentConsent { get; set; } = new();
}

public class AuditConfiguration
{
    public bool EnableAuditLogging { get; set; } = true;
    public bool LogStudentDetails { get; set; } = true;
    public int RetentionDays { get; set; } = 2555; // 7 years
}