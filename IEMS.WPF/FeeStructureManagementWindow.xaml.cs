using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using IEMS.Application.DTOs;
using IEMS.Application.Services;
using IEMS.Core.Enums;
using IEMS.WPF.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace IEMS.WPF
{
    public partial class FeeStructureManagementWindow : Window
    {
        private readonly FeeStructureService _feeStructureService;
        private readonly ClassService _classService;
        private readonly AcademicYearService _academicYearService;
        private List<FeeStructureDto> _allFeeStructures = new();
        private List<ClassDto> _allClasses = new();

        public FeeStructureManagementWindow(FeeStructureService feeStructureService, ClassService classService, AcademicYearService academicYearService)
        {
            InitializeComponent();
            _feeStructureService = feeStructureService;
            _classService = classService;
            _academicYearService = academicYearService;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                try
                {
                    await LoadClasses();
                    await InitializeFilters();
                    await LoadFeeStructures();
                    lblStatus.Text = "Fee Structure Management Ready";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading Fee Structure Management: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }, "Fee Structure Management Window Loading Error");
        }

        private async Task LoadClasses()
        {
            _allClasses = (await _classService.GetAllClassesAsync()).ToList();
        }

        private async Task InitializeFilters()
        {
            // Initialize Academic Year dropdown from database
            try
            {
                var academicYears = await _academicYearService.GetAllAcademicYearsAsync();
                var yearsList = new List<string> { "All" };
                yearsList.AddRange(academicYears.OrderByDescending(ay => ay.StartDate).Select(ay => ay.Year));
                cmbAcademicYear.ItemsSource = yearsList;
                cmbAcademicYear.SelectedIndex = 0;
            }
            catch (Exception)
            {
                // Fallback: Generate years dynamically
                var currentYear = DateTime.Now.Year;
                var academicYears = new List<string> { "All" };
                for (int i = -2; i <= 2; i++)
                {
                    var year = currentYear + i;
                    academicYears.Add($"{year}-{(year + 1).ToString().Substring(2)}");
                }
                cmbAcademicYear.ItemsSource = academicYears;
                cmbAcademicYear.SelectedIndex = 0;
            }

            // Initialize Class dropdown
            var classItems = new List<dynamic> { new { Id = -1, Display = "All Classes" } };
            classItems.AddRange(_allClasses.Select(c => new { Id = c.Id, Display = $"{c.Name} - {c.Section}" }));
            cmbClassFilter.ItemsSource = classItems;
            cmbClassFilter.DisplayMemberPath = "Display";
            cmbClassFilter.SelectedValuePath = "Id";
            cmbClassFilter.SelectedIndex = 0;

            // Initialize Fee Type dropdown
            var feeTypes = new List<dynamic> { new { Value = -1, Display = "All Types" } };
            feeTypes.AddRange(Enum.GetValues<FeeType>()
                .Select(ft => new { Value = (int)ft, Display = ft.ToString() }));
            cmbFeeTypeFilter.ItemsSource = feeTypes;
            cmbFeeTypeFilter.DisplayMemberPath = "Display";
            cmbFeeTypeFilter.SelectedValuePath = "Value";
            cmbFeeTypeFilter.SelectedIndex = 0;
        }

        private async Task LoadFeeStructures()
        {
            try
            {
                _allFeeStructures = (await _feeStructureService.GetAllFeeStructuresAsync()).ToList();
                ApplyFilters();
                UpdateStatusBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading fee structures: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ApplyFilters()
        {
            var filtered = _allFeeStructures.AsEnumerable();

            // Apply Academic Year filter
            if (cmbAcademicYear.SelectedItem != null && cmbAcademicYear.SelectedItem.ToString() != "All")
            {
                var selectedYear = cmbAcademicYear.SelectedItem.ToString();
                filtered = filtered.Where(fs => fs.AcademicYear == selectedYear);
            }

            // Apply Class filter
            if (cmbClassFilter.SelectedValue != null && (int)cmbClassFilter.SelectedValue != -1)
            {
                var classId = (int)cmbClassFilter.SelectedValue;
                filtered = filtered.Where(fs => fs.ClassId == classId);
            }

            // Apply Fee Type filter
            if (cmbFeeTypeFilter.SelectedValue != null && (int)cmbFeeTypeFilter.SelectedValue != -1)
            {
                var feeType = (FeeType)cmbFeeTypeFilter.SelectedValue;
                filtered = filtered.Where(fs => fs.FeeType == feeType);
            }

            // Apply Status filter
            if (cmbStatusFilter.SelectedItem is ComboBoxItem selectedStatus)
            {
                var status = selectedStatus.Content.ToString();
                if (status == "Active")
                    filtered = filtered.Where(fs => fs.IsActive);
                else if (status == "Inactive")
                    filtered = filtered.Where(fs => !fs.IsActive);
            }

            // Apply search filter
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                var searchTerm = txtSearch.Text.ToLower();
                filtered = filtered.Where(fs => fs.Description.ToLower().Contains(searchTerm));
            }

            var filteredList = filtered.ToList();
            dgFeeStructures.ItemsSource = filteredList;

            // Show/hide empty state
            if (filteredList.Count == 0)
            {
                dgFeeStructures.Visibility = Visibility.Collapsed;
                emptyStatePanel.Visibility = Visibility.Visible;
            }
            else
            {
                dgFeeStructures.Visibility = Visibility.Visible;
                emptyStatePanel.Visibility = Visibility.Collapsed;
            }

            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            var items = dgFeeStructures.ItemsSource as List<FeeStructureDto>;
            if (items != null)
            {
                lblTotalRecords.Text = $"Total Records: {items.Count}";
                var totalAmount = items.Sum(fs => fs.Amount);
                lblTotalAmount.Text = $"Total Amount: ₹{totalAmount:N2}";
            }
            else
            {
                lblTotalRecords.Text = "Total Records: 0";
                lblTotalAmount.Text = "Total Amount: ₹0.00";
            }
        }

        private void BtnAddFeeStructure_Click(object sender, RoutedEventArgs e)
        {
            var addEditWindow = App.ServiceProvider.GetRequiredService<AddEditFeeStructureWindow>();
            addEditWindow.Owner = this;
            if (addEditWindow.ShowDialog() == true)
            {
                AsyncHelper.SafeFireAndForget(async () => await LoadFeeStructures(),
                    "Error refreshing fee structures");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int feeStructureId)
            {
                var addEditWindow = App.ServiceProvider.GetRequiredService<AddEditFeeStructureWindow>();
                addEditWindow.Owner = this;
                addEditWindow.SetFeeStructureId(feeStructureId);
                if (addEditWindow.ShowDialog() == true)
                {
                    AsyncHelper.SafeFireAndForget(async () => await LoadFeeStructures(),
                        "Error refreshing fee structures");
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is int feeStructureId)
            {
                var feeStructure = _allFeeStructures.FirstOrDefault(fs => fs.Id == feeStructureId);
                if (feeStructure != null)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete the fee structure for {feeStructure.ClassName} - {feeStructure.FeeType}?\n\n" +
                        $"Amount: ₹{feeStructure.Amount:N2}\n" +
                        $"Academic Year: {feeStructure.AcademicYear}",
                        "Confirm Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        AsyncHelper.SafeFireAndForget(async () =>
                        {
                            try
                            {
                                await _feeStructureService.DeleteFeeStructureAsync(feeStructureId);
                                MessageBox.Show("Fee structure deleted successfully.", "Success",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                                await LoadFeeStructures();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error deleting fee structure: {ex.Message}", "Error",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }, "Error deleting fee structure");
                    }
                }
            }
        }

        private void DgFeeStructures_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgFeeStructures.SelectedItem is FeeStructureDto selectedFeeStructure)
            {
                var addEditWindow = App.ServiceProvider.GetRequiredService<AddEditFeeStructureWindow>();
                addEditWindow.Owner = this;
                addEditWindow.SetFeeStructureId(selectedFeeStructure.Id);
                if (addEditWindow.ShowDialog() == true)
                {
                    AsyncHelper.SafeFireAndForget(async () => await LoadFeeStructures(),
                        "Error refreshing fee structures");
                }
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(async () =>
            {
                lblStatus.Text = "Refreshing...";
                await LoadFeeStructures();
                lblStatus.Text = "Fee structures refreshed";
            }, "Error refreshing fee structures");
        }

        private void CmbAcademicYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbClassFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbFeeTypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbStatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            cmbAcademicYear.SelectedIndex = 0;
            cmbClassFilter.SelectedIndex = 0;
            cmbFeeTypeFilter.SelectedIndex = 0;
            cmbStatusFilter.SelectedIndex = 0;
            txtSearch.Text = "";
            ApplyFilters();
        }
    }

    // Value Converters for the DataGrid
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActive)
            {
                return isActive ? new SolidColorBrush(Color.FromRgb(39, 174, 96)) :
                                 new SolidColorBrush(Color.FromRgb(231, 76, 60));
            }
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isActive)
            {
                return isActive ? "Active" : "Inactive";
            }
            return "Unknown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}