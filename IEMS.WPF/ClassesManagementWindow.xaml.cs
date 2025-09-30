using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.WPF.Helpers;

namespace IEMS.WPF;

public partial class ClassesManagementWindow : Window
{
    private readonly ClassService _classService;
    private readonly TeacherService _teacherService;
    private readonly StudentService _studentService;

    public ClassesManagementWindow(ClassService classService, TeacherService teacherService, StudentService studentService)
    {
        InitializeComponent();
        _classService = classService;
        _teacherService = teacherService;
        _studentService = studentService;
        AsyncHelper.SafeFireAndForget(LoadClassesAsync, "Classes Management Error");
    }

    private async Task LoadClassesAsync()
    {
        lblStatus.Text = "Loading classes...";
        var classes = await _classService.GetAllClassesAsync();
        dgClasses.ItemsSource = classes;
        lblStatus.Text = $"Loaded {classes.Count()} classes";
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void BtnAddClass_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditClassWindow(_classService, _teacherService);
        if (addWindow.ShowDialog() == true)
        {
            AsyncHelper.SafeFireAndForget(LoadClassesAsync, "Classes Management Error");
        }
    }

    private void BtnEditClass_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            var editWindow = new AddEditClassWindow(_classService, _teacherService, selectedClass);
            if (editWindow.ShowDialog() == true)
            {
                AsyncHelper.SafeFireAndForget(LoadClassesAsync, "Classes Management Error");
            }
        }
        else
        {
            MessageBox.Show("Please select a class to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnDeleteClass_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            AsyncHelper.SafeFireAndForget(async () => await DeleteClassAsync(selectedClass), "Delete Class Error");
        }
        else
        {
            MessageBox.Show("Please select a class to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async Task DeleteClassAsync(ClassDto selectedClass)
    {
        var result = MessageBox.Show($"Are you sure you want to delete class {selectedClass.DisplayName}?",
                                   "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            await _classService.DeleteClassAsync(selectedClass.Id);
            await LoadClassesAsync();
            lblStatus.Text = "Class deleted successfully";
        }
    }

    private void BtnRefreshClasses_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadClassesAsync, "Classes Management Error");
    }

    private void BtnViewStudents_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            AsyncHelper.SafeFireAndForget(async () => await ViewStudentsAsync(selectedClass), "View Students Error");
        }
        else
        {
            MessageBox.Show("Please select a class to view students.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async Task ViewStudentsAsync(ClassDto selectedClass)
    {
        var students = await _studentService.GetAllStudentsAsync();
        var classStudents = students.Where(s => s.ClassId == selectedClass.Id).ToList();

        var message = classStudents.Any()
            ? $"Students in {selectedClass.DisplayName}:\n\n" +
              string.Join("\n", classStudents.Select(s => $"• {s.StudentNumber} - {s.FullName}"))
            : $"No students enrolled in {selectedClass.DisplayName}";

        MessageBox.Show(message, $"Students in {selectedClass.DisplayName}", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}