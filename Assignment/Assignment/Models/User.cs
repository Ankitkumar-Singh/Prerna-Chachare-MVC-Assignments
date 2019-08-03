using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment.Models
{
    /// <summary>
    /// Table from database to access UserList table data
    /// </summary>
    [Table("UserList")]
    public class User
    {
        #region "User Details"
        /// <summary>
        /// Class to get user details from database
        /// </summary>
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public int DeptId { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        #endregion
    }
}