using Assignment.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment2Controller : Controller
    {
        #region "Get list of user from Database and display in view"
        /// <summary>
        /// Get list of user from database and send to view
        /// </summary>
        /// <returns></returns>
        public ActionResult Details(int? deptId)
        {
            if (deptId == null)
            {
                return RedirectToAction("Index");
            }
            UserContext userContext = new UserContext();
            List<User> user = userContext.Users.Where(u => u.DeptId == deptId).ToList();
            return View(user);
        }
        #endregion

        #region "Get list of department from Database and display in view"
        /// <summary>
        /// Get details of department from database and send to view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            UserContext userContext = new UserContext();
            List<Department> department = userContext.Departments.ToList();
            return View(department);
        }
        #endregion
    }
}