using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class MainWindow : Window
{
    private readonly StudentService _studentService;
    private readonly TeacherService _teacherService;
    private readonly ClassService _classService;

    public MainWindow(StudentService studentService, TeacherService teacherService, ClassService classService)
    {
        InitializeComponent();
        _studentService = studentService;
        _teacherService = teacherService;
        _classService = classService;
        LoadStudents();
        LoadTeachers();
        LoadClasses();
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
        var addWindow = new AddEditStudentWindow(_studentService, _classService);
        if (addWindow.ShowDialog() == true)
        {
            LoadStudents();
        }
    }

    private void BtnEditStudent_Click(object sender, RoutedEventArgs e)
    {
        if (dgStudents.SelectedItem is StudentDto selectedStudent)
        {
            var editWindow = new AddEditStudentWindow(_studentService, _classService, selectedStudent);
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

    private void BtnAddClass_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditClassWindow(_classService, _teacherService);
        if (addWindow.ShowDialog() == true)
        {
            LoadClasses();
            LoadTeachers(); // Refresh teacher class counts
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
                LoadTeachers(); // Refresh teacher class counts
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
                    LoadTeachers(); // Refresh teacher class counts
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

    private async void BtnViewStudents_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                var classStudents = students.Where(s => s.ClassId == selectedClass.Id).ToList();

                var message = classStudents.Any()
                    ? $"Students in {selectedClass.DisplayName}:\n\n" +
                      string.Join("\n", classStudents.Select(s => $"• {s.RollNumber} - {s.FirstName} {s.LastName}"))
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
}