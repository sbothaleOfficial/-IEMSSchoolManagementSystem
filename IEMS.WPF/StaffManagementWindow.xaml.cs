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
        LoadDashboardData();
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
                UpdateDashboard();
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
                    UpdateDashboard();
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
                    UpdateDashboard();
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
                UpdateDashboard();
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
                    UpdateDashboard();
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
                    UpdateDashboard();
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

    // Dashboard Methods
    private async void LoadDashboardData()
    {
        try
        {
            await LoadOverallStatistics();
            await LoadTeacherClassStatistics();
            await LoadPositionStatistics();
            await LoadSalaryRangeStatistics();
            await LoadRecentJoinersStatistics();
            await LoadPayrollSummary();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task LoadOverallStatistics()
    {
        var totalTeachers = _allTeachers.Count;
        var totalSupportStaff = _allStaff.Count;
        var totalStaff = totalTeachers + totalSupportStaff;

        var allSalaries = _allTeachers.Select(t => t.MonthlySalary)
                                     .Concat(_allStaff.Select(s => s.MonthlySalary))
                                     .Where(s => s > 0);
        var averageSalary = allSalaries.Any() ? allSalaries.Average() : 0;

        lblTotalTeachers.Text = totalTeachers.ToString();
        lblTotalSupportStaff.Text = totalSupportStaff.ToString();
        lblTotalStaff.Text = totalStaff.ToString();
        lblAverageSalary.Text = $"₹{averageSalary:N0}";
    }

    private async Task LoadTeacherClassStatistics()
    {
        var teacherClassStats = new List<object>();

        foreach (var teacher in _allTeachers)
        {
            var classes = await _classService.GetClassesByTeacherIdAsync(teacher.Id);
            var classNames = string.Join(", ", classes.Select(c => c.DisplayName));

            teacherClassStats.Add(new
            {
                TeacherName = teacher.FullName,
                EmployeeId = teacher.EmployeeId,
                ClassCount = classes.Count(),
                ClassNames = string.IsNullOrEmpty(classNames) ? "No classes assigned" : classNames,
                FormattedSalary = $"₹{teacher.MonthlySalary:N0}"
            });
        }

        dgTeacherClassStats.ItemsSource = teacherClassStats.OrderByDescending(t => ((dynamic)t).ClassCount).ToList();
    }

    private async Task LoadPositionStatistics()
    {
        var allPositions = _allTeachers.Select(t => "Teacher")
                                      .Concat(_allStaff.Select(s => s.Position))
                                      .ToList();

        var allSalariesWithPositions = _allTeachers.Select(t => new { Position = "Teacher", Salary = t.MonthlySalary })
                                                  .Concat(_allStaff.Select(s => new { Position = s.Position, Salary = s.MonthlySalary }))
                                                  .ToList();

        var positionStats = allPositions
            .GroupBy(p => p)
            .Select(g => new
            {
                Position = g.Key,
                Count = g.Count(),
                FormattedAvgSalary = $"₹{allSalariesWithPositions.Where(x => x.Position == g.Key).Average(x => x.Salary):N0}",
                FormattedTotalSalary = $"₹{allSalariesWithPositions.Where(x => x.Position == g.Key).Sum(x => x.Salary):N0}",
                Percentage = $"{(g.Count() * 100.0 / allPositions.Count):F1}%"
            })
            .OrderByDescending(x => x.Count)
            .ToList();

        dgPositionStats.ItemsSource = positionStats;
    }

    private async Task LoadSalaryRangeStatistics()
    {
        var allStaffWithSalaries = _allTeachers.Select(t => new { Name = t.FullName, Salary = t.MonthlySalary })
                                              .Concat(_allStaff.Select(s => new { Name = s.FullName, Salary = s.MonthlySalary }))
                                              .ToList();

        var salaryRanges = new[]
        {
            new { Range = "Below ₹20,000", Min = 0, Max = 20000 },
            new { Range = "₹20,000 - ₹40,000", Min = 20000, Max = 40000 },
            new { Range = "₹40,000 - ₹60,000", Min = 40000, Max = 60000 },
            new { Range = "₹60,000 - ₹80,000", Min = 60000, Max = 80000 },
            new { Range = "Above ₹80,000", Min = 80000, Max = int.MaxValue }
        };

        var salaryRangeStats = salaryRanges
            .Select(range =>
            {
                var staffInRange = allStaffWithSalaries
                    .Where(s => s.Salary >= range.Min && s.Salary < range.Max)
                    .ToList();

                return new
                {
                    SalaryRange = range.Range,
                    Count = staffInRange.Count,
                    Percentage = $"{(staffInRange.Count * 100.0 / allStaffWithSalaries.Count):F1}%",
                    StaffNames = string.Join(", ", staffInRange.Select(s => s.Name).Take(3)) +
                               (staffInRange.Count > 3 ? $" and {staffInRange.Count - 3} more..." : "")
                };
            })
            .Where(x => x.Count > 0)
            .ToList();

        dgSalaryRangeStats.ItemsSource = salaryRangeStats;
    }

    private async Task LoadRecentJoinersStatistics()
    {
        var twoYearsAgo = DateTime.Now.AddYears(-2);

        var recentTeachers = _allTeachers
            .Where(t => t.JoiningDate >= twoYearsAgo)
            .Select(t => new
            {
                Name = t.FullName,
                Position = "Teacher",
                JoiningDate = t.JoiningDate,
                FormattedJoiningDate = t.JoiningDate.ToString("dd/MM/yyyy"),
                DaysSinceJoined = $"{(DateTime.Now - t.JoiningDate).Days} days",
                FormattedSalary = $"₹{t.MonthlySalary:N0}"
            });

        var recentStaff = _allStaff
            .Where(s => s.JoiningDate >= twoYearsAgo)
            .Select(s => new
            {
                Name = s.FullName,
                Position = s.Position,
                JoiningDate = s.JoiningDate,
                FormattedJoiningDate = s.JoiningDate.ToString("dd/MM/yyyy"),
                DaysSinceJoined = $"{(DateTime.Now - s.JoiningDate).Days} days",
                FormattedSalary = $"₹{s.MonthlySalary:N0}"
            });

        var recentJoiners = recentTeachers
            .Concat(recentStaff)
            .OrderByDescending(x => x.JoiningDate)
            .ToList();

        dgRecentJoiners.ItemsSource = recentJoiners;
    }

    private async Task LoadPayrollSummary()
    {
        var teachersPayroll = _allTeachers.Sum(t => t.MonthlySalary);
        var supportStaffPayroll = _allStaff.Sum(s => s.MonthlySalary);
        var totalPayroll = teachersPayroll + supportStaffPayroll;

        lblTeachersPayroll.Text = $"₹{teachersPayroll:N0}";
        lblSupportStaffPayroll.Text = $"₹{supportStaffPayroll:N0}";
        lblTotalPayroll.Text = $"₹{totalPayroll:N0}";
    }

    // Update dashboard when data changes
    private void UpdateDashboard()
    {
        LoadDashboardData();
    }
}