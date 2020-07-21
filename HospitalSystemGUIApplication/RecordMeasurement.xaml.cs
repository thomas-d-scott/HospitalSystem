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
    /// Description : Window used to record a new measurement in the system
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class RecordMeasurement : Window
    {
        /// <summary>
        /// private field used to declare a new field of type hospital library.
        /// </summary>
        private HospitalLibrary hmsLibrary;

        /// <summary>
        /// Constructor for the record measurement window.
        /// 
        /// Sets the field hmsLibrary and initialises it to the singleton instance of the hospital library class.
        /// 
        /// Populates the patients combo box with the hospital library patients list.
        /// Populates the nurses combo box with the hospital library nurses list.
        /// </summary>
        public RecordMeasurement()
        {
            InitializeComponent();

            hmsLibrary = HospitalLibrary.Instance;

            cmbPatient.ItemsSource = hmsLibrary.Patients;
            cmbNurse.ItemsSource = hmsLibrary.Nurses;
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

            result = MessageBox.Show("Are you sure you'd like to cancel recording a new measurement?", "Closing window", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// This method is used to add a measurement to a patients treatment card.
        /// It uses if statements for validation as well as the data validation held in the business model.
        /// If the measurement has been successfully recorded, a success message appears and the window closes.
        /// If an error is encountered, then an error message appears with details of the error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordMeasurement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient; // Field to store the patient that the user selects.
                DateTime date; // field used to store the date the user will choose.
                string time; // Field to store the time the user enters.
                int bloodPressureSystolic; // field to store the blood pressure.
                int bloodPressureDiastolic; // field to store the blood pressure.
                double temperature; // field to store the temperature entered by the user.
                Nurse nurse; // field to store the nurse that records the measurement.

                if (cmbPatient.SelectedItem == null)
                {
                    throw new Exception("Please select a patient from the drop down list."); // Exception thrown if the patient has not been selected.
                }
                else
                {
                    patient = (Patient)cmbPatient.SelectedItem; // Sets the patient field to the patient selected from the combo box.
                }

                if (dpkrMeasurementDate.SelectedDate == null)
                {
                    throw new Exception("Please select a date from the date picker."); // Throws exception if the date has not been selected.
                }
                else
                {
                    date = (DateTime)dpkrMeasurementDate.SelectedDate; // Sets the date field to the date chosen from the date picker.
                }

                if (txtTime.Text == "")
                {
                    throw new Exception("Please enter a time."); // Throws an exception if the time has not been entered.
                }
                else
                {
                    time = txtTime.Text; // Sets the time field to the time entered in the text box.
                }

                if (txtBloodPressureSystolic.Text == "")
                {
                    throw new Exception("Please enter a systolic blood pressure."); // Throws an exception if the systolic blood pressure has not been entered.
                }
                else
                {
                    bloodPressureSystolic = Convert.ToInt32(txtBloodPressureSystolic.Text); // Sets the systolic blood pressure field to the data in the text box.
                }

                if (txtBloodPressureDiastolic.Text == "")
                {
                    throw new Exception("Please enter a diastolic blood pressure."); // Exception thrown if diastolic blood pressure has not been entered.
                }
                else
                {
                    bloodPressureDiastolic = Convert.ToInt32(txtBloodPressureDiastolic.Text); // Sets the diastolic blood pressure field as the value entered in text box.
                }

                if (txtTemperature.Text == "")
                {
                    throw new Exception("Please enter a temperature."); // Throws exception if the temperature has not been entered.
                }
                else
                {
                    temperature = Convert.ToDouble(txtTemperature.Text); // Sets the temperature field to the value in the temperature text box.
                }

                if (cmbNurse.SelectedItem == null)
                {
                    throw new Exception("Please select a nurse from the drop down list."); // Exception thrown if a nurse has not been selected.
                }
                else
                {
                    nurse = (Nurse)cmbNurse.SelectedItem; // Sets the nurse field to the nurse selected in the combo box.
                }

                hmsLibrary.recordMeasurements(patient, date, time, bloodPressureSystolic, bloodPressureDiastolic, temperature, nurse); // Calls record measurement method.
                MessageBox.Show("Measurement recorded", "Success", MessageBoxButton.OK, MessageBoxImage.Information); // Success message
                this.Close(); // Window closes
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); // Error message
            }
        }
    }
}
