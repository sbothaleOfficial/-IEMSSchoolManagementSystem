using IEMS.Core.Configuration;
using IEMS.Core.Entities;

namespace IEMS.Core.Services;

public class StudentEligibilityValidator
{
    private readonly BulkPromotionConfiguration _config;

    public StudentEligibilityValidator(BulkPromotionConfiguration config)
    {
        _config = config;
    }

    public Task<EligibilityResult> ValidateStudentAsync(Student student, decimal pendingFees)
    {
        var results = new List<string>();

        // Check if student exists and is active
        if (student == null)
        {
            return Task.FromResult(EligibilityResult.Ineligible("Student not found"));
        }

        // Fee validation
        if (!ValidateFeeEligibility(pendingFees, out string feeError))
        {
            results.Add(feeError);
        }

        // Attendance validation (placeholder - would require actual attendance data)
        if (!ValidateAttendance(student, out string attendanceError))
        {
            results.Add(attendanceError);
        }

        // Academic performance validation (placeholder)
        if (!ValidateAcademicPerformance(student, out string performanceError))
        {
            results.Add(performanceError);
        }

        // Disciplinary status validation (placeholder)
        if (!ValidateDisciplinaryStatus(student, out string disciplinaryError))
        {
            results.Add(disciplinaryError);
        }

        if (results.Count > 0)
        {
            return Task.FromResult(EligibilityResult.Ineligible(string.Join("; ", results)));
        }

        return Task.FromResult(EligibilityResult.Eligible());
    }

    private bool ValidateFeeEligibility(decimal pendingFees, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (!_config.EligibilityRules.AllowPromotionWithPendingFees && pendingFees > 0)
        {
            errorMessage = $"Student has pending fees of ₹{pendingFees:N2}";
            return false;
        }

        if (pendingFees > _config.EligibilityRules.MaxPendingFees)
        {
            errorMessage = $"Pending fees ₹{pendingFees:N2} exceed maximum allowed ₹{_config.EligibilityRules.MaxPendingFees:N2}";
            return false;
        }

        return true;
    }

    private bool ValidateAttendance(Student student, out string errorMessage)
    {
        errorMessage = string.Empty;

        // TODO: Implement actual attendance validation
        // This would require attendance tracking system
        // For now, we'll assume all students meet attendance requirements

        return true;
    }

    private bool ValidateAcademicPerformance(Student student, out string errorMessage)
    {
        errorMessage = string.Empty;

        // TODO: Implement academic performance validation
        // This would require grades/marks system
        // For now, we'll assume all students meet academic requirements

        return true;
    }

    private bool ValidateDisciplinaryStatus(Student student, out string errorMessage)
    {
        errorMessage = string.Empty;

        // TODO: Implement disciplinary status validation
        // This would require disciplinary records system
        // For now, we'll assume all students have clean disciplinary records

        return true;
    }
}

public class EligibilityResult
{
    public bool IsEligible { get; private set; }
    public string Reason { get; private set; } = string.Empty;

    private EligibilityResult(bool isEligible, string reason = "")
    {
        IsEligible = isEligible;
        Reason = reason;
    }

    public static EligibilityResult Eligible() => new(true);
    public static EligibilityResult Ineligible(string reason) => new(false, reason);
}