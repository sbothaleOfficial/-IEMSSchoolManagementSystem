using IEMS.Core.Enums;

namespace IEMS.Application.DTOs;

public class ElectricityBillDto
{
    public int Id { get; set; }
    public string BillNumber { get; set; } = string.Empty;
    public int BillMonth { get; set; }
    public int BillYear { get; set; }
    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? PaidDate { get; set; }
    public decimal Units { get; set; }
    public decimal UnitsRate { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public string? BankName { get; set; }
    public string? ChequeNumber { get; set; }
    public string? Notes { get; set; }
    public bool IsPaid { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string MonthYearDisplay => $"{GetMonthName(BillMonth)} {BillYear}";
    public string FormattedDueDate => DueDate.ToString("dd/MM/yyyy");
    public string FormattedPaidDate => PaidDate?.ToString("dd/MM/yyyy") ?? "Not Paid";
    public string PaymentStatus => IsPaid ? "Paid" : "Pending";

    private static string GetMonthName(int month)
    {
        return month switch
        {
            1 => "January",
            2 => "February",
            3 => "March",
            4 => "April",
            5 => "May",
            6 => "June",
            7 => "July",
            8 => "August",
            9 => "September",
            10 => "October",
            11 => "November",
            12 => "December",
            _ => "Unknown"
        };
    }
}