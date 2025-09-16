using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class StudentsManagementWindow : Window
{
    private readonly StudentService _studentService;
    private readonly ClassService _classService;
    private readonly TeacherService _teacherService;
    private List<StudentDto> _allStudents = new List<StudentDto>();

    public StudentsManagementWindow(StudentService studentService, ClassService classService, TeacherService teacherService)
    {
        InitializeComponent();
        _studentService = studentService;
        _classService = classService;
        _teacherService = teacherService;
        LoadStudents();
        LoadClasses();
    }

    private async void LoadStudents()
    {
        try
        {
            lblStatus.Text = "Loading students...";
            var students = await _studentService.GetAllStudentsAsync();
            _allStudents = students.ToList();
            dgStudents.ItemsSource = _allStudents;
            lblStatus.Text = $"Loaded {students.Count()} students";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading students";
        }
    }

    private async void LoadClasses()
    {
        try
        {
            lblStatus.Text = "Loading classes...";
            var classes = await _classService.GetAllClassesAsync();
            dgClasses.ItemsSource = classes;
            lblStatus.Text = $"Loaded {classes.Count()} classes";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading classes";
        }
    }

    // Student Management Events
    private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditStudentWindow(_studentService, _classService);
        if (addWindow.ShowDialog() == true)
        {
            var currentSearch = txtSearchStudents.Text;
            LoadStudents();
            LoadClasses(); // Refresh to update student counts in classes
            txtSearchStudents.Text = currentSearch; // Restore search after refresh
            FilterStudents();
        }
    }

    private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
    {
        if (dgStudents.SelectedItem is StudentDto selectedStudent)
        {
            var editWindow = new AddEditStudentWindow(_studentService, _classService, selectedStudent);
            if (editWindow.ShowDialog() == true)
            {
                var currentSearch = txtSearchStudents.Text;
                LoadStudents();
                LoadClasses(); // Refresh to update student counts in classes
                txtSearchStudents.Text = currentSearch; // Restore search after refresh
                FilterStudents();
            }
        }
        else
        {
            MessageBox.Show("Please select a student to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
    {
        if (dgStudents.SelectedItem is StudentDto selectedStudent)
        {
            var result = MessageBox.Show($"Are you sure you want to delete student {selectedStudent.FullName}?",
                                       "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _studentService.DeleteStudentAsync(selectedStudent.Id);
                    var currentSearch = txtSearchStudents.Text;
                    LoadStudents();
                    LoadClasses(); // Refresh to update student counts in classes
                    txtSearchStudents.Text = currentSearch; // Restore search after refresh
                    FilterStudents();
                    lblStatus.Text = "Student deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting student: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnRefreshStudents_Click(object sender, RoutedEventArgs e)
    {
        LoadStudents();
        txtSearchStudents.Text = ""; // Clear search when refreshing
    }

    // Class Management Events
    private void BtnAddClass_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditClassWindow(_classService, _teacherService);
        if (addWindow.ShowDialog() == true)
        {
            LoadClasses();
        }
    }

    private void BtnEditClass_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            var editWindow = new AddEditClassWindow(_classService, _teacherService, selectedClass);
            if (editWindow.ShowDialog() == true)
            {
                LoadClasses();
            }
        }
        else
        {
            MessageBox.Show("Please select a class to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async void BtnDeleteClass_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            var result = MessageBox.Show($"Are you sure you want to delete class {selectedClass.DisplayName}?",
                                       "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _classService.DeleteClassAsync(selectedClass.Id);
                    LoadClasses();
                    lblStatus.Text = "Class deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting class: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a class to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnRefreshClasses_Click(object sender, RoutedEventArgs e)
    {
        LoadClasses();
    }

    private async void BtnViewClassStudents_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                var classStudents = students.Where(s => s.ClassId == selectedClass.Id).ToList();

                var message = classStudents.Any()
                    ? $"Students in {selectedClass.DisplayName}:\n\n" +
                      string.Join("\n", classStudents.Select(s => $"• {s.StudentNumber} - {s.FullName}"))
                    : $"No students enrolled in {selectedClass.DisplayName}";

                MessageBox.Show(message, $"Students in {selectedClass.DisplayName}", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Please select a class to view students.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    // Search Functionality
    private void TxtSearchStudents_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        FilterStudents();
    }

    private void FilterStudents()
    {
        if (_allStudents == null || !_allStudents.Any())
            return;

        var searchText = txtSearchStudents.Text.Trim().ToLower();

        if (string.IsNullOrEmpty(searchText))
        {
            // Show all students if search is empty
            dgStudents.ItemsSource = _allStudents;
            lblStatus.Text = $"Showing all {_allStudents.Count} students";
            return;
        }

        // Filter students based on multiple criteria
        var filteredStudents = _allStudents.Where(student =>
            student.FirstName.ToLower().Contains(searchText) ||
            student.Surname.ToLower().Contains(searchText) ||
            student.FullName.ToLower().Contains(searchText) ||
            student.FatherName.ToLower().Contains(searchText) ||
            student.MotherName.ToLower().Contains(searchText) ||
            student.StudentNumber.ToLower().Contains(searchText) ||
            student.ParentMobileNumber.ToLower().Contains(searchText) ||
            student.Standard.ToLower().Contains(searchText) ||
            student.ClassDivision.ToLower().Contains(searchText) ||
            student.Address.ToLower().Contains(searchText)
        ).ToList();

        dgStudents.ItemsSource = filteredStudents;
        lblStatus.Text = $"Found {filteredStudents.Count} students matching '{txtSearchStudents.Text}'";
    }
}