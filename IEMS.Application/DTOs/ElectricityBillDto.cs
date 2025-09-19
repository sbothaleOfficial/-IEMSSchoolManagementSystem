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

    public string MonthYearDisplay
    {
        get
        {
            try
            {
                return $"{GetMonthName(BillMonth)} {BillYear}";
            }
            catch
            {
                return "Unknown";
            }
        }
    }

    public string FormattedDueDate
    {
        get
        {
            try
            {
                return DueDate.ToString("dd/MM/yyyy");
            }
            catch
            {
                return "Invalid Date";
            }
        }
    }

    public string FormattedPaidDate
    {
        get
        {
            try
            {
                return PaidDate?.ToString("dd/MM/yyyy") ?? "Not Paid";
            }
            catch
            {
                return "Invalid Date";
            }
        }
    }

    public string PaymentStatus
    {
        get
        {
            try
            {
                return IsPaid ? "Paid" : "Pending";
            }
            catch
            {
                return "Unknown";
            }
        }
    }

    private static string GetMonthName(int month)
    {
        try
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
        catch
        {
            return "Unknown";
        }
    }
}