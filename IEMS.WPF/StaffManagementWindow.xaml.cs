using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using System.Windows.Controls;

namespace IEMS.WPF;

public partial class StaffManagementWindow : Window
{
    private readonly TeacherService _teacherService;
    private readonly ClassService _classService;
    private readonly StaffService _staffService;

    private List<TeacherDto> _allTeachers = new List<TeacherDto>();
    private List<StaffDto> _allStaff = new List<StaffDto>();

    public StaffManagementWindow(TeacherService teacherService, ClassService classService, StaffService staffService)
    {
        InitializeComponent();
        _teacherService = teacherService;
        _classService = classService;
        _staffService = staffService;

        SetupSearchControls();
        LoadTeachers();
        LoadStaff();
        lblStatus.Text = "Staff Management loaded successfully";
    }

    private void SetupSearchControls()
    {
        cmbStaffPosition.SelectedIndex = 0; // Select "All Positions" by default
        txtSearchTeacher.Text = string.Empty;
        txtSearchStaff.Text = string.Empty;
    }

    // Teachers Tab Methods
    private async void LoadTeachers()
    {
        try
        {
            _allTeachers = (await _teacherService.GetAllTeachersAsync()).ToList();
            ApplyTeacherSearch();
            lblStatus.Text = $"Loaded {_allTeachers.Count} teachers";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading teachers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading teachers";
        }
    }

    private void ApplyTeacherSearch()
    {
        var searchText = txtSearchTeacher?.Text?.ToLower() ?? string.Empty;
        var filteredTeachers = _allTeachers.AsEnumerable();

        if (!string.IsNullOrEmpty(searchText))
        {
            filteredTeachers = filteredTeachers.Where(t =>
                t.FullName.ToLower().Contains(searchText) ||
                t.EmployeeId.ToLower().Contains(searchText) ||
                t.PhoneNumber.Contains(searchText) ||
                (t.Email?.ToLower().Contains(searchText) ?? false) ||
                (t.Address?.ToLower().Contains(searchText) ?? false) ||
                (t.BankAccountNumber?.Contains(searchText) ?? false) ||
                (t.AadharNumber?.Contains(searchText) ?? false) ||
                (t.PANNumber?.ToLower().Contains(searchText) ?? false)
            );
        }

        dgTeachers.ItemsSource = filteredTeachers.ToList();
        lblStatus.Text = $"Showing {filteredTeachers.Count()} of {_allTeachers.Count} teachers";
    }

    private async void BtnAddTeacher_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var addEditWindow = new AddEditTeacherWindow(_teacherService);
            if (addEditWindow.ShowDialog() == true)
            {
                LoadTeachers();
                lblStatus.Text = "Teacher added successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Add Teacher window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnEditTeacher_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
            {
                var addEditWindow = new AddEditTeacherWindow(_teacherService, selectedTeacher);
                if (addEditWindow.ShowDialog() == true)
                {
                    LoadTeachers();
                    lblStatus.Text = "Teacher updated successfully";
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to edit.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Edit Teacher window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnDeleteTeacher_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgTeachers.SelectedItem is TeacherDto selectedTeacher)
            {
                var result = MessageBox.Show($"Are you sure you want to delete teacher '{selectedTeacher.FullName}'?\n\nThis action cannot be undone.",
                                           "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    await _teacherService.DeleteTeacherAsync(selectedTeacher.Id);
                    LoadTeachers();
                    lblStatus.Text = "Teacher deleted successfully";
                    MessageBox.Show("Teacher deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a teacher to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting teacher: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error deleting teacher";
        }
    }

    private void BtnRefreshTeachers_Click(object sender, RoutedEventArgs e)
    {
        LoadTeachers();
    }

    // Staff Tab Methods
    private async void LoadStaff()
    {
        try
        {
            _allStaff = (await _staffService.GetAllStaffAsync()).ToList();
            ApplyStaffSearch();
            lblStatus.Text = $"Loaded {_allStaff.Count} staff members";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading staff: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            lblStatus.Text = "Error loading staff";
        }
    }

    private void ApplyStaffSearch()
    {
        var searchText = txtSearchStaff?.Text?.ToLower() ?? string.Empty;
        var selectedPosition = (cmbStaffPosition?.SelectedItem as ComboBoxItem)?.Content?.ToString();
        var filteredStaff = _allStaff.AsEnumerable();

        // Filter by position if not "All Positions"
        if (!string.IsNullOrEmpty(selectedPosition) && selectedPosition != "All Positions")
        {
            filteredStaff = filteredStaff.Where(s => s.Position.Equals(selectedPosition, StringComparison.OrdinalIgnoreCase));
        }

        // Filter by search text
        if (!string.IsNullOrEmpty(searchText))
        {
            filteredStaff = filteredStaff.Where(s =>
                s.FullName.ToLower().Contains(searchText) ||
                s.EmployeeId.ToLower().Contains(searchText) ||
                s.Position.ToLower().Contains(searchText) ||
                s.PhoneNumber.Contains(searchText) ||
                (s.Email?.ToLower().Contains(searchText) ?? false) ||
                (s.Address?.ToLower().Contains(searchText) ?? false) ||
                (s.BankAccountNumber?.Contains(searchText) ?? false) ||
                (s.AadharNumber?.Contains(searchText) ?? false) ||
                (s.PANNumber?.ToLower().Contains(searchText) ?? false)
            );
        }

        dgStaff.ItemsSource = filteredStaff.ToList();
        lblStatus.Text = $"Showing {filteredStaff.Count()} of {_allStaff.Count} staff members";
    }

    private async void BtnAddStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var addEditWindow = new AddEditStaffWindow(_staffService);
            if (addEditWindow.ShowDialog() == true)
            {
                LoadStaff();
                lblStatus.Text = "Staff member added successfully";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error opening Add Staff window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnEditStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgStaff.SelectedItem is StaffDto selectedStaff)
            {
                var addEditWindow = new AddEditStaffWindow(_staffService, selectedStaff);
                if (addEditWindow.ShowDialog() == true)
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
            MessageBox.Show($"Error opening Edit Staff window: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async void BtnDeleteStaff_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (dgStaff.SelectedItem is StaffDto selectedStaff)
            {
                var result = MessageBox.Show($"Are you sure you want to delete staff member '{selectedStaff.FullName}'?\n\nThis action cannot be undone.",
                                           "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    await _staffService.DeleteStaffAsync(selectedStaff.Id);
                    LoadStaff();
                    lblStatus.Text = "Staff member deleted successfully";
                    MessageBox.Show("Staff member deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
            lblStatus.Text = "Error deleting staff member";
        }
    }

    private void BtnRefreshStaff_Click(object sender, RoutedEventArgs e)
    {
        LoadStaff();
    }

    // Search Event Handlers
    private void TxtSearchTeacher_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyTeacherSearch();
    }

    private void BtnClearTeacherSearch_Click(object sender, RoutedEventArgs e)
    {
        txtSearchTeacher.Text = string.Empty;
        ApplyTeacherSearch();
    }

    private void TxtSearchStaff_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyStaffSearch();
    }

    private void CmbStaffPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ApplyStaffSearch();
    }

    private void BtnClearStaffSearch_Click(object sender, RoutedEventArgs e)
    {
        txtSearchStaff.Text = string.Empty;
        cmbStaffPosition.SelectedIndex = 0; // Reset to "All Positions"
        ApplyStaffSearch();
    }
}