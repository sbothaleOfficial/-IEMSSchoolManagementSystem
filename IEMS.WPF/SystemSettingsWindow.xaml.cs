using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using IEMS.Application.Interfaces;
using IEMS.Core.Entities;

namespace IEMS.WPF
{
    public partial class SystemSettingsWindow : Window
    {
        private readonly ISystemSettingsService _systemSettingsService;
        private List<SystemSetting> _currentSettings = new();
        private readonly Dictionary<string, Control> _settingControls = new();

        public SystemSettingsWindow()
        {
            InitializeComponent();

            var serviceProvider = App.ServiceProvider;
            _systemSettingsService = serviceProvider.GetRequiredService<ISystemSettingsService>();

            Loaded += SystemSettingsWindow_Loaded;
        }

        private async void SystemSettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadCategoriesAsync();
            await LoadSettingsAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _systemSettingsService.GetCategoriesAsync();
                var categoryList = new List<string> { "All Categories" };
                categoryList.AddRange(categories);

                CategoryComboBox.ItemsSource = categoryList;
                CategoryComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadSettingsAsync(string? category = null)
        {
            try
            {
                if (string.IsNullOrEmpty(category) || category == "All Categories")
                {
                    _currentSettings = (await _systemSettingsService.GetAllSettingsAsync()).ToList();
                }
                else
                {
                    _currentSettings = (await _systemSettingsService.GetSettingsByCategoryAsync(category)).ToList();
                }

                await BuildSettingsUIAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading settings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task BuildSettingsUIAsync()
        {
            SettingsPanel.Children.Clear();
            _settingControls.Clear();

            var settingsByCategory = _currentSettings.GroupBy(s => s.Category);

            foreach (var categoryGroup in settingsByCategory.OrderBy(g => g.Key))
            {
                // Category Header
                var categoryBorder = new Border
                {
                    Style = (Style)FindResource("CardStyle"),
                    Margin = new Thickness(0, 10, 0, 5)
                };

                var categoryPanel = new StackPanel();

                var categoryHeader = new TextBlock
                {
                    Text = $"📁 {categoryGroup.Key} Settings",
                    FontSize = 18,
                    FontWeight = FontWeights.Bold,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 122, 204)),
                    Margin = new Thickness(0, 0, 0, 15)
                };
                categoryPanel.Children.Add(categoryHeader);

                // Settings in this category
                foreach (var setting in categoryGroup.OrderBy(s => s.Key))
                {
                    var settingPanel = CreateSettingControl(setting);
                    categoryPanel.Children.Add(settingPanel);
                }

                categoryBorder.Child = categoryPanel;
                SettingsPanel.Children.Add(categoryBorder);
            }
        }

        private StackPanel CreateSettingControl(SystemSetting setting)
        {
            var panel = new StackPanel { Margin = new Thickness(0, 0, 0, 15) };

            // Setting label
            var labelPanel = new StackPanel { Orientation = Orientation.Horizontal };

            var label = new TextBlock
            {
                Text = setting.Key.Split('.').Last(), // Show only the key part after the last dot
                FontWeight = FontWeights.SemiBold,
                FontSize = 14,
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center
            };
            labelPanel.Children.Add(label);

            if (setting.IsReadOnly)
            {
                var readOnlyLabel = new TextBlock
                {
                    Text = "🔒 Read Only",
                    FontSize = 12,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray),
                    VerticalAlignment = VerticalAlignment.Center
                };
                labelPanel.Children.Add(readOnlyLabel);
            }

            panel.Children.Add(labelPanel);

            // Description
            if (!string.IsNullOrEmpty(setting.Description))
            {
                var description = new TextBlock
                {
                    Text = setting.Description,
                    FontSize = 12,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray),
                    Margin = new Thickness(0, 2, 0, 5),
                    TextWrapping = TextWrapping.Wrap
                };
                panel.Children.Add(description);
            }

            // Input control based on data type
            Control inputControl = CreateInputControl(setting);
            _settingControls[setting.Key] = inputControl;
            panel.Children.Add(inputControl);

