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
    /// Description : Used to create a new doctor or nurse type. Will be abstract.
    /// Date Completed : 21/05/2018
    /// </summary>
    /// 
    [Serializable]
    public abstract class Staff
    {
        /// <summary>
        /// Protected field to store the staff number.
        /// </summary>
        protected int staffNumber;
        /// <summary>
        /// Protected field to store the staff name.
        /// </summary>
        protected string staffName;
        /// <summary>
        /// Protected field to store the staff address.
        /// </summary>
        protected string staffAddress;
        /// <summary>
        /// Protected field to store the staff town.
        /// </summary>
        protected string staffTown;
        /// <summary>
        /// Protected field to store the staff postcode.
        /// </summary>
        protected string staffPostcode;
        /// <summary>
        /// Protected field to store the qualification date.
        /// </summary>
        protected DateTime qualificationDate;

        /// <summary>
        /// Constructor used to create an instance of the class staff. This however, will be abstract and will actually be used to create
        /// instances of the types of doctors and nurses.
        /// </summary>
        /// <param name="staffNumber">staff memeber ID</param>
        /// <param name="name">staff member name</param>
        /// <param name="address">staff member address</param>
        /// <param name="town">staff member town</param>
        /// <param name="postcode">staff member postcode</param>
        /// <param name="qualificationDate">staff member qualification date</param>
        public Staff(int staffNumber, string name, string address, string town, string postcode, DateTime qualificationDate)
        {
            setStaffNumber(staffNumber);
            setStaffName(name);
            setStaffAddress(address);
            setStaffTown(town);
            setStaffPostcode(postcode);
            setQualificationDate(qualificationDate);
        }

        /// <summary>
        /// public getter used to return the staff number.
        /// </summary>
        /// <returns>staff number</returns>
        public int getStaffNumber()
        {
            return staffNumber;
        }

        /// <summary>
        /// public getter used to return the staff number.
        /// </summary>
        /// <returns>staff number</returns>
        public string getStaffName()
        {
            return staffName;
        }

        /// <summary>
        /// public getter used to return the staff address.
        /// </summary>
        /// <returns>staff address</returns>
        public string getStaffAddress()
        {
            return staffAddress;
        }

        /// <summary>
        /// public getter used to return the staff town.
        /// </summary>
        /// <returns>staff town</returns>
        public string getStaffTown()
        {
            return staffTown;
        }

        /// <summary>
        /// public getter used to return the staff postcode.
        /// </summary>
        /// <returns>staff postcode</returns>
        public string getStaffPostcode()
        {
            return staffPostcode;
        }

        /// <summary>
        /// public getter used to return the qualification date in short date string format.
        /// </summary>
        /// <returns>qualification date</returns>
        public string getQualificationDate()
        {
            return qualificationDate.ToShortDateString();
        }

        /// <summary>
        /// Public setter used to set the staff number.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="staffNumber">the name of the staff member</param>
        public void setStaffNumber(int staffNumber)
        {
            if (!Regex.Match(Convert.ToString(staffNumber), @"^[1-9]+$").Success)
            {
                throw new Exception("Staff Number must only include numbers.");
            }
            else
            {
                this.staffNumber = staffNumber;
            }
        }

        /// <summary>
        /// Public setter used to set the staff name.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="name">the name of the staff member</param>
        public void setStaffName(string name)
        {
            if (!Regex.Match(name, @"^[A-Za-z ]+$").Success)
            {
                throw new Exception("Staff Name cannot be empty and should only include values A-Z.");
            }
            else
            {
                staffName = name;
            }
        }

        /// <summary>
        /// Public setter used to set the staff address.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="address">the address of the staff member</param>
        public void setStaffAddress(string address)
        {
            if (!Regex.Match(address, @"^[A-Za-z1-9 ]+$").Success)
            {
                throw new Exception("Staff Address cannot be empty or contain special characters.");
            }
            else
            {
                staffAddress = address;
            }
        }

        /// <summary>
        /// Public setter used to set the staff town.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="town">the town of the staff member</param>
        public void setStaffTown(string town)
        {
            if (!Regex.Match(town, @"^[A-Za-z ]+$").Success)
            {
                throw new Exception("Staff Town cannot be empty or contain numbers / special characters.");
            }
            else
            {
                staffTown = town;
            }
        }

        /// <summary>
        /// Public setter used to set the staff postcode.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="postcode">the postcode of the staff member</param>
        public void setStaffPostcode(string postcode)
        {
            if ((!Regex.Match(postcode, @"^[A-Za-z1-9 ]+$").Success) || postcode.Length < 6 || postcode.Length > 8)
            {
                throw new Exception("Staff Postcode cannot be empty or contain special characters.");
            }
            else
            {
                staffPostcode = postcode;
            }
        }

        /// <summary>
        /// Public setter used to set the qualification date of the staff member.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="date">the qualification date of the staff member</param>
        public void setQualificationDate(DateTime date)
        {
            if (date.Date > DateTime.Today || date.Year < 1950)
            {
                throw new Exception("The Qualification Date must lie between 1950 and todays date.");
            }
            else
            {
                qualificationDate = date;
            }
        }

        /// <summary>
        /// Overriden to string method used to return details about the staff member.
        /// Will be used within the subclasses also.
        /// </summary>
        /// <returns>String representation of the staff details.</returns>
        public override string ToString()
        {
            return $"{getStaffNumber()} - {getStaffName()}";
        }
    }
}
