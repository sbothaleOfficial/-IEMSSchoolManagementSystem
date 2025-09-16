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
    private readonly FeePaymentService _feePaymentService;
    private readonly FeeStructureService _feeStructureService;
    private List<StudentDto> _allStudents = new List<StudentDto>();
    private List<FeePaymentDto> _allFeePayments = new List<FeePaymentDto>();

    public StudentsManagementWindow(StudentService studentService, ClassService classService, TeacherService teacherService, FeePaymentService feePaymentService, FeeStructureService feeStructureService)
    {
        InitializeComponent();
        _studentService = studentService;
        _classService = classService;
        _teacherService = teacherService;
        _feePaymentService = feePaymentService;
        _feeStructureService = feeStructureService;
        LoadStudents();
        LoadClasses();
        LoadFeePayments();
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

    // Fee Payment Management
    private async void LoadFeePayments()
    {
        try
        {
            lblStatus.Text = "Loading fee payments...";
            var feePayments = await _feePaymentService.GetAllFeePaymentsAsync();
            _allFeePayments = feePayments.ToList();
            dgFeePayments.ItemsSource = _allFeePayments;
            lblStatus.Text = $"Loaded {feePayments.Count()} fee payments";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading fee payments: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading fee payments";
        }
    }

    // Fee Payment Events
    private void BtnAddFeePayment_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            // Debug: Check if services are null
            if (_feePaymentService == null)
            {
                MessageBox.Show("Fee Payment Service is not initialized.", "Service Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_feeStructureService == null)
            {
                MessageBox.Show("Fee Structure Service is not initialized.", "Service Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_studentService == null)
            {
                MessageBox.Show("Student Service is not initialized.", "Service Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var addFeePaymentWindow = new AddEditFeePaymentWindow(_feePaymentService, _feeStructureService, _studentService);
            if (addFeePaymentWindow.ShowDialog() == true)
            {
                LoadFeePayments(); // Refresh fee payments list
                lblStatus.Text = "Fee payment recorded successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening fee payment window: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnViewReceipt_Click(object sender, RoutedEventArgs e)
    {
        if (dgFeePayments.SelectedItem is FeePaymentDto selectedPayment)
        {
            try
            {
                lblStatus.Text = "Generating receipt...";
                var receipt = await _feePaymentService.GenerateReceiptAsync(selectedPayment.Id);
                var receiptWindow = new FeeReceiptWindow(receipt, _feePaymentService);
                receiptWindow.ShowDialog();
                lblStatus.Text = "Receipt displayed";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating receipt: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = "Error generating receipt";
            }
        }
        else
        {
            MessageBox.Show("Please select a fee payment to view receipt.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async void BtnPrintReceipt_Click(object sender, RoutedEventArgs e)
    {
        if (dgFeePayments.SelectedItem is FeePaymentDto selectedPayment)
        {
            try
            {
                lblStatus.Text = "Preparing receipt for printing...";
                var receipt = await _feePaymentService.GenerateReceiptAsync(selectedPayment.Id);
                var receiptWindow = new FeeReceiptWindow(receipt, _feePaymentService);
                receiptWindow.Show();

                // Automatically trigger print dialog
                var printButton = receiptWindow.FindName("btnPrint") as System.Windows.Controls.Button;
                printButton?.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Primitives.ButtonBase.ClickEvent));

                lblStatus.Text = "Receipt ready for printing";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error printing receipt: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = "Error printing receipt";
            }
        }
        else
        {
            MessageBox.Show("Please select a fee payment to print receipt.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnRefreshFeePayments_Click(object sender, RoutedEventArgs e)
    {
        LoadFeePayments();
        txtSearchFeePayments.Text = ""; // Clear search when refreshing
    }

    // Fee Payment Search Functionality
    private void TxtSearchFeePayments_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        FilterFeePayments();
    }

    private void FilterFeePayments()
    {
        if (_allFeePayments == null || !_allFeePayments.Any())
            return;

        var searchText = txtSearchFeePayments.Text.Trim().ToLower();

        if (string.IsNullOrEmpty(searchText))
        {
            // Show all fee payments if search is empty
            dgFeePayments.ItemsSource = _allFeePayments;
            lblStatus.Text = $"Showing all {_allFeePayments.Count} fee payments";
            return;
        }

        // Filter fee payments based on multiple criteria
        var filteredPayments = _allFeePayments.Where(payment =>
            payment.ReceiptNumber.ToLower().Contains(searchText) ||
            payment.StudentName.ToLower().Contains(searchText) ||
            payment.FeeTypeDisplay.ToLower().Contains(searchText) ||
            payment.PaymentMethodDisplay.ToLower().Contains(searchText) ||
            payment.AcademicYear.ToLower().Contains(searchText)
        ).ToList();

        dgFeePayments.ItemsSource = filteredPayments;
        lblStatus.Text = $"Found {filteredPayments.Count} fee payments matching '{txtSearchFeePayments.Text}'";
    }
}