using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        #region "Global Declaration"
        /// <summary>The connection string</summary>
        public string connectionString = ConfigurationManager.ConnectionStrings["UserContext"].ConnectionString;
        #endregion

        #region "Get Employees from Database"
        /// <summary>Gets the employees details.</summary>
        /// <value>The employees.</value>
        public IEnumerable<Employee> Employees
        {
            get
            {
                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(rdr["Id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.City = rdr["City"].ToString();
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        employees.Add(employee);
                    }
                }

                return employees;
            }
        }
        #endregion

        #region "Add new Employee"
        /// <summary>Adds the employee.</summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CRUDOperationsOnEmployees", con))
                {
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region "Update Employee"
        /// <summary>Updates the employee.</summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CRUDOperationsOnEmployees", con))
                {
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", employee.ID);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@City", employee.City);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region "Delete Employee"
        /// <summary>Deletes the employee.</summary>
        /// <param name="ID">The identifier.</param>
        public void DeleteEmployee(int ID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CRUDOperationsOnEmployees", con))
                {
                    cmd.Parameters.AddWithValue("@Action", "DELETE");
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", ID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}
