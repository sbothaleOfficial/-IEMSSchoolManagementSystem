using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Enums;
using IEMS.WPF.Helpers;

namespace IEMS.WPF;

public partial class TransportManagementWindow : Window
{
    private readonly VehicleService _vehicleService;
    private readonly TransportExpenseService _expenseService;
    private List<VehicleDto> _allVehicles = new List<VehicleDto>();
    private List<TransportExpenseDto> _allExpenses = new List<TransportExpenseDto>();

    public TransportManagementWindow(VehicleService vehicleService, TransportExpenseService expenseService)
    {
        try
        {
            InitializeComponent();

            _vehicleService = vehicleService ?? throw new ArgumentNullException(nameof(vehicleService));
            _expenseService = expenseService ?? throw new ArgumentNullException(nameof(expenseService));

            this.Loaded += TransportManagementWindow_Loaded;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error initializing transport management window: {ex.Message}", "Initialization Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }

    private void TransportManagementWindow_Loaded(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            await LoadAllData();
        }, "Transport Management Window Loading Error");
    }

    private async Task LoadAllData()
    {
        try
        {
            lblStatus.Text = "Loading data...";

            await LoadVehicles();
            await LoadExpenses();
            LoadFilterComboBoxes();
            await UpdateDashboard();

            lblStatus.Text = "Data loaded successfully";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading data: {ex.Message}", "Data Loading Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading data";
        }
    }

    private async Task LoadVehicles()
    {
        var vehicles = await _vehicleService.GetAllVehiclesAsync();
        _allVehicles = vehicles.ToList();
        dgVehicles.ItemsSource = _allVehicles;
    }

    private async Task LoadExpenses()
    {
        var expenses = await _expenseService.GetAllExpensesAsync();
        _allExpenses = expenses.ToList();
        dgExpenses.ItemsSource = _allExpenses;
    }

    private void LoadFilterComboBoxes()
    {
        // Vehicle filter
        var vehicleItems = new List<dynamic> { new { Id = 0, DisplayText = "All Vehicles" } };
        vehicleItems.AddRange(_allVehicles.Select(v => new { Id = v.Id, DisplayText = $"{v.VehicleNumber} - {v.VehicleTypeName}" }));
        cmbFilterVehicle.ItemsSource = vehicleItems;
        cmbFilterVehicle.SelectedIndex = 0;

        // Category filter
        var categoryItems = new List<dynamic> { new { Value = -1, Display = "All Categories" } };
        categoryItems.AddRange(Enum.GetValues<ExpenseCategory>().Select(c => new { Value = (int)c, Display = c.ToString() }));
        cmbFilterCategory.ItemsSource = categoryItems;
        cmbFilterCategory.DisplayMemberPath = "Display";
        cmbFilterCategory.SelectedValuePath = "Value";
        cmbFilterCategory.SelectedIndex = 0;
    }

    private async Task UpdateDashboard()
    {
        try
        {
            lblTotalVehicles.Text = _allVehicles.Count.ToString();

            var totalExpenses = _allExpenses.Sum(e => e.Amount);
            lblTotalExpenses.Text = $"₹{totalExpenses:N2}";

            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            var monthlyExpenses = _allExpenses
                .Where(e => e.ExpenseDate.Month == currentMonth && e.ExpenseDate.Year == currentYear)
                .Sum(e => e.Amount);
            lblMonthlyExpenses.Text = $"₹{monthlyExpenses:N2}";

            var avgExpensePerVehicle = _allVehicles.Count > 0 ? totalExpenses / _allVehicles.Count : 0;
            lblAvgExpensePerVehicle.Text = $"₹{avgExpensePerVehicle:N2}";

            // Recent activities
            var recentActivities = new List<string>();
            var recentExpenses = _allExpenses.OrderByDescending(e => e.CreatedAt).Take(5);
            foreach (var expense in recentExpenses)
            {
                recentActivities.Add($"{expense.CreatedAt:dd/MM/yyyy}: {expense.CategoryName} expense of ₹{expense.Amount:N2} for {expense.VehicleNumber}");
            }

            if (!recentActivities.Any())
            {
                recentActivities.Add("No recent activities found");
            }

            lstRecentActivities.ItemsSource = recentActivities;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating dashboard: {ex.Message}", "Dashboard Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnBack_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    // Vehicle Management Event Handlers
    private void BtnAddVehicle_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                var addVehicleWindow = new AddEditVehicleWindow(_vehicleService);
                if (addVehicleWindow.ShowDialog() == true)
                {
                    await LoadVehicles();
                    await UpdateDashboard();
                    lblStatus.Text = "Vehicle added successfully";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add vehicle dialog: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Add Vehicle Error");
    }

    private void BtnEditVehicle_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                if (dgVehicles.SelectedItem is VehicleDto selectedVehicle)
                {
                    var editVehicleWindow = new AddEditVehicleWindow(_vehicleService, selectedVehicle);
                    if (editVehicleWindow.ShowDialog() == true)
                    {
                        await LoadVehicles();
                        await UpdateDashboard();
                        lblStatus.Text = "Vehicle updated successfully";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a vehicle to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit vehicle dialog: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Edit Vehicle Error");
    }

    private void BtnDeleteVehicle_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                if (dgVehicles.SelectedItem is VehicleDto selectedVehicle)
                {
                    // Check if vehicle has related expenses
                    var vehicleExpenses = _allExpenses.Where(e => e.VehicleId == selectedVehicle.Id).ToList();

                    if (vehicleExpenses.Any())
                    {
                        MessageBox.Show(
                            $"Cannot delete vehicle '{selectedVehicle.VehicleNumber}'.\n\n" +
                            $"This vehicle has {vehicleExpenses.Count} expense record(s) associated with it.\n\n" +
                            $"Please delete all related expenses first or contact your administrator.",
                            "Delete Not Allowed",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    var result = MessageBox.Show(
                        $"Are you sure you want to delete vehicle '{selectedVehicle.VehicleNumber}'?\n\nThis action cannot be undone.",
                        "Confirm Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        await _vehicleService.DeleteVehicleAsync(selectedVehicle.Id);
                        await LoadVehicles();
                        await UpdateDashboard();
                        lblStatus.Text = $"Vehicle '{selectedVehicle.VehicleNumber}' deleted successfully";
                    }
                }
                else
                {
                    MessageBox.Show("Please select a vehicle to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting vehicle: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Delete Vehicle Error");
    }

    private void BtnViewExpenses_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgVehicles.SelectedItem is VehicleDto selectedVehicle)
            {
                // Switch to expenses tab and filter by selected vehicle
                var tabControl = (TabControl)this.FindName("TabControl") ??
                                this.FindVisualChildren<TabControl>().FirstOrDefault();

                if (tabControl != null && tabControl.Items.Count > 1)
                {
                    tabControl.SelectedIndex = 1; // Switch to Expenses tab

                    // Filter expenses by selected vehicle
                    cmbFilterVehicle.SelectedValue = selectedVehicle.Id;
                }
            }
            else
            {
                MessageBox.Show("Please select a vehicle to view its expenses.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error viewing vehicle expenses: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Expense Management Event Handlers
    private void BtnAddExpense_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                var addExpenseWindow = new AddEditTransportExpenseWindow(_expenseService, _vehicleService);
                if (addExpenseWindow.ShowDialog() == true)
                {
                    await LoadExpenses();
                    await LoadVehicles(); // Refresh vehicle totals
                    await UpdateDashboard();
                    lblStatus.Text = "Expense added successfully";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening add expense dialog: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Add Expense Error");
    }

    private void BtnEditExpense_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                if (dgExpenses.SelectedItem is TransportExpenseDto selectedExpense)
                {
                    var editExpenseWindow = new AddEditTransportExpenseWindow(_expenseService, _vehicleService, selectedExpense);
                    if (editExpenseWindow.ShowDialog() == true)
                    {
                        await LoadExpenses();
                        await LoadVehicles(); // Refresh vehicle totals
                        await UpdateDashboard();
                        lblStatus.Text = "Expense updated successfully";
                    }
                }
                else
                {
                    MessageBox.Show("Please select an expense to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening edit expense dialog: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Edit Expense Error");
    }

    private void BtnDeleteExpense_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            try
            {
                if (dgExpenses.SelectedItem is TransportExpenseDto selectedExpense)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete this expense?\n\nVehicle: {selectedExpense.VehicleNumber}\nAmount: ₹{selectedExpense.Amount:N2}\nDate: {selectedExpense.ExpenseDate:dd/MM/yyyy}\n\nThis action cannot be undone.",
                        "Confirm Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        await _expenseService.DeleteExpenseAsync(selectedExpense.Id);
                        await LoadExpenses();
                        await LoadVehicles(); // Refresh vehicle totals
                        await UpdateDashboard();
                        lblStatus.Text = "Expense deleted successfully";
                    }
                }
                else
                {
                    MessageBox.Show("Please select an expense to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting expense: {ex.Message}", "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }, "Delete Expense Error");
    }

    // Filter Event Handlers
    private void CmbFilterVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ApplyExpenseFilters();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error applying vehicle filter: {ex.Message}", "Filter Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void CmbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ApplyExpenseFilters();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error applying category filter: {ex.Message}", "Filter Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void DateFilter_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ApplyExpenseFilters();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error applying date filter: {ex.Message}", "Filter Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void ApplyExpenseFilters()
    {
        try
        {
            if (cmbFilterVehicle == null || cmbFilterCategory == null ||
                dpFromDate == null || dpToDate == null || dgExpenses == null)
            {
                return; // Controls not initialized yet
            }

            var filteredExpenses = _allExpenses.AsEnumerable();

            // Vehicle filter
            if (cmbFilterVehicle.SelectedValue != null && (int)cmbFilterVehicle.SelectedValue > 0)
            {
                var vehicleId = (int)cmbFilterVehicle.SelectedValue;
                filteredExpenses = filteredExpenses.Where(e => e.VehicleId == vehicleId);
            }

            // Category filter
            if (cmbFilterCategory.SelectedValue != null && (int)cmbFilterCategory.SelectedValue != -1)
            {
                var category = (ExpenseCategory)(int)cmbFilterCategory.SelectedValue;
                filteredExpenses = filteredExpenses.Where(e => e.Category == category);
            }

            // Date range filter
            if (dpFromDate.SelectedDate.HasValue)
            {
                filteredExpenses = filteredExpenses.Where(e => e.ExpenseDate >= dpFromDate.SelectedDate.Value);
            }

            if (dpToDate.SelectedDate.HasValue)
            {
                // End date is inclusive (includes entire day)
                var endOfDay = dpToDate.SelectedDate.Value.Date.AddDays(1).AddSeconds(-1);
                filteredExpenses = filteredExpenses.Where(e => e.ExpenseDate <= endOfDay);
            }

            dgExpenses.ItemsSource = filteredExpenses.ToList();

            if (lblStatus != null)
            {
                lblStatus.Text = $"Showing {filteredExpenses.Count()} expenses";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error applying filters: {ex.Message}", "Filter Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnClearFilter_Click(object sender, RoutedEventArgs e)
    {
        cmbFilterVehicle.SelectedIndex = 0;
        cmbFilterCategory.SelectedIndex = 0;
        dpFromDate.SelectedDate = null;
        dpToDate.SelectedDate = null;
        dgExpenses.ItemsSource = _allExpenses;
        lblStatus.Text = $"Showing all {_allExpenses.Count} expenses";
    }

    // Utility Event Handlers
    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
        AsyncHelper.SafeFireAndForget(async () =>
        {
            await LoadAllData();
        }, "Refresh Data Error");
    }

    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}

// Extension method to find visual children
public static class VisualTreeHelperExtensions
{
    public static IEnumerable<T> FindVisualChildren<T>(this DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }

                foreach (T childOfChild in FindVisualChildren<T>(child))
                {
                    yield return childOfChild;
                }
            }
        }
    }
}