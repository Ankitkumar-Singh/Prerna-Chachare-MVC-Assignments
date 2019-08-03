using System.Data.Entity;

namespace Assignment.Models
{
    public class UserContext : DbContext
    {
        #region "Dbset to get data from User class and Department"
        /// <summary>
        /// Class to get data of user and department in Dbset
        /// </summary>
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion
    }
}