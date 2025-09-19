using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.WPF.Controls;

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
    private List<ClassDto> _allClasses = new List<ClassDto>();

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
        LoadBonafideStudents();
        LoadDashboardData();
    }

    private async void LoadStudents()
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
            LoadDashboardData();

            // Load leaving certificate students dropdown after students data is loaded
            LoadLeavingCertificateStudents();
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

    private async void LoadClasses()
    {
        try
        {
            lblStatus.Text = "Loading classes...";
            var classes = await _classService.GetAllClassesAsync();
            _allClasses = classes.ToList();
            dgClasses.ItemsSource = _allClasses;
            lblStatus.Text = $"Loaded {classes.Count()} classes";

            // Refresh dashboard after loading classes
            LoadDashboardData();
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
            LoadDashboardData(); // Refresh dashboard
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
                LoadDashboardData(); // Refresh dashboard
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
                    loadingOverlay.IsLoading = true;
                    loadingOverlay.LoadingMessage = "Deleting student...";

                    await _studentService.DeleteStudentAsync(selectedStudent.Id);
                    var currentSearch = txtSearchStudents.Text;
                    LoadStudents();
                    LoadClasses(); // Refresh to update student counts in classes
                    txtSearchStudents.Text = currentSearch; // Restore search after refresh

                    toastNotification.Message = $"Student {selectedStudent.FullName} deleted successfully";
                    toastNotification.ToastType = ToastType.Success;
                    toastNotification.Show();
                    FilterStudents();
                    LoadDashboardData(); // Refresh dashboard
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
    }

    private void BtnRefreshStudents_Click(object sender, RoutedEventArgs e)
    {
        LoadStudents();
        txtSearchStudents.Text = ""; // Clear search when refreshing
        LoadDashboardData(); // Refresh dashboard
    }

    // Class Management Events
    private void BtnAddClass_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditClassWindow(_classService, _teacherService);
        if (addWindow.ShowDialog() == true)
        {
            LoadClasses();
            LoadDashboardData(); // Refresh dashboard
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
                LoadDashboardData(); // Refresh dashboard
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
                    LoadDashboardData(); // Refresh dashboard
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
        LoadDashboardData(); // Refresh dashboard
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
            student.Address.ToLower().Contains(searchText) ||
            student.CityVillage.ToLower().Contains(searchText)
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

    // Bonafide Certificate Event Handlers
    private async void BtnGenerateBonafide_Click(object sender, RoutedEventArgs e)
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
    }

    private void BtnRefreshBonafide_Click(object sender, RoutedEventArgs e)
    {
        LoadBonafideStudents();
    }

    private void LoadBonafideStudents()
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
    private async void LoadDashboardData()
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
    private void LoadLeavingCertificateStudents()
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
                    if (lblLeavingSubcaste != null) lblLeavingSubcaste.Text = ""; // Not available in current StudentDto
                    if (lblLeavingMotherTongue != null) lblLeavingMotherTongue.Text = "Marathi"; // Default or could be added to StudentDto
                    if (lblLeavingPlaceOfBirth != null) lblLeavingPlaceOfBirth.Text = selectedStudent.CityVillage ?? "";

                    // Set default value for last class
                    if (txtLastClass != null) txtLastClass.Text = selectedStudent.Standard;

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
                certStandard.Text = $"{student.Standard} ({student.ClassDivision})";

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

                    // Print with A4 size
                    printDialog.PrintVisual(certificateToPrint, $"Leaving Certificate - {selectedStudent.FullName}");

                    toastNotification.Message = "Leaving Certificate sent to printer!";
                    toastNotification.ToastType = ToastType.Success;
                    toastNotification.Show();

                    lblStatus.Text = "Certificate printed";
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

    private void CmbMotherTongue_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        try
        {
            if (cmbMotherTongue.SelectedItem is ComboBoxItem selectedItem)
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
}