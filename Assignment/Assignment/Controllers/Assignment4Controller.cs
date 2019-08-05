using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment4Controller : Controller
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}