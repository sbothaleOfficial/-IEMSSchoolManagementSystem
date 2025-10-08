using System.Windows;
using System.Windows.Controls;

namespace IEMS.WPF;

public partial class ColumnPickerDialog : Window
{
    public Dictionary<string, bool> SelectedColumns { get; private set; }

    public ColumnPickerDialog()
    {
        InitializeComponent();
        SelectedColumns = new Dictionary<string, bool>();
    }

    private void BtnSelectAll_Click(object sender, RoutedEventArgs e)
    {
        SetAllCheckboxes(true);
    }

    private void BtnDeselectAll_Click(object sender, RoutedEventArgs e)
    {
        SetAllCheckboxes(false);
    }

    private void SetAllCheckboxes(bool isChecked)
    {
        foreach (var child in ColumnListPanel.Children)
        {
            if (child is CheckBox checkBox)
            {
                checkBox.IsChecked = isChecked;
            }
        }
    }

    private void BtnExport_Click(object sender, RoutedEventArgs e)
    {
        // Collect selected columns
        SelectedColumns.Clear();
        SelectedColumns["SerialNo"] = chkSerialNo.IsChecked ?? false;
        SelectedColumns["StudentNumber"] = chkStudentNumber.IsChecked ?? false;
        SelectedColumns["FirstName"] = chkFirstName.IsChecked ?? false;
        SelectedColumns["FatherName"] = chkFatherName.IsChecked ?? false;
        SelectedColumns["Surname"] = chkSurname.IsChecked ?? false;
        SelectedColumns["MotherName"] = chkMotherName.IsChecked ?? false;
        SelectedColumns["DateOfBirth"] = chkDateOfBirth.IsChecked ?? false;
        SelectedColumns["Gender"] = chkGender.IsChecked ?? false;
        SelectedColumns["Standard"] = chkStandard.IsChecked ?? false;
        SelectedColumns["Division"] = chkDivision.IsChecked ?? false;
        SelectedColumns["AdmissionDate"] = chkAdmissionDate.IsChecked ?? false;
        SelectedColumns["CasteCategory"] = chkCasteCategory.IsChecked ?? false;
        SelectedColumns["Religion"] = chkReligion.IsChecked ?? false;
        SelectedColumns["BPL"] = chkBPL.IsChecked ?? false;
        SelectedColumns["SemiEnglish"] = chkSemiEnglish.IsChecked ?? false;
        SelectedColumns["Address"] = chkAddress.IsChecked ?? false;
        SelectedColumns["CityVillage"] = chkCityVillage.IsChecked ?? false;
        SelectedColumns["ParentMobile"] = chkParentMobile.IsChecked ?? false;
        SelectedColumns["AadhaarNumber"] = chkAadhaarNumber.IsChecked ?? false;
        SelectedColumns["OutstandingFees"] = chkOutstandingFees.IsChecked ?? false;

        // Validate that at least one column is selected
        if (!SelectedColumns.Values.Any(v => v))
        {
            MessageBox.Show("Please select at least one column to export.", "No Columns Selected",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
