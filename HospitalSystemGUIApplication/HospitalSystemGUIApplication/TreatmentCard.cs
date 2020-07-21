using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to create a new treatment card.
    /// Date Completed : 21/05/2018
    /// </summary>
    /// 
    [Serializable]
    public class TreatmentCard
    {
        /// <summary>
        /// private field used to store the measurement list.
        /// </summary>
        private List<Measurement> measurements;
        /// <summary>
        /// Private field to store the instance of prescription.
        /// </summary>
        public Prescription Prescription { get; set; }

        /// <summary>
        /// Property will return a reference to the measurements list.
        /// </summary>
        public List<Measurement> Measurements
        {
            get { return measurements; }
        }

        /// <summary>
        /// Constructor will create a new measurement list and instance of prescription.
        /// </summary>
        public TreatmentCard()
        {
            measurements = new List<Measurement>();
            Prescription = new Prescription();
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
            measurements.Add(new Measurement(date, time, bloodPressureSystolic, bloodPressureDiastolic, temperature, nurse));
        }

        /// <summary>
        /// Method used to prescribe a new drug.
        /// Will add to the drug list.
        /// </summary>
        /// <param name="name">Name of the drug</param>
        /// <param name="dosage">The dosage to be taken</param>
        /// <param name="frequency">The frequency of the drug</param>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end date</param>
        /// <param name="doctor">The doctor who prescribed the drug</param>
        public void prescribeDrug(string name, double dosage, string frequency, DateTime prescribeDate, Doctor doctor)
        {
            Prescription.prescribeDrug(name, dosage, frequency, prescribeDate, doctor);
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
            Prescription.administerDrug(drug, administerDate, administerTime, nurse);
        }

        /// <summary>
        /// Method used to remove a drug from the list.
        /// </summary>
        /// <param name="drug">The drug to be removed.</param>
        public void removeDrug(Drug drug)
        {
            Prescription.removeDrug(drug);
        }

        /// <summary>
        /// Method used to return the drugs currently on the prescription.
        /// </summary>
        /// <returns>The drugs held in the prescription</returns>
        public string getPrescription()
        {
            return Prescription.ToString();
        }

        /// <summary>
        /// Method used to get all of the measurements currently held in the measurements list.
        /// </summary>
        /// <returns>The measurements held in the measurements list.</returns>
        public string getMeasurements()
        {
            string strMeasurement = "";
            foreach (Measurement measurement in measurements)
            {
                strMeasurement = strMeasurement + $"Date: {measurement.getDate()} \nTime: {measurement.getTime()} \nBloodPressure: {measurement.getBloodPressureSystolic()}/{measurement.getBloodPressureDiastolic()} mmHg \nTemperature: {measurement.getTemperature()}°C \nNurse: {measurement.getNurse()} \n\r";
            }
            return strMeasurement;
        }

        /// <summary>
        /// Overriden tostring  method used to return the patients measurements and administered drug.
        /// </summary>
        /// <returns>The measurements and administered drugs</returns>
        public override string ToString()
        {
            return "Measurements:- \n\n" + getMeasurements() + "\n\n\nPrescription:- \n\n" + Prescription.getAdministeredDrug();
        }
    }
}
