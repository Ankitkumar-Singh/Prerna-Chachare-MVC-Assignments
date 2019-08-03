using System;

namespace BusinessLayer
{
    public class Employee
    {
        #region "Employee"
        /// <summary>Gets or sets the Employee ID.</summary>
        /// <value>The Employee ID.</value>
        public int ID { get; set; }
        /// <summary>Gets or sets the Employee name.</summary>
        /// <value>The Employee name.</value>
        public string Name { get; set; }
        /// <summary>Gets or sets the Employee gender.</summary>
        /// <value>The Employee gender.</value>
        public string Gender { get; set; }
        /// <summary>Gets or sets the Employee city.</summary>
        /// <value>The Employee city.</value>
        public string City { get; set; }
        /// <summary>Gets or sets the Employee date of birth.</summary>
        /// <value>The Employee date of birth.</value>
        public DateTime DateOfBirth { get; set; }
        #endregion
    }
}
