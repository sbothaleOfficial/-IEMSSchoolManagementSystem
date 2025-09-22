using System.Linq;
using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Enums;
using IEMS.WPF.Helpers;

namespace IEMS.WPF;

public partial class AddEditVehicleWindow : Window
{
    private readonly VehicleService _vehicleService;
    private readonly VehicleDto? _existingVehicle;
    private readonly bool _isEditMode;

    public AddEditVehicleWindow(VehicleService vehicleService, VehicleDto? existingVehicle = null)
    {
        try
        {
            InitializeComponent();

            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _existingVehicle = existingVehicle;
            _isEditMode = existingVehicle != null;

            this.Loaded += AddEditVehicleWindow_Loaded;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing vehicle window: {ex.Message}", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }

    private void AddEditVehicleWindow_Loaded(object sender, RoutedEventArgs e)
    {
        LoadVehicleTypes();

        if (_isEditMode)
        {
            lblWindowTitle.Text = "Edit Vehicle";
            btnSave.Content = "Update Vehicle";
            LoadVehicleData();
        }
    }

    private void LoadVehicleTypes()
    {
        var vehicleTypes = Enum.GetValues<VehicleType>().Select(vt => new
        {
            Value = vt,
            Display = vt.ToString()
        }).ToList();

        cmbVehicleType.ItemsSource = vehicleTypes;
        cmbVehicleType.DisplayMemberPath = "Display";
        cmbVehicleType.SelectedValuePath = "Value";

        if (!_isEditMode)
        {
            cmbVehicleType.SelectedIndex = 0;
        }
    }

    private void LoadVehicleData()
    {
        if (_existingVehicle != null)
        {
            txtVehicleNumber.Text = _existingVehicle.VehicleNumber;
            cmbVehicleType.SelectedValue = _existingVehicle.VehicleType;
            txtDriverName.Text = _existingVehicle.DriverName;
            txtDriverPhone.Text = _existingVehicle.DriverPhone;
            txtRoute.Text = _existingVehicle.Route;
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
                var updateDto = new UpdateVehicleDto
                {
                    Id = _existingVehicle!.Id,
                    VehicleNumber = txtVehicleNumber.Text.Trim().ToUpper(),
                    VehicleType = (VehicleType)cmbVehicleType.SelectedValue,
                    DriverName = txtDriverName.Text.Trim(),
                    DriverPhone = txtDriverPhone.Text.Trim(),
                    Route = txtRoute.Text.Trim()
                };

                await _vehicleService.UpdateVehicleAsync(updateDto);

                MessageBox.Show($"Vehicle '{updateDto.VehicleNumber}' updated successfully!",
                              "Update Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var createDto = new CreateVehicleDto
                {
                    VehicleNumber = txtVehicleNumber.Text.Trim().ToUpper(),
                    VehicleType = (VehicleType)cmbVehicleType.SelectedValue,
                    DriverName = txtDriverName.Text.Trim(),
                    DriverPhone = txtDriverPhone.Text.Trim(),
                    Route = txtRoute.Text.Trim()
                };

                var createdVehicle = await _vehicleService.CreateVehicleAsync(createDto);

                MessageBox.Show($"Vehicle '{createdVehicle.VehicleNumber}' added successfully!",
                              "Add Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            ShowValidationError($"Error saving vehicle: {ex.Message}");
        }
        finally
        {
            btnSave.IsEnabled = true;
            btnSave.Content = _isEditMode ? "Update Vehicle" : "Save Vehicle";
        }
    }

    private bool ValidateInput()
    {
        // Vehicle Number validation
        if (string.IsNullOrWhiteSpace(txtVehicleNumber.Text))
        {
            ShowValidationError("Vehicle Number is required.");
            txtVehicleNumber.Focus();
            return false;
        }

        if (txtVehicleNumber.Text.Trim().Length < 5)
        {
            ShowValidationError("Vehicle Number must be at least 5 characters long.");
            txtVehicleNumber.Focus();
            return false;
        }

        // Vehicle Type validation
        if (cmbVehicleType.SelectedValue == null)
        {
            ShowValidationError("Please select a Vehicle Type.");
            cmbVehicleType.Focus();
            return false;
        }

        // Driver Name validation
        if (string.IsNullOrWhiteSpace(txtDriverName.Text))
        {
            ShowValidationError("Driver Name is required.");
            txtDriverName.Focus();
            return false;
        }

        if (txtDriverName.Text.Trim().Length < 2)
        {
            ShowValidationError("Driver Name must be at least 2 characters long.");
            txtDriverName.Focus();
            return false;
        }

        // Phone validation (optional but if provided, should be valid)
        if (!string.IsNullOrWhiteSpace(txtDriverPhone.Text))
        {
            var phone = txtDriverPhone.Text.Trim();
            // Remove any spaces, dashes, or other formatting characters
            var cleanPhone = new string(phone.Where(char.IsDigit).ToArray());

            if (cleanPhone.Length < 10)
            {
                ShowValidationError("Driver Phone should be at least 10 digits.");
                txtDriverPhone.Focus();
                return false;
            }
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