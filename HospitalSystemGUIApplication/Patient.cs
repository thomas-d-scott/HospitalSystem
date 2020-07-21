
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HospitalSystemGUIApplication;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to create a new Patient.
    /// Date Completed : 21/05/2018
    /// </summary>
    /// 
    [Serializable]
    public class Patient
    {
        /// <summary>
        /// private field used to store the nhs number
        /// </summary>
        private int nhsNumber;
        /// <summary>
        /// private field used to store the patients name
        /// </summary>
        private string patientName;
        /// <summary>
        /// private field used to store the patients address
        /// </summary>
        private string patientAddress;
        /// <summary>
        /// private field used to store the patient town
        /// </summary>
        private string patientTown;
        /// <summary>
        /// private field used to store the patients postcode
        /// </summary>
        private string patientPostcode;
        /// <summary>
        /// private field used to store the consultant assigned to the patient
        /// </summary>
        private Doctor consultant;
        /// <summary>
        /// private field used to store the patients treatment card
        /// </summary>
        public TreatmentCard TreatmentCard { get; set; }

        /// <summary>
        /// Public getter used to get the nhs number
        /// </summary>
        /// <returns>The nhs number</returns>
        public int getNhsNumber()
        {
            return nhsNumber;
        }

        /// <summary>
        /// Public getter used to get the patient name
        /// </summary>
        /// <returns>The patient name</returns>
        public string getPatientName()
        {
            return patientName;
        }

        /// <summary>
        /// Public getter used to get the patient address
        /// </summary>
        /// <returns>The patient address</returns>
        public string getPatientAddress()
        {
            return patientAddress;
        }

        /// <summary>
        /// Public getter used to get the patient town
        /// </summary>
        /// <returns>The patients town</returns>
        public string getPatientTown()
        {
            return patientTown;
        }

        /// <summary>
        /// Public getter used to get the patient postcode
        /// </summary>
        /// <returns>The patients postcode</returns>
        public string getPatientPostcode()
        {
            return patientPostcode;
        }

        /// <summary>
        /// Public getter used to return the consultants name
        /// </summary>
        /// <returns>The consultants name</returns>
        public string getConsultant()
        {
            return consultant.getStaffName();
        }

        /// <summary>
        /// Public setter used to set the patients nhs number
        /// Regex used to ensure only numbers are entered.
        /// If not an exception is thrown.
        /// </summary>
        /// <param name="nhsNumber">The nhs number of the patient</param>
        public void setNhsNumber(int nhsNumber)
        {
            if (!Regex.Match(Convert.ToString(nhsNumber), @"^[1-9]+$").Success)
            {
                throw new Exception("Patient nhs number must only include numbers.");
            }
            else
            {
                this.nhsNumber = nhsNumber;
            }
        }

        /// <summary>
        /// Public setter used to set the patient name.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="name">the name of the patient member</param>
        public void setPatientName(string name)
        {
            if (!Regex.Match(name, @"^[A-Za-z ]+$").Success)
            {
                throw new Exception("Patient Name cannot be empty and should only include values A-Z.");
            }
            else
            {
                patientName = name;
            }
        }

        /// <summary>
        /// Public setter used to set the patient address.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="address">the address of the patient member</param>
        public void setPatientAddress(string address)
        {
            if (!Regex.Match(address, @"^[A-Za-z0-9 ]+$").Success)
            {
                throw new Exception("Patient Address cannot be empty or contain special characters.");
            }
            else
            {
                patientAddress = address;
            }
        }

        /// <summary>
        /// Public setter used to set the patient town.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="town">the town of the patient</param>
        public void setPatientTown(string town)
        {
            if (!Regex.Match(town, @"^[A-Za-z ]+$").Success)
            {
                throw new Exception("Patient Town cannot be empty or contain numbers / special characters.");
            }
            else
            {
                patientTown = town;
            }
        }

        /// <summary>
        /// Public setter used to set the patient postcode.
        /// Uses regex and if statements for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="postcode">the postcode of the patient</param>
        public void setPatientPostcode(string postcode)
        {
            if ((!Regex.Match(postcode, @"^[A-Za-z1-9 ]+$").Success))
            {
                throw new Exception("Patient Postcode cannot be empty or contain special characters.");
            }
            else if (postcode.Length < 6 || postcode.Length > 8)
            {
                throw new Exception("Patient Postcode should be between 6 and 8 characters.");
            }
            else
            {
                patientPostcode = postcode;
            }
        }

        /// <summary>
        /// Public setter used to set the consultant
        /// If statement used for validation to ensure only consultants are assigned.
        /// If not an exception is thrown.
        /// </summary>
        /// <param name="consultant">The consultant who will be assigned</param>
        public void setConsultant(Doctor consultant)
        {
            if (!(consultant.getPost() == "Consultant"))
            {
                throw new Exception("Only consultants can be assigned to patients.");
            }
            else
            {
                this.consultant = consultant;
            }
        }

        /// <summary>
        /// Constructor used to create a new patient 
        /// </summary>
        /// <param name="nhsNumber">patients nhs number</param>
        /// <param name="patientName">patients name</param>
        /// <param name="patientAddress">patients address</param>
        /// <param name="patientTown">patients town</param>
        /// <param name="patientPostcode">patients postcode</param>
        /// <param name="consultant">consultant assigned to patient</param>
        public Patient(int nhsNumber, string patientName, string patientAddress, string patientTown, string patientPostcode, Doctor consultant)
        {
            setNhsNumber(nhsNumber);
            setPatientName(patientName);
            setPatientAddress(patientAddress);
            setPatientTown(patientTown);
            setPatientPostcode(patientPostcode);
            setConsultant(consultant);
            TreatmentCard = new TreatmentCard();
        }

        /// <summary>
        /// Method used to record a new measurement.
        /// Will add the new measurement to the measurements list.
        /// </summary>
        /// <param name="date">Date the measurement was taken</param>
        /// <param name="time">The time the measurement was taken</param>
        /// <param name="bloodPressure">Patients blood pressure</param>
        /// <param name="temperature">Patients temperature</param>
        /// <param name="nurse">The nurse who recorded the measurement</param>
        public void recordMeasurement(DateTime date, string time, int bloodPressureSystolic, int bloodPressureDiastolic, double temperature, Nurse nurse)
        {
            TreatmentCard.recordMeasurement(date, time, bloodPressureSystolic, bloodPressureDiastolic, temperature, nurse);
        }

        /// <summary>
        /// Method used to prescribe a new drug.
        /// Will add to the drug list.
        /// </summary>
        /// <param name="name">Name of the drug</param>
        /// <param name="dosage">The dosage to be taken</param>
        /// <param name="instructions">The instructions of the drug</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="doctor">The doctor who prescribed the drug</param>
        public void prescribeDrug(string name, double dosage, string instructions, DateTime prescribeDate,  Doctor doctor)
        {
            TreatmentCard.prescribeDrug(name, dosage, instructions, prescribeDate, doctor);
        }

        /// <summary>
        /// Method used to administer a drug.
        /// Will add the drug to the administered drug list and remove from the regular drug list.
        /// </summary>
        /// <param name="drug">The drug being administered</param>
        /// <param name="administerDate">The date the drug was administered</param>
        /// <param name="administerTime">The time the drug was administered</param>
        /// <param name="nurse">The nurse who administered the drug</param>
        public void administerDrug(Drug drug, DateTime administerDate, string administerTime, Nurse nurse)
        {
            TreatmentCard.administerDrug(drug, administerDate, administerTime, nurse);
        }

        /// <summary>
        /// Method used to remove a drug from the list.
        /// </summary>
        /// <param name="drug">The drug to be removed.</param>
        public void removeDrug(Drug drug)
        {
            TreatmentCard.removeDrug(drug);
        }

        /// <summary>
        /// Method used to return the treatment card details.
        /// </summary>
        /// <returns>the treatment card in string format</returns>
        public string getTreatmentCard()
        {
            return $"Patient Name : {getPatientName()} \nConsultant : {getConsultant()} \n\n" + TreatmentCard.ToString();
        }

        /// <summary>
        /// Method used to return the drugs currently on the prescription.
        /// </summary>
        /// <returns>The drugs held in the prescription</returns>
        public string getPrescription()
        {
            return $"Patient Name : {getPatientName()} \nConsultant : {getConsultant()} \n\n" + TreatmentCard.getPrescription();
        }

        /// <summary>
        /// Overriden tostring method used to return details about the patient in string format.
        /// </summary>
        /// <returns>The details about the patient</returns>
        public override string ToString()
        {
            return $"{getNhsNumber()} - {getPatientName()}";
        }
    }
}
