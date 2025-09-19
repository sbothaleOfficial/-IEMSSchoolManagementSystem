using System.Windows;
using System.Windows.Controls;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.Core.Enums;

namespace IEMS.WPF;

public partial class AddEditOtherExpenseWindow : Window
{
    private readonly OtherExpenseService _otherExpenseService;
    private readonly int? _expenseId;
    private OtherExpenseDto? _currentExpense;

    public AddEditOtherExpenseWindow(OtherExpenseService otherExpenseService, int? expenseId = null)
    {
        InitializeComponent();
        _otherExpenseService = otherExpenseService;
        _expenseId = expenseId;

        InitializeWindow();
    }

    private async void InitializeWindow()
    {
        try
        {
            InitializeComboBoxes();

            if (_expenseId.HasValue)
            {
                lblTitle.Text = "Edit Other Expense";
                _currentExpense = await _otherExpenseService.GetByIdAsync(_expenseId.Value);
                if (_currentExpense != null)
                {
                    PopulateForm(_currentExpense);
                }
                else
                {
                    MessageBox.Show("Other expense not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Close();
                }
            }
            else
            {
                lblTitle.Text = "Add Other Expense";
                dpExpenseDate.SelectedDate = DateTime.Now;
                cmbPaymentMethod.SelectedValue = PaymentMethod.CASH;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void InitializeComboBoxes()
    {
        // Initialize categories
        var categories = Enum.GetValues<OtherExpenseCategory>()
            .Select(c => new { Value = c, Display = c.ToString().Replace("_", " ") })
            .ToList();
        cmbCategory.ItemsSource = categories;
        cmbCategory.DisplayMemberPath = "Display";
        cmbCategory.SelectedValuePath = "Value";

        // Initialize payment methods
        cmbPaymentMethod.ItemsSource = Enum.GetValues<PaymentMethod>();
    }

    private void PopulateForm(OtherExpenseDto expense)
    {
        cmbCategory.SelectedValue = expense.Category;
        txtExpenseType.Text = expense.ExpenseType;
        txtDescription.Text = expense.Description;
        txtAmount.Text = expense.Amount.ToString();
        dpExpenseDate.SelectedDate = expense.ExpenseDate;
        txtVendorName.Text = expense.VendorName;
        txtInvoiceNumber.Text = expense.InvoiceNumber;
        cmbPaymentMethod.SelectedValue = expense.PaymentMethod;
        txtTransactionId.Text = expense.TransactionId;
        txtBankName.Text = expense.BankName;
        txtChequeNumber.Text = expense.ChequeNumber;
        txtNotes.Text = expense.Notes;
    }

    private void CmbPaymentMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbPaymentMethod.SelectedValue is PaymentMethod method)
        {
            // Enable/disable fields based on payment method
            txtTransactionId.IsEnabled = method == PaymentMethod.ONLINE;
            txtBankName.IsEnabled = method == PaymentMethod.CHEQUE || method == PaymentMethod.DD;
            txtChequeNumber.IsEnabled = method == PaymentMethod.CHEQUE || method == PaymentMethod.DD;

            // Clear disabled fields
            if (!txtTransactionId.IsEnabled) txtTransactionId.Clear();
            if (!txtBankName.IsEnabled) txtBankName.Clear();
            if (!txtChequeNumber.IsEnabled) txtChequeNumber.Clear();
        }
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!ValidateForm())
                return;

            var expenseDto = new OtherExpenseDto
            {
                Id = _currentExpense?.Id ?? 0,
                Category = (OtherExpenseCategory)cmbCategory.SelectedValue,
                ExpenseType = txtExpenseType.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Amount = decimal.Parse(txtAmount.Text),
                ExpenseDate = dpExpenseDate.SelectedDate!.Value,
                VendorName = txtVendorName.Text.Trim(),
                InvoiceNumber = txtInvoiceNumber.Text.Trim(),
                PaymentMethod = (PaymentMethod)cmbPaymentMethod.SelectedValue,
                TransactionId = txtTransactionId.Text.Trim(),
                BankName = txtBankName.Text.Trim(),
                ChequeNumber = txtChequeNumber.Text.Trim(),
                Notes = txtNotes.Text.Trim()
            };

            if (_expenseId.HasValue)
            {
                await _otherExpenseService.UpdateAsync(expenseDto);
            }
            else
            {
                await _otherExpenseService.CreateAsync(expenseDto);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving other expense: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateForm()
    {
        if (cmbCategory.SelectedValue == null)
        {
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbCategory.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtExpenseType.Text))
        {
            MessageBox.Show("Please enter an expense type.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtExpenseType.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            MessageBox.Show("Please enter a description.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtDescription.Focus();
            return false;
        }

        if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtAmount.Focus();
            return false;
        }

        if (!dpExpenseDate.SelectedDate.HasValue)
        {
            MessageBox.Show("Please select an expense date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpExpenseDate.Focus();
            return false;
        }

        if (cmbPaymentMethod.SelectedValue == null)
        {
            MessageBox.Show("Please select a payment method.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbPaymentMethod.Focus();
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