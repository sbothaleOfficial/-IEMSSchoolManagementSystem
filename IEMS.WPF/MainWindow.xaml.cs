using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class MainWindow : Window
{
    private readonly StudentService _studentService;

    public MainWindow(StudentService studentService)
    {
        InitializeComponent();
        _studentService = studentService;
        LoadStudents();
    }

    private async void LoadStudents()
    {
        try
        {
            lblStatus.Text = "Loading students...";
            var students = await _studentService.GetAllStudentsAsync();
            dgStudents.ItemsSource = students;
            lblStatus.Text = $"Loaded {students.Count()} students";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading students";
        }
    }

    private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditStudentWindow(_studentService);
        if (addWindow.ShowDialog() == true)
        {
            LoadStudents();
        }
    }

    private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
    {
        if (dgStudents.SelectedItem is StudentDto selectedStudent)
        {
            var editWindow = new AddEditStudentWindow(_studentService, selectedStudent);
            if (editWindow.ShowDialog() == true)
            {
                LoadStudents();
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
            var result = MessageBox.Show($"Are you sure you want to delete student {selectedStudent.FirstName} {selectedStudent.LastName}?",
                                       "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _studentService.DeleteStudentAsync(selectedStudent.Id);
                    LoadStudents();
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
    }
}