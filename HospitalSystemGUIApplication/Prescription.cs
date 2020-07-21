using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to create a new prescription.
    /// Date Completed : 15/05/2018
    /// </summary>
    /// 
    [Serializable]
    public class Prescription
    {
        /// <summary>
        /// private field to store the drug list.
        /// </summary>
        private List<Drug> drugList;
        /// <summary>
        /// private field to store the administereddrug list
        /// </summary>
        private List<Drug> administeredDrugList;

        /// <summary>
        /// Property used to reference the drug list.
        /// </summary>
        public List<Drug> DrugList
        {
            get { return drugList; }
        }

        /// <summary>
        /// property used to reference the administereddrug list.
        /// </summary>
        public List<Drug> AdministeredDrugList
        {
            get { return administeredDrugList; }
        }

        /// <summary>
        /// Constructor used to create two new lists.
        /// </summary>
        public Prescription()
        {
            drugList = new List<Drug>();
            administeredDrugList = new List<Drug>();
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
        public void prescribeDrug(string name, double dosage, string instructions, DateTime prescribeDate, Doctor doctor)
        {
            drugList.Add(new Drug(name, dosage, instructions, prescribeDate, doctor));
        }

        /// <summary>
        /// Method used to remove a drug from the list.
        /// </summary>
        /// <param name="drug">The drug to be removed.</param>
        public void removeDrug(Drug drug)
        {
            drugList.Remove(drug);
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
            drug.administerDrug(administerDate, administerTime, nurse);
            administeredDrugList.Add(drug);
            removeDrug(drug);
        }

        /// <summary>
        /// Method used to return the drugs in the drug list.
        /// </summary>
        /// <returns>Each of the drugs in the drug list</returns>
        public string getDrugs()
        {
            string strDrugs = "";
            foreach (Drug drug in drugList)
            {
                strDrugs = strDrugs + $"Drug Name : {drug.getDrugName()} \nDosage : {drug.getDosage()} units \nInstructions : {drug.getInstructions()} \nPrescribe Date : {drug.getPrescribeDate()} \nDoctor : {drug.getDoctor()} \n\r";
            }
            return strDrugs;
        }

        /// <summary>
        /// Method used to return the drugs in the administered drug list.
        /// </summary>
        /// <returns>Each of the drugs in the administered drug list.</returns>
        public string getAdministeredDrug()
        {
            string strDrugs = "";
            foreach (Drug drug in administeredDrugList)
            {
                strDrugs = strDrugs + $"Drug Name : {drug.getDrugName()} \nDosage : {drug.getDosage()} units \nInstructions : {drug.getInstructions()} \nPrescribe Date : {drug.getPrescribeDate()} \nDoctor : {drug.getDoctor()} \nAdminister Date : {drug.getAdministerDate()} \nAdminister Time : {drug.getAdministerTime()} \nNurse : {drug.getNurse()}\n\r";
            }
            return strDrugs;
        }

        /// <summary>
        /// Overriden tostring method used to return the drugs on the prescription.
        /// </summary>
        /// <returns>The drugs list in string format.</returns>
        public override string ToString()
        {
            return getDrugs();
        }
    }
}
