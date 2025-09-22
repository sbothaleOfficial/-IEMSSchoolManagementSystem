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
            Console.WriteLine("=== BulkPromotionWindow.Window_Loaded() CALLED ===");
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
            Console.WriteLine("=== LoadInitialData() CALLED - FORCE OVERRIDE ===");

            // FORCE OVERRIDE: Completely bypass all existing logic and directly populate ComboBoxes
            try
            {
                Console.WriteLine("=== FORCING PREDEFINED CLASSES OVERRIDE ===");

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

                Console.WriteLine($"=== FORCE OVERRIDE: Created {predefinedClasses.Count} classes ===");

                // Force clear and repopulate ComboBoxes
                cmbFromClass.ItemsSource = null;
                cmbToClass.ItemsSource = null;
                cmbFromClass.Items.Clear();
                cmbToClass.Items.Clear();

                // Set ItemsSource to our predefined list
                cmbFromClass.ItemsSource = predefinedClasses.ToList();
                cmbToClass.ItemsSource = predefinedClasses.ToList();

                // Set default selection
                cmbFromClass.SelectedIndex = 0;
                cmbToClass.SelectedIndex = 0;

                Console.WriteLine("=== FORCE OVERRIDE: ComboBoxes populated successfully ===");
                _allClasses = predefinedClasses;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=== FORCE OVERRIDE ERROR: {ex.Message} ===");
                MessageBox.Show($"Error in force override: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Load extended academic years (past 10 years + current + future 40 years)
            LoadExtendedAcademicYears();
        }

        private void LoadPredefinedClassesDirectly()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("=== BULK PROMOTION - LOADING PREDEFINED CLASSES DIRECTLY ===");
                Console.WriteLine("=== BULK PROMOTION - LOADING PREDEFINED CLASSES DIRECTLY ===");

                // Use a clean, predefined list with proper class hierarchy
                var cleanClasses = new List<ClassDto>
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

                System.Diagnostics.Debug.WriteLine($"=== PREDEFINED CLASSES COUNT: {cleanClasses.Count} ===");
                foreach (var cls in cleanClasses)
                {
                    System.Diagnostics.Debug.WriteLine($"Predefined: ID={cls.Id}, Name='{cls.Name}'");
                }

                _allClasses = cleanClasses;

                // Clear and set ComboBox items directly
                cmbFromClass.Items.Clear();
                cmbToClass.Items.Clear();
                cmbFromClass.ItemsSource = null;
                cmbToClass.ItemsSource = null;

                // Create separate lists for each ComboBox to avoid binding issues
                var fromClassList = new List<ClassDto>(_allClasses);
                var toClassList = new List<ClassDto>(_allClasses);

                // Set new bindings with separate lists
                cmbFromClass.ItemsSource = fromClassList;
                cmbToClass.ItemsSource = toClassList;

                // Force refresh of the ComboBoxes
                cmbFromClass.UpdateLayout();
                cmbToClass.UpdateLayout();

                // Set default selection to first item (-- Select Class --)
                cmbFromClass.SelectedIndex = 0;
                cmbToClass.SelectedIndex = 0;

                // Debug: Verify what's actually in the ComboBoxes
                System.Diagnostics.Debug.WriteLine("=== VERIFYING DIRECT COMBOBOX CONTENTS ===");
                System.Diagnostics.Debug.WriteLine($"FromClass ComboBox has {cmbFromClass.Items.Count} items:");
                for (int i = 0; i < cmbFromClass.Items.Count; i++)
                {
                    var item = cmbFromClass.Items[i] as ClassDto;
                    System.Diagnostics.Debug.WriteLine($"  FromClass[{i}]: ID={item?.Id}, Name='{item?.Name}'");
                }

                System.Diagnostics.Debug.WriteLine($"ToClass ComboBox has {cmbToClass.Items.Count} items:");
                for (int i = 0; i < cmbToClass.Items.Count; i++)
                {
                    var item = cmbToClass.Items[i] as ClassDto;
                    System.Diagnostics.Debug.WriteLine($"  ToClass[{i}]: ID={item?.Id}, Name='{item?.Name}'");
                }

                System.Diagnostics.Debug.WriteLine("=== BULK PROMOTION - PREDEFINED CLASSES LOADED SUCCESSFULLY ===");
                Console.WriteLine("=== BULK PROMOTION - PREDEFINED CLASSES LOADED SUCCESSFULLY ===");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"=== ERROR LOADING PREDEFINED CLASSES: {ex.Message} ===");
                Console.WriteLine($"=== ERROR LOADING PREDEFINED CLASSES: {ex.Message} ===");

                // Fallback to the old predefined classes method
                LoadPredefinedClasses();
                MessageBox.Show($"Warning: Could not load predefined classes. Using fallback.\nError: {ex.Message}",
                               "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async Task LoadClassesAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("=== BULK PROMOTION - LOADING CLASSES (FIXED) ===");

                // Use a clean, predefined list with proper class hierarchy
                // Fixed spelling: "Nursery" not "Nursary"
                var cleanClasses = new List<ClassDto>
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

                System.Diagnostics.Debug.WriteLine($"=== CLEAN DROPDOWN CLASSES ({cleanClasses.Count}) ===");
                foreach (var cleanClass in cleanClasses)
                {
                    System.Diagnostics.Debug.WriteLine($"Clean: ID={cleanClass.Id}, Name='{cleanClass.Name}'");
                }

                _allClasses = cleanClasses;

                // Update UI on the dispatcher thread to ensure proper binding
                await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    // Clear existing items and bindings
                    cmbFromClass.Items.Clear();
                    cmbToClass.Items.Clear();
                    cmbFromClass.ItemsSource = null;
                    cmbToClass.ItemsSource = null;

                    // Create separate lists for each ComboBox to avoid binding issues
                    var fromClassList = new List<ClassDto>(_allClasses);
                    var toClassList = new List<ClassDto>(_allClasses);

                    // Set new bindings with separate lists
                    cmbFromClass.ItemsSource = fromClassList;
                    cmbToClass.ItemsSource = toClassList;

                    // Force refresh of the ComboBoxes
                    cmbFromClass.UpdateLayout();
                    cmbToClass.UpdateLayout();

                    // Set default selection to first item (-- Select Class --)
                    cmbFromClass.SelectedIndex = 0;
                    cmbToClass.SelectedIndex = 0;

                    // Debug: Verify what's actually in the ComboBoxes
                    System.Diagnostics.Debug.WriteLine("=== VERIFYING COMBOBOX CONTENTS ===");
                    System.Diagnostics.Debug.WriteLine($"FromClass ComboBox has {cmbFromClass.Items.Count} items:");
                    for (int i = 0; i < cmbFromClass.Items.Count; i++)
                    {
                        var item = cmbFromClass.Items[i] as ClassDto;
                        System.Diagnostics.Debug.WriteLine($"  FromClass[{i}]: ID={item?.Id}, Name='{item?.Name}'");
                    }

                    System.Diagnostics.Debug.WriteLine($"ToClass ComboBox has {cmbToClass.Items.Count} items:");
                    for (int i = 0; i < cmbToClass.Items.Count; i++)
                    {
                        var item = cmbToClass.Items[i] as ClassDto;
                        System.Diagnostics.Debug.WriteLine($"  ToClass[{i}]: ID={item?.Id}, Name='{item?.Name}'");
                    }
                });

                System.Diagnostics.Debug.WriteLine("=== BULK PROMOTION - CLEAN CLASSES LOADED SUCCESSFULLY ===");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"=== ERROR LOADING CLEAN CLASSES: {ex.Message} ===");

                // Fallback to predefined classes if this fails
                await System.Windows.Application.Current.Dispatcher.InvokeAsync(() => LoadPredefinedClasses());
                MessageBox.Show($"Warning: Could not load classes. Using fallback classes.\nError: {ex.Message}",
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

            // Clear existing items and bindings
            cmbFromClass.Items.Clear();
            cmbToClass.Items.Clear();
            cmbFromClass.ItemsSource = null;
            cmbToClass.ItemsSource = null;

            // Create separate lists for each ComboBox to avoid binding issues
            var fromClassList = new List<ClassDto>(_allClasses);
            var toClassList = new List<ClassDto>(_allClasses);

            // Set new bindings with separate lists
            cmbFromClass.ItemsSource = fromClassList;
            cmbToClass.ItemsSource = toClassList;

            // Force refresh of the ComboBoxes
            cmbFromClass.UpdateLayout();
            cmbToClass.UpdateLayout();

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