            return panel;
        }

        private Control CreateInputControl(SystemSetting setting)
        {
            Control control;

            switch (setting.DataType.ToLower())
            {
                case "boolean":
                    var checkBox = new CheckBox
                    {
                        Style = (Style)FindResource("ModernCheckBoxStyle"),
                        IsChecked = bool.TryParse(setting.Value, out bool boolValue) && boolValue,
                        IsEnabled = !setting.IsReadOnly
                    };
                    control = checkBox;
                    break;

                case "integer":
                case "decimal":
                    var numberBox = new TextBox
                    {
                        Style = (Style)FindResource("ModernTextBoxStyle"),
                        Text = setting.Value,
                        IsEnabled = !setting.IsReadOnly,
                        Width = 200,
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    control = numberBox;
                    break;

                case "filepath":
                case "directorypath":
                    var pathBox = new TextBox
                    {
                        Style = (Style)FindResource("ModernTextBoxStyle"),
                        Text = setting.Value,
                        IsEnabled = !setting.IsReadOnly,
                        Width = 400,
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    // Store the data type in the Tag property for later retrieval
                    pathBox.Tag = setting.DataType;
                    control = pathBox;
                    break;

                default: // String and others
                    var textBox = new TextBox
                    {
                        Style = (Style)FindResource("ModernTextBoxStyle"),
                        Text = setting.Value,
                        IsEnabled = !setting.IsReadOnly,
                        Width = 400,
                        HorizontalAlignment = HorizontalAlignment.Left
                    };
                    control = textBox;
                    break;
            }

            return control;
        }

        private void BrowseForPath(TextBox pathBox, bool isDirectory)
        {
            if (isDirectory)
            {
                var dialog = new Microsoft.Win32.OpenFolderDialog();
                if (dialog.ShowDialog() == true)
                {
                    pathBox.Text = dialog.FolderName;
                }
            }
            else
            {
                var dialog = new Microsoft.Win32.OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    pathBox.Text = dialog.FileName;
                }
            }
        }

        private async void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem is string selectedCategory)
            {
                await LoadSettingsAsync(selectedCategory == "All Categories" ? null : selectedCategory);
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var updatedSettings = new List<SystemSetting>();

                foreach (var setting in _currentSettings)
                {
                    if (setting.IsReadOnly) continue;

                    var control = _settingControls[setting.Key];
                    string newValue = GetControlValue(control, setting.DataType);

                    if (newValue != setting.Value)
                    {
                        setting.Value = newValue;
                        updatedSettings.Add(setting);
                    }
                }

                if (updatedSettings.Any())
                {
                    var result = await _systemSettingsService.UpdateSettingsAsync(updatedSettings);
                    if (result)
                    {
                        MessageBox.Show($"Successfully updated {updatedSettings.Count} settings.", "Success",
                                      MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to save some settings. Please check your inputs and try again.",
                                      "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No changes detected.", "Information",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving settings: {ex.Message}", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetControlValue(Control control, string dataType)
        {
            switch (control)
            {
                case CheckBox checkBox:
                    return (checkBox.IsChecked ?? false).ToString();

                case TextBox textBox:
                    return textBox.Text ?? string.Empty;


                default:
                    return string.Empty;
            }
        }

        private async void ResetCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoryComboBox.SelectedItem as string;
            if (string.IsNullOrEmpty(selectedCategory) || selectedCategory == "All Categories")
            {
                MessageBox.Show("Please select a specific category to reset.", "Information",
                              MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Are you sure you want to reset all settings in the '{selectedCategory}' category to their default values?",
                "Confirm Reset", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    var resetResult = await _systemSettingsService.ResetCategoryToDefaultAsync(selectedCategory);
                    if (resetResult)
                    {
                        MessageBox.Show($"Successfully reset '{selectedCategory}' settings to defaults.", "Success",
                                      MessageBoxButton.OK, MessageBoxImage.Information);
                        await LoadSettingsAsync(selectedCategory);
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset settings. Some settings may not have default values.",
                                      "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error resetting settings: {ex.Message}", "Error",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}