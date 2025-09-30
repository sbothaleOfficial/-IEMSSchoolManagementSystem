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

            if (txtNewPassword.Password.Length < 8)
            {
                ShowError("Password must be at least 8 characters");
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