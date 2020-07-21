using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Description : Window used to administer medication to a patient.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class AdministerMedication : Window
    {
        /// <summary>
        /// private field used to declare a new field of type Hospital Library.
        /// </summary>
        private HospitalLibrary hmsLibrary;
        /// <summary>
        /// Private field used to store the patient that is selected from the combobox.
        /// </summary>
        private Patient patient;
        /// <summary>
        /// private field used to store the drug that is selected from the combobox.
        /// </summary>
        private Drug drug;

        /// <summary>
        /// The constructor of the administer medication window. 
        /// Initialises the hmsLibrary field to the singleton instance of the Hospital Library class.
        /// Populates the patient combo box with the patients stored in the patients list.
        /// Populates the Nurse combo box with the nurses stored in the nursesexceptancillary list.
        /// Sets the drug item sourse to null as this will be set depending on the patient combo boxes selected item.
        /// </summary>
        public AdministerMedication()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance; // Calling singleton instance

            cmbPatient.ItemsSource = hmsLibrary.Patients; // Populating with patients held in hospital library system.
            cmbNurse.ItemsSource = hmsLibrary.NursesExceptAncillary; // Populate with nurses held in hospital library system.
            cmbDrug.ItemsSource = null; // Setting drug combo box to null as this will be sourced when patient is selected.
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

            result = MessageBox.Show("Are you sure you'd like to cancel administering medication?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// This is the method used to adminiser a drug that has been prescribed to a patient. 
        /// Uses a if statements within this method for validation with further validation stored within the business model. 
        /// The reason for repeating some validation is to ensure the errors are caught in the correct order, as youd 
        /// have to wait until all data is entered before validation works. 
        /// Exceptions are thrown if the data entered is invalid, and these are caught using a try catch. 
        /// The error message is displayed in a message box. If successful, a drug will have been administered and 
        /// a success message will appear on screen. The window will also close if successful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdministerMedication_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime date; // To store the date that is selected with the datepicker.
                string time; // To store the time thats entered into the time text box.
                Nurse nurse; // To store the nurse selected in the combobox.

                if (cmbPatient.SelectedItem == null)
                {
                    throw new Exception("Please select a patient from the drop down list."); // Exception if no patient has been selected.
                }
                else
                {
                    patient = (Patient)cmbPatient.SelectedItem; // Assigns selected patient to the patient field.
                }

                if (cmbDrug.SelectedItem == null)
                {
                    throw new Exception("Please select a drug from the drop down list."); // Exception if no drug has been selected.
                }
                else
                {
                    drug = (Drug)cmbDrug.SelectedItem; // Assigns selected drug to the drug field.
                }

                if (dpkrAdministerDate.SelectedDate == null)
                {
                    throw new Exception("Please choose a date from the date picker."); // Exception if no date has been selected.
                }
                else
                {
                     date = (DateTime)dpkrAdministerDate.SelectedDate; // Assigns the selected date to the date field.
                }

                if (txtTime.Text == "")
                {
                    throw new Exception("Please enter the administer time, from 0000 to 2359."); // Exception if the time text box is null.
                }
                else
                {
                    time = txtTime.Text; // Assigns the time field to the time entered in the text box.
                }

                if (cmbNurse.SelectedItem == null)
                {
                    throw new Exception("Please select a nurse from the drop down list."); // Exception if the nurse has not been selected.
                }
                else
                {
                    nurse = (Nurse)cmbNurse.SelectedItem; // Assigns the selected nurse to the nurse field.
                }

                hmsLibrary.administerDrug(patient, drug, date, time, nurse); // Calls the administer drug method in the singleton instance. 
                MessageBox.Show("Drug successfully administered", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success message
                this.Close(); // Closes the window if the drug is successfully administered
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message
            }
        }

        /// <summary>
        /// Method will check which patient has been selected in the patient combo box, then based on this will populate the 
        /// drug combo box with the drugs that have been prescribed to the selected patient.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient = (Patient)cmbPatient.SelectedItem;
            cmbDrug.ItemsSource = patient.TreatmentCard.Prescription.DrugList;
        }
    }
}
