using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace IEMS.WPF
{
    public partial class FinanceManagementWindow : Window
    {
        private readonly FeePaymentService _feePaymentService;
        private readonly ClassService _classService;
        private readonly StudentService _studentService;
        private readonly FeeStructureService _feeStructureService;
        private readonly ElectricityBillService _electricityBillService;
        private readonly OtherExpenseService _otherExpenseService;
        private readonly TransportExpenseService _transportExpenseService;
        private readonly TeacherService _teacherService;
        private readonly StaffService _staffService;
        private List<FeePaymentDto> _allFeePayments = new();
        private List<ClassDto> _allClasses = new();
        private string _currentAcademicYear = DateTime.Now.Year.ToString() + "-" + (DateTime.Now.Year + 1).ToString().Substring(2);

        public FinanceManagementWindow(FeePaymentService feePaymentService, ClassService classService, StudentService studentService, FeeStructureService feeStructureService, ElectricityBillService electricityBillService, OtherExpenseService otherExpenseService, TransportExpenseService transportExpenseService, TeacherService teacherService, StaffService staffService)
        {
            InitializeComponent();
            _feePaymentService = feePaymentService;
            _classService = classService;
            _studentService = studentService;
            _feeStructureService = feeStructureService;
            _electricityBillService = electricityBillService;
            _otherExpenseService = otherExpenseService;
            _transportExpenseService = transportExpenseService;
            _teacherService = teacherService;
            _staffService = staffService;
            Loaded += Window_Loaded;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load Expense Management into frame
                frameExpenseManagement.Content = new ExpenseManagementWindow(_electricityBillService, _otherExpenseService, _transportExpenseService, _feePaymentService, _teacherService, _staffService);

                // Initialize academic year dropdown
                InitializeAcademicYears();

                // Initialize date filters
                dpFeeFromDate.SelectedDate = DateTime.Today.AddDays(-30);
                dpFeeToDate.SelectedDate = DateTime.Today;

                // Load initial data
                await LoadClasses();
                await LoadFeePayments();
                await LoadAnalytics();

                lblStatus.Text = "Finance Management Ready";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Finance Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeAcademicYears()
        {
            var currentYear = DateTime.Now.Year;
            var academicYears = new List<string>();

            for (int i = -2; i <= 1; i++)
            {
                var year = currentYear + i;
                academicYears.Add($"{year}-{(year + 1).ToString().Substring(2)}");
            }

            cmbAcademicYear.ItemsSource = academicYears;
            cmbAcademicYear.SelectedItem = _currentAcademicYear;
        }

        private async Task LoadClasses()
        {
            try
            {
                _allClasses = (await _classService.GetAllClassesAsync()).ToList();

                // Add "All Classes" option for filter
                var filterClasses = new List<ClassDto> { new ClassDto { Id = 0, Name = "All Classes" } };
                filterClasses.AddRange(_allClasses);
                cmbClassFilter.ItemsSource = filterClasses;
                cmbClassFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadFeePayments()
        {
            try
            {
                _allFeePayments = (await _feePaymentService.GetAllFeePaymentsAsync()).ToList();
                ApplyFeeFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading fee payments: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadAnalytics()
        {
            try
            {
                var analytics = await _feePaymentService.GetFeeAnalyticsAsync(_currentAcademicYear);

                // Update summary cards
                txtTotalCollection.Text = $"₹{analytics.TotalCollection:N2}";
                txtPendingFees.Text = $"₹{analytics.PendingFees:N2}";
                txtStudentsWithPending.Text = analytics.StudentsWithPendingFees.ToString();
                txtCollectionRate.Text = $"{analytics.CompletionPercentage:F1}%";

                // Load data grids
                dgMonthlyTrend.ItemsSource = analytics.MonthlyCollections;
                dgFeeTypeAnalytics.ItemsSource = analytics.FeeTypeAnalytics;
                dgClassWiseAnalysis.ItemsSource = analytics.ClassWisePendingFees;

                // Load pending fees
                await LoadPendingFees();

                lblStatus.Text = $"Analytics updated for {_currentAcademicYear}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadPendingFees(int? classId = null)
        {
            try
            {
                var pendingFees = await _feePaymentService.GetStudentsWithPendingFeesAsync(_currentAcademicYear, classId);
                dgPendingFees.ItemsSource = pendingFees;

                lblStatus.Text = $"Found {pendingFees.Count} students with pending fees";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending fees: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFeeFilter()
        {
            if (_allFeePayments == null) return;

            var filtered = _allFeePayments.AsEnumerable();

            if (dpFeeFromDate.SelectedDate.HasValue)
            {
                filtered = filtered.Where(f => f.PaymentDate >= dpFeeFromDate.SelectedDate.Value);
            }

            if (dpFeeToDate.SelectedDate.HasValue)
            {
                filtered = filtered.Where(f => f.PaymentDate <= dpFeeToDate.SelectedDate.Value.AddDays(1));
            }

            dgFeePayments.ItemsSource = filtered.OrderByDescending(f => f.PaymentDate).ToList();
        }

        #region Event Handlers

        private async void CmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAcademicYear.SelectedItem != null)
            {
                _currentAcademicYear = cmbAcademicYear.SelectedItem.ToString() ?? _currentAcademicYear;
                await LoadAnalytics();
            }
        }

        private async void BtnRefreshAnalytics_Click(object sender, RoutedEventArgs e)
        {
            await LoadFeePayments();
            await LoadAnalytics();
        }

        private async void CmbClassFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbClassFilter.SelectedItem is ClassDto selectedClass)
            {
                var classId = selectedClass.Id == 0 ? (int?)null : selectedClass.Id;
                await LoadPendingFees(classId);
            }
        }

        private async void BtnCollectFee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var feeWindow = new AddEditFeePaymentWindow(_feePaymentService, _feeStructureService, _studentService);
                if (feeWindow.ShowDialog() == true)
                {
                    await LoadFeePayments();
                    await LoadAnalytics();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening fee collection: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnViewReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (dgFeePayments.SelectedItem is FeePaymentDto selectedPayment)
            {
                try
                {
                    var receiptDto = new FeeReceiptDto
                    {
                        ReceiptNumber = selectedPayment.ReceiptNumber,
                        ReceiptDate = selectedPayment.PaymentDate,
                        StudentName = selectedPayment.StudentName,
                        ClassName = selectedPayment.ClassName,
                        FeeType = selectedPayment.FeeType,
                        AmountPaid = selectedPayment.AmountPaid,
                        PaymentMethod = selectedPayment.PaymentMethod
                    };
                    var receiptWindow = new FeeReceiptWindow(receiptDto, _feePaymentService);
                    receiptWindow.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening receipt: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a payment to view receipt.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnApplyFeeFilter_Click(object sender, RoutedEventArgs e)
        {
            ApplyFeeFilter();
        }

        private void BtnExportPendingFees_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var pendingFees = dgPendingFees.ItemsSource as List<StudentFeeStatusDto>;
                if (pendingFees?.Count > 0)
                {
                    ExportToExcel(pendingFees);
                }
                else
                {
                    MessageBox.Show("No pending fees data to export.", "No Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region Export Functionality

        private void ExportToExcel(List<StudentFeeStatusDto> pendingFees)
        {
            try
            {
                var saveDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                    DefaultExt = "csv",
                    FileName = $"PendingFees_{_currentAcademicYear}_{DateTime.Now:yyyyMMdd}.csv"
                };

                if (saveDialog.ShowDialog() == true)
                {
                    using (var writer = new System.IO.StreamWriter(saveDialog.FileName))
                    {
                        // Write header
                        writer.WriteLine("Student Name,Class,Student Number,Parent Phone,Total Pending Amount,Last Payment Date,Days Since Last Payment");

                        // Write data
                        foreach (var student in pendingFees)
                        {
                            writer.WriteLine($"\"{student.StudentName}\",\"{student.ClassName}\",\"{student.StudentNumber}\",\"{student.ParentPhone}\",{student.TotalPendingAmount:F2},{student.LastPaymentDate:yyyy-MM-dd},{student.DaysSinceLastPayment}");
                        }
                    }

                    MessageBox.Show($"Data exported successfully to {saveDialog.FileName}", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                    lblStatus.Text = $"Exported {pendingFees.Count} records to CSV";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during export: {ex.Message}", "Export Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}