using System.Linq;
using System.Windows;

namespace IEMS.WPF
{
    public partial class ResetPasswordWindow : Window
    {
        public string NewPassword { get; private set; } = string.Empty;

        public ResetPasswordWindow()
        {
            InitializeComponent();
            txtNewPassword.Focus();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Hide previous errors
            txtError.Visibility = Visibility.Collapsed;

            // Validate
            if (string.IsNullOrWhiteSpace(txtNewPassword.Password))
            {
                ShowError("Password is required");
                txtNewPassword.Focus();
                return;
            }

            var password = txtNewPassword.Password;

            // Comprehensive password validation matching UserService requirements
            if (password.Length < 8)
            {
                ShowError("Password must be at least 8 characters long");
                txtNewPassword.Focus();
                return;
            }

            if (!password.Any(char.IsUpper))
            {
                ShowError("Password must contain at least one uppercase letter");
                txtNewPassword.Focus();
                return;
            }

            if (!password.Any(char.IsLower))
            {
                ShowError("Password must contain at least one lowercase letter");
                txtNewPassword.Focus();
                return;
            }

            if (!password.Any(char.IsDigit))
            {
                ShowError("Password must contain at least one number");
                txtNewPassword.Focus();
                return;
            }

            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                ShowError("Password must contain at least one special character");
                txtNewPassword.Focus();
                return;
            }

            if (txtNewPassword.Password != txtConfirmPassword.Password)
            {
                ShowError("Passwords do not match");
                txtConfirmPassword.Focus();
                return;
            }

            NewPassword = txtNewPassword.Password;
            this.DialogResult = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void ShowError(string message)
        {
            txtError.Text = message;
            txtError.Visibility = Visibility.Visible;
        }
    }
}