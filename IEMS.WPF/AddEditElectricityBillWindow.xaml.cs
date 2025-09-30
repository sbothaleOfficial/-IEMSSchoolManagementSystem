using System.Windows;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.WPF.Helpers;

namespace IEMS.WPF;

public partial class AddEditElectricityBillWindow : Window
{
    private readonly ElectricityBillService _electricityBillService;
    private readonly int? _billId;
    private ElectricityBillDto? _currentBill;

    public AddEditElectricityBillWindow(ElectricityBillService electricityBillService, int? billId = null)
    {
        InitializeComponent();
        _electricityBillService = electricityBillService;
        _billId = billId;

        AsyncHelper.SafeFireAndForget(InitializeWindowAsync);
    }

    private async Task InitializeWindowAsync()
    {
        try
        {
            if (_billId.HasValue)
            {
                lblTitle.Text = "Edit Electricity Bill";
                _currentBill = await _electricityBillService.GetByIdAsync(_billId.Value);
                if (_currentBill != null)
                {
                    PopulateForm(_currentBill);
                }
                else
                {
                    MessageBox.Show("Electricity bill not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
            else
            {
                lblTitle.Text = "Add Electricity Bill";
                dpBillDate.SelectedDate = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


    private void PopulateForm(ElectricityBillDto bill)
    {
        dpBillDate.SelectedDate = new DateTime(bill.BillYear, bill.BillMonth, 1);
        txtAmount.Text = bill.Amount.ToString();
    }


    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(SaveAsync);
    }

    private async Task SaveAsync()
    {
        try
        {
            if (!ValidateForm())
                return;

            var billDate = dpBillDate.SelectedDate!.Value;
            var billDto = new ElectricityBillDto
            {
                Id = _currentBill?.Id ?? 0,
                BillNumber = $"{billDate:MMMM yyyy}",
                BillMonth = billDate.Month,
                BillYear = billDate.Year,
                Units = 1,
                UnitsRate = decimal.Parse(txtAmount.Text),
                Amount = decimal.Parse(txtAmount.Text),
                DueDate = billDate.AddDays(15),
                IsPaid = false,
                PaidDate = null,
                PaymentMethod = null,
                TransactionId = string.Empty,
                BankName = string.Empty,
                ChequeNumber = string.Empty,
                Notes = $"Simple electricity bill entry for {billDate:MMMM yyyy}"
            };

            if (_billId.HasValue)
            {
                await _electricityBillService.UpdateAsync(billDto);
            }
            else
            {
                await _electricityBillService.CreateAsync(billDto);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving electricity bill: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateForm()
    {
        if (!dpBillDate.SelectedDate.HasValue)
        {
            MessageBox.Show("Please select a bill date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpBillDate.Focus();
            return false;
        }

        if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Please enter valid amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtAmount.Focus();
            return false;
        }

        return true;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}