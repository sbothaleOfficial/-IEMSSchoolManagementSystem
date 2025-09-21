using IEMS.Application.DTOs;
using IEMS.Core.Interfaces;
using IEMS.Core.Services;
using IEMS.Core.Entities;

namespace IEMS.Application.Services;

public class BulkPromotionService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;
    private readonly IFeePaymentRepository _feePaymentRepository;
    private readonly StudentPromotionService _promotionService;

    public BulkPromotionService(
        IStudentRepository studentRepository,
        IClassRepository classRepository,
        IFeePaymentRepository feePaymentRepository,
        StudentPromotionService promotionService)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
        _feePaymentRepository = feePaymentRepository;
        _promotionService = promotionService;
    }

    public async Task<List<StudentPromotionDto>> GetPromotionPreviewAsync(int fromClassId, int toClassId)
    {
        var students = await _studentRepository.GetStudentsWithClassDetailsAsync(fromClassId);
        var fromClass = await _classRepository.GetByIdAsync(fromClassId);
        var toClass = await _classRepository.GetByIdAsync(toClassId);

        var result = new List<StudentPromotionDto>();

        foreach (var student in students)
        {
            var pendingFees = await GetPendingFeesForStudent(student.Id);

            result.Add(new StudentPromotionDto
            {
                StudentId = student.Id,
                StudentName = student.FullName,
                StudentNumber = student.StudentNumber,
                CurrentClass = fromClass?.Name ?? "Unknown",
                TargetClass = toClass?.Name ?? "Unknown",
                IsEligible = IsStudentEligibleForPromotion(student, pendingFees),
                IneligibilityReason = GetIneligibilityReason(student, pendingFees),
                HasPendingFees = pendingFees > 0,
                PendingAmount = pendingFees
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

            // Get class details
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

            // Filter excluded students
            var studentsToPromote = allStudents
                .Where(s => !request.ExcludedStudentIds.Contains(s.Id))
                .ToList();

            result.TotalStudents = studentsToPromote.Count;

            // Validate promotion using domain service
            var promotionRequest = new StudentPromotionService.PromotionRequest
            {
                FromClass = fromClass,
                ToClass = toClass,
                Students = studentsToPromote,
                ExcludedStudentIds = request.ExcludedStudentIds,
                AcademicYear = request.AcademicYear,
                Reason = request.Reason
            };

            var validation = _promotionService.ValidatePromotion(promotionRequest);

            if (!validation.IsValid)
            {
                foreach (var error in validation.ValidationErrors)
                {
                    result.Errors.Add(new PromotionError
                    {
                        StudentId = 0,
                        StudentName = "Validation",
                        Error = error
                    });
                }
                return result;
            }

            // Execute promotion for eligible students
            var eligibleStudents = validation.EligibleStudents;

            if (eligibleStudents.Any())
            {
                try
                {
                    _promotionService.ExecutePromotion(eligibleStudents, request.ToClassId, request.AcademicYear);
                    await _studentRepository.UpdateMultipleStudentsAsync(eligibleStudents);

                    result.PromotedStudents = eligibleStudents.Count;
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

            // Add errors for ineligible students
            foreach (var student in validation.IneligibleStudents)
            {
                result.Errors.Add(new PromotionError
                {
                    StudentId = student.Id,
                    StudentName = student.FullName,
                    Error = "Student not eligible for promotion"
                });
                result.FailedPromotions++;
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

    private async Task<decimal> GetPendingFeesForStudent(int studentId)
    {
        try
        {
            var feePayments = await _feePaymentRepository.GetAllAsync();
            var studentPayments = feePayments.Where(fp => fp.StudentId == studentId);

            // Calculate pending fees based on remaining balance from latest payment
            // In this system, RemainingBalance represents what's still owed
            var latestPayment = studentPayments.OrderByDescending(fp => fp.PaymentDate).FirstOrDefault();

            return latestPayment?.RemainingBalance ?? 0;
        }
        catch
        {
            return 0; // Default to no pending fees if calculation fails
        }
    }

    private bool IsStudentEligibleForPromotion(Student student, decimal pendingFees)
    {
        // Basic eligibility rules
        if (pendingFees > 1000) // Arbitrary threshold
            return false;

        // Add other business rules as needed
        return true;
    }

    private string GetIneligibilityReason(Student student, decimal pendingFees)
    {
        if (pendingFees > 1000)
            return $"Pending fees: ₹{pendingFees:N2}";

        return string.Empty;
    }
}