using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HospitalSystemConsoleApplication;

namespace HospitalSystemGUIApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Window used to prescribe a drug to a patient.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class PrescribeDrug : Window
    {
        /// <summary>
        /// private field used to declare a new field of type hospital library.
        /// </summary>
        private HospitalLibrary hmsLibrary;

        /// <summary>
        /// Constructor for the prescribe drug window.
        /// 
        /// Sets the field hmsLibrary and initialises it to the singleton instance of the hospital library class.
        /// 
        /// Populates the patients combo box with the hospital library patients list.
        /// Populates the doctors combo box with the hospital library doctors list.
        /// </summary>
        public PrescribeDrug()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance;

            cmbPatient.ItemsSource = hmsLibrary.Patients;
            cmbDoctor.ItemsSource = hmsLibrary.Doctors;
        }

        /// <summary>
        /// Method designed to close the window when the cancel button is clicked.
        /// A message box will appear on screen to get the user to confirm if this is what they want.
        /// If it is the window will close, otherwise the window will stay open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("Are you sure you'd like to cancel prescribing a new drug?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// This method is used to prescribe a drug to a patient within the hospital system.
        /// If statements and regex are used in the GUI application to ensure the data fields are not empty
        /// and also to check if the dosage is a numerical value between 0-9. The data validation in the 
        /// business model will also be used here for further validation. 
        /// If an exception is thrown, the system will display an error message with details of the error.
        /// Otherwise, if the patient is successfully added, a success message will appear on screen and the window will close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrescribeDrug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDrugName.Text == "Drug Name")
                {
                    txtDrugName.Text = ""; // Sets the drug name to be empty if the user has not entered a value.
                }
                if (txtDosage.Text == "Dosage")
                {
                    txtDosage.Text = ""; // Sets teh dosage to be empty if the user has not entered a value.
                }
                if (txtInstructions.Text == "Instructions")
                {
                    txtInstructions.Text = ""; // Sets the instructions to be empty if the user hasn't entered any.
                }

                Patient patient; // field used to store the patient the user selects from the patient combobox.
                if (cmbPatient.SelectedItem == null)
                {
                    throw new Exception("Please select a patient from the drop down menu."); // Exception thrown if the patient has not been selected.
                }
                else
                {
                    patient = (Patient)cmbPatient.SelectedItem; // patient field set to the patient the user selected from the combobox.
                }

                string drugName; // field used to store the drug name that the user will enter.

                if (txtDrugName.Text == "")
                {
                    txtDrugName.Text = "Drug Name";
                    throw new Exception("Drug Name must be entered"); // Exception thrown if the drug name has not been entered.
                }
                else
                {
                    drugName = txtDrugName.Text; // Sets the drug name field to the contents of the drug name text box.
                }

                double dosage; // field used to store the dosage

                if (!(Regex.Match(txtDosage.Text, @"[0-9.]")).Success)
                {
                    txtDosage.Text = "Dosage";
                    throw new Exception("Dosage must be numeric. Cannot be 0"); // Regex used to check if the value in the text box is numeric. If not, an exception is thrown. 
                }
                else
                {
                    dosage = Convert.ToDouble(txtDosage.Text); // Sets the dosage field to the contents of the dosage text box.
                }

                string instructions; // instructions field used to store the instructions entered into the instructions text box.

                if (txtInstructions.Text == "")
                {
                    txtInstructions.Text = "Instructions";
                    throw new Exception("Instructions cannot be empty."); // Exception thrown if the instructions have not been entered.
                }
                else
                {
                    instructions = txtInstructions.Text; // Sets the instructions field to be the contents of the instructions text box.
                }

                DateTime date; // Date field used to store the prescribe date.
                if (dpkrPrescribeDate.SelectedDate == null)
                {
                    throw new Exception("Please select a date from the date picker."); // Throws an exception if the date has not been selected.
                }
                else
                {
                    date = (DateTime)dpkrPrescribeDate.SelectedDate; // Sets the date field to be the date chosen from the date picker.
                }

                Doctor doctor; // doctor field used to store the doctor that the user will select from combobox.
                if (cmbDoctor.SelectedItem == null)
                {
                    throw new Exception("Please select a doctor from the drop down menu."); // Exception thrown if no doctor has been selected.
                }
                else
                {
                    doctor = (Doctor)cmbDoctor.SelectedItem; // Sets the doctor field to be the doctor chosen from the combobox.
                }

                hmsLibrary.prescribeDrug(patient, drugName, dosage, instructions, date, doctor); // Calls the prescribe drug method from the hospital library class.
                MessageBox.Show("Drug prescribed to patient: " + patient.getPatientName(), "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success message.
                this.Close(); // Window closes.
            }
            catch (Exception ex)
            {
                if (txtDrugName.Text == "")
                {
                    txtDrugName.Text = "Drug Name";
                }
                if (txtDosage.Text == "")
                {
                    txtDosage.Text = "Dosage";
                }
                if (txtInstructions.Text == "")
                {
                    txtInstructions.Text = "Instructions";
                }
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message.
            }
        }

        /// <summary>
        /// Sets the drug name text box to be empty if it is clicked on and contains the default name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDrugName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDrugName.Text == "Drug Name")
            {
                txtDrugName.Text = "";
            }
        }

        /// <summary>
        /// Populates the drug name text box with default value if it is not longer 
        /// clicked on and is empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDrugName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDrugName.Text == "")
            {
                txtDrugName.Text = "Drug Name";
            }
        }

        /// <summary>
        /// Sets the dosage text box to be empty if it is clicked on and contains the default name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDosage_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtDosage.Text == "Dosage")
            {
                txtDosage.Text = "";
            }
        }

        /// <summary>
        /// Populates the dosage text box with default value if it is not longer 
        /// clicked on and is empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDosage_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtDosage.Text == "")
            {
                txtDosage.Text = "Dosage";
            }
        }

        /// <summary>
        /// Sets the instructions text box to be empty if it is clicked on and contains the default name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInstructions_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtInstructions.Text == "Instructions")
            {
                txtInstructions.Text = "";
            }
        }

        /// <summary>
        /// Populates the instructions text box with default value if it is not longer 
        /// clicked on and is empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtInstructions_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtInstructions.Text == "")
            {
                txtInstructions.Text = "Instructions";
            }
        }
    }
}
