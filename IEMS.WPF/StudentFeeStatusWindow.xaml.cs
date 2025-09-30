using System;
using System.Threading.Tasks;
using System.Windows;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.WPF.Helpers;

namespace IEMS.WPF
{
    public partial class StudentFeeStatusWindow : Window
    {
        private readonly FeePaymentService _feePaymentService;
        private readonly int _studentId;
        private readonly string _academicYear;
        private StudentFeeStatusDto? _currentFeeStatus;

        public StudentFeeStatusWindow(FeePaymentService feePaymentService, int studentId, string academicYear)
        {
            InitializeComponent();
            _feePaymentService = feePaymentService;
            _studentId = studentId;
            _academicYear = academicYear;

            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                await LoadStudentFeeStatusAsync();
            }, "Student Fee Status Loading Error");
        }

        private async Task LoadStudentFeeStatusAsync()
        {
            try
            {
                _currentFeeStatus = await _feePaymentService.GetStudentFeeStatusAsync(_studentId, _academicYear);

                if (_currentFeeStatus != null)
                {
                    UpdateUI();
                }
                else
                {
                    MessageBox.Show("Unable to load student fee status.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading student fee status: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateUI()
        {
            if (_currentFeeStatus == null) return;

            // Update header information
            lblStudentName.Text = $"📚 {_currentFeeStatus.StudentName}";
            lblStudentNumber.Text = $"Student No: {_currentFeeStatus.StudentNumber}";
            lblClassName.Text = $"Class: {_currentFeeStatus.ClassName}";
            lblAcademicYear.Text = $"Academic Year: {_currentFeeStatus.AcademicYear}";

            // Update total outstanding with appropriate styling
            lblTotalOutstanding.Text = _currentFeeStatus.FormattedTotalOutstanding;

            if (_currentFeeStatus.HasOutstandingFees)
            {
                lblTotalOutstanding.Style = (Style)FindResource("OutstandingTextStyle");
                Title = $"Student Fee Status - {_currentFeeStatus.StudentName} (Outstanding: {_currentFeeStatus.FormattedTotalOutstanding})";
            }
            else
            {
                lblTotalOutstanding.Style = (Style)FindResource("PaidTextStyle");
                lblTotalOutstanding.Text = "✅ All Paid";
                Title = $"Student Fee Status - {_currentFeeStatus.StudentName} (All Fees Paid)";
            }

            // Load fee type status data
            dgFeeTypes.ItemsSource = _currentFeeStatus.FeeTypeStatuses;

            // Load recent payments data
            if (_currentFeeStatus.RecentPayments != null && _currentFeeStatus.RecentPayments.Count > 0)
            {
                dgRecentPayments.ItemsSource = _currentFeeStatus.RecentPayments;
                emptyPaymentsPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                dgRecentPayments.ItemsSource = null;
                emptyPaymentsPanel.Visibility = Visibility.Visible;
            }
        }

        private void BtnRecordPayment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the required services from the application's service provider
                var serviceProvider = App.ServiceProvider;
                var studentService = serviceProvider?.GetService(typeof(StudentService)) as StudentService;
                var classService = serviceProvider?.GetService(typeof(ClassService)) as ClassService;
                var feeStructureService = serviceProvider?.GetService(typeof(FeeStructureService)) as FeeStructureService;
                var academicYearService = serviceProvider?.GetService(typeof(AcademicYearService)) as AcademicYearService;

                if (studentService != null && feeStructureService != null && academicYearService != null)
                {
                    var addFeePaymentWindow = new AddEditFeePaymentWindow(
                        _feePaymentService, feeStructureService, studentService, academicYearService);

                    // Pre-select the current student if possible
                    addFeePaymentWindow.SetStudentId(_studentId);

                    addFeePaymentWindow.Owner = this;
                    var result = addFeePaymentWindow.ShowDialog();

                    if (result == true)
                    {
                        // Refresh the fee status after payment
                        AsyncHelper.SafeFireAndForget(async () =>
                        {
                            await LoadStudentFeeStatusAsync();
                        }, "Fee Status Refresh Error");
                    }
                }
                else
                {
                    MessageBox.Show("Unable to open payment window. Required services not available.", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening payment window: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                await LoadStudentFeeStatusAsync();
            }, "Fee Status Refresh Error");
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}