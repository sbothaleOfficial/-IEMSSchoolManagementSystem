using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Enums;
using IEMS.WPF.Helpers;

namespace IEMS.WPF;

public partial class AddEditTransportExpenseWindow : Window
{
    private readonly TransportExpenseService _expenseService;
    private readonly VehicleService _vehicleService;
    private readonly TransportExpenseDto? _existingExpense;
    private readonly bool _isEditMode;

    public AddEditTransportExpenseWindow(
        TransportExpenseService expenseService,
        VehicleService vehicleService,
        TransportExpenseDto? existingExpense = null)
    {
        try
        {
            InitializeComponent();

            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));
            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _existingExpense = existingExpense;
            _isEditMode = existingExpense != null;

            this.Loaded += (s, e) => AsyncHelper.SafeFireAndForget(LoadWindowAsync);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing expense window: {ex.Message}", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }

    private async Task LoadWindowAsync()
    {
        await LoadComboBoxData();

        if (_isEditMode)
        {
            lblWindowTitle.Text = "Edit Transport Expense";
            btnSave.Content = "Update Expense";
            LoadExpenseData();
        }
        else
        {
            // Set default date to today
            dpExpenseDate.SelectedDate = DateTime.Today;
        }
    }

    private async Task LoadComboBoxData()
    {
        try
        {
            // Load vehicles
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            var vehicleItems = vehicles.Select(v => new
            {
                Id = v.Id,
                DisplayText = $"{v.VehicleNumber} - {v.VehicleTypeName}" +
                              (string.IsNullOrWhiteSpace(v.DriverName) ? "" : $" ({v.DriverName})")
            }).ToList();

            vehicleItems.Insert(0, new { Id = 0, DisplayText = "-- Select Vehicle --" });

            cmbVehicle.ItemsSource = vehicleItems;
            cmbVehicle.SelectedIndex = 0;

            // Load categories
            var categories = Enum.GetValues<ExpenseCategory>().Select(c => new
            {
                Value = c,
                Display = c.ToString()
            }).ToList();

            categories.Insert(0, new { Value = (ExpenseCategory)(-1), Display = "-- Select Category --" });

            cmbCategory.ItemsSource = categories;
            cmbCategory.SelectedIndex = 0;

            // Load fuel types
            var fuelTypes = new List<dynamic> { new { Value = (FuelType?)null, Display = "-- Select Fuel Type --" } };
            fuelTypes.AddRange(Enum.GetValues<FuelType>().Select(f => new { Value = (FuelType?)f, Display = f.ToString() }));

            cmbFuelType.ItemsSource = fuelTypes;
            cmbFuelType.SelectedIndex = 0;

            // Initially disable fuel type (enabled only for FUEL category)
            cmbFuelType.IsEnabled = false;
        }
        catch (Exception ex)
        {
            ShowValidationError($"Error loading data: {ex.Message}");
        }
    }

    private void LoadExpenseData()
    {
        if (_existingExpense != null)
        {
            cmbVehicle.SelectedValue = _existingExpense.VehicleId;
            cmbCategory.SelectedValue = _existingExpense.Category;
            cmbFuelType.SelectedValue = _existingExpense.FuelType;
            txtAmount.Text = _existingExpense.Amount.ToString("F2");
            txtQuantity.Text = _existingExpense.Quantity.ToString("F2");
            dpExpenseDate.SelectedDate = _existingExpense.ExpenseDate;
            txtDriverName.Text = _existingExpense.DriverName;
            txtDescription.Text = _existingExpense.Description;
            txtInvoiceNumber.Text = _existingExpense.InvoiceNumber;

            // Calculate and display price per unit
            CalculatePricePerUnit();
        }
    }

