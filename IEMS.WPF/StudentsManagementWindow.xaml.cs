using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Printing;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.WPF.Controls;
using IEMS.WPF.Helpers;
using IEMS.Core.Interfaces;

namespace IEMS.WPF;

public partial class StudentsManagementWindow : Window
{
    private readonly StudentService _studentService;
    private readonly ClassService _classService;
    private readonly TeacherService _teacherService;
    private readonly FeePaymentService _feePaymentService;
    private readonly FeeStructureService _feeStructureService;
    private readonly BulkPromotionService? _bulkPromotionService;
    private readonly IAcademicYearRepository? _academicYearRepository;
    private List<StudentDto> _allStudents = new List<StudentDto>();
    private List<FeePaymentDto> _allFeePayments = new List<FeePaymentDto>();
    private List<ClassDto> _allClasses = new List<ClassDto>();

    public StudentsManagementWindow(StudentService studentService, ClassService classService, TeacherService teacherService, FeePaymentService feePaymentService, FeeStructureService feeStructureService, BulkPromotionService? bulkPromotionService = null, IAcademicYearRepository? academicYearRepository = null)
    {
        InitializeComponent();
        _studentService = studentService;
        _classService = classService;
        _teacherService = teacherService;
        _feePaymentService = feePaymentService;
        _feeStructureService = feeStructureService;
        _bulkPromotionService = bulkPromotionService;
        _academicYearRepository = academicYearRepository;
        AsyncHelper.SafeFireAndForget(LoadStudentsAsync);
        AsyncHelper.SafeFireAndForget(LoadClassesAsync);
        AsyncHelper.SafeFireAndForget(LoadFeePaymentsAsync);
        AsyncHelper.SafeFireAndForget(LoadBonafideStudentsAsync);
        AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync);
        AsyncHelper.SafeFireAndForget(LoadPromotionDataAsync);
    }

    private async Task LoadStudentsAsync()
    {
        try
        {
            loadingOverlay.IsLoading = true;
            loadingOverlay.LoadingMessage = "Loading students...";
            lblStatus.Text = "Loading students...";

            var students = await _studentService.GetAllStudentsAsync();
            _allStudents = students.ToList();
            dgStudents.ItemsSource = _allStudents;

            lblStatus.Text = $"Loaded {students.Count()} students";

            toastNotification.Message = $"Successfully loaded {students.Count()} students";
            toastNotification.ToastType = ToastType.Success;
            toastNotification.Show();

            // Refresh dashboard after loading students
            await LoadDashboardDataAsync();

            // Load leaving certificate students dropdown after students data is loaded
            await LoadLeavingCertificateStudentsAsync();
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error loading students";

            toastNotification.Message = $"Error loading students: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
        finally
        {
            loadingOverlay.IsLoading = false;
        }
    }

    private async Task LoadClassesAsync()
    {
        try
        {
            lblStatus.Text = "Loading classes...";
            var classes = await _classService.GetAllClassesAsync();
            _allClasses = classes.ToList();
            dgClasses.ItemsSource = _allClasses;
            lblStatus.Text = $"Loaded {classes.Count()} classes";

            // Refresh dashboard after loading classes
            await LoadDashboardDataAsync();
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
            AsyncHelper.SafeFireAndForget(LoadStudentsAsync);
            AsyncHelper.SafeFireAndForget(LoadClassesAsync); // Refresh to update student counts in classes
            txtSearchStudents.Text = currentSearch; // Restore search after refresh
            FilterStudents();
            AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
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
                AsyncHelper.SafeFireAndForget(LoadStudentsAsync);
                AsyncHelper.SafeFireAndForget(LoadClassesAsync); // Refresh to update student counts in classes
                txtSearchStudents.Text = currentSearch; // Restore search after refresh
                FilterStudents();
                AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
            }
        }
        else
        {
            MessageBox.Show("Please select a student to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnDeleteStudent_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            if (dgStudents.SelectedItem is StudentDto selectedStudent)
            {
                var result = MessageBox.Show($"Are you sure you want to delete student {selectedStudent.FullName}?",
                                           "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        loadingOverlay.IsLoading = true;
                        loadingOverlay.LoadingMessage = "Deleting student...";

                        await _studentService.DeleteStudentAsync(selectedStudent.Id);
                        var currentSearch = txtSearchStudents.Text;
                        AsyncHelper.SafeFireAndForget(LoadStudentsAsync);
                        AsyncHelper.SafeFireAndForget(LoadClassesAsync); // Refresh to update student counts in classes
                        txtSearchStudents.Text = currentSearch; // Restore search after refresh

                        toastNotification.Message = $"Student {selectedStudent.FullName} deleted successfully";
                        toastNotification.ToastType = ToastType.Success;
                        toastNotification.Show();
                        FilterStudents();
                        AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
                        lblStatus.Text = "Student deleted successfully";
                    }
                    catch (Exception ex)
                    {
                        toastNotification.Message = $"Error deleting student: {ex.Message}";
                        toastNotification.ToastType = ToastType.Error;
                        toastNotification.Show();
                        lblStatus.Text = "Error deleting student";
                    }
                    finally
                    {
                        loadingOverlay.IsLoading = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }, "Student Delete Error");
    }

    private void BtnRefreshStudents_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadStudentsAsync);
        txtSearchStudents.Text = ""; // Clear search when refreshing
        AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
    }

    // Class Management Events
    private void BtnAddClass_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditClassWindow(_classService, _teacherService);
        if (addWindow.ShowDialog() == true)
        {
            AsyncHelper.SafeFireAndForget(LoadClassesAsync);
            AsyncHelper.SafeFireAndForget(LoadPromotionDataAsync); // Refresh promotion dropdowns
            AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
        }
    }

    private void BtnEditClass_Click(object sender, RoutedEventArgs e)
    {
        if (dgClasses.SelectedItem is ClassDto selectedClass)
        {
            var editWindow = new AddEditClassWindow(_classService, _teacherService, selectedClass);
            if (editWindow.ShowDialog() == true)
            {
                AsyncHelper.SafeFireAndForget(LoadClassesAsync);
                AsyncHelper.SafeFireAndForget(LoadPromotionDataAsync); // Refresh promotion dropdowns
                AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
            }
        }
        else
        {
            MessageBox.Show("Please select a class to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnDeleteClass_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
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
                        await LoadClassesAsync();
                        await LoadDashboardDataAsync(); // Refresh dashboard
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
        });
    }

    private void BtnRefreshClasses_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadClassesAsync);
        AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync); // Refresh dashboard
    }

    private void BtnViewClassStudents_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
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
        });
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
            student.Address.ToLower().Contains(searchText) ||
            student.CityVillage.ToLower().Contains(searchText)
        ).ToList();

        dgStudents.ItemsSource = filteredStudents;
        lblStatus.Text = $"Found {filteredStudents.Count} students matching '{txtSearchStudents.Text}'";
    }

    // Fee Payment Management
    private async Task LoadFeePaymentsAsync()
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
                AsyncHelper.SafeFireAndForget(LoadFeePaymentsAsync); // Refresh fee payments list
                lblStatus.Text = "Fee payment recorded successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening fee payment window: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnViewReceipt_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
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
        });
    }

    private void BtnPrintReceipt_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
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
        });
    }

    private void BtnRefreshFeePayments_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadFeePaymentsAsync);
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

    // Bonafide Certificate Event Handlers
    private void BtnGenerateBonafide_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                if (dgBonafideStudents.SelectedItem is StudentDto selectedStudentDto)
                {
                    // Get the full student entity from the service
                    var student = await _studentService.GetStudentEntityByIdAsync(selectedStudentDto.Id);
                    if (student != null)
                    {
                        var bonafideWindow = new BonafideCertificateWindow(student);
                        bonafideWindow.ShowDialog();
                    }
                    else
                    {
                        toastNotification.Message = "Student not found!";
                        toastNotification.ToastType = ToastType.Error;
                        toastNotification.Show();
                    }
                }
                else
                {
                    toastNotification.Message = "Please select a student to generate Bonafide certificate.";
                    toastNotification.ToastType = ToastType.Warning;
                    toastNotification.Show();
                }
            }
            catch (Exception ex)
            {
                toastNotification.Message = $"Error generating certificate: {ex.Message}";
                toastNotification.ToastType = ToastType.Error;
                toastNotification.Show();
            }
        });
    }

    private void BtnRefreshBonafide_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(LoadBonafideStudentsAsync);
    }

    private async Task LoadBonafideStudentsAsync()
    {
        try
        {
            // Use the same student data as the main students tab
            dgBonafideStudents.ItemsSource = _allStudents;
            lblStatus.Text = $"Loaded {_allStudents.Count} students for Bonafide certificates";
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error loading students: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    // Bonafide Search Functionality
    private void TxtSearchBonafide_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        FilterBonafideStudents();
    }

    private void FilterBonafideStudents()
    {
        if (_allStudents == null || !_allStudents.Any())
            return;

        var searchText = txtSearchBonafide.Text.Trim().ToLower();

        if (string.IsNullOrEmpty(searchText))
        {
            // Show all students if search is empty
            dgBonafideStudents.ItemsSource = _allStudents;
            lblStatus.Text = $"Showing all {_allStudents.Count} students";
            return;
        }

        // Filter students based on multiple criteria
        var filteredStudents = _allStudents.Where(student =>
            student.FirstName.ToLower().Contains(searchText) ||
            student.Surname.ToLower().Contains(searchText) ||
            student.FatherName.ToLower().Contains(searchText) ||
            student.MotherName.ToLower().Contains(searchText) ||
            student.StudentNumber.ToLower().Contains(searchText) ||
            student.Standard.ToLower().Contains(searchText) ||
            student.ClassDivision.ToLower().Contains(searchText)
        ).ToList();

        dgBonafideStudents.ItemsSource = filteredStudents;
        lblStatus.Text = $"Found {filteredStudents.Count} students matching '{txtSearchBonafide.Text}'";
    }

    // Dashboard Data Loading and Statistics Methods
    private async Task LoadDashboardDataAsync()
    {
        if (_allStudents == null || !_allStudents.Any() || _allClasses == null || !_allClasses.Any())
            return;

        try
        {
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    // Calculate overall statistics
                    var totalStudents = _allStudents.Count;
                    var maleStudents = _allStudents.Count(s => s.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase));
                    var femaleStudents = _allStudents.Count(s => s.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase));
                    var totalClasses = _allClasses.Count;

                    // Update dashboard cards
                    lblTotalStudents.Text = totalStudents.ToString();
                    lblMaleStudents.Text = maleStudents.ToString();
                    lblFemaleStudents.Text = femaleStudents.ToString();
                    lblTotalClasses.Text = totalClasses.ToString();

                    // Calculate additional statistics
                    var bplStudents = _allStudents.Count(s => s.IsBPL);
                    var semiEnglishStudents = _allStudents.Count(s => s.IsSemiEnglish);

                    lblBPLStudents.Text = bplStudents.ToString();
                    lblSemiEnglishStudents.Text = semiEnglishStudents.ToString();

                    // Generate class-wise statistics
                    LoadClassWiseStatistics();

                    // Generate religion-wise statistics
                    LoadReligionWiseStatistics();

                    // Generate caste category statistics
                    LoadCasteWiseStatistics();

                    // Generate city/village statistics
                    LoadCityVillageWiseStatistics();
                });
            });
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Dashboard Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void LoadClassWiseStatistics()
    {
        var classStats = new List<dynamic>();

        foreach (var classDto in _allClasses.OrderBy(c => c.Name))
        {
            var studentsInClass = _allStudents.Where(s => s.ClassId == classDto.Id).ToList();
            var totalStudents = studentsInClass.Count;
            var maleStudents = studentsInClass.Count(s => s.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase));
            var femaleStudents = studentsInClass.Count(s => s.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase));

            classStats.Add(new
            {
                ClassName = classDto.DisplayName,
                TotalStudents = totalStudents,
                MaleStudents = maleStudents,
                FemaleStudents = femaleStudents
            });
        }

        dgClassStats.ItemsSource = classStats;
    }

    private void LoadReligionWiseStatistics()
    {
        var religionStats = _allStudents
            .GroupBy(s => s.Religion)
            .Select(g => new
            {
                Religion = string.IsNullOrEmpty(g.Key) ? "Not Specified" : g.Key,
                Count = g.Count(),
                MaleCount = g.Count(s => s.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)),
                FemaleCount = g.Count(s => s.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            })
            .OrderByDescending(x => x.Count)
            .ToList();

        dgReligionStats.ItemsSource = religionStats;
    }

    private void LoadCasteWiseStatistics()
    {
        var casteStats = _allStudents
            .GroupBy(s => s.CasteCategory)
            .Select(g => new
            {
                Category = string.IsNullOrEmpty(g.Key) ? "Not Specified" : g.Key,
                Count = g.Count(),
                MaleCount = g.Count(s => s.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)),
                FemaleCount = g.Count(s => s.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            })
            .OrderByDescending(x => x.Count)
            .ToList();

        dgCasteStats.ItemsSource = casteStats;
    }

    private void LoadCityVillageWiseStatistics()
    {
        var cityVillageStats = _allStudents
            .GroupBy(s => s.CityVillage)
            .Select(g => new
            {
                CityVillage = string.IsNullOrEmpty(g.Key) ? "Not Specified" : g.Key,
                Count = g.Count(),
                MaleCount = g.Count(s => s.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase)),
                FemaleCount = g.Count(s => s.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            })
            .OrderByDescending(x => x.Count)
            .ToList();

        dgCityVillageStats.ItemsSource = cityVillageStats;
    }

    // Leaving Certificate Event Handlers
    private async Task LoadLeavingCertificateStudentsAsync()
    {
        try
        {
            // Use the same student data as the main students tab
            if (cmbLeavingCertStudent != null)
                cmbLeavingCertStudent.ItemsSource = _allStudents;

            if (lblStatus != null)
                lblStatus.Text = $"Loaded {_allStudents.Count} students for Leaving certificates";

            // Populate the reason dropdown
            var leavingReasons = new List<string>
            {
                "Completion of course",
                "Transfer to another school",
                "Family relocation",
                "Financial reasons",
                "Health reasons",
                "Migration",
                "Other"
            };
            if (cmbLeavingReason != null)
                cmbLeavingReason.ItemsSource = leavingReasons;

            // Populate character/conduct dropdown
            var characterOptions = new List<string>
            {
                "Excellent",
                "Very Good",
                "Good",
                "Satisfactory"
            };
            if (cmbCharacterConduct != null)
            {
                cmbCharacterConduct.ItemsSource = characterOptions;
                cmbCharacterConduct.SelectedIndex = 0; // Default to "Excellent"
            }

            // Populate progress in studies dropdown
            if (cmbProgressInStudies != null)
            {
                cmbProgressInStudies.ItemsSource = characterOptions; // Same options as character conduct
                cmbProgressInStudies.SelectedIndex = 0; // Default to "Excellent"
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error loading students: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private void CmbLeavingCertStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        try
        {
            if (cmbLeavingCertStudent.SelectedItem is StudentDto selectedStudent)
            {
                try
                {
                    // Show the student details section
                    gridLeavingCertDetails.Visibility = System.Windows.Visibility.Visible;

                    // Populate the left panel student details
                    if (lblLeavingStudentName != null) lblLeavingStudentName.Text = selectedStudent.FullName;
                    if (lblLeavingMotherName != null) lblLeavingMotherName.Text = selectedStudent.MotherName;
                    if (lblLeavingFatherName != null) lblLeavingFatherName.Text = selectedStudent.FatherName;
                    if (lblLeavingAdmissionNo != null) lblLeavingAdmissionNo.Text = selectedStudent.StudentNumber;
                    if (lblLeavingStudentId != null) lblLeavingStudentId.Text = selectedStudent.Id.ToString();
                    if (lblLeavingClass != null) lblLeavingClass.Text = $"{selectedStudent.Standard} ({selectedStudent.ClassDivision})";
                    if (lblLeavingDOB != null) lblLeavingDOB.Text = selectedStudent.DateOfBirth.ToString("dd/MM/yyyy");
                    if (lblLeavingAdmissionDate != null) lblLeavingAdmissionDate.Text = selectedStudent.AdmissionDate.ToString("dd/MM/yyyy");
                    if (lblLeavingReligion != null) lblLeavingReligion.Text = selectedStudent.Religion;
                    if (lblLeavingCaste != null) lblLeavingCaste.Text = selectedStudent.CasteCategory;
                    if (lblLeavingMotherTongue != null) lblLeavingMotherTongue.Text = "Marathi"; // Default or could be added to StudentDto

                    // Set default value for last class
                    if (txtLastClass != null) txtLastClass.Text = selectedStudent.Standard;

                    // Populate Certificate Details fields with student data (auto-fill but allow override)
                    if (txtBirthPlace != null) txtBirthPlace.Text = selectedStudent.CityVillage ?? "";
                    if (txtSerialNoOverride != null) txtSerialNoOverride.Text = selectedStudent.SerialNo.ToString();
                    if (txtStudentId != null) txtStudentId.Text = selectedStudent.Id.ToString();
                    if (txtGeneralRegisterNumber != null) txtGeneralRegisterNumber.Text = selectedStudent.StudentNumber;
                    if (txtPhoneNumber != null) txtPhoneNumber.Text = selectedStudent.ParentMobileNumber;

                    // Auto-populate Place of Birth fields from student data
                    // For now, we'll use defaults since we don't have specific fields in the database
                    // Users can override these values manually
                    if (txtTaluka != null) txtTaluka.Text = ""; // Empty by default, user can fill
                    if (txtDistrict != null) txtDistrict.Text = ""; // Empty by default, user can fill
                    if (txtBirthState != null) txtBirthState.Text = "Maharashtra"; // Default state

                    // Auto-populate additional fields that don't exist in database yet
                    if (txtAadhaarNumber != null) txtAadhaarNumber.Text = ""; // Empty by default, user must fill
                    if (txtEmail != null) txtEmail.Text = ""; // Empty by default, user can fill

                    // Set default Academic Session based on current date
                    if (txtAcademicSession != null)
                    {
                        var currentYear = DateTime.Now.Year;
                        var nextYear = currentYear + 1;
                        var defaultAcademicSession = $"{currentYear}-{nextYear.ToString().Substring(2)}";
                        txtAcademicSession.Text = defaultAcademicSession;
                    }
                    // txtSubcaste, txtAadhaarNumber, txtEmail remain empty for manual entry
                    // txtState already defaults to "Maharashtra"

                    // Populate the certificate preview with student data
                    PopulateLeavingCertificatePreview(selectedStudent);
                }
                catch (Exception labelEx)
                {
                    toastNotification.Message = $"Error populating student details: {labelEx.Message}";
                    toastNotification.ToastType = ToastType.Error;
                    toastNotification.Show();
                }
            }
            else
            {
                // Hide the student details section if no student is selected
                gridLeavingCertDetails.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error selecting student: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private void PopulateLeavingCertificatePreview(StudentDto student)
    {
        try
        {
            // Find and populate the TextBlock elements in the certificate (not Run elements)
            if (FindName("CertStudentName") is TextBlock certStudentName)
                certStudentName.Text = student.FullName.ToUpper();

            if (FindName("CertMotherName") is TextBlock certMotherName)
                certMotherName.Text = student.MotherName.ToUpper();

            if (FindName("CertDateOfBirth") is TextBlock certDateOfBirth)
                certDateOfBirth.Text = student.DateOfBirth.ToString("dd/MM/yyyy");

            if (FindName("CertDateOfBirthWords") is TextBlock certDateOfBirthWords)
                certDateOfBirthWords.Text = ConvertDateToWords(student.DateOfBirth);

            if (FindName("CertDateOfAdmission") is TextBlock certDateOfAdmission)
                certDateOfAdmission.Text = student.AdmissionDate.ToString("dd/MM/yyyy");

            if (FindName("CertAdmissionClass") is TextBlock certAdmissionClass)
                certAdmissionClass.Text = student.Standard;

            if (FindName("CertStandard") is TextBlock certStandard)
            {
                // Enhanced Grade field with default academic session format (both numeric and words)
                var currentYear = DateTime.Now.Year;
                var nextYear = currentYear + 1;
                var academicSession = $"{currentYear}–{nextYear.ToString().Substring(2)}";
                var standardWords = ConvertStandardToWords(student.Standard);

                // Create both numeric and words format
                var numericFormat = $"{student.Standard}th — Academic Session {academicSession}";
                var wordsFormat = $"Class {standardWords} — Academic Session {ConvertAcademicSessionToWords(academicSession)}";

                // Combine both formats
                var combinedText = $"{numericFormat}, {wordsFormat}";
                certStandard.Text = combinedText;
            }

            if (FindName("CertReligion") is TextBlock certReligion)
                certReligion.Text = student.Religion;

            if (FindName("CertCaste") is TextBlock certCaste)
                certCaste.Text = student.CasteCategory;

            if (FindName("CertSubcaste") is TextBlock certSubcaste)
                certSubcaste.Text = ""; // Not available in current StudentDto

            // Mother Tongue will be populated when certificate is generated based on dropdown selection

            if (FindName("CertGeneralRegisterNumber") is TextBlock certGeneralRegisterNumber)
                certGeneralRegisterNumber.Text = student.StudentNumber;

            // Set default leaving date to today
            dpLeavingDate.SelectedDate = DateTime.Now;
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error populating certificate: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private string ConvertDateToWords(DateTime date)
    {
        try
        {
            var months = new[] { "", "January", "February", "March", "April", "May", "June",
                               "July", "August", "September", "October", "November", "December" };

            var day = ConvertNumberToWords(date.Day);
            var month = months[date.Month];
            var year = ConvertNumberToWords(date.Year);

            return $"{day} {month} {year}";
        }
        catch
        {
            return "";
        }
    }

    private string ConvertNumberToWords(int number)
    {
        if (number == 0) return "Zero";

        var ones = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                          "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                          "Seventeen", "Eighteen", "Nineteen" };

        var tens = new[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        var result = "";

        if (number >= 1000)
        {
            result += ones[number / 1000] + " Thousand ";
            number %= 1000;
        }

        if (number >= 100)
        {
            result += ones[number / 100] + " Hundred ";
            number %= 100;
        }

        if (number >= 20)
        {
            result += tens[number / 10] + " ";
            number %= 10;
        }

        if (number > 0)
        {
            result += ones[number];
        }

        return result.Trim();
    }

    private void BtnGenerateLeavingCert_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (cmbLeavingCertStudent.SelectedItem is StudentDto selectedStudent)
            {
                // Validate required fields
                if (dpLeavingDate.SelectedDate == null)
                {
                    toastNotification.Message = "Please select a leaving date.";
                    toastNotification.ToastType = ToastType.Warning;
                    toastNotification.Show();
                    return;
                }

                if (cmbLeavingReason.SelectedItem == null)
                {
                    toastNotification.Message = "Please select a reason for leaving.";
                    toastNotification.ToastType = ToastType.Warning;
                    toastNotification.Show();
                    return;
                }

                if (cmbCharacterConduct.SelectedItem == null)
                {
                    toastNotification.Message = "Please select character/conduct rating.";
                    toastNotification.ToastType = ToastType.Warning;
                    toastNotification.Show();
                    return;
                }

                // Populate additional certificate fields
                if (FindName("CertLeavingDate") is TextBlock certLeavingDate)
                    certLeavingDate.Text = dpLeavingDate.SelectedDate.Value.ToString("dd/MM/yyyy");

                // Populate Medium field
                if (FindName("CertMedium") is TextBlock certMedium)
                {
                    var medium = (cmbMedium?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "English";
                    certMedium.Text = medium;
                }

                // Populate Mother Tongue field
                if (FindName("CertMotherTongue") is TextBlock certMotherTongue)
                {
                    var motherTongueSelection = (cmbMotherTongue?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Marathi";
                    if (motherTongueSelection == "Other" && !string.IsNullOrWhiteSpace(txtCustomMotherTongue.Text))
                    {
                        certMotherTongue.Text = txtCustomMotherTongue.Text;
                    }
                    else if (motherTongueSelection != "Other")
                    {
                        certMotherTongue.Text = motherTongueSelection;
                    }
                    else
                    {
                        certMotherTongue.Text = "Marathi"; // Default if Other is selected but no custom value entered
                    }
                }

                if (FindName("CertLeavingReason") is TextBlock certLeavingReason)
                {
                    var reason = (cmbLeavingReason.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
                    certLeavingReason.Text = reason;
                }

                // For field 13 - Progress in Studies
                if (FindName("CertProgressInStudies") is TextBlock certProgressInStudies)
                {
                    var progress = (cmbProgressInStudies?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Good";
                    certProgressInStudies.Text = progress;
                }

                // For field 13 - Behavior
                if (FindName("CertCharacterConduct") is TextBlock certCharacterConduct)
                {
                    var conduct = (cmbCharacterConduct.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Good";
                    certCharacterConduct.Text = conduct;
                }

                if (FindName("CertRemarks") is TextBlock certRemarks)
                    certRemarks.Text = !string.IsNullOrWhiteSpace(txtLeavingRemarks.Text) ? txtLeavingRemarks.Text : "NIL";

                if (FindName("CertIssueDate") is TextBlock certIssueDate)
                    certIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                // Populate new fields from Certificate Details textboxes
                // Place of Birth fields (Field 8)
                if (FindName("CertBirthPlace") is TextBlock certBirthPlace)
                    certBirthPlace.Text = !string.IsNullOrWhiteSpace(txtBirthPlace?.Text) ? txtBirthPlace.Text : "";

                if (FindName("CertTaluka") is TextBlock certTaluka)
                    certTaluka.Text = !string.IsNullOrWhiteSpace(txtTaluka?.Text) ? txtTaluka.Text : "";

                if (FindName("CertDistrict") is TextBlock certDistrict)
                    certDistrict.Text = !string.IsNullOrWhiteSpace(txtDistrict?.Text) ? txtDistrict.Text : "";

                if (FindName("CertBirthStateDisplay") is TextBlock certBirthStateDisplay)
                    certBirthStateDisplay.Text = !string.IsNullOrWhiteSpace(txtBirthState?.Text) ? txtBirthState.Text : "Maharashtra";

                // Populate Header fields
                if (FindName("CertHeaderPhone") is TextBlock certHeaderPhone)
                    certHeaderPhone.Text = !string.IsNullOrWhiteSpace(txtPhoneNumber?.Text) ? txtPhoneNumber.Text : "";

                if (FindName("CertHeaderEmail") is TextBlock certHeaderEmail)
                    certHeaderEmail.Text = !string.IsNullOrWhiteSpace(txtEmail?.Text) ? txtEmail.Text : "";

                if (FindName("CertHeaderSerialNo") is TextBlock certHeaderSerialNo)
                {
                    var serialNo = !string.IsNullOrWhiteSpace(txtSerialNoOverride?.Text) ? txtSerialNoOverride.Text : selectedStudent.SerialNo.ToString();
                    certHeaderSerialNo.Text = serialNo;
                }

                if (FindName("CertHeaderGeneralRegister") is TextBlock certHeaderGeneralRegister)
                    certHeaderGeneralRegister.Text = !string.IsNullOrWhiteSpace(txtGeneralRegisterNumber?.Text) ? txtGeneralRegisterNumber.Text : selectedStudent.StudentNumber;

                if (FindName("CertSubcaste") is TextBlock certSubcaste)
                    certSubcaste.Text = !string.IsNullOrWhiteSpace(txtSubcaste?.Text) ? txtSubcaste.Text : "";

                if (FindName("CertSerialNo") is TextBlock certSerialNo)
                {
                    // Use override if provided, otherwise use student's serial number
                    var serialNo = !string.IsNullOrWhiteSpace(txtSerialNoOverride?.Text) ? txtSerialNoOverride.Text : selectedStudent.SerialNo.ToString();
                    certSerialNo.Text = serialNo;
                }

                if (FindName("CertStudentId") is TextBlock certStudentId)
                    certStudentId.Text = !string.IsNullOrWhiteSpace(txtStudentId?.Text) ? txtStudentId.Text : selectedStudent.Id.ToString();

                if (FindName("CertAadhaarNumber") is TextBlock certAadhaarNumber)
                    certAadhaarNumber.Text = !string.IsNullOrWhiteSpace(txtAadhaarNumber?.Text) ? txtAadhaarNumber.Text : "";

                if (FindName("CertPhoneNumber") is TextBlock certPhoneNumber)
                    certPhoneNumber.Text = !string.IsNullOrWhiteSpace(txtPhoneNumber?.Text) ? txtPhoneNumber.Text : "";

                if (FindName("CertEmail") is TextBlock certEmail)
                    certEmail.Text = !string.IsNullOrWhiteSpace(txtEmail?.Text) ? txtEmail.Text : "";

                if (FindName("CertGeneralRegisterNumber") is TextBlock certGeneralRegisterNumber)
                    certGeneralRegisterNumber.Text = !string.IsNullOrWhiteSpace(txtGeneralRegisterNumber?.Text) ? txtGeneralRegisterNumber.Text : selectedStudent.StudentNumber;

                if (FindName("CertState") is TextBlock certState)
                    certState.Text = !string.IsNullOrWhiteSpace(txtState?.Text) ? txtState.Text : "Maharashtra";

                // Fix for Issue 4: Previous School and Grade
                if (FindName("CertPreviousSchool") is TextBlock certPreviousSchool)
                    certPreviousSchool.Text = !string.IsNullOrWhiteSpace(txtPreviousSchool?.Text) ? txtPreviousSchool.Text : "";

                // Update Grade field with user-specified Academic Session (both numeric and words format)
                if (FindName("CertStandard") is TextBlock certStandard)
                {
                    var userAcademicSession = !string.IsNullOrWhiteSpace(txtAcademicSession?.Text) ? txtAcademicSession.Text : "";
                    var standardWords = ConvertStandardToWords(selectedStudent.Standard);

                    string academicSessionToUse;
                    if (!string.IsNullOrWhiteSpace(userAcademicSession))
                    {
                        academicSessionToUse = userAcademicSession;
                    }
                    else
                    {
                        // Fallback to current year if no academic session is specified
                        var currentYear = DateTime.Now.Year;
                        var nextYear = currentYear + 1;
                        academicSessionToUse = $"{currentYear}–{nextYear.ToString().Substring(2)}";
                    }

                    // Create both numeric and words format as specified
                    // Remove 'th' suffix if it already exists in selectedStudent.Standard
                    var standardNumeric = selectedStudent.Standard.EndsWith("th") ? selectedStudent.Standard : $"{selectedStudent.Standard}th";
                    var numericFormat = $"{standardNumeric} — Academic Session {academicSessionToUse}";
                    var wordsFormat = $"Class {standardWords} — Academic Session {ConvertAcademicSessionToWords(academicSessionToUse)}";

                    // Combine both formats with proper line break
                    var combinedText = $"{numericFormat}\n{wordsFormat}";
                    certStandard.Text = combinedText;
                }

                toastNotification.Message = "Leaving Certificate generated successfully!";
                toastNotification.ToastType = ToastType.Success;
                toastNotification.Show();

                lblStatus.Text = "Leaving Certificate generated";
            }
            else
            {
                toastNotification.Message = "Please select a student to generate Leaving certificate.";
                toastNotification.ToastType = ToastType.Warning;
                toastNotification.Show();
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error generating certificate: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private void BtnPrintLeavingCert_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (cmbLeavingCertStudent.SelectedItem is StudentDto selectedStudent)
            {
                // First generate the certificate if not already done
                BtnGenerateLeavingCert_Click(sender, e);

                // Print the certificate
                var printDialog = new System.Windows.Controls.PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    // Create a copy of the certificate border for printing
                    var certificateToPrint = LeavingCertificateBorder;

                    // Get the printable area
                    var printableArea = printDialog.PrintableAreaWidth;
                    var printableHeight = printDialog.PrintableAreaHeight;

                    // Ensure the certificate fits the printable area
                    var originalWidth = certificateToPrint.ActualWidth;
                    var originalHeight = certificateToPrint.ActualHeight;

                    // Calculate scale factor to fit within printable area while maintaining aspect ratio
                    var scaleX = printableArea / originalWidth;
                    var scaleY = printableHeight / originalHeight;
                    var scale = Math.Min(scaleX, scaleY);

                    // Create a transform group for scaling
                    var transformGroup = new TransformGroup();
                    transformGroup.Children.Add(new ScaleTransform(scale, scale));

                    // Apply transform to ensure it fits
                    certificateToPrint.RenderTransform = transformGroup;

                    try
                    {
                        // Print with proper scaling
                        printDialog.PrintVisual(certificateToPrint, $"Leaving Certificate - {selectedStudent.FullName}");

                        toastNotification.Message = "Leaving Certificate sent to printer!";
                        toastNotification.ToastType = ToastType.Success;
                        toastNotification.Show();

                        lblStatus.Text = "Certificate printed";
                    }
                    finally
                    {
                        // Reset transform
                        certificateToPrint.RenderTransform = null;
                    }
                }
            }
            else
            {
                toastNotification.Message = "Please select a student and generate certificate first.";
                toastNotification.ToastType = ToastType.Warning;
                toastNotification.Show();
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error printing certificate: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private void BtnExportLeavingCertPDF_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (cmbLeavingCertStudent.SelectedItem is StudentDto selectedStudent)
            {
                // First generate the certificate if not already done
                BtnGenerateLeavingCert_Click(sender, e);

                // Create save file dialog
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    DefaultExt = "pdf",
                    FileName = $"School_Leaving_Certificate_{selectedStudent.FullName.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd}.pdf"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Export certificate to PDF using visual capture
                    ExportCertificateToPDF(LeavingCertificateBorder, saveFileDialog.FileName);

                    toastNotification.Message = "Certificate exported to PDF successfully!";
                    toastNotification.ToastType = ToastType.Success;
                    toastNotification.Show();

                    lblStatus.Text = "Certificate exported to PDF";
                }
            }
            else
            {
                toastNotification.Message = "Please select a student and generate certificate first.";
                toastNotification.ToastType = ToastType.Warning;
                toastNotification.Show();
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error exporting certificate: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private void ExportCertificateToPDF(FrameworkElement element, string filePath)
    {
        // Ensure the element is measured and arranged
        element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        element.Arrange(new Rect(element.DesiredSize));

        // Update layout to ensure all elements are rendered
        element.UpdateLayout();

        // Create render target bitmap with high DPI for quality
        var dpi = 300; // High DPI for PDF quality
        var renderBitmap = new RenderTargetBitmap(
            (int)(element.ActualWidth * dpi / 96),
            (int)(element.ActualHeight * dpi / 96),
            dpi, dpi, PixelFormats.Pbgra32);

        // Render the visual
        renderBitmap.Render(element);

        // Create print dialog to convert to PDF
        var printDialog = new PrintDialog();

        // Set printer to Microsoft Print to PDF if available
        var printServer = new System.Printing.LocalPrintServer();
        var printQueue = printServer.GetPrintQueue("Microsoft Print to PDF");

        if (printQueue != null)
        {
            printDialog.PrintQueue = printQueue;
        }

        // Create a document for printing
        var printDocument = new System.Windows.Documents.FixedDocument();
        var pageContent = new System.Windows.Documents.PageContent();
        var fixedPage = new System.Windows.Documents.FixedPage
        {
            Width = 793.7, // A4 width in device units (96 DPI)
            Height = 1122.5 // A4 height in device units (96 DPI)
        };

        // Calculate scale to fit A4 page
        var scaleX = fixedPage.Width / element.ActualWidth;
        var scaleY = fixedPage.Height / element.ActualHeight;
        var scale = Math.Min(scaleX, scaleY);

        // Create a visual brush from the certificate
        var visualBrush = new VisualBrush(element)
        {
            Stretch = Stretch.Uniform,
            TileMode = TileMode.None
        };

        // Create a rectangle to hold the visual
        var rectangle = new System.Windows.Shapes.Rectangle
        {
            Width = element.ActualWidth * scale,
            Height = element.ActualHeight * scale,
            Fill = visualBrush
        };

        // Center the content on the page
        System.Windows.Documents.FixedPage.SetLeft(rectangle, (fixedPage.Width - rectangle.Width) / 2);
        System.Windows.Documents.FixedPage.SetTop(rectangle, (fixedPage.Height - rectangle.Height) / 2);

        fixedPage.Children.Add(rectangle);
        pageContent.Child = fixedPage;
        printDocument.Pages.Add(pageContent);

        // Print the document
        printDialog.PrintDocument(printDocument.DocumentPaginator, $"School Leaving Certificate - {DateTime.Now:yyyy-MM-dd}");
    }

    private void CmbMotherTongue_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        try
        {
            // Add null checks to prevent initialization issues
            if (cmbMotherTongue?.SelectedItem is ComboBoxItem selectedItem && txtCustomMotherTongue != null)
            {
                var selectedValue = selectedItem.Content.ToString();
                if (selectedValue == "Other")
                {
                    // Show the custom input textbox
                    txtCustomMotherTongue.Visibility = System.Windows.Visibility.Visible;
                    txtCustomMotherTongue.Focus();
                }
                else
                {
                    // Hide the custom input textbox
                    txtCustomMotherTongue.Visibility = System.Windows.Visibility.Collapsed;
                    txtCustomMotherTongue.Text = "";
                }
            }
        }
        catch (Exception ex)
        {
            toastNotification.Message = $"Error handling mother tongue selection: {ex.Message}";
            toastNotification.ToastType = ToastType.Error;
            toastNotification.Show();
        }
    }

    private string ConvertStandardToWords(string standard)
    {
        var standardMap = new Dictionary<string, string>
        {
            {"1", "First"},
            {"2", "Second"},
            {"3", "Third"},
            {"4", "Fourth"},
            {"5", "Fifth"},
            {"6", "Sixth"},
            {"7", "Seventh"},
            {"8", "Eighth"},
            {"9", "Ninth"},
            {"10", "Tenth"},
            {"11", "Eleventh"},
            {"12", "Twelfth"}
        };

        return standardMap.ContainsKey(standard) ? standardMap[standard] : standard;
    }

    private string ConvertAcademicSessionToWords(string academicSession)
    {
        // Convert format like "2025-26" to "Two Thousand Twenty-Five–Twenty-Six"
        if (string.IsNullOrWhiteSpace(academicSession))
            return "";

        var parts = academicSession.Split('-', '–');
        if (parts.Length != 2)
            return academicSession;

        try
        {
            var firstYear = int.Parse(parts[0]);
            var secondPart = parts[1];

            // Handle 2-digit second part (e.g., "26")
            int secondYear;
            if (secondPart.Length == 2)
            {
                // Convert "26" to "2026"
                var century = firstYear / 100 * 100; // Gets 2000 from 2025
                secondYear = century + int.Parse(secondPart);
            }
            else
            {
                // Full year format
                secondYear = int.Parse(secondPart);
            }

            var firstYearWords = ConvertYearToWords(firstYear);
            var secondYearWords = ConvertYearToWords(secondYear);

            return $"{firstYearWords}–{secondYearWords}";
        }
        catch
        {
            return academicSession; // Return original if parsing fails
        }
    }

    private string ConvertYearToWords(int year)
    {
        // Convert years like 2025 to "Two Thousand Twenty-Five"
        if (year < 1000 || year > 9999)
            return year.ToString();

        var thousands = year / 1000;
        var remainder = year % 1000;
        var hundreds = remainder / 100;
        var tens = (remainder % 100) / 10;
        var units = remainder % 10;

        var result = "";

        // Thousands
        if (thousands > 0)
        {
            result += ConvertNumberToWords(thousands) + " Thousand";
        }

        // Hundreds
        if (hundreds > 0)
        {
            result += (result.Length > 0 ? " " : "") + ConvertNumberToWords(hundreds) + " Hundred";
        }

        // Tens and units
        var lastTwoDigits = remainder % 100;
        if (lastTwoDigits > 0)
        {
            if (result.Length > 0) result += " ";

            if (lastTwoDigits < 20)
            {
                result += ConvertNumberToWords(lastTwoDigits);
            }
            else
            {
                var tensWords = ConvertNumberToWords(tens * 10);
                result += tensWords;
                if (units > 0)
                {
                    result += "-" + ConvertNumberToWords(units);
                }
            }
        }

        return result;
    }


    #region Bulk Promotion Methods

    private async Task LoadPromotionDataAsync()
    {
        try
        {
            if (_bulkPromotionService == null || _academicYearRepository == null)
                return;

            // Always load classes fresh from database for promotion dropdowns
            var classes = await _classService.GetAllClassesAsync();
            var classesForPromotion = classes
                .Select(c => new { Id = c.Id, Name = c.Name })
                .OrderBy(c => GetClassOrder(c.Name))
                .ToList();

            cmbPromotionFromClass.ItemsSource = classesForPromotion;
            cmbPromotionToClass.ItemsSource = classesForPromotion;

            // Load academic years
            var academicYears = await _academicYearRepository.GetRecentAcademicYearsAsync();
            cmbPromotionAcademicYear.ItemsSource = academicYears;
            cmbPromotionAcademicYear.SelectedItem = academicYears.FirstOrDefault(ay => ay.IsCurrent);
        }
        catch (Exception ex)
        {
            lblStatus.Text = $"Error loading promotion data: {ex.Message}";
        }
    }

    private int GetClassOrder(string className)
    {
        // Define order for sorting classes logically
        var classOrder = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Nursery", 0}, {"KG1", 1}, {"KG2", 2},
            {"Class 1", 3}, {"Class 2", 4}, {"Class 3", 5},
            {"Class 4", 6}, {"Class 5", 7}, {"Class 6", 8},
            {"Class 7", 9}, {"Class 8", 10}, {"Class 9", 11},
            {"Class 10", 12}
        };

        return classOrder.TryGetValue(className, out var order) ? order : 99;
    }

    private int GetClassIdByName(string className)
    {
        // Simple mapping of class names to IDs
        var classMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Nursery", 1}, {"KG1", 2}, {"KG2", 3},
            {"Class 1", 4}, {"Class 2", 5}, {"Class 3", 6}, {"Class 4", 7}, {"Class 5", 8},
            {"Class 6", 9}, {"Class 7", 10}, {"Class 8", 11}, {"Class 9", 12}, {"Class 10", 13}
        };

        return classMap.TryGetValue(className, out var id) ? id : -1;
    }

    private void CmbPromotionFromClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ValidatePromotionInputs();
    }

    private void CmbPromotionToClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ValidatePromotionInputs();
    }

    private void CmbPromotionAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ValidatePromotionInputs();
    }

    private void ValidatePromotionInputs()
    {
        var hasValidInput = cmbPromotionFromClass?.SelectedValue != null &&
                           cmbPromotionToClass?.SelectedValue != null &&
                           cmbPromotionAcademicYear?.SelectedItem != null &&
                           !cmbPromotionFromClass.SelectedValue.Equals(cmbPromotionToClass.SelectedValue);

        btnExecutePromotion.IsEnabled = hasValidInput;

        if (cmbPromotionFromClass?.SelectedValue != null && cmbPromotionToClass?.SelectedValue != null &&
            cmbPromotionFromClass.SelectedValue.Equals(cmbPromotionToClass.SelectedValue))
        {
            lblStatus.Text = "Source and target classes must be different";
            txtPromotionSummary.Text = "Source and target classes must be different.";
        }
        else if (hasValidInput)
        {
            lblStatus.Text = "Ready to execute bulk promotion";
            txtPromotionSummary.Text = $"Ready to promote students from {cmbPromotionFromClass.Text} to {cmbPromotionToClass.Text} for academic year {((dynamic)cmbPromotionAcademicYear.SelectedItem).Year}.\n\nClick 'Execute Promotion' to proceed with bulk promotion.";
        }
        else
        {
            lblStatus.Text = "Please select source class, target class, and academic year";
            txtPromotionSummary.Text = "Select source and target classes, then click 'Execute Promotion' to proceed with bulk promotion.";
        }
    }


    private void BtnExecutePromotion_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(BtnExecutePromotion_ClickAsync);
    }

    private async Task BtnExecutePromotion_ClickAsync()
    {
        try
        {
            if (_bulkPromotionService == null)
            {
                MessageBox.Show("Bulk promotion service is not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cmbPromotionFromClass.SelectedValue == null || cmbPromotionToClass.SelectedValue == null || cmbPromotionAcademicYear.SelectedValue == null)
            {
                MessageBox.Show("Please select source class, target class, and academic year.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var fromClassId = (int)cmbPromotionFromClass.SelectedValue;
            var toClassId = (int)cmbPromotionToClass.SelectedValue;

            if (fromClassId == toClassId)
            {
                MessageBox.Show("Source and target classes must be different.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Get a preview first to show how many students will be promoted
            var preview = await _bulkPromotionService.GetPromotionPreviewAsync(fromClassId, toClassId);
            var eligibleStudents = preview.Count(p => p.IsEligible);

            var result = MessageBox.Show(
                $"Are you sure you want to promote {eligibleStudents} eligible students from {cmbPromotionFromClass.Text} to {cmbPromotionToClass.Text}?\n\nThis action cannot be easily undone.",
                "Confirm Bulk Promotion",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
                return;

            lblStatus.Text = "Executing bulk promotion...";
            btnExecutePromotion.IsEnabled = false;

            var request = new BulkPromotionRequest
            {
                FromClassId = fromClassId,
                ToClassId = toClassId,
                AcademicYear = cmbPromotionAcademicYear.SelectedValue.ToString(),
                ExcludedStudentIds = new List<int>(), // No exclusions since no preview
                Reason = "Annual Promotion"
            };

            var promotionResult = await _bulkPromotionService.ExecuteBulkPromotionAsync(request);

            // Update summary and show results
            if (promotionResult.IsSuccess)
            {
                txtPromotionSummary.Text = $"✅ Promotion Completed Successfully!\n\nPromoted: {promotionResult.PromotedStudents} students\nFrom: {cmbPromotionFromClass.Text}\nTo: {cmbPromotionToClass.Text}\nAcademic Year: {request.AcademicYear}\nDate: {promotionResult.PromotionDate:yyyy-MM-dd HH:mm:ss}";
                MessageBox.Show($"Bulk promotion completed successfully!\n\nPromoted: {promotionResult.PromotedStudents} students from {cmbPromotionFromClass.Text} to {cmbPromotionToClass.Text}",
                               "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                txtPromotionSummary.Text = $"⚠️ Promotion Completed with Errors\n\nPromoted: {promotionResult.PromotedStudents} students\nFailed: {promotionResult.FailedPromotions} students\nFrom: {cmbPromotionFromClass.Text}\nTo: {cmbPromotionToClass.Text}\nAcademic Year: {request.AcademicYear}\nDate: {promotionResult.PromotionDate:yyyy-MM-dd HH:mm:ss}";
                var errorDetails = string.Join("\n", promotionResult.Errors.Take(5).Select(e => $"• {e.StudentName}: {e.Error}"));
                if (promotionResult.Errors.Count > 5)
                    errorDetails += $"\n... and {promotionResult.Errors.Count - 5} more errors";

                MessageBox.Show($"Bulk promotion completed with errors.\n\nPromoted: {promotionResult.PromotedStudents}\nFailed: {promotionResult.FailedPromotions}\n\nSample errors:\n{errorDetails}",
                               "Partial Success", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            lblStatus.Text = promotionResult.IsSuccess
                ? $"Successfully promoted {promotionResult.PromotedStudents} students"
                : $"Promotion completed with {promotionResult.FailedPromotions} errors";

            // Refresh students list and apply filters after loading
            await LoadStudentsAsync();
            FilterStudents();

            // Refresh classes to update student counts and dashboard
            AsyncHelper.SafeFireAndForget(LoadClassesAsync);
            AsyncHelper.SafeFireAndForget(LoadDashboardDataAsync);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error executing promotion: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error executing promotion";
        }
        finally
        {
            btnExecutePromotion.IsEnabled = true;
        }
    }


    private void BtnCancelPromotion_Click(object sender, RoutedEventArgs e)
    {
        // Reset the promotion form
        cmbPromotionFromClass.SelectedValue = null;
        cmbPromotionToClass.SelectedValue = null;
        cmbPromotionAcademicYear.SelectedValue = null;
        txtPromotionSummary.Text = "Select source and target classes, then click 'Execute Promotion' to proceed with bulk promotion.";
        lblStatus.Text = "Promotion form reset";
    }

    #endregion
}