using System;
using System.Windows;
using IEMS.Application.Services;
using IEMS.Core.Entities;

namespace IEMS.WPF
{
    public partial class AddEditUserWindow : Window
    {
        private readonly UserService _userService;
        private readonly User? _existingUser;
        private readonly bool _isEditMode;

        public AddEditUserWindow(UserService userService, User? existingUser)
        {
            InitializeComponent();
            _userService = userService;
            _existingUser = existingUser;
            _isEditMode = existingUser != null;

            if (_isEditMode)
            {
                LoadUserData();
                txtTitle.Text = "Edit User";
                pnlPassword.Visibility = Visibility.Collapsed;
                pnlStatus.Visibility = Visibility.Visible;
            }
            else
            {
                cmbRole.SelectedIndex = 0; // Default to Admin
            }
        }

        private void LoadUserData()
        {
            if (_existingUser != null)
            {
                txtUsername.Text = _existingUser.Username;
                txtUsername.IsEnabled = false; // Don't allow username changes
                txtFullName.Text = _existingUser.FullName;
                txtEmail.Text = _existingUser.Email;

                // Set role
                for (int i = 0; i < cmbRole.Items.Count; i++)
                {
                    var item = cmbRole.Items[i] as System.Windows.Controls.ComboBoxItem;
                    if (item?.Content.ToString() == _existingUser.Role)
                    {
                        cmbRole.SelectedIndex = i;
                        break;
                    }
                }

                chkIsActive.IsChecked = _existingUser.IsActive;
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Hide previous errors
                txtError.Visibility = Visibility.Collapsed;

                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    ShowError("Username is required");
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    ShowError("Full name is required");
                    txtFullName.Focus();
                    return;
                }

                if (cmbRole.SelectedIndex < 0)
                {
                    ShowError("Please select a role");
                    cmbRole.Focus();
                    return;
                }

                var selectedRole = ((System.Windows.Controls.ComboBoxItem)cmbRole.SelectedItem).Content.ToString();

                if (_isEditMode)
                {
                    // Update existing user
                    if (_existingUser != null)
                    {
                        _existingUser.FullName = txtFullName.Text.Trim();
                        _existingUser.Email = txtEmail.Text.Trim();
                        _existingUser.Role = selectedRole ?? "Clerk";
                        _existingUser.IsActive = chkIsActive.IsChecked == true;

                        await _userService.UpdateUserAsync(_existingUser, LoginWindow.CurrentUser?.Username ?? "System");

                        MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.DialogResult = true;
                        this.Close();
                    }
                }
                else
                {
                    // Create new user
                    if (string.IsNullOrWhiteSpace(txtPassword.Password))
                    {
                        ShowError("Password is required");
                        txtPassword.Focus();
                        return;
                    }

                    if (txtPassword.Password.Length < 8)
                    {
                        ShowError("Password must be at least 8 characters");
                        txtPassword.Focus();
                        return;
                    }

                    if (txtPassword.Password != txtConfirmPassword.Password)
                    {
                        ShowError("Passwords do not match");
                        txtConfirmPassword.Focus();
                        return;
                    }

                    // Check if username exists
                    if (await _userService.UsernameExistsAsync(txtUsername.Text.Trim()))
                    {
                        ShowError($"Username '{txtUsername.Text.Trim()}' already exists");
                        txtUsername.Focus();
                        return;
                    }

                    await _userService.CreateUserAsync(
                        username: txtUsername.Text.Trim(),
                        password: txtPassword.Password,
                        fullName: txtFullName.Text.Trim(),
                        role: selectedRole ?? "Clerk",
                        email: txtEmail.Text.Trim(),
                        createdBy: LoginWindow.CurrentUser?.Username ?? "System"
                    );

                    MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.DialogResult = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Error saving user: {ex.Message}");
            }
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