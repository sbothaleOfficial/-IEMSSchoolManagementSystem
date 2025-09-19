using System.Windows;
using System.Windows.Controls;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.Core.Enums;

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

        InitializeWindow();
    }

    private async void InitializeWindow()
    {
        try
        {
            InitializeComboBoxes();

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
                dpDueDate.SelectedDate = DateTime.Now.AddDays(15);
                cmbMonth.SelectedValue = DateTime.Now.Month;
                cmbYear.SelectedValue = DateTime.Now.Year;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void InitializeComboBoxes()
    {
        // Initialize months
        var months = new Dictionary<int, string>();
        for (int i = 1; i <= 12; i++)
        {
            months.Add(i, new DateTime(2000, i, 1).ToString("MMMM"));
        }
        cmbMonth.ItemsSource = months;
        cmbMonth.DisplayMemberPath = "Value";
        cmbMonth.SelectedValuePath = "Key";

        // Initialize years (current year - 5 to current year + 1)
        var years = new List<int>();
        for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 1; i++)
        {
            years.Add(i);
        }
        cmbYear.ItemsSource = years;

        // Initialize payment methods
        cmbPaymentMethod.ItemsSource = Enum.GetValues<PaymentMethod>();
    }

    private void PopulateForm(ElectricityBillDto bill)
    {
        txtBillNumber.Text = bill.BillNumber;
        cmbMonth.SelectedValue = bill.BillMonth;
        cmbYear.SelectedValue = bill.BillYear;
        txtUnits.Text = bill.Units.ToString();
        txtUnitsRate.Text = bill.UnitsRate.ToString();
        txtAmount.Text = bill.Amount.ToString();
        dpDueDate.SelectedDate = bill.DueDate;
        chkIsPaid.IsChecked = bill.IsPaid;
        dpPaidDate.SelectedDate = bill.PaidDate;
        cmbPaymentMethod.SelectedValue = bill.PaymentMethod;
        txtTransactionId.Text = bill.TransactionId;
        txtBankName.Text = bill.BankName;
        txtChequeNumber.Text = bill.ChequeNumber;
        txtNotes.Text = bill.Notes;
    }

    private void TxtUnits_TextChanged(object sender, TextChangedEventArgs e)
    {
        CalculateAmount();
    }

    private void TxtUnitsRate_TextChanged(object sender, TextChangedEventArgs e)
    {
        CalculateAmount();
    }

    private void CalculateAmount()
    {
        if (decimal.TryParse(txtUnits.Text, out decimal units) &&
            decimal.TryParse(txtUnitsRate.Text, out decimal rate))
        {
            var amount = units * rate;
            txtAmount.Text = amount.ToString("F2");
        }
    }

    private void ChkIsPaid_Checked(object sender, RoutedEventArgs e)
    {
        pnlPaymentDetails.Visibility = Visibility.Visible;
        if (!dpPaidDate.SelectedDate.HasValue)
        {
            dpPaidDate.SelectedDate = DateTime.Now;
        }
    }

    private void ChkIsPaid_Unchecked(object sender, RoutedEventArgs e)
    {
        pnlPaymentDetails.Visibility = Visibility.Collapsed;
        dpPaidDate.SelectedDate = null;
        cmbPaymentMethod.SelectedItem = null;
        txtTransactionId.Clear();
        txtBankName.Clear();
        txtChequeNumber.Clear();
    }

    private void CmbPaymentMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbPaymentMethod.SelectedValue is PaymentMethod method)
        {
            // Enable/disable fields based on payment method
            txtTransactionId.IsEnabled = method == PaymentMethod.ONLINE;
            txtBankName.IsEnabled = method == PaymentMethod.CHEQUE || method == PaymentMethod.DD;
            txtChequeNumber.IsEnabled = method == PaymentMethod.CHEQUE || method == PaymentMethod.DD;
        }
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!ValidateForm())
                return;

            var billDto = new ElectricityBillDto
            {
                Id = _currentBill?.Id ?? 0,
                BillNumber = txtBillNumber.Text.Trim(),
                BillMonth = (int)cmbMonth.SelectedValue,
                BillYear = (int)cmbYear.SelectedValue,
                Units = decimal.Parse(txtUnits.Text),
                UnitsRate = decimal.Parse(txtUnitsRate.Text),
                Amount = decimal.Parse(txtAmount.Text),
                DueDate = dpDueDate.SelectedDate!.Value,
                IsPaid = chkIsPaid.IsChecked ?? false,
                PaidDate = dpPaidDate.SelectedDate,
                PaymentMethod = cmbPaymentMethod.SelectedValue as PaymentMethod?,
                TransactionId = txtTransactionId.Text.Trim(),
                BankName = txtBankName.Text.Trim(),
                ChequeNumber = txtChequeNumber.Text.Trim(),
                Notes = txtNotes.Text.Trim()
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
        if (string.IsNullOrWhiteSpace(txtBillNumber.Text))
        {
            MessageBox.Show("Please enter a bill number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtBillNumber.Focus();
            return false;
        }

        if (cmbMonth.SelectedValue == null)
        {
            MessageBox.Show("Please select a month.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbMonth.Focus();
            return false;
        }

        if (cmbYear.SelectedValue == null)
        {
            MessageBox.Show("Please select a year.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbYear.Focus();
            return false;
        }

        if (!decimal.TryParse(txtUnits.Text, out decimal units) || units <= 0)
        {
            MessageBox.Show("Please enter valid units consumed.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtUnits.Focus();
            return false;
        }

        if (!decimal.TryParse(txtUnitsRate.Text, out decimal rate) || rate <= 0)
        {
            MessageBox.Show("Please enter valid rate per unit.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtUnitsRate.Focus();
            return false;
        }

        if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Please enter valid amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtAmount.Focus();
            return false;
        }

        if (!dpDueDate.SelectedDate.HasValue)
        {
            MessageBox.Show("Please select a due date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpDueDate.Focus();
            return false;
        }

        if (chkIsPaid.IsChecked == true)
        {
            if (!dpPaidDate.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a paid date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                dpPaidDate.Focus();
                return false;
            }

            if (cmbPaymentMethod.SelectedValue == null)
            {
                MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbPaymentMethod.Focus();
                return false;
            }
        }

        return true;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}