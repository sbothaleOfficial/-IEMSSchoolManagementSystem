using IEMS.Core.Entities;

namespace IEMS.Core.Services;

public class StudentPromotionService
{
    public class PromotionValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> ValidationErrors { get; set; } = new();
        public List<Student> EligibleStudents { get; set; } = new();
        public List<Student> IneligibleStudents { get; set; } = new();
    }

    public class PromotionRequest
    {
        public Class FromClass { get; set; } = null!;
        public Class ToClass { get; set; } = null!;
        public List<Student> Students { get; set; } = new();
        public List<int> ExcludedStudentIds { get; set; } = new();
        public string AcademicYear { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }

    public PromotionValidationResult ValidatePromotion(PromotionRequest request)
    {
        var result = new PromotionValidationResult();

        // Validate basic requirements
        if (request.FromClass == null)
        {
            result.ValidationErrors.Add("Source class is required");
        }

        if (request.ToClass == null)
        {
            result.ValidationErrors.Add("Target class is required");
        }

        if (request.FromClass?.Id == request.ToClass?.Id)
        {
            result.ValidationErrors.Add("Source and target classes cannot be the same");
        }

        if (string.IsNullOrWhiteSpace(request.AcademicYear))
        {
            result.ValidationErrors.Add("Academic year is required");
        }

        if (!request.Students.Any())
        {
            result.ValidationErrors.Add("No students found in the source class");
        }

        // Class progression is validated in ClassProgressionValidator service
        // No need to duplicate validation here

        // Filter eligible students
        foreach (var student in request.Students)
        {
            if (request.ExcludedStudentIds.Contains(student.Id))
            {
                result.IneligibleStudents.Add(student);
                continue;
            }

            if (IsStudentEligibleForPromotion(student))
            {
                result.EligibleStudents.Add(student);
            }
            else
            {
                result.IneligibleStudents.Add(student);
            }
        }

        result.IsValid = !result.ValidationErrors.Any();
        return result;
    }

    public void ExecutePromotion(List<Student> students, int targetClassId, string academicYear)
    {
        if (students == null || !students.Any())
            throw new ArgumentException("No students provided for promotion");

        foreach (var student in students)
        {
            // Update student's class
            student.ClassId = targetClassId;

            // Update academic year information if Student entity had that field
            // For now, we'll use a comment to indicate where this would go
            // student.AcademicYear = academicYear;

            // Update timestamps
            student.UpdatedAt = DateTime.UtcNow;
        }
    }


    private bool IsStudentEligibleForPromotion(Student student)
    {
        // Basic eligibility checks
        if (student == null) return false;

        // Check if student is active (not deleted)
        // Additional business rules can be added here such as:
        // - Attendance percentage
        // - Academic performance
        // - Disciplinary status
        // - Fee payment status

        return true; // Default to eligible
    }

    public string GeneratePromotionSummary(PromotionValidationResult validation, string fromClass, string toClass)
    {
        var summary = $"Bulk Promotion Summary:\n";
        summary += $"From: {fromClass}\n";
        summary += $"To: {toClass}\n";
        summary += $"Eligible Students: {validation.EligibleStudents.Count}\n";
        summary += $"Ineligible Students: {validation.IneligibleStudents.Count}\n";

        if (validation.ValidationErrors.Any())
        {
            summary += $"\nValidation Errors:\n";
            summary += string.Join("\n", validation.ValidationErrors.Select(e => $"- {e}"));
        }

        return summary;
    }
}