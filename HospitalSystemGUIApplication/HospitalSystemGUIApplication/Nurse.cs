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
    /// Description : Used to create a new nurse type. 
    /// Date Completed : 21/05/2018
    /// </summary>
    [Serializable]
    public class Nurse : Staff
    {
        /// <summary>
        /// private field used to store the nurse post.
        /// </summary>
        private string post;

        /// <summary>
        /// Public getter used to return the post of the nurse.
        /// </summary>
        /// <returns>The post of the nurse.</returns>
        public string getPost()
        {
            return post;
        }

        /// <summary>
        /// Public setter used to set the nurses post.
        /// Uses regex for validation. Throws an excpetion if match is unsuccessful.
        /// </summary>
        /// <param name="post">the post of the nurse</param>
        public void setPost(string post)
        {
            if (!(Regex.Match(post, @"^[A-Za-z ]+$").Success && post == "Charge" || post == "Registered"|| post == "Ancillary"))
            {
                throw new Exception("nurse post must be assigned. No special characters or numbers. Post should only be Charge, Registered or Ancillary.");
            }
            else
            {
                this.post = post;
            }
        }

        /// <summary>
        /// Constructor used to create a new abstract instance of Nurse using the superclass. This instance will be carried down to the 
        /// subclasses as you cannot create an individual instance of an abstract class.
        /// </summary>
        /// <param name="staffNumber">staff ID</param>
        /// <param name="name">staff name</param>
        /// <param name="address">staff address</param>
        /// <param name="town">staff town</param>
        /// <param name="postcode">staff postcode</param>
        /// <param name="qualificationDate">staff qualification date</param>
        /// <param name="post">Staff members post</param>
        public Nurse(int staffNumber, string name, string address, string town, string postcode, DateTime qualificationDate, string post)
            : base(staffNumber, name, address, town, postcode, qualificationDate)
        {
            setPost(post);
        }

        /// <summary>
        /// Overriden to string method used to return details about the nurse.
        /// </summary>
        /// <returns>String representation of the staff details.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
