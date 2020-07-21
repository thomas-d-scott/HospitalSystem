using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to create a new drug.
    /// Date Completed : 21/05/2018
    /// </summary>
    [Serializable]
    public class Drug
    {
        /// <summary>
        /// private field used to store the drug name.
        /// </summary>
        private string drugName;
        /// <summary>
        /// private field used to store the drug dosage.
        /// </summary>
        private double dosage;
        /// <summary>
        /// private field used to store the frequency.
        /// </summary>
        private string instructions;
        /// <summary>
        /// private field used to store the date the prescription was written.
        /// </summary>
        private DateTime prescribeDate;
        private Doctor doctor;
        /// <summary>
        /// private field used to store the administer date of the drug.
        /// </summary>
        private DateTime administerDate;
        /// <summary>
        /// private field used to store the administer time of the drug.
        /// </summary>
        private string administerTime;
        /// <summary>
        /// private field used to store the nurse who administered the drug.
        /// </summary>
        private Nurse nurse;

        /// <summary>
        /// Constructor used to create a new drug (or prescribe a new drug)
        /// </summary>
        /// <param name="drugName">The name of the drug</param>
        /// <param name="dosage">The dosage to be administered</param>
        /// <param name="frequency">The frequency</param>
        /// <param name="startDate">The date the drug was administered</param>
        /// <param name="doctor">The doctor who prescribed the drug</param>
        public Drug(string drugName, double dosage, string instructions, DateTime prescribeDate, Doctor doctor)
        {
            setDrugName(drugName);
            setDosage(dosage);
            setInstructions(instructions);
            setPrescriptionDate(prescribeDate);
            setDoctor(doctor);
        }

        /// <summary>
        /// This method is used to administer the drug and set the 
        /// appropriate fields for the drug class. 
        /// </summary>
        /// <param name="administerDate">Date the drug was administered on</param>
        /// <param name="administerTime">The time the drug was administered at</param>
        /// <param name="nurse">The nurse who administered the drug</param>
        public void administerDrug(DateTime administerDate, string administerTime, Nurse nurse)
        {
            setAdministerDate(administerDate);
            setAdministerTime(administerTime);
            setNurse(nurse);
        }

        /// <summary>
        /// public getter used to return the name of the drug.
        /// </summary>
        /// <returns>name of the drug</returns>
        public string getDrugName()
        {
            return drugName;
        }

        /// <summary>
        /// public getter used to return the dosage that should be administered.
        /// </summary>
        /// <returns>dosage that should be administered</returns>
        public double getDosage()
        {
            return dosage;
        }

        /// <summary>
        /// public getter used to return the frequency of which the drug should be administered.
        /// </summary>
        /// <returns>frequency</returns>
        public string getInstructions()
        {
            return instructions;
        }

        /// <summary>
        /// public getter used to return the date that the drug was prescribed on.
        /// </summary>
        /// <returns>prescribed date</returns>
        public string getPrescribeDate()
        {
            return prescribeDate.ToShortDateString();
        }

        /// <summary>
        /// public getter used to return the name of the doctor who prescribed the drug.
        /// </summary>
        /// <returns>doctors name</returns>
        public string getDoctor()
        {
            return doctor.getStaffName();
        }

        /// <summary>
        /// public getter used to return the date that the drug was administered on.
        /// </summary>
        /// <returns>administer date</returns>
        public string getAdministerDate()
        {
            return administerDate.ToShortDateString();
        }

        /// <summary>
        /// public getter used to return the time of which the drug was administered.
        /// </summary>
        /// <returns>administer time</returns>
        public string getAdministerTime()
        {
            return administerTime;
        }

        /// <summary>
        /// public getter used to return the name of the nurse who administered the drug.
        /// </summary>
        /// <returns>Nurses name</returns>
        public string getNurse()
        {
            return nurse.getStaffName();
        }

        /// <summary>
        /// Public setter used to set the drug name.
        /// Regex is used for validation to ensure the right values are passed into the field.
        /// If values aren't valid an exception is thrown.
        /// </summary>
        /// <param name="drugName">The name of the drug</param>
        public void setDrugName(string drugName)
        {
            if (!Regex.Match(drugName, @"^[A-Za-z ]+$").Success)
            {
                throw new Exception("Drug name cannot be empty and should only include letters.");
            }
            else
	{
                this.drugName = drugName; 
            }
        }

        /// <summary>
        /// Public setter used to set the dosage.
        /// If statement used for validation to ensure the value entered is within a certain range.
        /// Exception thrown if the value entered is not valid.
        /// </summary>
        /// <param name="dosage">The dosage that is to be administered</param>
        public void setDosage(double dosage)
        {
            if (dosage <= 0)
            {
                throw new Exception("Dosage must be numeric and cannot be 0.");
            }
            else
            {
                this.dosage = dosage; 
            }
        }

        /// <summary>
        /// Public setter used to set the instructions.
        /// Regex is used to make sure the value entered only includes the specified values.
        /// If the match is unsuccessful, an exception is thrown.
        /// </summary>
        /// <param name="instructions">The instructions of the drug.</param>
        public void setInstructions(string instructions)
        {
            if (!Regex.Match(instructions, @"^[A-Za-z1-9. ]+$").Success)
            {
                throw new Exception("Instructions cannot be empty or contain special characters.");
            }
            else
            {
                this.instructions = instructions; 
            }
        }

        /// <summary>
        /// Public setter used to set the prescribe date of the drug.
        /// If statement used for validation to ensure the date entered is valid.
        /// Exception thrown if it is not a valid date.
        /// </summary>
        /// <param name="date">The date of which the drug has been prescribed.</param>
        public void setPrescriptionDate(DateTime date)
        {
            if (date.Date > DateTime.Today || date.Date < DateTime.Today)
            {
                throw new Exception("The drug can only be prescribed on the present day.");
            }
            else
            {
                this.prescribeDate = date;
            }
        }

        /// <summary>
        /// Public setter used to set the doctor who prescribed the drug.
        /// If statement used to ensure the doctor is valid.
        /// Exception thrown if not.
        /// </summary>
        /// <param name="doctor">The doctor who prescribed the drug</param>
        public void setDoctor(Doctor doctor)
        {
            if (!(doctor.getPost() == "Consultant" || doctor.getPost() == "Senior" || doctor.getPost() == "Junior"))
            {
                throw new Exception("Only doctors have the qualifications to prescribe medication.");
            }
            else
            {
                this.doctor = doctor; 
            }
        }

        /// <summary>
        /// Public setter used to set the administer date.
        /// If statement used for validation, to see if the date is valid.
        /// If not, an exception is thrown.
        /// </summary>
        /// <param name="date">The date the drug was administered</param>
        public void setAdministerDate(DateTime date)
        {
            if (date.Date > DateTime.Today || date.Date < DateTime.Today)
            {
                throw new Exception("The drug can only be administered on the present day.");
            }
            else
            {
                this.administerDate = date;
            }
        }

        /// <summary>
        /// Public setter used to set the time the drug was administered.
        /// If statement used to check if the time falls within an acceptable range.
        /// If time is not valid, an exception is thrown.
        /// </summary>
        /// <param name="time">The time the drug was administered</param>
        public void setAdministerTime(string time)
        {
            int timeInt = Convert.ToInt32(time);
            if (time.Length < 4 || timeInt < 0000 || timeInt > 2359 || (!Regex.IsMatch(Convert.ToString(time[0]), "^[0-2]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[2]),
                "^[0-9]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[2]), "^[0-5]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[3]), "^[0-9]{1}$")))
            {
                throw new Exception("Time should lie between 0000 and 2359.");
            }
            else
            {
                this.administerTime = time;
            }
        }

        /// <summary>
        /// Public setter used to set the nurse who administered the drug.
        /// If statement used to check the nurse who administers the drug is valid.
        /// Exception thrown if not.
        /// </summary>
        /// <param name="nurse">The nurse who administered the drug.</param>
        public void setNurse(Nurse nurse)
        {
            if (nurse.getPost() == "Ancillary")
            {
                throw new Exception("Ancillary nurses are not qualified to administer medication.");
            }
            else
            {
                this.nurse = nurse;
            }
        }

        /// <summary>
        /// Overriden ToString method will return drug details dependant on if it has been administered or not.
        /// </summary>
        /// <returns>Details about the drug</returns>
        public override string ToString()
        {
            return getDrugName();
        }
    }
}
