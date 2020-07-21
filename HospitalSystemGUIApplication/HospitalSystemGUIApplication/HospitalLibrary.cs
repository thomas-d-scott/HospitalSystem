using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to allow the GUI to access various aspects of the hospital system
    /// Date Completed : 21/05/2018
    /// </summary>
    /// 
    [Serializable]
    public class HospitalLibrary
    {
        #region Singleton Instance - COMPLETE

        /// <summary>
        /// Singleton object declared
        /// </summary>
        private static HospitalLibrary theLib;
        /// <summary>
        /// Instance property returns the singleton instance
        /// Calls the read file method. Will read in if file exists or populate if not.
        /// </summary>
        public static HospitalLibrary Instance
        {
            get
            {
                if (theLib == null)
                {
                    theLib = new HospitalLibrary();
                    theLib.readFile();
                }
                return theLib;
            }
        }

        #endregion

        #region Fields and List Properties - COMPLETE

        /// <summary>
        /// private field used to store the staff members list
        /// </summary>
        private List<Staff> staffMembers;
        /// <summary>
        /// private field used to store the nurses list
        /// </summary>
        private List<Nurse> nurses;
        /// <summary>
        /// private field used to store the nurse except ancillary list
        /// </summary>
        private List<Nurse> nursesExceptAncillary;
        /// <summary>
        /// private field used to store the doctors list
        /// </summary>
        private List<Doctor> doctors;
        /// <summary>
        /// private field used to store the consultants list
        /// </summary>
        private List<Doctor> consultants;
        /// <summary>
        /// private field used to store the patients list
        /// </summary>
        private List<Patient> patients;

        /// <summary>
        /// property used to return a reference to the list patients
        /// </summary>
        public List<Patient> Patients { get { return patients; } }
        /// <summary>
        /// property used to return a reference to the list consultants
        /// </summary>
        public List<Doctor> Consultants { get { return consultants; } }
        /// <summary>
        /// property used to return a reference to the list doctors
        /// </summary>
        public List<Doctor> Doctors { get { return doctors; } }
        /// <summary>
        /// property used to return a reference to the list nurses
        /// </summary>
        public List<Nurse> Nurses { get { return nurses; } }
        /// <summary>
        /// Property used to return a reference to the list nurses not ancillary
        /// </summary>
        public List<Nurse> NursesExceptAncillary { get { return nursesExceptAncillary; } }

        /// <summary>
        /// Constructor used to initialise all of the lists in the hospital library class.
        /// </summary>
        public HospitalLibrary()
        {
            staffMembers = new List<Staff>();
            nurses = new List<Nurse>();
            nursesExceptAncillary = new List<Nurse>();
            consultants = new List<Doctor>();
            doctors = new List<Doctor>();
            patients = new List<Patient>();
        }

        #endregion

        #region Add Patient - COMPLETE

        /// <summary>
        /// Method used to add a new patient to the system and patients list
        /// </summary>
        /// <param name="patientName">Patients name</param>
        /// <param name="patientAddress">Patients address</param>
        /// <param name="patientTown">Patients town</param>
        /// <param name="patientPostcode">Patients postcode</param>
        /// <param name="consultant">Consultant assigned to patient</param>
        public void addPatient(string patientName, string patientAddress, string patientTown, string patientPostcode, Doctor consultant)
        {
            patients.Add(new Patient(patients.Count + 1, patientName, patientAddress, patientTown, patientPostcode, consultant));
        }

        #endregion

        #region Remove Patient - COMPLETE

        /// <summary>
        /// method used to remove a patient
        /// </summary>
        /// <param name="patient">the patient to be removed from the patients list</param>
        public void removePatient(Patient patient)
        {
            patients.Remove(patient);
        }

        #endregion

        #region Add Doctor - COMPLETE

        /// <summary>
        /// Method used to add a new doctor to the system
        /// Will filter into different lists depending on the type of doctor.
        /// </summary>
        /// <param name="staffName">The doctors name</param>
        /// <param name="staffAddress">The doctors address</param>
        /// <param name="staffTown">The doctors town</param>
        /// <param name="staffPostcode">The doctors postcode</param>
        /// <param name="qualificationDate">The doctors qualification date</param>
        /// <param name="post">The doctors post</param>
        public void addDoctor(string staffName, string staffAddress, string staffTown, string staffPostcode, DateTime qualificationDate, string post)
        {
            if (post == "Consultant")
            {
                staffMembers.Add(new Doctor(staffMembers.Count + 1, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
                doctors.Add(new Doctor(staffMembers.Count, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
                consultants.Add(new Doctor(staffMembers.Count, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
            }
            else
            {
                staffMembers.Add(new Doctor(staffMembers.Count + 1, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
                doctors.Add(new Doctor(staffMembers.Count, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
            }
        }

        #endregion

        #region Add Nurse - COMPLETE

        /// <summary>
        /// Method used to add a new nurse to the system
        /// Will filter into different lists dependent on the nurses post
        /// </summary>
        /// <param name="staffName">The nurses name</param>
        /// <param name="staffAddress">The nurses address</param>
        /// <param name="staffTown">The nurses town</param>
        /// <param name="staffPostcode">The nurses postcode</param>
        /// <param name="qualificationDate">The nurses qualification date</param>
        /// <param name="post">The nurses post</param>
        public void addNurse(string staffName, string staffAddress, string staffTown, string staffPostcode, DateTime qualificationDate, string post)
        {
            staffMembers.Add(new Nurse(staffMembers.Count + 1, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
            nurses.Add(new Nurse(staffMembers.Count, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));

            if (post == "Registered" || post == "Charge")
            {
                nursesExceptAncillary.Add(new Nurse(staffMembers.Count, staffName, staffAddress, staffTown, staffPostcode, qualificationDate, post));
            }
        }

        #endregion

        #region Get Patients - COMPLETE

        /// <summary>
        /// Method used to get all the patients in the system
        /// </summary>
        /// <returns>the patients held in the patients list</returns>
        public string getPatients()
        {
            string strPatients = "";
            foreach (Patient patient in patients)
            {
                strPatients = strPatients + $"NHS Number: {patient.getNhsNumber()} \nName: {patient.getPatientName()} \nAddress: {patient.getPatientAddress()}, {patient.getPatientTown()}, {patient.getPatientPostcode()} \nConsultant: {patient.getConsultant()}" + "\n\r";
            }
            return strPatients;
        }

        #endregion

        #region Search Patients - COMPLETE 

        /// <summary>
        /// This method takes in a nhs number as a parameter
        /// Then searches through each patient in the list to check for a match.
        /// If a match is found the patient details are returned.
        /// </summary>
        /// <param name="nhsNumber">The unique number for each patient in the system</param>
        /// <returns>The patients details</returns>
        public string searchPatients(int nhsNumber)
        {
            string strPatients = "";
            foreach (Patient patient in patients)
            {
                if (nhsNumber == patient.getNhsNumber())
                {
                    strPatients = strPatients + $"NHS Number: {patient.getNhsNumber()} \nName: {patient.getPatientName()} \nAddress: {patient.getPatientAddress()}, {patient.getPatientTown()}, {patient.getPatientPostcode()} \nConsultant: {patient.getConsultant()}" + "\n\r";
                }
            }
            return strPatients;
        }

        /// <summary>
        /// This method takes in a nhs number as a parameter
        /// Then searches through each patient in the list to check for a match.
        /// If a match is found the patient treatment card is returned.
        /// </summary>
        /// <param name="nhsNumber">The unique number for each patient in the system</param>
        /// <returns>The patients treatment card</returns>
        public string searchPatientsTC(int nhsNumber)
        {
            string val = "";
            foreach (Patient patient in patients)
            {
                if (nhsNumber == patient.getNhsNumber())
                {
                    val = val + patient.getTreatmentCard();
                }
            }
            return val;
        }

        /// <summary>
        /// This method takes in a nhs number as a parameter
        /// Then searches through each patient in the list to check for a match.
        /// If a match is found the patient prescription is returned.
        /// </summary>
        /// <param name="nhsNumber">The unique number for each patient in the system</param>
        /// <returns>The patients prescription</returns>
        public string searchPatientsPrescription(int nhsNumber)
        {
            string val = "";
            foreach (Patient patient in patients)
            {
                if (nhsNumber == patient.getNhsNumber())
                {
                    val = val + patient.getPrescription();
                }
            }
            return val;
        }

        #endregion

        #region Get All Staff - COMPLETE

        /// <summary>
        /// method used to get all the staff members
        /// </summary>
        /// <returns>the staff members held in the staffMembers list</returns>
        public string getAllStaff()
        {
            string strStaff = "";
            foreach (Staff staffmember in staffMembers)
            {
                strStaff = strStaff + $"Staff Number: {staffmember.getStaffNumber()} \nName: {staffmember.getStaffName()} \nAddress: {staffmember.getStaffAddress()}, {staffmember.getStaffTown()}, {staffmember.getStaffPostcode()} \nQualification Date: {staffmember.getQualificationDate()}" + "\n\r";
            }
            return strStaff;
        }
        #endregion

        #region Search Staff Member - COMPLETE

        /// <summary>
        /// This method takes in a staff number as a parameter
        /// Then searches through each staff member in the list to check for a match.
        /// If a match is found the staff members details are returned.
        /// </summary>
        /// <param name="staffNo">The unique number for each staff member in the system</param>
        /// <returns>The staff members details</returns>
        public string searchStaffMember(int staffNo)
        {
            string strStaff = "";
            foreach (Staff staffmember in staffMembers)
            {
                if (staffmember.getStaffNumber() == staffNo)
                {
                    strStaff = strStaff + $"Staff Number: {staffmember.getStaffNumber()} \nName: {staffmember.getStaffName()} \nAddress: {staffmember.getStaffAddress()}, {staffmember.getStaffTown()}, {staffmember.getStaffPostcode()} \nQualification Date: {staffmember.getQualificationDate()}" + "\n\r";
                }
            }
            return strStaff;
        }

        #endregion

        #region Get Nurses - COMPLETE

        /// <summary>
        /// method used to get all nurses
        /// </summary>
        /// <returns>the nurses held in the nurses list</returns>
        public string getNurses()
        {
            string strNurses = "";
            foreach (Nurse nurse in nurses)
            {
                strNurses = strNurses + $"Staff Number: {nurse.getStaffNumber()} \nName: {nurse.getStaffName()} \nAddress: {nurse.getStaffAddress()}, {nurse.getStaffTown()}, {nurse.getStaffPostcode()} \nQualification Date: {nurse.getQualificationDate()} \nPost: {nurse.getPost()} \n\r";
            }
            return strNurses;
        }

        #endregion

        #region Get Doctors - COMPLETE

        /// <summary>
        /// Method used to get all doctors
        /// </summary>
        /// <returns>the doctors held in the doctors list</returns>
        public string getDoctors()
        {
            string strDoctors = "";
            foreach (Doctor doctor in doctors)
            {
                strDoctors = strDoctors + $"Staff Number: {doctor.getStaffNumber()} \nName: {doctor.getStaffName()} \nAddress: {doctor.getStaffAddress()}, {doctor.getStaffTown()}, {doctor.getStaffPostcode()} \nQualification Date: {doctor.getQualificationDate()} \nPost: {doctor.getPost()} \n\r";
            }
            return strDoctors;
        }

        #endregion

        #region Prescribe Drug - COMPLETE

        /// <summary>
        /// Method used to prescribe a new drug.
        /// </summary>
        /// <param name="patient">The patient who the drug will be prescribed to</param>
        /// <param name="drugName">Name of the drug</param>
        /// <param name="dosage">The dosage to be taken</param>
        /// <param name="instructions">The instructions of the drug</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="doctor">The doctor who prescribed the drug</param>
        public void prescribeDrug(Patient patient, string drugName, double dosage, string instructions, DateTime prescribeDate, Doctor doctor)
        {
            patient.prescribeDrug(drugName, dosage, instructions, prescribeDate, doctor);
        }

        #endregion

        #region Administer Drug - COMPLETE

        /// <summary>
        /// Method used to administer a drug.
        /// </summary>
        /// <param name="patient">The patient who the drug will be administered to</param>
        /// <param name="drug">The drug being administered</param>
        /// <param name="administerDate">The date the drug was administered</param>
        /// <param name="administerTime">The time the drug was administered</param>
        /// <param name="nurse">The nurse who administered the drug</param>
        public void administerDrug(Patient patient, Drug drug, DateTime administerDate, string administerTime, Nurse nurse)
        {
            patient.administerDrug(drug, administerDate, administerTime, nurse);
        }

        #endregion

        #region Remove Drug - COMPLETE

        /// <summary>
        /// Method used to remove a drug from the patients prescription.
        /// </summary>
        /// <param name="patient">Patient who will have prescription altered</param>
        /// <param name="drug">The drug to be removed.</param>
        public void removeDrug(Patient patient, Drug drug)
        {
            patient.removeDrug(drug);
        }

        #endregion

        #region Record Measurement - COMPLETE

        /// <summary>
        /// Method used to record a new measurement.
        /// </summary>
        /// <param name="patient">The patient who will have a measurement recorded</param>
        /// <param name="date">Date the measurement was taken</param>
        /// <param name="time">The time the measurement was taken</param>
        /// <param name="bloodPressure">Patients blood pressure</param>
        /// <param name="temperature">Patients temperature</param>
        /// <param name="nurse">The nurse who recorded the measurement</param>
        public void recordMeasurements(Patient patient, DateTime date, string time, int bloodPressureSystolic, int bloodPressureDiastolic, double temperature, Nurse nurse)
        {
            patient.recordMeasurement(date, time, bloodPressureSystolic, bloodPressureDiastolic, temperature, nurse);
        }

        #endregion

        #region Get Treatment Card - COMPLETE

        /// <summary>
        /// Method used to get the patients treatment card
        /// </summary>
        /// <param name="patient">The patients whose treatment card to get.</param>
        /// <returns>Patients treatment card</returns>
        public string getTreatmentCard(Patient patient)
        {
            return patient.getTreatmentCard();
        }

        #endregion

        #region Get Prescription - COMPLETE

        /// <summary>
        /// Method used to get the patients prescription
        /// </summary>
        /// <param name="patient">The patients whose prescription to retrieve</param>
        /// <returns>The patients prescription</returns>
        public string getPrescription(Patient patient)
        {
            return patient.getPrescription();
        }

        #endregion

        #region Populate - COMPLETE

        /// <summary>
        /// Populates the system with staff members as the users wont be able to add these in the prototype.
        /// </summary>
        public void populate()
        {
            addDoctor("Fred Flintstone", "123 Oneway Street", "Overtown", "ML1 8TJ", Convert.ToDateTime("12/05/1998"), "Consultant");
            addNurse("Wilma Flintstone", "123 Oneway Street", "Overtown", "ML1 8TJ", Convert.ToDateTime("12/05/1998"), "Charge");
        }

        #endregion

        #region Read File - COMPLETE

        /// <summary>
        /// this will read from the datafile if it exists or else it will populate the library.
        /// </summary>
        public void readFile()
        {
            if (File.Exists("DataFile.dat"))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream newStream = new FileStream("DataFile.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
                theLib = (HospitalLibrary)formatter.Deserialize(newStream);
                newStream.Close();
            }
            else
            {
                populate();
            }
        }

        #endregion

        #region Write File - COMPLETE

        /// <summary>
        /// This will create a new datafile and add the contents of the library to it.
        /// </summary>
        public void writeFile()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream newStream = new FileStream("DataFile.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(newStream, theLib);
            newStream.Close();
        }

        #endregion
    }
}
