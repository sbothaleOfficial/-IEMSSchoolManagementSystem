using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class StudentFeeStatusDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string AcademicYear { get; set; } = string.Empty;
    public decimal TotalOutstandingBalance { get; set; }
    public List<StudentFeeTypeStatusDto> FeeTypeStatuses { get; set; } = new();
    public List<FeePaymentDto> RecentPayments { get; set; } = new();
    public bool HasOutstandingFees => TotalOutstandingBalance > 0;
    public string FormattedTotalOutstanding => $"₹{TotalOutstandingBalance:N2}";
    public string FeeStatusText => HasOutstandingFees ? "Pending" : "Paid";
}

public class StudentFeeTypeStatusDto
{
    public FeeType FeeType { get; set; }
    public string FeeTypeName { get; set; } = string.Empty;
    public decimal FeeStructureAmount { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal OutstandingAmount { get; set; }
    public decimal LastPaidAmount { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public int PaymentCount { get; set; }
    public bool IsPaid => OutstandingAmount <= 0;
    public string FormattedFeeAmount => $"₹{FeeStructureAmount:N2}";
    public string FormattedTotalPaid => $"₹{TotalPaid:N2}";
    public string FormattedOutstanding => $"₹{OutstandingAmount:N2}";
    public string FormattedLastPayment => LastPaymentDate?.ToString("dd/MM/yyyy") ?? "N/A";
    public string PaymentStatus => IsPaid ? "✅ Paid" : "⏳ Pending";
}