using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class AddEditStaffWindow : Window
{
    private readonly StaffService _staffService;
    private readonly StaffDto? _existingStaff;
    private readonly bool _isEditMode;

    public AddEditStaffWindow(StaffService staffService, StaffDto? existingStaff = null)
    {
        InitializeComponent();
        _staffService = staffService;
        _existingStaff = existingStaff;
        _isEditMode = existingStaff != null;

        InitializeForm();
    }

    private void InitializeForm()
    {
        if (_isEditMode && _existingStaff != null)
        {
            lblTitle.Text = "Edit Staff Member";
            PopulateFormFields();
        }
        else
        {
            lblTitle.Text = "Add New Staff Member";
            SetDefaultValues();
        }
    }

    private void SetDefaultValues()
    {
        dpDateOfBirth.SelectedDate = DateTime.Now.AddYears(-25);
    }

    private void PopulateFormFields()
    {
        if (_existingStaff == null) return;

        txtEmployeeId.Text = _existingStaff.EmployeeId;
        txtFirstName.Text = _existingStaff.FirstName;
        txtLastName.Text = _existingStaff.LastName;
        txtPhoneNumber.Text = _existingStaff.PhoneNumber;
        dpDateOfBirth.SelectedDate = _existingStaff.DateOfBirth;

        // Set gender
        cmbGender.Text = _existingStaff.Gender;

        txtAddress.Text = _existingStaff.Address;
        cmbPosition.Text = _existingStaff.Position;
        txtSalary.Text = _existingStaff.Salary.ToString("F2");
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (!ValidateForm())
                return;

            var staffDto = CreateStaffDto();

            if (_isEditMode && _existingStaff != null)
            {
                staffDto.Id = _existingStaff.Id;
                await _staffService.UpdateStaffAsync(staffDto);
                MessageBox.Show("Staff member updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _staffService.CreateStaffAsync(staffDto);
                MessageBox.Show("Staff member added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving staff member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private bool ValidateForm()
    {
        if (string.IsNullOrWhiteSpace(txtEmployeeId.Text))
        {
            MessageBox.Show("Employee ID is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmployeeId.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("First name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtFirstName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtLastName.Focus();
            return false;
        }


        if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
        {
            MessageBox.Show("Phone number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtPhoneNumber.Focus();
            return false;
        }

        if (!dpDateOfBirth.SelectedDate.HasValue)
        {
            MessageBox.Show("Date of birth is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpDateOfBirth.Focus();
            return false;
        }

        if (dpDateOfBirth.SelectedDate.Value > DateTime.Now.AddYears(-16))
        {
            MessageBox.Show("Staff member must be at least 16 years old.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpDateOfBirth.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbGender.Text))
        {
            MessageBox.Show("Gender is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbGender.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbPosition.Text))
        {
            MessageBox.Show("Position is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbPosition.Focus();
            return false;
        }


        if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
        {
            MessageBox.Show("Please enter a valid salary amount.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtSalary.Focus();
            return false;
        }

        return true;
    }

    private StaffDto CreateStaffDto()
    {
        return new StaffDto
        {
            Id = _isEditMode ? _existingStaff!.Id : 0,
            EmployeeId = txtEmployeeId.Text.Trim(),
            FirstName = txtFirstName.Text.Trim(),
            LastName = txtLastName.Text.Trim(),
            PhoneNumber = txtPhoneNumber.Text.Trim(),
            DateOfBirth = dpDateOfBirth.SelectedDate!.Value,
            Gender = cmbGender.Text.Trim(),
            Address = txtAddress.Text.Trim(),
            Position = cmbPosition.Text.Trim(),
            Salary = decimal.Parse(txtSalary.Text)
        };
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}