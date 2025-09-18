using System.Windows;
using IEMS.Application.Services;
using IEMS.Application.DTOs;
using IEMS.Core.Interfaces;

namespace IEMS.WPF;

public partial class AddEditStudentWindow : Window
{
    private readonly StudentService _studentService;
    private readonly ClassService _classService;
    private readonly StudentDto? _studentToEdit;

    public AddEditStudentWindow(StudentService studentService, ClassService classService, StudentDto? studentToEdit = null)
    {
        InitializeComponent();
        _studentService = studentService;
        _classService = classService;
        _studentToEdit = studentToEdit;

        LoadClasses();
        LoadStudentData();

        Title = studentToEdit == null ? "Add Student" : "Edit Student";
    }

    private async void LoadClasses()
    {
        try
        {
            var classes = await _classService.GetAllClassesAsync();
            var classList = classes.Select(c => new
            {
                Id = c.Id,
                Name = c.DisplayName
            }).ToList();

            cmbClass.ItemsSource = classList;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading classes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void LoadStudentData()
    {
        if (_studentToEdit != null)
        {
            txtSerialNo.Text = _studentToEdit.SerialNo.ToString();
            txtStandard.Text = _studentToEdit.Standard;
            txtClassDivision.Text = _studentToEdit.ClassDivision;
            txtFirstName.Text = _studentToEdit.FirstName;
            txtFatherName.Text = _studentToEdit.FatherName;
            txtSurname.Text = _studentToEdit.Surname;
            dpDateOfBirth.SelectedDate = _studentToEdit.DateOfBirth;
            cmbGender.Text = _studentToEdit.Gender;
            txtMotherName.Text = _studentToEdit.MotherName;
            txtStudentNumber.Text = _studentToEdit.StudentNumber;
            dpAdmissionDate.SelectedDate = _studentToEdit.AdmissionDate;
            cmbCasteCategory.Text = _studentToEdit.CasteCategory;
            cmbReligion.Text = _studentToEdit.Religion;
            chkBPL.IsChecked = _studentToEdit.IsBPL;
            chkSemiEnglish.IsChecked = _studentToEdit.IsSemiEnglish;
            txtAddress.Text = _studentToEdit.Address;
            txtCityVillage.Text = _studentToEdit.CityVillage;
            txtParentMobile.Text = _studentToEdit.ParentMobileNumber;
            cmbClass.SelectedValue = _studentToEdit.ClassId;
        }
        else
        {
            dpDateOfBirth.SelectedDate = DateTime.Today.AddYears(-15);
            dpAdmissionDate.SelectedDate = DateTime.Today;
            cmbGender.SelectedIndex = 0;
            cmbCasteCategory.SelectedIndex = 0;
            cmbReligion.SelectedIndex = 0;
        }
    }

    private async void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            var studentDto = new StudentDto
            {
                Id = _studentToEdit?.Id ?? 0,
                SerialNo = int.Parse(txtSerialNo.Text.Trim()),
                Standard = txtStandard.Text.Trim(),
                ClassDivision = txtClassDivision.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                FatherName = txtFatherName.Text.Trim(),
                Surname = txtSurname.Text.Trim(),
                DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.Today,
                Gender = cmbGender.Text,
                MotherName = txtMotherName.Text.Trim(),
                StudentNumber = txtStudentNumber.Text.Trim(),
                AdmissionDate = dpAdmissionDate.SelectedDate ?? DateTime.Today,
                CasteCategory = cmbCasteCategory.Text,
                Religion = cmbReligion.Text,
                IsBPL = chkBPL.IsChecked ?? false,
                IsSemiEnglish = chkSemiEnglish.IsChecked ?? false,
                Address = txtAddress.Text.Trim(),
                CityVillage = txtCityVillage.Text.Trim(),
                ParentMobileNumber = txtParentMobile.Text.Trim(),
                ClassId = (int)cmbClass.SelectedValue
            };

            if (_studentToEdit == null)
            {
                await _studentService.AddStudentAsync(studentDto);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                await _studentService.UpdateStudentAsync(studentDto);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DialogResult = true;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving student: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtSerialNo.Text) || !int.TryParse(txtSerialNo.Text.Trim(), out _))
        {
            MessageBox.Show("Serial number is required and must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtSerialNo.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtStandard.Text))
        {
            MessageBox.Show("Standard is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtStandard.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtClassDivision.Text))
        {
            MessageBox.Show("Class division is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtClassDivision.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBox.Show("First name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtFirstName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtFatherName.Text))
        {
            MessageBox.Show("Father's name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtFatherName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtSurname.Text))
        {
            MessageBox.Show("Surname is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtSurname.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtMotherName.Text))
        {
            MessageBox.Show("Mother's name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtMotherName.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtStudentNumber.Text))
        {
            MessageBox.Show("Student number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtStudentNumber.Focus();
            return false;
        }

        if (dpDateOfBirth.SelectedDate == null)
        {
            MessageBox.Show("Date of birth is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpDateOfBirth.Focus();
            return false;
        }

        if (dpAdmissionDate.SelectedDate == null)
        {
            MessageBox.Show("Admission date is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            dpAdmissionDate.Focus();
            return false;
        }

        if (cmbGender.SelectedItem == null)
        {
            MessageBox.Show("Gender selection is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbGender.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtParentMobile.Text))
        {
            MessageBox.Show("Parent mobile number is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            txtParentMobile.Focus();
            return false;
        }

        if (cmbClass.SelectedValue == null)
        {
            MessageBox.Show("Class selection is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            cmbClass.Focus();
            return false;
        }

        return true;
    }
}