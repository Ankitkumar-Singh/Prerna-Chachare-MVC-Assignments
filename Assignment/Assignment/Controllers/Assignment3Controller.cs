using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment3Controller : Controller
    {
        /// <summary>
        /// View to display user details using ADO .NET
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
    }
}