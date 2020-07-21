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
    /// Description : Window used to remove a patient from the system.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class RemovePatient : Window
    {
        /// <summary>
        /// private field used to declare a new field of type hospital library.
        /// </summary>
        private HospitalLibrary hmsLibrary;

        /// <summary>
        /// Constructor for the remove patient window.
        /// 
        /// Sets the field hmsLibrary and initialises it to the singleton instance of the hospital library class.
        /// 
        /// Populates the patients combo box with the hospital library patients list.
        /// </summary>
        public RemovePatient()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance;

            cmbPatient.ItemsSource = hmsLibrary.Patients;
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

            result = MessageBox.Show("Are you sure you'd like to cancel removing a patient?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// This method is used to remove a patient from the hospital system,
        /// It will use if statements to ensure a patient is selected in the combo box.
        /// If not an error message will pop on screen.
        /// If the removal of a patient is successful then a success message is shown and the
        /// window will close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemovePatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient; // field used to store the patient the user selects from the combobox.

                if (cmbPatient.SelectedItem == null)
                {
                    throw new Exception("Please select a patient from the drop down list."); // Exception thrown if no patient has been selected.
                }
                else
                {
                    patient = (Patient)cmbPatient.SelectedItem; // Sets the patient field to the patient selected in the combobox.
                }

                hmsLibrary.removePatient(patient); // Calls the remove patient method in the hospital library class.
                MessageBox.Show("Patient removed", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success message.
                this.Close(); // Closes the window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message
            }
        }
    }
}
