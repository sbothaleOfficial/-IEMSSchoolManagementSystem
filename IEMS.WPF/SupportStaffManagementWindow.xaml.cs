using System.Windows;
using System.Windows.Controls;
using IEMS.Application.Services;
using IEMS.Application.DTOs;

namespace IEMS.WPF;

public partial class SupportStaffManagementWindow : Window
{
    private readonly StaffService _staffService;
    private List<StaffDto> _allStaff = new List<StaffDto>();
    private List<StaffDto> _filteredStaff = new List<StaffDto>();

    public SupportStaffManagementWindow(StaffService staffService)
    {
        InitializeComponent();
        _staffService = staffService;
        LoadStaff();
        LoadFilters();
    }

    private async void LoadStaff()
    {
        try
        {
            lblStatus.Text = "Loading staff...";
            var staff = await _staffService.GetAllStaffAsync();
            _allStaff = staff.ToList();
            _filteredStaff = _allStaff.ToList();
            dgStaff.ItemsSource = _filteredStaff;

            UpdateStatusCounts();
            lblStatus.Text = $"Loaded {staff.Count()} staff members";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading staff: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading staff";
        }
    }

    private async void LoadFilters()
    {
        try
        {
            var departments = await _staffService.GetDepartmentsAsync();
            var positions = await _staffService.GetPositionsAsync();

            cmbDepartmentFilter.Items.Clear();
            cmbDepartmentFilter.Items.Add(new ComboBoxItem { Content = "All Departments", IsSelected = true });
            foreach (var dept in departments)
            {
                cmbDepartmentFilter.Items.Add(new ComboBoxItem { Content = dept });
            }

            cmbPositionFilter.Items.Clear();
            cmbPositionFilter.Items.Add(new ComboBoxItem { Content = "All Positions", IsSelected = true });
            foreach (var pos in positions)
            {
                cmbPositionFilter.Items.Add(new ComboBoxItem { Content = pos });
            }
        }
        catch (Exception ex)
        {
            // Silently handle filter loading errors
            System.Diagnostics.Debug.WriteLine($"Error loading filters: {ex.Message}");
        }
    }

    private void UpdateStatusCounts()
    {
        lblTotalStaff.Text = $"Total: {_filteredStaff.Count}";
        lblActiveStaff.Text = $"Active: {_filteredStaff.Count(s => s.Status == "Active")}";
    }

    // Search and Filter Methods
    private void TxtSearchStaff_TextChanged(object sender, TextChangedEventArgs e)
    {
        FilterStaff();
    }

    private void CmbDepartmentFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FilterStaff();
    }

    private void CmbPositionFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FilterStaff();
    }

    private void CmbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        FilterStaff();
    }

    private void FilterStaff()
    {
        if (_allStaff == null || !_allStaff.Any())
            return;

        var searchText = txtSearchStaff?.Text?.Trim().ToLower() ?? "";
        var selectedDept = (cmbDepartmentFilter?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "All Departments";
        var selectedPos = (cmbPositionFilter?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "All Positions";
        var selectedStatus = (cmbStatusFilter?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "All";

        _filteredStaff = _allStaff.Where(staff =>
            // Search filter
            (string.IsNullOrEmpty(searchText) ||
             staff.FullName.ToLower().Contains(searchText) ||
             staff.EmployeeId.ToLower().Contains(searchText) ||
             staff.Position.ToLower().Contains(searchText) ||
             staff.Department.ToLower().Contains(searchText) ||
             staff.PhoneNumber.ToLower().Contains(searchText) ||
             staff.Email.ToLower().Contains(searchText)) &&

            // Department filter
            (selectedDept == "All Departments" || staff.Department == selectedDept) &&

            // Position filter
            (selectedPos == "All Positions" || staff.Position == selectedPos) &&

            // Status filter
            (selectedStatus == "All" || staff.Status == selectedStatus)
        ).ToList();

        dgStaff.ItemsSource = _filteredStaff;
        UpdateStatusCounts();

        if (!string.IsNullOrEmpty(searchText) || selectedDept != "All Departments" ||
            selectedPos != "All Positions" || selectedStatus != "All")
        {
            lblStatus.Text = $"Found {_filteredStaff.Count} staff members matching filters";
        }
        else
        {
            lblStatus.Text = $"Showing all {_filteredStaff.Count} staff members";
        }
    }

    // CRUD Event Handlers
    private void BtnAddStaff_Click(object sender, RoutedEventArgs e)
    {
        var addWindow = new AddEditStaffWindow(_staffService);
        if (addWindow.ShowDialog() == true)
        {
            var currentSearch = txtSearchStaff.Text;
            var currentDept = cmbDepartmentFilter.SelectedIndex;
            var currentPos = cmbPositionFilter.SelectedIndex;
            var currentStatus = cmbStatusFilter.SelectedIndex;

            LoadStaff();
            LoadFilters();

            // Restore filter states
            txtSearchStaff.Text = currentSearch;
            cmbDepartmentFilter.SelectedIndex = currentDept;
            cmbPositionFilter.SelectedIndex = currentPos;
            cmbStatusFilter.SelectedIndex = currentStatus;

            FilterStaff();
        }
    }

    private void BtnEditStaff_Click(object sender, RoutedEventArgs e)
    {
        if (dgStaff.SelectedItem is StaffDto selectedStaff)
        {
            var editWindow = new AddEditStaffWindow(_staffService, selectedStaff);
            if (editWindow.ShowDialog() == true)
            {
                var currentSearch = txtSearchStaff.Text;
                var currentDept = cmbDepartmentFilter.SelectedIndex;
                var currentPos = cmbPositionFilter.SelectedIndex;
                var currentStatus = cmbStatusFilter.SelectedIndex;

                LoadStaff();
                LoadFilters();

                // Restore filter states
                txtSearchStaff.Text = currentSearch;
                cmbDepartmentFilter.SelectedIndex = currentDept;
                cmbPositionFilter.SelectedIndex = currentPos;
                cmbStatusFilter.SelectedIndex = currentStatus;

                FilterStaff();
            }
        }
        else
        {
            MessageBox.Show("Please select a staff member to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private async void BtnDeleteStaff_Click(object sender, RoutedEventArgs e)
    {
        if (dgStaff.SelectedItem is StaffDto selectedStaff)
        {
            var result = MessageBox.Show($"Are you sure you want to delete staff member {selectedStaff.FullName}?",
                                       "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    await _staffService.DeleteStaffAsync(selectedStaff.Id);
                    LoadStaff();
                    LoadFilters();
                    FilterStaff();
                    lblStatus.Text = "Staff member deleted successfully";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting staff member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Please select a staff member to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void BtnRefreshStaff_Click(object sender, RoutedEventArgs e)
    {
        LoadStaff();
        LoadFilters();
        txtSearchStaff.Text = "";
        cmbDepartmentFilter.SelectedIndex = 0;
        cmbPositionFilter.SelectedIndex = 0;
        cmbStatusFilter.SelectedIndex = 0;
        FilterStaff();
    }
}