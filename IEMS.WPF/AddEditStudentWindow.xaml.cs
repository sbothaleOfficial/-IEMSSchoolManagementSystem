using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Interfaces;

namespace IEMS.WPF;

public partial class AddEditStudentWindow : Window
{
    private readonly StudentService _studentService;
    private readonly StudentDto? _studentToEdit;

    public AddEditStudentWindow(StudentService studentService, StudentDto? studentToEdit = null)
    {
        InitializeComponent();
        _studentService = studentService;
        _studentToEdit = studentToEdit;

        LoadClasses();
        LoadStudentData();

        Title = studentToEdit == null ? "Add Student" : "Edit Student";
    }

    private void LoadClasses()
    {
        try
        {
            var classes = new[]
            {
                new { Id = 1, Name = "Grade 10 - A" },
                new { Id = 2, Name = "Grade 10 - B" }
            };

            cmbClass.ItemsSource = classes;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadStudentData()
    {
        if (_studentToEdit != null)
        {
            txtRollNumber.Text = _studentToEdit.RollNumber;
            txtFirstName.Text = _studentToEdit.FirstName;
            txtLastName.Text = _studentToEdit.LastName;
            txtEmail.Text = _studentToEdit.Email;
            dpDateOfBirth.SelectedDate = _studentToEdit.DateOfBirth;
            cmbClass.SelectedValue = _studentToEdit.ClassId;
        }
        else
        {
            dpDateOfBirth.SelectedDate = DateTime.Today.AddYears(-15);
        }
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            var studentDto = new StudentDto
            {
                Id = _studentToEdit?.Id ?? 0,
                RollNumber = txtRollNumber.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Today,
                ClassId = (int)cmbClass.SelectedValue
            };

            if (_studentToEdit == null)
            {
                await _studentService.AddStudentAsync(studentDto);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _studentService.UpdateStudentAsync(studentDto);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtRollNumber.Text))
        {
            MessageBox.Show("Roll number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtRollNumber.Focus();
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

        if (dpDateOfBirth.SelectedDate == null)
        {
            MessageBox.Show("Date of birth is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpDateOfBirth.Focus();
            return false;
        }

        if (cmbClass.SelectedValue == null)
        {
            MessageBox.Show("Class selection is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbClass.Focus();
            return false;
        }

        return true;
    }
}