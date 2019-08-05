using BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment4Controller : Controller
    {
        #region "Index View to display list of employees"
        /// <summary>
        /// View to display user details using ADO .NET
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        #endregion

        #region "Create View to Add a new Employee"
        /// <summary>Creates this instance.</summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>Creates the specified employee.</summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region "Edit View to Update Employee"
        /// <summary>Edits the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.ID == id);
            return View(employee);
        }

        /// <summary>Edits the specified employee.</summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        #endregion

        #region "Delete Action to Delete Employee"
        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}