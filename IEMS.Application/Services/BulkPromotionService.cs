using IEMS.Application.DTOs;
using IEMS.Core.Interfaces;
using IEMS.Core.Services;
using IEMS.Core.Entities;
using IEMS.Core.Configuration;

namespace IEMS.Application.Services;

public class BulkPromotionService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;
    private readonly IFeePaymentRepository _feePaymentRepository;
    private readonly StudentPromotionService _promotionService;
    private readonly StudentEligibilityValidator _eligibilityValidator;
    private readonly ClassProgressionValidator _progressionValidator;

    public BulkPromotionService(
        IStudentRepository studentRepository,
        IClassRepository classRepository,
        IFeePaymentRepository feePaymentRepository,
        StudentPromotionService promotionService,
        StudentEligibilityValidator eligibilityValidator,
        ClassProgressionValidator progressionValidator)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
        _feePaymentRepository = feePaymentRepository;
        _promotionService = promotionService;
        _eligibilityValidator = eligibilityValidator;
        _progressionValidator = progressionValidator;
    }

    public async Task<List<StudentPromotionDto>> GetPromotionPreviewAsync(int fromClassId, int toClassId)
    {
        var students = await _studentRepository.GetStudentsWithClassDetailsAsync(fromClassId);
        var fromClass = await _classRepository.GetByIdAsync(fromClassId);
        var toClass = await _classRepository.GetByIdAsync(toClassId);

        var result = new List<StudentPromotionDto>();

        foreach (var student in students)
        {
            // Simplified: All students are eligible for promotion (basic class update)
            result.Add(new StudentPromotionDto
            {
                StudentId = student.Id,
                StudentName = student.FullName,
                StudentNumber = student.StudentNumber,
                CurrentClass = fromClass?.Name ?? "Unknown",
                TargetClass = toClass?.Name ?? "Unknown",
                IsEligible = true, // All students eligible for simple class update
                IneligibilityReason = string.Empty,
                HasPendingFees = false, // Not checking fees for simple promotion
                PendingAmount = 0
            });
        }

        return result;
    }

    public async Task<BulkPromotionResult> ExecuteBulkPromotionAsync(BulkPromotionRequest request)
    {
        var result = new BulkPromotionResult
        {
            PromotionDate = DateTime.UtcNow,
            AcademicYear = request.AcademicYear
        };

        try
        {
            // Get source students
            var allStudents = (await _studentRepository.GetStudentsByClassIdAsync(request.FromClassId)).ToList();

            // Get class details for validation
            var fromClass = await _classRepository.GetByIdAsync(request.FromClassId);
            var toClass = await _classRepository.GetByIdAsync(request.ToClassId);

            if (fromClass == null || toClass == null)
            {
                result.Errors.Add(new PromotionError
                {
                    StudentId = 0,
                    StudentName = "System",
                    Error = "Invalid source or target class"
                });
                return result;
            }

            // Simple validation: just check if classes exist and are different
            if (request.FromClassId == request.ToClassId)
            {
                result.Errors.Add(new PromotionError
                {
                    StudentId = 0,
                    StudentName = "System",
                    Error = "Source and target classes must be different"
                });
                return result;
            }

            // Filter excluded students
            var studentsToPromote = allStudents
                .Where(s => !request.ExcludedStudentIds.Contains(s.Id))
                .ToList();

            result.TotalStudents = studentsToPromote.Count;

            // Simple execution: Just update the ClassId for all students
            if (studentsToPromote.Any())
            {
                try
                {
                    // Simple class update - no complex validations
                    foreach (var student in studentsToPromote)
                    {
                        student.ClassId = request.ToClassId;
                        student.UpdatedAt = DateTime.UtcNow;
                    }

                    await _studentRepository.UpdateMultipleStudentsAsync(studentsToPromote);
                    result.PromotedStudents = studentsToPromote.Count;
                }
                catch (Exception ex)
                {
                    result.Errors.Add(new PromotionError
                    {
                        StudentId = 0,
                        StudentName = "Database",
                        Error = $"Failed to update students: {ex.Message}"
                    });
                }
            }
        }
        catch (Exception ex)
        {
            result.Errors.Add(new PromotionError
            {
                StudentId = 0,
                StudentName = "System",
                Error = $"Unexpected error: {ex.Message}"
            });
        }

        return result;
    }

    public async Task<BulkPromotionResult> RollbackPromotionAsync(int fromClassId, int toClassId, string academicYear)
    {
        var result = new BulkPromotionResult
        {
            PromotionDate = DateTime.UtcNow,
            AcademicYear = academicYear
        };

        try
        {
            // Get students who were promoted (now in target class)
            var promotedStudents = (await _studentRepository.GetStudentsByClassIdAsync(toClassId)).ToList();

            result.TotalStudents = promotedStudents.Count;

            // Rollback promotion (move back to original class)
            foreach (var student in promotedStudents)
            {
                student.ClassId = fromClassId;
                student.UpdatedAt = DateTime.UtcNow;
            }

            await _studentRepository.UpdateMultipleStudentsAsync(promotedStudents);
            result.PromotedStudents = promotedStudents.Count;
        }
        catch (Exception ex)
        {
            result.Errors.Add(new PromotionError
            {
                StudentId = 0,
                StudentName = "System",
                Error = $"Rollback failed: {ex.Message}"
            });
        }

        return result;
    }


}