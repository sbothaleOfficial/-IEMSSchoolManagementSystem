using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Interfaces;
using IEMS.WPF.Helpers;

namespace IEMS.WPF
{
    public partial class BulkPromotionWindow : Window
    {
        private readonly BulkPromotionService _bulkPromotionService;
        private readonly ClassService _classService;
        private readonly IAcademicYearRepository _academicYearRepository;
        private List<StudentPromotionViewModel> _currentPreview = new();
        private List<ClassDto> _allClasses = new();

        public BulkPromotionWindow(BulkPromotionService bulkPromotionService, ClassService classService, IAcademicYearRepository academicYearRepository)
        {
            InitializeComponent();
            _bulkPromotionService = bulkPromotionService;
            _classService = classService;
            _academicYearRepository = academicYearRepository;
            Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadInitialData();
                lblStatus.Text = "Bulk Promotion Ready";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bulk promotion data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = "Error loading data";
            }
        }

        private void LoadInitialData()
        {
            // Load classes from database instead of predefined
            AsyncHelper.SafeFireAndForget(LoadClassesAsync);

            // Load extended academic years (past 10 years + current + future 40 years)
            LoadExtendedAcademicYears();
        }

        private async Task LoadClassesAsync()
        {
            try
            {
                // Load actual classes from database
                var databaseClasses = await _classService.GetAllClassesAsync();

                // Create a clean, ordered list with the required classes
                var orderedClasses = new List<ClassDto>
                {
                    new ClassDto { Id = -1, Name = "-- Select Class --" }
                };

                // Define the required class order for promotion
                var requiredClasses = new[]
                {
                    "Nursery", "KG1", "KG2", "Class 1", "Class 2", "Class 3",
                    "Class 4", "Class 5", "Class 6", "Class 7", "Class 8",
                    "Class 9", "Class 10"
                };

                // Get unique class names from database (ignore sections)
                var uniqueClassNames = databaseClasses
                    .Select(c => c.Name.Trim())
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                // Add classes in the correct order only if they exist in database
                foreach (var requiredClass in requiredClasses)
                {
                    if (uniqueClassNames.Contains(requiredClass))
                    {
                        // Find the first database class with this name (pick any section)
                        var dbClass = databaseClasses.FirstOrDefault(c =>
                            c.Name.Equals(requiredClass, StringComparison.OrdinalIgnoreCase));

                        if (dbClass != null)
                        {
                            // Create a standardized entry for the dropdown
                            orderedClasses.Add(new ClassDto
                            {
                                Id = dbClass.Id, // Use actual database ID
                                Name = requiredClass, // Use standardized name
                                Section = dbClass.Section, // Preserve section info if needed
                                TeacherId = dbClass.TeacherId
                            });
                        }
                    }
                }

                _allClasses = orderedClasses;
                cmbFromClass.ItemsSource = _allClasses;
                cmbToClass.ItemsSource = _allClasses;

                // Set default selection to first item (-- Select Class --)
                cmbFromClass.SelectedIndex = 0;
                cmbToClass.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                // Fallback to predefined classes if database load fails
                LoadPredefinedClasses();
                MessageBox.Show($"Warning: Could not load classes from database. Using predefined classes.\nError: {ex.Message}",
                               "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadPredefinedClasses()
        {
            var predefinedClasses = new List<ClassDto>
            {
                new ClassDto { Id = -1, Name = "-- Select Class --" },
                new ClassDto { Id = 1, Name = "Nursery" },
                new ClassDto { Id = 2, Name = "KG1" },
                new ClassDto { Id = 3, Name = "KG2" },
                new ClassDto { Id = 4, Name = "Class 1" },
                new ClassDto { Id = 5, Name = "Class 2" },
                new ClassDto { Id = 6, Name = "Class 3" },
                new ClassDto { Id = 7, Name = "Class 4" },
                new ClassDto { Id = 8, Name = "Class 5" },
                new ClassDto { Id = 9, Name = "Class 6" },
                new ClassDto { Id = 10, Name = "Class 7" },
                new ClassDto { Id = 11, Name = "Class 8" },
                new ClassDto { Id = 12, Name = "Class 9" },
                new ClassDto { Id = 13, Name = "Class 10" }
            };

            _allClasses = predefinedClasses;
            cmbFromClass.ItemsSource = _allClasses;
            cmbToClass.ItemsSource = _allClasses;

            // Set default selection to first item (-- Select Class --)
            cmbFromClass.SelectedIndex = 0;
            cmbToClass.SelectedIndex = 0;
        }

        private void LoadExtendedAcademicYears()
        {
            var currentYear = DateTime.Now.Year;
            var academicYears = new List<SimpleAcademicYear>();

            // Add past 10 years
            for (int i = 10; i >= 1; i--)
            {
                var year = currentYear - i;
                academicYears.Add(new SimpleAcademicYear
                {
                    Year = year,
                    IsCurrent = false
                });
            }

            // Add current year
            academicYears.Add(new SimpleAcademicYear
            {
                Year = currentYear,
                IsCurrent = true
            });

            // Add future 40 years
            for (int i = 1; i <= 40; i++)
            {
                var year = currentYear + i;
                academicYears.Add(new SimpleAcademicYear
                {
                    Year = year,
                    IsCurrent = false
                });
            }

            cmbAcademicYear.ItemsSource = academicYears;
            cmbAcademicYear.SelectedItem = academicYears.FirstOrDefault(ay => ay.IsCurrent);
        }

        private void CmbFromClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidatePromotionInputs();
        }

        private void CmbToClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidatePromotionInputs();
        }

        private void ValidatePromotionInputs()
        {
            var fromClass = cmbFromClass.SelectedItem as ClassDto;
            var toClass = cmbToClass.SelectedItem as ClassDto;

            var hasValidSelection = fromClass != null && fromClass.Id != -1 &&
                                  toClass != null && toClass.Id != -1 &&
                                  cmbAcademicYear.SelectedItem != null &&
                                  fromClass.Id != toClass.Id;

            btnLoadPreview.IsEnabled = hasValidSelection;
            btnExecutePromotion.IsEnabled = false;

            if (fromClass != null && toClass != null && fromClass.Id == toClass.Id && fromClass.Id != -1)
            {
                lblStatus.Text = "Source and target classes must be different";
            }
            else if (hasValidSelection)
            {
                lblStatus.Text = "Ready to load preview";
            }
            else
            {
                lblStatus.Text = "Please select source class, target class, and academic year";
            }
        }

        private void BtnLoadPreview_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(LoadPreviewAsync);
        }

