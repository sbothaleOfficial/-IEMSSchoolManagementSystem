using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class TeachersManagementWindow : Window
{
    private readonly TeacherService _teacherService;
    private readonly ClassService _classService;

    public TeachersManagementWindow(TeacherService teacherService, ClassService classService)
    {
        InitializeComponent();
        _teacherService = teacherService;
        _classService = classService;
        LoadTeachers();
    }

    private async void LoadTeachers()
    {
        try
        {
            lblStatus.Text = "Loading teachers...";
            var teachers = await _teacherService.GetAllTeachersAsync();
            dgTeachers.ItemsSource = teachers;
            lblStatus.Text = $"Loaded {teachers.Count()} teachers";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading teachers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading teachers";
        }
    }

    private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditTeacherWindow(_teacherService);
        if (addWindow.ShowDialog() == true)
        {
            LoadTeachers();
        }
    }

    private void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
    {
        if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
        {
            var editWindow = new AddEditTeacherWindow(_teacherService, selectedTeacher);
            if (editWindow.ShowDialog() == true)
            {
                LoadTeachers();
            }
        }
        else
        {
            MessageBox.Show("Please select a teacher to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
    {
        if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
        {
            var result = MessageBox.Show($"Are you sure you want to delete teacher {selectedTeacher.FullName}?",
                                       "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _teacherService.DeleteTeacherAsync(selectedTeacher.Id);
                    LoadTeachers();
                    lblStatus.Text = "Teacher deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting teacher: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a teacher to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnRefreshTeachers_Click(object sender, RoutedEventArgs e)
    {
        LoadTeachers();
    }
}