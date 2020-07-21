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
    /// Description : Window used to add a new patient to the system.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class AddPatient : Window
    {
        /// <summary>
        /// private field used to declare a new field of type hospital library.
        /// </summary>
        private HospitalLibrary hmsLibrary;

        /// <summary>
        /// Constructor for the add patient window.
        /// 
        /// Sets the field hmsLibrary and initialises it to the singleton instance of the hospital library class.
        /// 
        /// Populates the consultants combo box with the hospital library consultants list.
        /// </summary>
        public AddPatient()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance;

            cmbConsultants.ItemsSource = hmsLibrary.Consultants;
        }

        /// <summary>
        /// This method is used to add a new patient to the hospital system.
        /// If statements are used in the GUI application to ensure the data fields are not empty
        /// and also to check if the postcode is the correct length. The data validation in the 
        /// business model will also be used here for further validation. 
        /// If an exception is thrown, the system will display an error message with details of the error.
        /// Otherwise, if the patient is successfully added, a success message will appear on screen and the window will close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name; // field used to store the patients name.
                string address; // field used to store the patients address.
                string town; // field used to store the patients town.
                string postcode; // field used to store the patients postcode.
                Doctor consultant = null; // field declared to store the consultant and is initialised to be null. 

                if (txtPatientName.Text == "Full Name")
                {
                    txtPatientName.Text = ""; // Sets the patient name text box to be empty if user has not entered value.
                }
                if (txtPatientAddress.Text == "Address")
                {
                    txtPatientAddress.Text = ""; // Sets the address text box to be empty if the user has not entered value.
                }
                if (txtPatientTown.Text == "Town")
                {
                    txtPatientTown.Text = ""; // Sets the town text box to be empty if the user has not entered value.
                }
                if (txtPatientPostcode.Text == "Postcode")
                {
                    txtPatientPostcode.Text = ""; // Sets the postcode text box to be empty if the user has not entered value.
                }

                if (txtPatientName.Text == "")
                {
                    txtPatientName.Text = "Full Name";
                    throw new Exception("Patient Name cannot be empty"); // Exception thrown if the user has not entered a name.
                }
                else
                {
                    name = txtPatientName.Text; // sets the name field to the contents of the name text box.
                }

                if (txtPatientAddress.Text == "")
                {
                    txtPatientAddress.Text = "Address";
                    throw new Exception("Patient Address cannot be empty"); // Exception thrown if the user has not entered an address.
                }
                else
                {
                    address = txtPatientAddress.Text; // Sets the address field to the contents of the address text box.
                }

                if (txtPatientTown.Text == "")
                {
                    txtPatientTown.Text = "Town";
                    throw new Exception("Patient Town cannot be empty"); // Exception thrown if the user has not entered a town.
                }
                else
                {
                    town = txtPatientTown.Text; // Sets the town field to the contents of the town text box.
                }

                if (txtPatientPostcode.Text == "")
                {
                    txtPatientPostcode.Text = "Postcode";
                    throw new Exception("Patient Postcode cannot be empty"); // Exception thrown if the user has not entered a postcode.
                }
                else if (txtPatientPostcode.Text.Length < 6 || txtPatientPostcode.Text.Length > 8)
                {
                    throw new Exception("Patient Postcode must be between 6 and 8 characters in length."); // Exception thrown if the postcode length is out of range.
                }
                else
                {
                    postcode = txtPatientPostcode.Text; // Sets the postcode field to the contents of the postcode text box.
                }

                if (cmbConsultants.SelectedItem == null)
                {
                    throw new Exception("Please select a consultant from the drop down list."); // Exception thrown if the user has not selected a consultant from the combo box.
                }
                else
                {

                    consultant = (Doctor)cmbConsultants.SelectedItem; // Sets the consultant to the item chosen from the combobox by the user.
                }

                hmsLibrary.addPatient(name, address, town, postcode, consultant); // Calls the add patient method from the hospital library singleton instance.
                MessageBox.Show("Patient Added", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success Message.
                this.Close(); // Window will close.
            }
            catch (Exception ex)
            {
                if (txtPatientName.Text == "")
                {
                    txtPatientName.Text = "Full Name";
                }
                if (txtPatientAddress.Text == "")
                {
                    txtPatientAddress.Text = "Address";
                }
                if (txtPatientTown.Text == "")
                {
                    txtPatientTown.Text = "Town";
                }
                if (txtPatientPostcode.Text == "")
                {
                    txtPatientPostcode.Text = "Postcode";
                }

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message.

            }
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

            result = MessageBox.Show("Are you sure you'd like to cancel adding a new patient?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Empties the patient name text box when clicked and the default value is there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientName.Text == "Full Name")
            {
                txtPatientName.Text = "";
            }
        }

        /// <summary>
        /// Populates the patient name text box when no longer clicked on, only if empty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientName.Text == "")
            {
                txtPatientName.Text = "Full Name";
            }
        }

        /// <summary>
        /// Empties the patient address text box if the default value is there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientAddress_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientAddress.Text == "Address")
            {
                txtPatientAddress.Text = "";
            }
        }

        /// <summary>
        /// Populates the address text box if it is empty and no longer clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientAddress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientAddress.Text == "")
            {
                txtPatientAddress.Text = "Address";
            }
        }

        /// <summary>
        /// Empties the patient town text box if the default value is there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientTown_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientTown.Text == "Town")
            {
                txtPatientTown.Text = "";
            }
        }

        /// <summary>
        /// Populates the town text box if it is empty and no longer clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientTown_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientTown.Text == "")
            {
                txtPatientTown.Text = "Town";
            }
        }

        /// <summary>
        /// Empties the patient postcode text box if the default value is there.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientPostcode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientPostcode.Text == "Postcode")
            {
                txtPatientPostcode.Text = "";
            }
        }

        /// <summary>
        /// Populates the postcode textbox if it is empty and no longer clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPatientPostcode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatientPostcode.Text == "")
            {
                txtPatientPostcode.Text = "Postcode";
            }
        }
    }
}