        private async Task LoadPreviewAsync()
        {
            try
            {
                var fromClass = cmbFromClass.SelectedItem as ClassDto;
                var toClass = cmbToClass.SelectedItem as ClassDto;

                if (fromClass == null || toClass == null || fromClass.Id == -1 || toClass.Id == -1)
                {
                    MessageBox.Show("Please select both source and target classes.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                lblStatus.Text = "Loading promotion preview...";

                var fromClassId = fromClass.Id;
                var toClassId = toClass.Id;

                var preview = await _bulkPromotionService.GetPromotionPreviewAsync(fromClassId, toClassId);

                _currentPreview = preview.Select(p => new StudentPromotionViewModel
                {
                    StudentId = p.StudentId,
                    StudentName = p.StudentName,
                    StudentNumber = p.StudentNumber,
                    CurrentClass = p.CurrentClass,
                    TargetClass = p.TargetClass,
                    IsEligible = p.IsEligible,
                    IneligibilityReason = p.IneligibilityReason,
                    HasPendingFees = p.HasPendingFees,
                    PendingAmount = p.PendingAmount,
                    IsExcluded = false
                }).ToList();

                UpdatePreviewGrid();
                UpdateSummaryCards();

                btnExecutePromotion.IsEnabled = _currentPreview.Any(p => p.IsEligible && !p.IsExcluded);
                lblStatus.Text = $"Loaded {_currentPreview.Count} students for preview";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading preview: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = "Error loading preview";
            }
        }

        private void UpdatePreviewGrid()
        {
            var filteredStudents = _currentPreview.AsEnumerable();

            if (chkShowOnlyEligible.IsChecked == true)
            {
                filteredStudents = filteredStudents.Where(s => s.IsEligible);
            }

            if (chkShowPendingFees.IsChecked == true)
            {
                filteredStudents = filteredStudents.Where(s => s.HasPendingFees);
            }

            dgPromotionPreview.ItemsSource = filteredStudents.ToList();
        }

        private void UpdateSummaryCards()
        {
            var total = _currentPreview.Count;
            var eligible = _currentPreview.Count(p => p.IsEligible && !p.IsExcluded);
            var excluded = _currentPreview.Count(p => p.IsExcluded);

            txtTotalStudents.Text = total.ToString();
            txtEligibleStudents.Text = eligible.ToString();
            txtExcludedStudents.Text = excluded.ToString();
        }

        private void BtnExecutePromotion_Click(object sender, RoutedEventArgs e)
        {
            AsyncHelper.SafeFireAndForget(ExecutePromotionAsync);
        }

        private async Task ExecutePromotionAsync()
        {
            try
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to promote {_currentPreview.Count(p => p.IsEligible && !p.IsExcluded)} students?\n\nThis action cannot be easily undone.",
                    "Confirm Bulk Promotion",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result != MessageBoxResult.Yes)
                    return;

                lblStatus.Text = "Executing bulk promotion...";
                btnExecutePromotion.IsEnabled = false;

                var fromClass = cmbFromClass.SelectedItem as ClassDto;
                var toClass = cmbToClass.SelectedItem as ClassDto;

                var selectedAcademicYear = cmbAcademicYear.SelectedItem as SimpleAcademicYear;

                var request = new BulkPromotionRequest
                {
                    FromClassId = fromClass!.Id,
                    ToClassId = toClass!.Id,
                    AcademicYear = selectedAcademicYear!.Year.ToString(),
                    ExcludedStudentIds = _currentPreview.Where(p => p.IsExcluded).Select(p => p.StudentId).ToList(),
                    Reason = "Annual Promotion"
                };

                var promotionResult = await _bulkPromotionService.ExecuteBulkPromotionAsync(request);

                // Show results
                DisplayPromotionResults(promotionResult);

                lblStatus.Text = promotionResult.IsSuccess
                    ? $"Successfully promoted {promotionResult.PromotedStudents} students"
                    : $"Promotion completed with {promotionResult.FailedPromotions} errors";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing promotion: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                lblStatus.Text = "Error executing promotion";
                btnExecutePromotion.IsEnabled = true;
            }
        }

