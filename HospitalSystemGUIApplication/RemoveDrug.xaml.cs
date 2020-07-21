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
    /// Description : Window used to remove a drug from a patients prescription.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class RemoveDrug : Window
    {
        /// <summary>
        /// private field used to declare a new field of type hospital library.
        /// </summary>
        private HospitalLibrary hmsLibrary;
        /// <summary>
        /// private field used to store the patient that will be selected by the user.
        /// </summary>
        private Patient patient;
        /// <summary>
        /// private field used to store the drug which will be chosen by the user.
        /// </summary>
        private Drug drug;

        /// <summary>
        /// Constructor for the remove drug window.
        /// 
        /// Sets the field hmsLibrary and initialises it to the singleton instance of the hospital library class.
        /// 
        /// Populates the patients combo box with the hospital library patients list.
        /// Initialises the drug combobox and sets to null.
        /// </summary>
        public RemoveDrug()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance;

            cmbPatient.ItemsSource = hmsLibrary.Patients;
            cmbDrug.ItemsSource = null;
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

            result = MessageBox.Show("Are you sure you'd like to cancel removing a drug?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// This method is used to populate the drug combo box.
        /// The drug comboboxes source will be based on the patient the user selects.
        /// When a patient is selected, the drugs for that patient are loaded into the drug combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient = (Patient)cmbPatient.SelectedItem;
            cmbDrug.ItemsSource = patient.TreatmentCard.Prescription.DrugList;
        }

        /// <summary>
        /// This method is used to remove a drug from a patients prescription.
        /// It uses if statements for validation to check the user has selected a patient 
        /// and a drug from the combo box.
        /// Exceptions are thrown, and catched, if no patient or drug has been selected.
        /// An error message with details of the error is displayed if drug is not removed.
        /// Success message shown if the drug has been removed. Window will also close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveDrug_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbPatient.SelectedItem == null)
                {
                    throw new Exception("Please select a patient from the drop down list."); // Throws exception if no patient has been selected.
                }
                else
                {
                    patient = (Patient)cmbPatient.SelectedItem; // Sets the patient field to the patient selected in the combobox.
                }

                if (cmbDrug.SelectedItem == null)
                {
                    throw new Exception("Please select a drug from the drop down list."); // Exception thrown if the drug has not been chosen.
                }
                else
                {
                    drug = (Drug)cmbDrug.SelectedItem; // Sets the drug field to the drug selected in the combobox.
                }

                hmsLibrary.removeDrug(patient, drug); // Calls the remove drug method in the hospital library class.
                MessageBox.Show("Drug removed from prescription", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success message
                this.Close(); // Window closes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message
            }
        }
    }
}
