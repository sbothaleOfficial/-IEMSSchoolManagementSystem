using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.WPF.Helpers;

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
        AsyncHelper.SafeFireAndForget(LoadTeachersAsync, "Teacher Management Error");
    }

    private async Task LoadTeachersAsync()
    {
        lblStatus.Text = "Loading teachers...";
        var teachers = await _teacherService.GetAllTeachersAsync();
        dgTeachers.ItemsSource = teachers;
        lblStatus.Text = $"Loaded {teachers.Count()} teachers";
    }

    private void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditTeacherWindow(_teacherService);
        if (addWindow.ShowDialog() == true)
        {
            AsyncHelper.SafeFireAndForget(LoadTeachersAsync, "Teacher Management Error");
        }
    }

    private void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
    {
        if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
        {
            var editWindow = new AddEditTeacherWindow(_teacherService, selectedTeacher);
            if (editWindow.ShowDialog() == true)
            {
                AsyncHelper.SafeFireAndForget(LoadTeachersAsync, "Teacher Management Error");
            }
        }
        else
        {
            MessageBox.Show("Please select a teacher to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
    {
        if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
        {
            AsyncHelper.SafeFireAndForget(async () => await DeleteTeacherAsync(selectedTeacher), "Delete Teacher Error");
        }
        else
        {
            MessageBox.Show("Please select a teacher to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async Task DeleteTeacherAsync(TeacherDto selectedTeacher)
    {
        var result = MessageBox.Show($"Are you sure you want to delete teacher {selectedTeacher.FullName}?",
                                   "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            await _teacherService.DeleteTeacherAsync(selectedTeacher.Id);
            await LoadTeachersAsync();
            lblStatus.Text = "Teacher deleted successfully";
        }
    }

    private void BtnRefreshTeachers_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadTeachersAsync, "Teacher Management Error");
    }
}