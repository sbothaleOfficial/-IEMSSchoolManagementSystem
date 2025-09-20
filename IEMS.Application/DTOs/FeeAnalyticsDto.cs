using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class FeeAnalyticsDto
{
    public decimal TotalCollection { get; set; }
    public decimal PendingFees { get; set; }
    public int StudentsWithPendingFees { get; set; }
    public int TotalStudents { get; set; }
    public decimal CompletionPercentage { get; set; }
    public List<ClassWiseFeeDto> ClassWisePendingFees { get; set; } = new();
    public List<MonthlyCollectionDto> MonthlyCollections { get; set; } = new();
    public List<FeeTypeAnalyticsDto> FeeTypeAnalytics { get; set; } = new();
}

public class ClassWiseFeeDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public string Section { get; set; } = string.Empty;
    public int TotalStudents { get; set; }
    public int StudentsWithPendingFees { get; set; }
    public decimal TotalPendingAmount { get; set; }
    public decimal AveragePendingPerStudent { get; set; }
    public decimal CollectionPercentage { get; set; }
}

public class MonthlyCollectionDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public string MonthName { get; set; } = string.Empty;
    public decimal TotalCollection { get; set; }
    public int NumberOfPayments { get; set; }
    public decimal AveragePaymentAmount { get; set; }
    public List<FeeTypeCollectionDto> ByFeeType { get; set; } = new();
}

public class FeeTypeCollectionDto
{
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }
    public int PaymentCount { get; set; }
}

public class FeeTypeAnalyticsDto
{
    public FeeType FeeType { get; set; }
    public string FeeTypeName { get; set; } = string.Empty;
    public decimal TotalCollected { get; set; }
    public decimal TotalPending { get; set; }
    public int StudentsWithPending { get; set; }
    public decimal CollectionRate { get; set; }
}

public class StudentFeeStatusDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public string ClassName { get; set; } = string.Empty;
    public string StudentNumber { get; set; } = string.Empty;
    public string ParentPhone { get; set; } = string.Empty;
    public decimal TotalPendingAmount { get; set; }
    public List<FeeTypePendingDto> PendingByFeeType { get; set; } = new();
    public DateTime? LastPaymentDate { get; set; }
    public int DaysSinceLastPayment { get; set; }
}

public class FeeTypePendingDto
{
    public FeeType FeeType { get; set; }
    public decimal PendingAmount { get; set; }
    public DateTime? LastPaid { get; set; }
    public int OverdueDays { get; set; }
}