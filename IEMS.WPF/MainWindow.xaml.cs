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
    private readonly StaffService _staffService;
    private readonly FeePaymentService _feePaymentService;
    private readonly FeeStructureService _feeStructureService;
    private readonly VehicleService _vehicleService;
    private readonly TransportExpenseService _transportExpenseService;

    public MainWindow(StudentService studentService, TeacherService teacherService, ClassService classService, StaffService staffService, FeePaymentService feePaymentService, FeeStructureService feeStructureService, VehicleService vehicleService, TransportExpenseService transportExpenseService)
    {
        InitializeComponent();
        _studentService = studentService;
        _teacherService = teacherService;
        _classService = classService;
        _staffService = staffService;
        _feePaymentService = feePaymentService;
        _feeStructureService = feeStructureService;
        _vehicleService = vehicleService;
        _transportExpenseService = transportExpenseService;

        lblStatus.Text = "Dashboard loaded successfully";
    }

    // Dashboard Navigation Event Handlers

    private void BtnStudentsModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var studentsWindow = new StudentsManagementWindow(_studentService, _classService, _teacherService, _feePaymentService, _feeStructureService);
            studentsWindow.ShowDialog();
            lblStatus.Text = "Students Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Students Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Students Management";
        }
    }

    private void BtnClassesModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var classesWindow = new ClassesManagementWindow(_classService, _teacherService, _studentService);
            classesWindow.ShowDialog();
            lblStatus.Text = "Classes Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Classes Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Classes Management";
        }
    }

    private void BtnTeachersModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var teachersWindow = new TeachersManagementWindow(_teacherService, _classService);
            teachersWindow.ShowDialog();
            lblStatus.Text = "Teachers Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Teachers Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Teachers Management";
        }
    }

    private void BtnBusesModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var transportWindow = new TransportManagementWindow(_vehicleService, _transportExpenseService);
            transportWindow.ShowDialog();
            lblStatus.Text = "Transport Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Transport Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Transport Management";
        }
    }

    private void BtnRoutesModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var transportWindow = new TransportManagementWindow(_vehicleService, _transportExpenseService);
            transportWindow.ShowDialog();
            lblStatus.Text = "Transport Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Transport Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Transport Management";
        }
    }

    private void BtnSupportStaffModule_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var supportStaffWindow = new SupportStaffManagementWindow(_staffService);
            supportStaffWindow.ShowDialog();
            lblStatus.Text = "Support Staff Management module accessed";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Support Staff Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error opening Support Staff Management";
        }
    }

    private void BtnFeesModule_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Expense Management - Student Fees module\nComing soon!", "Module Under Development", MessageBoxButton.OK, MessageBoxImage.Information);
        lblStatus.Text = "Expense Management - Student Fees (Coming Soon)";
    }

    private void BtnExpensesModule_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Expense Management - Expenses module\nComing soon!", "Module Under Development", MessageBoxButton.OK, MessageBoxImage.Information);
        lblStatus.Text = "Expense Management - Expenses (Coming Soon)";
    }
}