using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    /// <summary>
    /// Table from database to access DepartmentList table data
    /// </summary>
    [Table("DepartmentList")]
    public class Department
    {
        #region "Department Class to get Department table details"
        /// <summary>
        /// Class to get Department table from database and get list of users from one department
        /// </summary>
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public List<User> users { get; set; }
        #endregion
    }
}