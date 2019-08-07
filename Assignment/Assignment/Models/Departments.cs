using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Departments
    {
        #region "Department Properties"        
        /// <summary>
        /// Gets or sets the department properties.
        /// </summary>
        /// <value>
        /// The dept identifier.
        /// </value>
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        #endregion
    }
}