using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using IEMS.Application.Services;
using IEMS.Core.Entities;

namespace IEMS.WPF
{
    public partial class LoginWindow : Window
    {
        public static User? CurrentUser { get; internal set; }

        public LoginWindow()
        {
            InitializeComponent();

            // Set focus to username field
            Loaded += (s, e) => txtUsername.Focus();

            // Handle Enter key press
            KeyDown += LoginWindow_KeyDown;
        }

        private void LoginWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Password;

            // Clear previous error messages
            txtErrorMessage.Visibility = Visibility.Collapsed;

            // Basic validation
            if (string.IsNullOrEmpty(username))
            {
                ShowError("Please enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Please enter your password.");
                txtPassword.Focus();
                return;
            }

            // Show loading overlay
            ShowLoading(true);

            try
            {
                // Simulate authentication delay
                await Task.Delay(1000);

                // Simple authentication logic (you can enhance this later)
                bool isAuthenticated = await AuthenticateUser(username, password);

                if (isAuthenticated)
                {
                    // Authentication successful
                    try
                    {
                        // Create a scope for resolving MainWindow with all its dependencies
                        var scope = App.ServiceProvider.CreateScope();
                        var mainWindow = scope.ServiceProvider.GetRequiredService<MainWindow>();

                        // Store the scope so it doesn't get disposed
                        mainWindow.Tag = scope;

                        // Set this flag to prevent app shutdown when login window closes
                        System.Windows.Application.Current.MainWindow = mainWindow;

                        // Transfer the window state and position
                        mainWindow.WindowState = this.WindowState;
                        if (this.WindowState == WindowState.Normal)
                        {
                            mainWindow.Left = this.Left;
                            mainWindow.Top = this.Top;
                            mainWindow.Width = this.Width;
                            mainWindow.Height = this.Height;
                        }

                        // Show main window first, then close login window
                        mainWindow.Show();

                        // Dispose scope when main window closes
                        mainWindow.Closed += (s, args) =>
                        {
                            if (mainWindow.Tag is IServiceScope serviceScope)
                            {
                                serviceScope.Dispose();
                            }
                        };

                        this.Close();
                    }
                    catch (Exception mainWindowEx)
                    {
                        MessageBox.Show($"Failed to open main window: {mainWindowEx.Message}\n\nInner Exception: {mainWindowEx.InnerException?.Message}\n\nStack trace: {mainWindowEx.StackTrace}",
                                      "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        ShowError($"Failed to open main window. Please check the error details.");
                        ShowLoading(false);
                    }
                }
                else
                {
                    ShowError("Invalid username or password. Please try again.");
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}\n\nStack trace: {ex.StackTrace}",
                              "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ShowError($"Login failed: {ex.Message}");
            }
            finally
            {
                ShowLoading(false);
            }
        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            try
            {
                using (var scope = App.ServiceProvider.CreateScope())
                {
                    var userService = scope.ServiceProvider.GetRequiredService<UserService>();
                    var user = await userService.AuthenticateAsync(username, password);

                    if (user != null)
                    {
                        CurrentUser = user;
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        private void ShowError(string message)
        {
            txtErrorMessage.Text = message;
            txtErrorMessage.Visibility = Visibility.Visible;
        }

        private void ShowLoading(bool show)
        {
            LoadingOverlay.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
            btnLogin.IsEnabled = !show;
        }

        protected override void OnClosed(EventArgs e)
        {
            // If login window is closed without successful login (MainWindow not set or not visible), exit the application
            var mainWindow = System.Windows.Application.Current.MainWindow;
            if (mainWindow == null || mainWindow == this)
            {
                System.Windows.Application.Current.Shutdown();
            }
            base.OnClosed(e);
        }
    }
}