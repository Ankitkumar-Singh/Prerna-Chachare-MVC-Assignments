using System;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }
        /// <summary>Gets or sets the Employee gender.</summary>
        /// <value>The Employee gender.</value>
        [Required]
        public string Gender { get; set; }
        /// <summary>Gets or sets the Employee city.</summary>
        /// <value>The Employee city.</value>
        [Required]
        public string City { get; set; }
        /// <summary>Gets or sets the Employee date of birth.</summary>
        /// <value>The Employee date of birth.</value>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        #endregion
    }
}
