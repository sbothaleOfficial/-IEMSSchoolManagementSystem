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

        LoadSubjects();
        LoadTeacherData();

        Title = teacherToEdit == null ? "Add Teacher" : "Edit Teacher";
    }

    private void LoadSubjects()
    {
        var subjects = new[]
        {
            "Mathematics",
            "English",
            "Science",
            "History",
            "Geography",
            "Physics",
            "Chemistry",
            "Biology",
            "Computer Science",
            "Art",
            "Music",
            "Physical Education"
        };

        cmbSubject.ItemsSource = subjects;
    }

    private void LoadTeacherData()
    {
        if (_teacherToEdit != null)
        {
            txtEmployeeId.Text = _teacherToEdit.EmployeeId;
            txtFirstName.Text = _teacherToEdit.FirstName;
            txtLastName.Text = _teacherToEdit.LastName;
            txtEmail.Text = _teacherToEdit.Email;
            cmbSubject.Text = _teacherToEdit.Subject;
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
                Email = txtEmail.Text.Trim(),
                Subject = cmbSubject.Text.Trim()
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
                MessageBox.Show("Teacher added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _teacherService.UpdateTeacherAsync(teacherDto);
                MessageBox.Show("Teacher updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving teacher: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Email is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return false;
        }

        if (!IsValidEmail(txtEmail.Text))
        {
            MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtEmail.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbSubject.Text))
        {
            MessageBox.Show("Subject is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbSubject.Focus();
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