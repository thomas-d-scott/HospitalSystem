using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalSystemConsoleApplication;

namespace HospitalSystemGUIApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : The system main window which will be the main hub for the user.
    /// Date Completed : 21/05/2018
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// private field used to declare the field hmsLibrary as type Hospital Library.
        /// </summary>
        private HospitalLibrary hmsLibrary;

        /// <summary>
        /// Main window constructor used to set hms library to the Hospital Library singleton instance.
        /// Populates the patients comboboxes as the patients stored in the hospital library.
        /// 
        /// Disables the main tabs content to prevent unauthorised access.
        /// Message box shown to user before app opens to inform them on how to get sign in information.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            hmsLibrary = HospitalLibrary.Instance;

            cmbPatientTC.ItemsSource = hmsLibrary.Patients; // Sets the patient combobox source to be the patients list.
            cmbPatientsPrescription.ItemsSource = hmsLibrary.Patients; // Sets patient combobox source to the patients list.

            tabPatientsContent.IsEnabled = false;
            tabStaffContent.IsEnabled = false;
            tabPrescriptionContent.IsEnabled = false;
            tabTCContent.IsEnabled = false;

            MessageBox.Show("To use this prototype application, you will need to sign in. Check the Login Information Help on the Help Page tab for more information. Thanks.", "Before you start...", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        /// <summary>
        /// Displays the patients in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewAllPatients_Click(object sender, RoutedEventArgs e)
        {
            txtPatient.Text = hmsLibrary.getPatients();
        }

        /// <summary>
        /// Displays all the staff members in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewAllStaff_Click(object sender, RoutedEventArgs e)
        {
            txtStaff.Text = hmsLibrary.getAllStaff();
        }

        /// <summary>
        /// Displays the doctors in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewDoctors_Click(object sender, RoutedEventArgs e)
        {
            txtStaff.Text = hmsLibrary.getDoctors();
        }

        /// <summary>
        /// Displays the nurses in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewNurses_Click(object sender, RoutedEventArgs e)
        {
            txtStaff.Text = hmsLibrary.getNurses();
        }

        /// <summary>
        /// User will select a patient from drop down menu.
        /// The system will get that patients treatment card and send it to display.
        /// If user hasn't selected a patient, an error message will appear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTreatmentCard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = (Patient)cmbPatientTC.SelectedItem;

                txtTreatmentCard.Text = hmsLibrary.getTreatmentCard(patient);
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a patient from the drop down menu ");
            }
        }

        /// <summary>
        /// User will select a patient from drop down menu.
        /// The system will get that patients prescription and send it to display.
        /// If user hasn't selected a patient, an error message will appear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewPrescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Patient patient = (Patient)cmbPatientsPrescription.SelectedItem;

                txtPrescription.Text = hmsLibrary.getPrescription(patient);
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a patient from the drop down menu");
            }
        }

        /// <summary>
        /// Opens the add patient window as a modal dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.ShowDialog();
        }

        /// <summary>
        /// When the window is closing the data held in the system will be written to a datafile.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hmsLibrary.writeFile();
        }

        /// <summary>
        /// Opens the remove patient window as a modal dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemovePatient_Click(object sender, RoutedEventArgs e)
        {
            RemovePatient removePatient = new RemovePatient();
            removePatient.ShowDialog();
        }

        /// <summary>
        /// Opens the prescribe drug window as a modal dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrescribeDrug_Click(object sender, RoutedEventArgs e)
        {
            PrescribeDrug prescribeDrug = new PrescribeDrug();
            prescribeDrug.ShowDialog();
        }

        /// <summary>
        /// Opens the remove drug window as a modal dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveDrug_Click(object sender, RoutedEventArgs e)
        {
            RemoveDrug removeDrug = new RemoveDrug();
            removeDrug.ShowDialog();
        }

        /// <summary>
        /// Opens the administer medication window as a modal dialog.                   
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdministerMedication_Click(object sender, RoutedEventArgs e)
        {
            AdministerMedication administerMedication = new AdministerMedication();
            administerMedication.ShowDialog();
        }

        /// <summary>
        /// Opens the record measurement window as a modal dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecordMeasurement_Click(object sender, RoutedEventArgs e)
        {
            RecordMeasurement recordMeasurement = new RecordMeasurement();
            recordMeasurement.ShowDialog();
        }

        /// <summary>
        /// When the user clicks the logout button, the window will reset back to its original state.
        /// The tabs are locked except from the help tab.
        /// Text boxes and password boxes are cleared and the search box text is reset to its default value.
        /// The data file will also be written to when a user logs out.
        /// A success message will appear when the user has logged out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            tabPatientsContent.IsEnabled = false;
            tabStaffContent.IsEnabled = false;
            tabPrescriptionContent.IsEnabled = false;
            tabTCContent.IsEnabled = false;

            txtUsername.Clear();
            txtPassword.Clear();
            txtPatient.Clear();
            txtPrescription.Clear();
            txtTreatmentCard.Clear();
            txtSearchPatient.Text = "Click to search for a patient by NHS Number";
            txtSearchStaffMember.Text = "Click to search for a Staff Member by Staff Number";
            txtSearchPatientTC.Text = "Click to search for a patient by NHS Number";
            txtSearchPatientPrescription.Text = "Click to search for a patient by NHS Number";

            hmsLibrary.writeFile();

            MessageBox.Show("Logout Successful!");

        }

        /// <summary>
        /// In order to represent a basic login system, some users and passwords have been created,
        /// so when a user enters a user name and password it will check if those are valid and unlock 
        /// the appropriate content on the page. 
        /// It will either result in a success message if details are valid or an error message if details are invalid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string NurseUsername = "nurse"; // nurse username
            string Nursepassword = "nurse1"; // nurse password
            string AncillaryNurseUsername = "ancillarynurse"; // ancillary nurse username
            string AncillaryNursepassword = "ancillarynurse1"; // ancillary nurse password
            string DoctorUsername = "doctor"; // doctor username
            string Doctorpassword = "doctor1"; // doctor password


            if (txtUsername.Text == NurseUsername && txtPassword.Password == Nursepassword)
            {
                tabPatientsContent.IsEnabled = true;
                tabStaffContent.IsEnabled = true;
                tabTCContent.IsEnabled = true;
                btnRemovePatient.IsEnabled = false;
                btnAdministerMedication.IsEnabled = true;
                btnRecordMeasurement.IsEnabled = true;

                MessageBox.Show("Login Success");
            }
            else if (txtUsername.Text == DoctorUsername && txtPassword.Password == Doctorpassword)
            {
                tabPatientsContent.IsEnabled = true;
                tabStaffContent.IsEnabled = true;
                tabTCContent.IsEnabled = true;
                tabPrescriptionContent.IsEnabled = true;
                btnRemovePatient.IsEnabled = true;
                btnAdministerMedication.IsEnabled = false;
                btnRecordMeasurement.IsEnabled = false;

                MessageBox.Show("Login Success");
            }
            else if (txtUsername.Text == AncillaryNurseUsername && txtPassword.Password == AncillaryNursepassword)
            {
                tabPatientsContent.IsEnabled = true;
                tabStaffContent.IsEnabled = true;
                tabTCContent.IsEnabled = true;
                btnAdministerMedication.IsEnabled = false;
                btnRemovePatient.IsEnabled = false;
                btnRecordMeasurement.IsEnabled = true;

                MessageBox.Show("Login Success");
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                txtUsername.Clear();
                txtPassword.Clear();
            }
        }

        /// <summary>
        /// If the search text box is clicked and has default value, it will be cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatient_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatient.Text == "Click to search for a patient by NHS Number")
            {
                txtSearchPatient.Text = "";
            }
        }

        /// <summary>
        /// If search text box is no longer clicked and is empty, the default value will be placed inside.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatient_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatient.Text == "")
            {
                txtSearchPatient.Text = "Click to search for a patient by NHS Number";
            }
        }

        /// <summary>
        /// This method calls the search patients method in the hospital library,
        /// passing in the number the user entered into the search box as the parameter.
        /// If the value entered is not numeric, an error message pops up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPatient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nhsNo = Convert.ToInt32(txtSearchPatient.Text);
                txtPatient.Text = hmsLibrary.searchPatients(nhsNo);
            }
            catch (Exception)
            {
                MessageBox.Show("Must only be numerical values.");
            }
        }

        /// <summary>
        /// If the search text box is clicked and has default value, it will be cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatientTC_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatientTC.Text == "Click to search for a patient by NHS Number")
            {
                txtSearchPatientTC.Text = "";
            }
        }

        /// <summary>
        /// If search text box is no longer clicked and is empty, the default value will be placed inside.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatientTC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatientTC.Text == "")
            {
                txtSearchPatientTC.Text = "Click to search for a patient by NHS Number";
            }
        }

        /// <summary>
        /// This method calls the search patients method in the hospital library,
        /// passing in the number the user entered into the search box as the parameter.
        /// If the value entered is not numeric, an error message pops up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPatientTC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nhsNo = Convert.ToInt32(txtSearchPatientTC.Text);
                txtTreatmentCard.Text = hmsLibrary.searchPatientsTC(nhsNo);
            }
            catch (Exception)
            {
                MessageBox.Show("Must only be numerical values.");
            }
        }

        /// <summary>
        /// Clears the patient tabs text box and sets the search button text to a default value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearPatient_Click(object sender, RoutedEventArgs e)
        {
            txtPatient.Clear();
            txtSearchPatient.Text = "Click to search for a patient by NHS Number";
        }

        /// <summary>
        /// Clears the Treatment Card tabs text box and sets the search button text to a default value.
        /// Also sets the selected item in the combobox to null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearTC_Click(object sender, RoutedEventArgs e)
        {
            txtTreatmentCard.Clear();
            cmbPatientTC.SelectedItem = null;
            txtSearchPatientTC.Text = "Click to search for a patient by NHS Number";
        }

        /// <summary>
        /// This method calls the search patients method in the hospital library,
        /// passing in the number the user entered into the search box as the parameter.
        /// If the value entered is not numeric, an error message pops up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchPatientPrescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int nhsNo = Convert.ToInt32(txtSearchPatientPrescription.Text);
                txtPrescription.Text = hmsLibrary.searchPatientsPrescription(nhsNo);
            }
            catch (Exception)
            {
                MessageBox.Show("Must only be numerical values.");
            }
        }

        /// <summary>
        /// Clears the prescription tabs text box and sets the search button text to a default value.
        /// Also sets the selected item in the combobox to null.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearPatientPrescription_Click(object sender, RoutedEventArgs e)
        {
            txtPrescription.Clear();
            cmbPatientsPrescription.SelectedItem = null;
            txtSearchPatientPrescription.Text = "Click to search for a patient by NHS Number";
        }

        /// <summary>
        /// If the search text box is clicked and has default value, it will be cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatientPrescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatientPrescription.Text == "Click to search for a patient by NHS Number")
            {
                txtSearchPatientPrescription.Text = "";
            }
        }

        /// <summary>
        /// If search text box is no longer clicked and is empty, the default value will be placed inside.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchPatientPrescription_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchPatientPrescription.Text == "")
            {
                txtSearchPatientPrescription.Text = "Click to search for a patient by NHS Number";
            }
        }

        /// <summary>
        /// Clears the staff member tabs text box and sets the search button text to a default value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearStaffMember_Click(object sender, RoutedEventArgs e)
        {
            txtStaff.Clear();
            txtSearchStaffMember.Text = "Click to search for a Staff Member by Staff Number";
        }

        /// <summary>
        /// If the search text box is clicked and has default value, it will be cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchStaffMember_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchStaffMember.Text == "Click to search for a Staff Member by Staff Number")
            {
                txtSearchStaffMember.Text = "";
            }
        }

        /// <summary>
        /// If search text box is no longer clicked and is empty, the default value will be placed inside.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchStaffMember_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearchStaffMember.Text == "")
            {
                txtSearchStaffMember.Text = "Click to search for a Staff Member by Staff Number";
            }
        }

        /// <summary>
        /// This method calls the search staff member method in the hospital library,
        /// passing in the number the user entered into the search box as the parameter.
        /// If the value entered is not numeric, an error message pops up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearchStaffMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int staffNo = Convert.ToInt32(txtSearchStaffMember.Text);
                txtStaff.Text = hmsLibrary.searchStaffMember(staffNo);
            }
            catch (Exception)
            {
                MessageBox.Show("Must only be numerical values.");
            }
        }

        /// <summary>
        /// Loads in the content of the text file and displays in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatientHelp_Click(object sender, RoutedEventArgs e)
        {
            
            using (StreamReader sr = new StreamReader("PatientTabHelp.txt"))
            {
                txtHelpDisplay.Text = sr.ReadToEnd();
                txtHelpDisplay.ScrollToHome();
                sr.Close();
            }
        }

        /// <summary>
        /// Clears the help tab text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearHelpDisplay_Click_1(object sender, RoutedEventArgs e)
        {
            txtHelpDisplay.Clear();
        }

        /// <summary>
        /// Loads in the content of the text file and displays in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginInformation_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("LoginInformation.txt"))
            {
                txtHelpDisplay.Text = sr.ReadToEnd();
                txtHelpDisplay.ScrollToHome();
                sr.Close();
            }
        }

        /// <summary>
        /// Loads in the content of the text file and displays in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStaffMemberHelp_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("StaffMemberTabHelp.txt"))
            {
                txtHelpDisplay.Text = sr.ReadToEnd();
                txtHelpDisplay.ScrollToHome();
                sr.Close();
            }
        }

        /// <summary>
        /// Loads in the content of the text file and displays in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTreatmentCardHelp_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("TreatmentCardTabHelp.txt"))
            {
                txtHelpDisplay.Text = sr.ReadToEnd();
                txtHelpDisplay.ScrollToHome();
                sr.Close();
            }
        }

        /// <summary>
        /// Loads in the content of the text file and displays in the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrescriptionHelp_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader("PrescriptionTabHelp.txt"))
            {
                txtHelpDisplay.Text = sr.ReadToEnd();
                txtHelpDisplay.ScrollToHome();
                sr.Close();
            }
        }

        /// <summary>
        /// This button is used to close the application.
        /// Before this happens a confirmation box appears.
        /// If the user confirms, the application will close, otherwise it will not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("You are about to close the Hospital System Application. \nAre you sure this is what you want?", "Close the program?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
