using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.Core.Enums;

namespace IEMS.WPF;

public partial class ExpenseManagementWindow : Window
{
    private readonly ElectricityBillService _electricityBillService;
    private readonly OtherExpenseService _otherExpenseService;
    private readonly TransportExpenseService _transportExpenseService;
    private readonly FeePaymentService _feePaymentService;
    private readonly TeacherService _teacherService;
    private readonly StaffService _staffService;

    private ObservableCollection<ElectricityBillDto> _electricityBills = new();
    private ObservableCollection<OtherExpenseDto> _otherExpenses = new();

    public ExpenseManagementWindow(
        ElectricityBillService electricityBillService,
        OtherExpenseService otherExpenseService,
        TransportExpenseService transportExpenseService,
        FeePaymentService feePaymentService,
        TeacherService teacherService,
        StaffService staffService)
    {
        InitializeComponent();
        _electricityBillService = electricityBillService;
        _otherExpenseService = otherExpenseService;
        _transportExpenseService = transportExpenseService;
        _feePaymentService = feePaymentService;
        _teacherService = teacherService;
        _staffService = staffService;

        InitializeWindow();
    }

    private async void InitializeWindow()
    {
        try
        {
            await LoadElectricityBills();
            await LoadOtherExpenses();
            InitializeCategoryFilter();

            dgElectricityBills.ItemsSource = _electricityBills;
            dgOtherExpenses.ItemsSource = _otherExpenses;

            lblStatus.Text = "Expense Management Ready";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            await RefreshDashboard();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    #region Electricity Bills Tab

    private async Task LoadElectricityBills()
    {
        try
        {
            var bills = await _electricityBillService.GetAllAsync();
            _electricityBills.Clear();
            foreach (var bill in bills)
            {
                _electricityBills.Add(bill);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading electricity bills: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnAddElectricityBill_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var addWindow = new AddEditElectricityBillWindow(_electricityBillService);
            if (addWindow.ShowDialog() == true)
            {
                await LoadElectricityBills();
                await RefreshDashboard();
                lblStatus.Text = "Electricity bill added successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening add electricity bill window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnEditElectricityBill_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (sender is Button button && button.Tag is int billId)
            {
                var editWindow = new AddEditElectricityBillWindow(_electricityBillService, billId);
                if (editWindow.ShowDialog() == true)
                {
                    await LoadElectricityBills();
                    await RefreshDashboard();
                    lblStatus.Text = "Electricity bill updated successfully";
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening edit electricity bill window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
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
                    await RefreshDashboard();
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
                await RefreshDashboard();
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
                await RefreshDashboard();
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
                    await RefreshDashboard();
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
                    await RefreshDashboard();
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
                await RefreshDashboard();
            }
        }
    }

    #endregion

    #region Dashboard Tab

    private async void ViewRadioButton_Checked(object sender, RoutedEventArgs e)
    {
        await RefreshDashboard();
    }

    private async void BtnRefreshDashboard_Click(object sender, RoutedEventArgs e)
    {
        await RefreshDashboard();
    }

    private async Task RefreshDashboard()
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

            var currentDate = DateTime.Now;
            DateTime fromDate, toDate;

            if (rbMonthly.IsChecked == true)
            {
                fromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
                toDate = fromDate.AddMonths(1).AddDays(-1);
            }
            else if (rbYearly.IsChecked == true)
            {
                fromDate = new DateTime(currentDate.Year, 1, 1);
                toDate = new DateTime(currentDate.Year, 12, 31);
            }
            else
            {
                fromDate = DateTime.MinValue;
                toDate = DateTime.MaxValue;
            }

            // Calculate totals
            var electricityTotal = rbOverall.IsChecked == true
                ? await _electricityBillService.GetTotalAmountByDateRangeAsync(DateTime.MinValue, DateTime.MaxValue)
                : await _electricityBillService.GetTotalAmountByDateRangeAsync(fromDate, toDate);

            var otherExpensesTotal = rbOverall.IsChecked == true
                ? await _otherExpenseService.GetTotalAmountByDateRangeAsync(DateTime.MinValue, DateTime.MaxValue)
                : await _otherExpenseService.GetTotalAmountByDateRangeAsync(fromDate, toDate);

            var transportTotal = rbOverall.IsChecked == true
                ? await _transportExpenseService.GetTotalAmountByDateRangeAsync(DateTime.MinValue, DateTime.MaxValue)
                : await _transportExpenseService.GetTotalAmountByDateRangeAsync(fromDate, toDate);

            var feeIncome = rbOverall.IsChecked == true
                ? await _feePaymentService.GetTotalAmountByDateRangeAsync(DateTime.MinValue, DateTime.MaxValue)
                : await _feePaymentService.GetTotalAmountByDateRangeAsync(fromDate, toDate);

            // Calculate monthly salaries
            var teachers = await _teacherService.GetAllAsync();
            var staff = await _staffService.GetAllAsync();
            var monthlySalaries = teachers.Sum(t => t.MonthlySalary) + staff.Sum(s => s.MonthlySalary);

            var salariesTotal = rbMonthly.IsChecked == true
                ? monthlySalaries
                : rbYearly.IsChecked == true
                    ? monthlySalaries * 12
                    : monthlySalaries * 12; // For overall, assume 1 year

            // Update UI
            txtElectricityTotal.Text = $"₹{electricityTotal:N2}";
            txtOtherExpensesTotal.Text = $"₹{otherExpensesTotal:N2}";
            txtTransportTotal.Text = $"₹{transportTotal:N2}";
            txtSalariesTotal.Text = $"₹{salariesTotal:N2}";
            txtTotalIncome.Text = $"₹{feeIncome:N2}";

            var totalExpenses = electricityTotal + otherExpensesTotal + transportTotal + salariesTotal;
            txtTotalExpenses.Text = $"₹{totalExpenses:N2}";

            var netBalance = feeIncome - totalExpenses;
            txtNetBalance.Text = $"₹{netBalance:N2}";
            txtNetBalance.Foreground = netBalance >= 0
                ? new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(76, 175, 80))
                : new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(244, 67, 54));

            // Update category breakdown
            var categoryBreakdown = new List<CategoryBreakdownItem>
            {
                new() { Category = "Electricity", Amount = electricityTotal, Percentage = totalExpenses > 0 ? (double)(electricityTotal / totalExpenses) * 100 : 0 },
                new() { Category = "Other Expenses", Amount = otherExpensesTotal, Percentage = totalExpenses > 0 ? (double)(otherExpensesTotal / totalExpenses) * 100 : 0 },
                new() { Category = "Transport", Amount = transportTotal, Percentage = totalExpenses > 0 ? (double)(transportTotal / totalExpenses) * 100 : 0 },
                new() { Category = "Staff Salaries", Amount = salariesTotal, Percentage = totalExpenses > 0 ? (double)(salariesTotal / totalExpenses) * 100 : 0 }
            };

            dgCategoryBreakdown.ItemsSource = categoryBreakdown;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error refreshing dashboard: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    #endregion

    #region Window Events

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    #endregion

    public class CategoryBreakdownItem
    {
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public double Percentage { get; set; }
    }
}