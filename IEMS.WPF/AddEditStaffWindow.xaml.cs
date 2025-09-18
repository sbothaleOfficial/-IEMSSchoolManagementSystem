using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class AddEditStaffWindow : Window
{
    private readonly StaffService _staffService;
    private readonly StaffDto? _staffToEdit;

    public AddEditStaffWindow(StaffService staffService, StaffDto? staffToEdit = null)
    {
        InitializeComponent();
        _staffService = staffService;
        _staffToEdit = staffToEdit;

        LoadStaffData();

        Title = staffToEdit == null ? "Add Staff Member" : "Edit Staff Member";
    }

    private void LoadStaffData()
    {
        if (_staffToEdit != null)
        {
            txtEmployeeId.Text = _staffToEdit.EmployeeId;
            txtFirstName.Text = _staffToEdit.FirstName;
            txtLastName.Text = _staffToEdit.LastName;
            txtPhoneNumber.Text = _staffToEdit.PhoneNumber;
            txtAddress.Text = _staffToEdit.Address;
            dpJoiningDate.SelectedDate = _staffToEdit.JoiningDate;
            txtMonthlySalary.Text = _staffToEdit.MonthlySalary.ToString("F2");
            cmbPosition.Text = _staffToEdit.Position;

            txtEmail.Text = _staffToEdit.Email ?? "";
            txtBankAccount.Text = _staffToEdit.BankAccountNumber ?? "";
            txtAadharNumber.Text = _staffToEdit.AadharNumber ?? "";
            txtPANNumber.Text = _staffToEdit.PANNumber ?? "";
        }
        else
        {
            dpJoiningDate.SelectedDate = DateTime.Today;
        }
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            var staffDto = new StaffDto
            {
                Id = _staffToEdit?.Id ?? 0,
                EmployeeId = txtEmployeeId.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                JoiningDate = dpJoiningDate.SelectedDate ?? DateTime.Today,
                MonthlySalary = decimal.TryParse(txtMonthlySalary.Text.Trim(), out var salary) ? salary : 0,
                Position = cmbPosition.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                BankAccountNumber = string.IsNullOrWhiteSpace(txtBankAccount.Text) ? null : txtBankAccount.Text.Trim(),
                AadharNumber = string.IsNullOrWhiteSpace(txtAadharNumber.Text) ? null : txtAadharNumber.Text.Trim(),
                PANNumber = string.IsNullOrWhiteSpace(txtPANNumber.Text) ? null : txtPANNumber.Text.Trim()
            };

            // Check for unique employee ID
            if (!await _staffService.IsEmployeeIdUniqueAsync(staffDto.EmployeeId, staffDto.Id == 0 ? null : staffDto.Id))
            {
                MessageBox.Show("Employee ID already exists. Please choose a different one.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmployeeId.Focus();
                return;
            }

            if (_staffToEdit == null)
            {
                await _staffService.CreateStaffAsync(staffDto);
                MessageBox.Show("Staff member added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _staffService.UpdateStaffAsync(staffDto);
                MessageBox.Show("Staff member updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving staff member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private bool ValidateInput()
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

        if (string.IsNullOrWhiteSpace(txtAddress.Text))
        {
            MessageBox.Show("Address is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtAddress.Focus();
            return false;
        }

        if (!dpJoiningDate.SelectedDate.HasValue)
        {
            MessageBox.Show("Joining date is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpJoiningDate.Focus();
            return false;
        }

        if (!decimal.TryParse(txtMonthlySalary.Text.Trim(), out var salary) || salary < 0)
        {
            MessageBox.Show("Please enter a valid monthly salary.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtMonthlySalary.Focus();
            txtMonthlySalary.SelectAll();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbPosition.Text))
        {
            MessageBox.Show("Position is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbPosition.Focus();
            return false;
        }

        // Optional field validations
        if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text.Trim()))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
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
}