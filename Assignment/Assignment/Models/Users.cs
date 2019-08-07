using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Users
    {
        #region "User Properties"        
        /// <summary>
        /// Gets or sets the user properties.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }

        public virtual Departments Departments { get; set; }
        #endregion
    }
}