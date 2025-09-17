using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class AddEditTeacherWindow : Window
{
    private readonly TeacherService _teacherService;
    private readonly TeacherDto? _teacherToEdit;

    public AddEditTeacherWindow(TeacherService teacherService, TeacherDto? teacherToEdit = null)
    {
        InitializeComponent();
        _teacherService = teacherService;
        _teacherToEdit = teacherToEdit;

        LoadTeacherData();

        Title = teacherToEdit == null ? "Add Class Teacher" : "Edit Class Teacher";
    }

    private void LoadTeacherData()
    {
        if (_teacherToEdit != null)
        {
            txtEmployeeId.Text = _teacherToEdit.EmployeeId;
            txtFirstName.Text = _teacherToEdit.FirstName;
            txtLastName.Text = _teacherToEdit.LastName;
            txtPhoneNumber.Text = _teacherToEdit.PhoneNumber;
            txtAddress.Text = _teacherToEdit.Address;
            dpJoiningDate.SelectedDate = _teacherToEdit.JoiningDate;
            txtMonthlySalary.Text = _teacherToEdit.MonthlySalary.ToString("F2");

            txtEmail.Text = _teacherToEdit.Email ?? "";
            txtBankAccount.Text = _teacherToEdit.BankAccountNumber ?? "";
            txtAadharNumber.Text = _teacherToEdit.AadharNumber ?? "";
            txtPANNumber.Text = _teacherToEdit.PANNumber ?? "";
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
            var teacherDto = new TeacherDto
            {
                Id = _teacherToEdit?.Id ?? 0,
                EmployeeId = txtEmployeeId.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                JoiningDate = dpJoiningDate.SelectedDate ?? DateTime.Today,
                MonthlySalary = decimal.TryParse(txtMonthlySalary.Text.Trim(), out var salary) ? salary : 0,
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                BankAccountNumber = string.IsNullOrWhiteSpace(txtBankAccount.Text) ? null : txtBankAccount.Text.Trim(),
                AadharNumber = string.IsNullOrWhiteSpace(txtAadharNumber.Text) ? null : txtAadharNumber.Text.Trim(),
                PANNumber = string.IsNullOrWhiteSpace(txtPANNumber.Text) ? null : txtPANNumber.Text.Trim()
            };

            // Check for unique employee ID
            if (!await _teacherService.IsEmployeeIdUniqueAsync(teacherDto.EmployeeId, teacherDto.Id == 0 ? null : teacherDto.Id))
            {
                MessageBox.Show("Employee ID already exists. Please choose a different one.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmployeeId.Focus();
                return;
            }

            if (_teacherToEdit == null)
            {
                await _teacherService.AddTeacherAsync(teacherDto);
                MessageBox.Show("Class Teacher added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _teacherService.UpdateTeacherAsync(teacherDto);
                MessageBox.Show("Class Teacher updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving class teacher: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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