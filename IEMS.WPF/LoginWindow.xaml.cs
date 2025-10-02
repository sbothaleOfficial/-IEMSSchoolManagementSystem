using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using IEMS.Application.Services;
using IEMS.Core.Entities;
using IEMS.Core.Services;

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

                        // Check if user must change password
                        if (user.MustChangePassword)
                        {
                            ShowLoading(false);

                            MessageBox.Show(
                                "Your password must be changed before you can continue.\n\nPlease enter a new password that meets the following requirements:\n" +
                                "• At least 8 characters long\n" +
                                "• Contains uppercase and lowercase letters\n" +
                                "• Contains at least one number\n" +
                                "• Contains at least one special character",
                                "Password Change Required",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

                            var passwordWindow = new ResetPasswordWindow();
                            if (passwordWindow.ShowDialog() == true)
                            {
                                try
                                {
                                    // Use ChangePasswordAsync which properly handles the password change and clears MustChangePassword flag
                                    // We pass the old password (which we don't have) but since ResetPasswordAsync is for admin reset,
                                    // we'll need to use a different approach for forced password change

                                    // Directly update the password hash and clear the flag
                                    var passwordHashingService = scope.ServiceProvider.GetRequiredService<PasswordHashingService>();
                                    user.PasswordHash = passwordHashingService.HashPassword(passwordWindow.NewPassword);
                                    user.MustChangePassword = false;
                                    user.ModifiedDate = DateTime.Now;
                                    user.ModifiedBy = user.Username;

                                    await userService.UpdateUserAsync(user, user.Username);

                                    MessageBox.Show(
                                        "Your password has been changed successfully.\n\nYou can now access the system.",
                                        "Password Changed",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);

                                    ShowLoading(true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Failed to change password: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("You must change your password to access the system.", "Password Change Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                                return false;
                            }
                        }

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