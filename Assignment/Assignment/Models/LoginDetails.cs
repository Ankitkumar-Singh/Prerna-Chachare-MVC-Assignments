using System.Data;
using System.Data.SqlClient;

namespace Assignment.Models
{
    public class LoginDetails
    {
        /// <summary>  
        /// Get all records from the DB  
        /// </summary>  
        /// <returns>Datatable</returns>  
        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=MACHINE-214;Initial Catalog=UserDetails;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [User]", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}