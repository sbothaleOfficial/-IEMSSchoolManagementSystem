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
            var positions = await _staffService.GetPositionsAsync();

            cmbPositionFilter.Items.Clear();
            cmbPositionFilter.Items.Add(new ComboBoxItem { Content = "All Positions", IsSelected = true });
            foreach (var position in positions)
            {
                cmbPositionFilter.Items.Add(new ComboBoxItem { Content = position });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading filters: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void UpdateStatusCounts()
    {
        var totalCount = _allStaff.Count;
        lblTotalStaff.Text = $"Total Staff: {totalCount}";
    }

    private void ApplyFilters()
    {
        _filteredStaff = _allStaff.Where(staff =>
        {
            // Search filter
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                if (!staff.FullName.ToLower().Contains(searchTerm) &&
                    !staff.EmployeeId.ToLower().Contains(searchTerm) &&
                    !staff.PhoneNumber.Contains(searchTerm) &&
                    !staff.Position.ToLower().Contains(searchTerm) &&
                    !staff.Address.ToLower().Contains(searchTerm))
                    return false;
            }

            // Position filter
            var selectedPosition = (cmbPositionFilter.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (selectedPosition != null && selectedPosition != "All Positions")
            {
                if (staff.Position != selectedPosition)
                    return false;
            }

            return true;
        }).ToList();

        dgStaff.ItemsSource = _filteredStaff;
        lblStatus.Text = $"Showing {_filteredStaff.Count} of {_allStaff.Count} staff members";
    }

    private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyFilters();
    }

    private void CmbPositionFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ApplyFilters();
    }

    private async void BtnAddStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var addWindow = new AddEditStaffWindow(_staffService);
            if (addWindow.ShowDialog() == true)
            {
                LoadStaff();
                lblStatus.Text = "Staff member added successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening add staff window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnEditStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgStaff.SelectedItem is StaffDto selectedStaff)
            {
                var editWindow = new AddEditStaffWindow(_staffService, selectedStaff);
                if (editWindow.ShowDialog() == true)
                {
                    LoadStaff();
                    lblStatus.Text = "Staff member updated successfully";
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening edit staff window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnDeleteStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgStaff.SelectedItem is StaffDto selectedStaff)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedStaff.FullName}?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    await _staffService.DeleteStaffAsync(selectedStaff.Id);
                    LoadStaff();
                    lblStatus.Text = "Staff member deleted successfully";
                }
            }
            else
            {
                MessageBox.Show("Please select a staff member to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting staff member: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnRefresh_Click(object sender, RoutedEventArgs e)
    {
        LoadStaff();
    }

    private void BtnClearSearch_Click(object sender, RoutedEventArgs e)
    {
        txtSearch.Clear();
        cmbPositionFilter.SelectedIndex = 0;
        ApplyFilters();
    }
}