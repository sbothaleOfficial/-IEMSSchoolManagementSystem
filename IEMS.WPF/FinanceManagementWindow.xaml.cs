using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Entities;
using IEMS.Core.Enums;
using IEMS.WPF.Helpers;
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

        // Expense management collections
        private ObservableCollection<ElectricityBillDto> _electricityBills = new();
        private ObservableCollection<OtherExpenseDto> _otherExpenses = new();

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                try
                {
                    // Initialize expense management data
                    await LoadElectricityBills();
                    await LoadOtherExpenses();
                    InitializeCategoryFilter();

                    dgElectricityBills.ItemsSource = _electricityBills;
                    dgOtherExpenses.ItemsSource = _otherExpenses;

                    // Initialize academic year dropdown
                    InitializeAcademicYears();

                    // Initialize date filters
                    dpFeeFromDate.SelectedDate = DateTime.Today.AddDays(-30);
                    dpFeeToDate.SelectedDate = DateTime.Today;

                    // Load initial data
                    await LoadClasses();
                    await LoadFeePayments();
                    await LoadAnalytics();

                    // Load expense dashboard
                    await RefreshExpenseDashboard();

                    lblStatus.Text = "Finance Management Ready";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading Finance Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, "Finance Management Window Loading Error");
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

        private void CmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                if (cmbAcademicYear.SelectedItem != null)
                {
                    _currentAcademicYear = cmbAcademicYear.SelectedItem.ToString() ?? _currentAcademicYear;
                    await LoadAnalytics();
                }
            }, "Academic Year Selection Error");
        }

        private void BtnRefreshAnalytics_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                await LoadFeePayments();
                await LoadAnalytics();
            }, "Analytics Refresh Error");
        }

        private void CmbClassFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                if (cmbClassFilter.SelectedItem is ClassDto selectedClass)
                {
                    var classId = selectedClass.Id == 0 ? (int?)null : selectedClass.Id;
                    await LoadPendingFees(classId);
                }
            }, "Class Filter Selection Error");
        }

        private void BtnGoToStudentManagement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Close current window
                this.Close();

                // Open Student Management window directly on Fee Payment tab
                var studentsWindow = new StudentsManagementWindow(
                    _studentService,
                    _classService,
                    _teacherService,
                    _feePaymentService,
                    _feeStructureService,
                    null, // BulkPromotionService (optional)
                    null  // IAcademicYearRepository (optional)
                );

                // Note: User will need to manually navigate to Fee Payment tab
                // as the TabControl doesn't have a public name
                studentsWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Student Management: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        #region Expense Management Methods

        #region Electricity Bills Tab

        private async Task LoadElectricityBills()
        {
            try
            {
                var bills = await _electricityBillService.GetAllAsync();
                _electricityBills.Clear();

                if (bills != null)
                {
                    foreach (var bill in bills)
                    {
                        if (bill != null)
                        {
                            _electricityBills.Add(bill);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading electricity bills: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = $"Error loading electricity bills: {ex.Message}";
            }
        }

        private void BtnAddElectricityBill_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                try
                {
                    var addWindow = new AddEditElectricityBillWindow(_electricityBillService);
                    if (addWindow.ShowDialog() == true)
                    {
                        await LoadElectricityBills();
                        await RefreshExpenseDashboard();
                        lblStatus.Text = "Electricity bill added successfully";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening add electricity bill window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private void BtnEditElectricityBill_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                try
                {
                    if (sender is Button button && button.Tag is int billId)
                {
                    var editWindow = new AddEditElectricityBillWindow(_electricityBillService, billId);
                    if (editWindow.ShowDialog() == true)
                    {
                        await LoadElectricityBills();
                        await RefreshExpenseDashboard();
                        lblStatus.Text = "Electricity bill updated successfully";
                    }
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening edit electricity bill window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }

        private async void BtnDeleteElectricityBill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is int billId)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this electricity bill?",
                        "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        await _electricityBillService.DeleteAsync(billId);
                        await LoadElectricityBills();
                        await RefreshExpenseDashboard();
                        lblStatus.Text = "Electricity bill deleted successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting electricity bill: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DgElectricityBills_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgElectricityBills.SelectedItem is ElectricityBillDto selectedBill)
            {
                var editWindow = new AddEditElectricityBillWindow(_electricityBillService, selectedBill.Id);
                if (editWindow.ShowDialog() == true)
                {
                    await LoadElectricityBills();
                    await RefreshExpenseDashboard();
                }
            }
        }

        #endregion

        #region Other Expenses Tab

        private async Task LoadOtherExpenses()
        {
            try
            {
                var expenses = await _otherExpenseService.GetAllAsync();
                _otherExpenses.Clear();
                foreach (var expense in expenses)
                {
                    _otherExpenses.Add(expense);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading other expenses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeCategoryFilter()
        {
            var categories = new List<string> { "All Categories" };
            categories.AddRange(Enum.GetNames<OtherExpenseCategory>().Select(c => c.Replace("_", " ")));
            cmbCategoryFilter.ItemsSource = categories;
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private async void CmbCategoryFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbCategoryFilter.SelectedItem is string selectedCategory && selectedCategory != "All Categories")
                {
                    var category = Enum.Parse<OtherExpenseCategory>(selectedCategory.Replace(" ", "_"));
                    var filteredExpenses = await _otherExpenseService.GetByCategoryAsync(category);

                    _otherExpenses.Clear();
                    foreach (var expense in filteredExpenses)
                    {
                        _otherExpenses.Add(expense);
                    }
                }
                else
                {
                    await LoadOtherExpenses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering expenses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnClearFilter_Click(object sender, RoutedEventArgs e)
        {
            cmbCategoryFilter.SelectedIndex = 0;
            await LoadOtherExpenses();
        }

        private async void BtnAddOtherExpense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addWindow = new AddEditOtherExpenseWindow(_otherExpenseService);
                if (addWindow.ShowDialog() == true)
                {
                    await LoadOtherExpenses();
                    await RefreshExpenseDashboard();
                    lblStatus.Text = "Other expense added successfully";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add other expense window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnEditOtherExpense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is int expenseId)
                {
                    var editWindow = new AddEditOtherExpenseWindow(_otherExpenseService, expenseId);
                    if (editWindow.ShowDialog() == true)
                    {
                        await LoadOtherExpenses();
                        await RefreshExpenseDashboard();
                        lblStatus.Text = "Other expense updated successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit other expense window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnDeleteOtherExpense_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender is Button button && button.Tag is int expenseId)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this expense?",
                        "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        await _otherExpenseService.DeleteAsync(expenseId);
                        await LoadOtherExpenses();
                        await RefreshExpenseDashboard();
                        lblStatus.Text = "Other expense deleted successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting other expense: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void DgOtherExpenses_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgOtherExpenses.SelectedItem is OtherExpenseDto selectedExpense)
            {
                var editWindow = new AddEditOtherExpenseWindow(_otherExpenseService, selectedExpense.Id);
                if (editWindow.ShowDialog() == true)
                {
                    await LoadOtherExpenses();
                    await RefreshExpenseDashboard();
                }
            }
        }

        #endregion

        #region Expense Analytics Tab

        private async void ViewRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            await RefreshExpenseDashboard();
        }

        private async void BtnRefreshDashboard_Click(object sender, RoutedEventArgs e)
        {
            await RefreshExpenseDashboard();
        }

        private async Task RefreshExpenseDashboard()
        {
            try
            {
                // Check if UI elements are loaded
                if (rbMonthly == null || rbYearly == null || rbOverall == null ||
                    txtElectricityTotal == null || txtOtherExpensesTotal == null ||
                    txtTransportTotal == null || txtSalariesTotal == null ||
                    txtTotalIncome == null || txtTotalExpenses == null ||
                    txtNetBalance == null || dgCategoryBreakdown == null)
                {
                    return; // UI not ready yet
                }

                DateTime fromDate, toDate;
                GetDateRange(out fromDate, out toDate);

                // Get expense data by filtering existing collections
                var electricityBills = await _electricityBillService.GetAllAsync();
                var electricityTotal = electricityBills
                    .Where(b => (b.PaidDate ?? b.DueDate) >= fromDate && (b.PaidDate ?? b.DueDate) <= toDate)
                    .Sum(b => b.Amount);

                var otherExpenses = await _otherExpenseService.GetAllAsync();
                var otherExpensesTotal = otherExpenses
                    .Where(e => e.ExpenseDate >= fromDate && e.ExpenseDate <= toDate)
                    .Sum(e => e.Amount);

                // For transport expenses - use a simple calculation
                var transportTotal = 0m; // Placeholder - would need to implement based on TransportExpenseService

                // For salaries - use a simple calculation
                var salariesTotal = 0m; // Placeholder - would need to implement based on StaffService

                // Get income data from fee payments
                var feePayments = await _feePaymentService.GetAllFeePaymentsAsync();
                var totalIncome = feePayments
                    .Where(f => f.PaymentDate >= fromDate && f.PaymentDate <= toDate)
                    .Sum(f => f.AmountPaid);

                // Update UI
                txtElectricityTotal.Text = $"₹{electricityTotal:N2}";
                txtOtherExpensesTotal.Text = $"₹{otherExpensesTotal:N2}";
                txtTransportTotal.Text = $"₹{transportTotal:N2}";
                txtSalariesTotal.Text = $"₹{salariesTotal:N2}";
                txtTotalIncome.Text = $"₹{totalIncome:N2}";

                var totalExpenses = electricityTotal + otherExpensesTotal + transportTotal + salariesTotal;
                txtTotalExpenses.Text = $"₹{totalExpenses:N2}";

                var netBalance = totalIncome - totalExpenses;
                txtNetBalance.Text = $"₹{netBalance:N2}";
                txtNetBalance.Foreground = netBalance >= 0
                    ? new SolidColorBrush(Color.FromRgb(76, 175, 80)) // Green
                    : new SolidColorBrush(Color.FromRgb(244, 67, 54)); // Red

                // Update category breakdown
                var categoryData = new List<dynamic>
                {
                    new { Category = "Electricity", Amount = electricityTotal, Percentage = totalExpenses > 0 ? (electricityTotal / totalExpenses) * 100 : 0 },
                    new { Category = "Other Expenses", Amount = otherExpensesTotal, Percentage = totalExpenses > 0 ? (otherExpensesTotal / totalExpenses) * 100 : 0 },
                    new { Category = "Transport", Amount = transportTotal, Percentage = totalExpenses > 0 ? (transportTotal / totalExpenses) * 100 : 0 },
                    new { Category = "Staff Salaries", Amount = salariesTotal, Percentage = totalExpenses > 0 ? (salariesTotal / totalExpenses) * 100 : 0 }
                };

                dgCategoryBreakdown.ItemsSource = categoryData.Where(c => c.Amount > 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing expense dashboard: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetDateRange(out DateTime fromDate, out DateTime toDate)
        {
            var today = DateTime.Today;

            if (rbMonthly?.IsChecked == true)
            {
                fromDate = new DateTime(today.Year, today.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
            }
            else if (rbYearly?.IsChecked == true)
            {
                fromDate = new DateTime(today.Year, 1, 1);
                toDate = new DateTime(today.Year, 12, 31);
            }
            else // Overall
            {
                fromDate = DateTime.MinValue;
                toDate = DateTime.MaxValue;
            }
        }

        #endregion

        #endregion
    }
}