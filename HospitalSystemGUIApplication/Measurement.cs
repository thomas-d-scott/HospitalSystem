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
    /// Description : Used to create a new measurement.
    /// Date Completed : 21/05/2018
    /// </summary>
    /// 
    [Serializable]
    public class Measurement
    {
        /// <summary>
        /// private field used to store the date.
        /// </summary>
        private DateTime date;
        /// <summary>
        /// private field used to store the time.
        /// </summary>
        private string time;
        /// <summary>
        /// private field used to store the blood pressure.
        /// </summary>
        private int bloodPressureSystolic;
        /// <summary>
        /// private field used to store the blood pressure.
        /// </summary>
        private int bloodPressureDiastolic;
        /// <summary>
        /// private field used to store the temperature.
        /// </summary>
        private double temperature;
        /// <summary>
        /// private field used to store the nurse.
        /// </summary>
        private Nurse nurse;

        /// <summary>
        /// public getter used to return the date.
        /// </summary>
        /// <returns>date</returns>
        public string getDate()
        {
            return date.ToShortDateString();
        }

        /// <summary>
        /// public getter used to return the time.
        /// </summary>
        /// <returns>time</returns>
        public string getTime()
        {
            return time;
        }

        /// <summary>
        /// public getter used to return the blood pressure.
        /// </summary>
        /// <returns>Systolic blood pressure</returns>
        public int getBloodPressureSystolic()
        {
            return bloodPressureSystolic;
        }

        /// <summary>
        /// public getter used to return the blood pressure.
        /// </summary>
        /// <returns>Diastolic blood pressure</returns>
        public int getBloodPressureDiastolic()
        {
            return bloodPressureDiastolic;
        }

        /// <summary>
        /// public getter used to return the temperature.
        /// </summary>
        /// <returns>temperature</returns>
        public double getTemperature()
        {
            return temperature;
        }

        /// <summary>
        /// public getter used to return the name of the nurse.
        /// </summary>
        /// <returns>The name of the nurse</returns>
        public string getNurse()
        {
            return nurse.getStaffName();
        }

        /// <summary>
        /// public setter used to set the date.
        /// If statement used to validate the date.
        /// Throws an exception if it is not valid.
        /// </summary>
        /// <param name="date">the date the measurement is taken</param>
        public void setDate(DateTime date)
        {
            if (!(date == DateTime.Today))
            {
                throw new Exception($"Please ensure you are only adding a measurement for todays date - \"{DateTime.Today.ToShortDateString()}\"");
            }
            else
            {
                this.date = date;
            }
        }

        /// <summary>
        /// Public setter used to set the time.
        /// If statement is used for validation.
        /// If validation fails, exception is thrown.
        /// </summary>
        /// <param name="time">The time the measurement is taken.</param>
        public void setTime(string time)
        {
            int timeInt = Convert.ToInt32(time);
            if (time.Length < 4 || timeInt < 0000 || timeInt > 2359 || (!Regex.IsMatch(Convert.ToString(time[0]), "^[0-2]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[2]),
                "^[0-9]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[2]), "^[0-5]{1}$")) || (!Regex.IsMatch(Convert.ToString(time[3]), "^[0-9]{1}$")))
            {
                throw new Exception("Time should lie between 0000 and 2359.");
            }
            else
            {
                this.time = time;
            }
        }

        /// <summary>
        /// Public setter used to set the Systolic blood pressure.
        /// If statement used to ensure the blood pressure is validated.
        /// If not an exception is thrown.
        /// </summary>
        /// <param name="systolicBloodPressure">The blood pressure of the patient</param>
        public void setSystolicBloodPressure(int systolicBloodPressure)
        {
            if (systolicBloodPressure <= 0 || systolicBloodPressure > 250)
            {
                throw new Exception("Systolic Blood Pressure must be recorded. Be between 0 and 250.");
            }
            else
            {
                this.bloodPressureSystolic = systolicBloodPressure;
            }
        }

        /// <summary>
        /// Public setter used to set the Diastolic blood pressure.
        /// If statement used to ensure the blood pressure is validated.
        /// If not an exception is thrown.
        /// </summary>
        /// <param name="diastolicBloodPressure">The blood pressure of the patient</param>
        public void setDiastolicBloodPressure(int diastolicBloodPressure)
        {
            if (diastolicBloodPressure <= 0 || diastolicBloodPressure > 250)
            {
                throw new Exception("Diastolic Blood Pressure must be recorded. Be between 0 and 250.");
            }
            else
            {
                this.bloodPressureDiastolic = diastolicBloodPressure;
            }
        }

        /// <summary>
        /// Public setter used to set the patients temperature.
        /// Regex used for validation to ensure only numbers are entered.
        /// Exception thrown if this is not the case.
        /// </summary>
        /// <param name="temperature">patients temperature</param>
        public void setTemperature(double temperature)
        {
            if (temperature < -30 || temperature > 50 || !Regex.Match(Convert.ToString(temperature), @"^[1-9.-]+$").Success)
            {
                throw new Exception("Temperature must only include numbers. Must be between -30 and 50 degrees celcius");
            }
            else
            {
                this.temperature = temperature;
            }
        }

        /// <summary>
        /// Public setter used to set the nurse who took the measurements.
        /// If statement used to ensure only nurses take measurements.
        /// Exception is thrown if this is not the case.
        /// </summary>
        /// <param name="nurse"></param>
        public void setNurse(Nurse nurse)
        {
            if (!(nurse.getPost() == "Charge" || nurse.getPost() == "Registered" || nurse.getPost() == "Ancillary"))
            {
                throw new Exception("Must be a valid type of nurse.");
            }
            else
            {
                this.nurse = nurse;
            }
        }

        /// <summary>
        /// Consructor used to create a new instance of measurement.
        /// </summary>
        /// <param name="date">Date measurement taken</param>
        /// <param name="time">Time measurement taken</param>
        /// <param name="bloodPressure">The patients blood pressure</param>
        /// <param name="temperature">The patients temperature</param>
        /// <param name="nurse">The nurse who took the measurement</param>
        public Measurement(DateTime date, string time, int bloodPressureSystolic, int bloodPressureDiastolic, double temperature, Nurse nurse)
        {
            setDate(date);
            setTime(time);
            setSystolicBloodPressure(bloodPressureSystolic);
            setDiastolicBloodPressure(bloodPressureDiastolic);
            setTemperature(temperature);
            setNurse(nurse);
        }

        /// <summary>
        /// ToString overriden to return the details about the measurement.
        /// </summary>
        /// <returns>The details of the measurement</returns>
        public override string ToString()
        {
            return $"Date: {getDate()} \nTime: {getTime()} \nBloodPressure: {getBloodPressureSystolic()}/{getBloodPressureDiastolic()} \nTemperature: {getTemperature()} \nNurse: {getNurse()} \n\n";
        }
    }
}
