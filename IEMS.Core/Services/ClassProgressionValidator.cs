using IEMS.Core.Configuration;
using IEMS.Core.Entities;

namespace IEMS.Core.Services;

public class ClassProgressionValidator
{
    private readonly BulkPromotionConfiguration _config;

    // Define clear class hierarchy mapping
    private static readonly Dictionary<string, int> ClassHierarchy = new(StringComparer.OrdinalIgnoreCase)
    {
        ["Nursery"] = 0,
        ["KG1"] = 1,
        ["LKG"] = 1,  // Alternative name for KG1
        ["KG2"] = 2,
        ["UKG"] = 2,  // Alternative name for KG2
        ["Class 1"] = 3,
        ["Class 2"] = 4,
        ["Class 3"] = 5,
        ["Class 4"] = 6,
        ["Class 5"] = 7,
        ["Class 6"] = 8,
        ["Class 7"] = 9,
        ["Class 8"] = 10,
        ["Class 9"] = 11,
        ["Class 10"] = 12,
        ["Class 11"] = 13,
        ["Class 12"] = 14
    };

    public ClassProgressionValidator(BulkPromotionConfiguration config)
    {
        _config = config;
    }

    public ValidationResult ValidateProgression(string fromClassName, string toClassName)
    {
        if (string.IsNullOrWhiteSpace(fromClassName) || string.IsNullOrWhiteSpace(toClassName))
        {
            return ValidationResult.Invalid("Source and target class names are required");
        }

        if (!ClassHierarchy.TryGetValue(fromClassName.Trim(), out var fromLevel))
        {
            return ValidationResult.Invalid($"Unknown source class: '{fromClassName}'");
        }

        if (!ClassHierarchy.TryGetValue(toClassName.Trim(), out var toLevel))
        {
            return ValidationResult.Invalid($"Unknown target class: '{toClassName}'");
        }

        // Same class progression
        if (fromLevel == toLevel)
        {
            if (!_config.ClassProgression.AllowSameGradePromotion)
            {
                return ValidationResult.Invalid($"Same grade promotion from '{fromClassName}' to '{toClassName}' is not allowed");
            }
            return ValidationResult.Valid();
        }

        // Skip grade validation
        if (toLevel > fromLevel + 1)
        {
            if (!_config.ClassProgression.AllowSkipGrade)
            {
                return ValidationResult.Invalid($"Grade skipping from '{fromClassName}' to '{toClassName}' is not allowed");
            }
        }

        // Backward progression (demotion)
        if (toLevel < fromLevel)
        {
            return ValidationResult.Invalid($"Backward progression from '{fromClassName}' to '{toClassName}' is not allowed");
        }

        // Strict progression validation
        if (_config.ClassProgression.StrictProgressionOnly && toLevel != fromLevel + 1 && toLevel != fromLevel)
        {
            return ValidationResult.Invalid($"Only sequential progression allowed. Cannot promote from '{fromClassName}' to '{toClassName}'");
        }

        // Special consent requirements
        if (_config.ClassProgression.RequireParentConsent.Contains(toClassName, StringComparer.OrdinalIgnoreCase))
        {
            // This would require additional validation in the business layer
            // For now, we'll allow it but this could be enhanced
        }

        return ValidationResult.Valid();
    }

    public bool IsValidClassProgression(string fromClassName, string toClassName)
    {
        return ValidateProgression(fromClassName, toClassName).IsValid;
    }

    public static IReadOnlyDictionary<string, int> GetClassHierarchy()
    {
        return ClassHierarchy.AsReadOnly();
    }
}

public class ValidationResult
{
    public bool IsValid { get; private set; }
    public string ErrorMessage { get; private set; } = string.Empty;

    private ValidationResult(bool isValid, string errorMessage = "")
    {
        IsValid = isValid;
        ErrorMessage = errorMessage;
    }

    public static ValidationResult Valid() => new(true);
    public static ValidationResult Invalid(string errorMessage) => new(false, errorMessage);
}