    private void CmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cmbCategory.SelectedValue != null && (int)cmbCategory.SelectedValue != -1)
        {
            var selectedCategory = (ExpenseCategory)cmbCategory.SelectedValue;

            // Enable fuel type only for FUEL category
            if (selectedCategory == ExpenseCategory.FUEL)
            {
                cmbFuelType.IsEnabled = true;
            }
            else
            {
                cmbFuelType.IsEnabled = false;
                cmbFuelType.SelectedIndex = 0; // Reset to "-- Select Fuel Type --"
            }
        }
        else
        {
            cmbFuelType.IsEnabled = false;
            cmbFuelType.SelectedIndex = 0;
        }
    }

    private void AmountQuantity_TextChanged(object sender, TextChangedEventArgs e)
    {
        CalculatePricePerUnit();
    }

    private void CalculatePricePerUnit()
    {
        try
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) &&
                decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
                quantity > 0)
            {
                var pricePerUnit = amount / quantity;
                txtPricePerUnit.Text = $"₹{pricePerUnit:F2}";
            }
            else
            {
                txtPricePerUnit.Text = "₹0.00";
            }
        }
        catch
        {
            txtPricePerUnit.Text = "₹0.00";
        }
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(SaveAsync);
    }

    private async Task SaveAsync()
    {
        if (!ValidateInput()) return;

        try
        {
            btnSave.IsEnabled = false;
            btnSave.Content = _isEditMode ? "Updating..." : "Saving...";

            if (_isEditMode)
            {
                var updateDto = new UpdateTransportExpenseDto
                {
                    Id = _existingExpense!.Id,
                    VehicleId = (int)cmbVehicle.SelectedValue,
                    Category = (ExpenseCategory)cmbCategory.SelectedValue,
                    FuelType = cmbFuelType.IsEnabled && cmbFuelType.SelectedValue != null ? (FuelType?)cmbFuelType.SelectedValue : null,
                    Amount = decimal.Parse(txtAmount.Text),
                    Quantity = decimal.Parse(txtQuantity.Text),
                    ExpenseDate = dpExpenseDate.SelectedDate!.Value,
                    DriverName = txtDriverName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    InvoiceNumber = txtInvoiceNumber.Text.Trim()
                };

                await _expenseService.UpdateExpenseAsync(updateDto);

                MessageBox.Show($"Transport expense updated successfully!\n\nAmount: ₹{updateDto.Amount:F2}\nVehicle: {((dynamic)cmbVehicle.SelectedItem).DisplayText}",
                              "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var createDto = new CreateTransportExpenseDto
                {
                    VehicleId = (int)cmbVehicle.SelectedValue,
                    Category = (ExpenseCategory)cmbCategory.SelectedValue,
                    FuelType = cmbFuelType.IsEnabled && cmbFuelType.SelectedValue != null ? (FuelType?)cmbFuelType.SelectedValue : null,
                    Amount = decimal.Parse(txtAmount.Text),
                    Quantity = decimal.Parse(txtQuantity.Text),
                    ExpenseDate = dpExpenseDate.SelectedDate!.Value,
                    DriverName = txtDriverName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    InvoiceNumber = txtInvoiceNumber.Text.Trim()
                };

                var createdExpense = await _expenseService.CreateExpenseAsync(createDto);

                MessageBox.Show($"Transport expense added successfully!\n\nAmount: ₹{createdExpense.Amount:F2}\nPrice per Unit: ₹{createdExpense.PricePerUnit:F2}\nVehicle: {createdExpense.VehicleNumber}",
                              "Add Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            ShowValidationError($"Error saving expense: {ex.Message}");
        }
        finally
        {
            btnSave.IsEnabled = true;
            btnSave.Content = _isEditMode ? "Update Expense" : "Save Expense";
        }
    }

    private bool ValidateInput()
    {
        // Vehicle validation
        if (cmbVehicle.SelectedValue == null || (int)cmbVehicle.SelectedValue <= 0)
        {
            ShowValidationError("Please select a vehicle.");
            cmbVehicle.Focus();
            return false;
        }

        // Category validation
        if (cmbCategory.SelectedValue == null || (int)cmbCategory.SelectedValue == -1)
        {
            ShowValidationError("Please select an expense category.");
            cmbCategory.Focus();
            return false;
        }

        // Fuel type validation for FUEL category
        var selectedCategory = (ExpenseCategory)cmbCategory.SelectedValue;
        if (selectedCategory == ExpenseCategory.FUEL &&
            (cmbFuelType.SelectedValue == null || cmbFuelType.SelectedValue.Equals(null)))
        {
            ShowValidationError("Please select a fuel type for fuel expenses.");
            cmbFuelType.Focus();
            return false;
        }

        // Amount validation
        if (string.IsNullOrWhiteSpace(txtAmount.Text))
        {
            ShowValidationError("Amount is required.");
            txtAmount.Focus();
            return false;
        }

        if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
        {
            ShowValidationError("Please enter a valid amount greater than zero.");
            txtAmount.Focus();
            return false;
        }

        // Quantity validation
        if (string.IsNullOrWhiteSpace(txtQuantity.Text))
        {
            ShowValidationError("Quantity is required.");
            txtQuantity.Focus();
            return false;
        }

        if (!decimal.TryParse(txtQuantity.Text, out decimal quantity) || quantity <= 0)
        {
            ShowValidationError("Please enter a valid quantity greater than zero.");
            txtQuantity.Focus();
            return false;
        }

        // Date validation
        if (!dpExpenseDate.SelectedDate.HasValue)
        {
            ShowValidationError("Please select an expense date.");
            dpExpenseDate.Focus();
            return false;
        }

        if (dpExpenseDate.SelectedDate.Value > DateTime.Today)
        {
            ShowValidationError("Expense date cannot be in the future.");
            dpExpenseDate.Focus();
            return false;
        }

        HideValidationError();
        return true;
    }

    private void ShowValidationError(string message)
    {
        lblValidationMessage.Text = message;
        borderValidation.Visibility = Visibility.Visible;
    }

    private void HideValidationError()
    {
        borderValidation.Visibility = Visibility.Collapsed;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}