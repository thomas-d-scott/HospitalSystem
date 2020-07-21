using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HospitalSystemConsoleApplication
{
    /// <summary>
    /// Developer : Thomas Scott
    /// Description : Used to create a new doctor type.
    /// Date Completed : 21/05/2018
    /// </summary>
    [Serializable]
    public class Doctor : Staff
    {
        /// <summary>
        /// private field used to store the doctor post.
        /// </summary>
        private string post;

        /// <summary>
        /// Public getter used to return the post of the doctor.
        /// </summary>
        /// <returns>The post of the doctor.</returns>
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
            if (!(Regex.Match(post, @"^[A-Za-z ]+$").Success && post == "Consultant" || post == "Senior" || post == "Junior"))
            {
                throw new Exception("doctor post must be assigned. No special characters or numbers. Post should only be Consultant. Senior or Junior.");
            }
            else
            {
                this.post = post;
            }
        }

        /// <summary>
        /// Constructor used to create a new abstract instance of Doctor using the superclass.
        /// </summary>
        /// <param name="staffNumber">staff ID</param>
        /// <param name="name">staff name</param>
        /// <param name="address">staff address</param>
        /// <param name="town">staff town</param>
        /// <param name="postcode">staff postcode</param>
        /// <param name="qualificationDate">staff qualification date</param>
        /// <param name="post">Staff member post</param>
        public Doctor(int staffNumber, string name, string address, string town, string postcode, DateTime qualificationDate, string post)
            : base(staffNumber, name, address, town, postcode, qualificationDate)
        {
            setPost(post);
        }

        /// <summary>
        /// Overriden to string method used to return details about the doctor.
        /// Will be used within the subclasses also.
        /// </summary>
        /// <returns>String representation of the staff details.</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