        private void DisplayPromotionResults(BulkPromotionResult result)
        {
            tabResults.IsSelected = true;
            borderResultsSummary.Visibility = Visibility.Visible;

            txtResultsSummary.Text = $"Promoted: {result.PromotedStudents} | Failed: {result.FailedPromotions} | Total: {result.TotalStudents}";
            txtPromotionDate.Text = $"Promotion Date: {result.PromotionDate:yyyy-MM-dd HH:mm:ss} | Academic Year: {result.AcademicYear}";

            dgPromotionErrors.ItemsSource = result.Errors;

            if (result.IsSuccess)
            {
                borderResultsSummary.Background = new SolidColorBrush(Color.FromRgb(232, 245, 233)); // Light green
                MessageBox.Show($"Bulk promotion completed successfully!\n\nPromoted: {result.PromotedStudents} students",
                               "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                borderResultsSummary.Background = new SolidColorBrush(Color.FromRgb(255, 243, 224)); // Light orange
                MessageBox.Show($"Bulk promotion completed with errors.\n\nPromoted: {result.PromotedStudents}\nFailed: {result.FailedPromotions}\n\nCheck the Results tab for details.",
                               "Partial Success", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ChkShowOnlyEligible_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePreviewGrid();
        }

        private void ChkShowOnlyEligible_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdatePreviewGrid();
        }

        private void ChkShowPendingFees_Checked(object sender, RoutedEventArgs e)
        {
            UpdatePreviewGrid();
        }

        private void ChkShowPendingFees_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdatePreviewGrid();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class StudentPromotionViewModel : INotifyPropertyChanged
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentNumber { get; set; } = string.Empty;
        public string CurrentClass { get; set; } = string.Empty;
        public string TargetClass { get; set; } = string.Empty;
        public bool IsEligible { get; set; }
        public string IneligibilityReason { get; set; } = string.Empty;
        public bool HasPendingFees { get; set; }
        public decimal PendingAmount { get; set; }

        private bool _isExcluded;
        public bool IsExcluded
        {
            get => _isExcluded;
            set
            {
                if (_isExcluded != value)
                {
                    _isExcluded = value;
                    OnPropertyChanged(nameof(IsExcluded));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SimpleAcademicYear
    {
        public int Year { get; set; }
        public bool IsCurrent { get; set; }
    }
}