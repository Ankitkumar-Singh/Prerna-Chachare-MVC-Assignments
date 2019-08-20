using Assignment.Models;
using System.Linq;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment11Controller : Controller
    {
        #region Database Context
        /// <summary>The database</summary>
        private UserDetailsContext db = new UserDetailsContext();
        #endregion

        #region View Employee List
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        #endregion

        #region Create Employee
        /// <summary>Creates this instance.</summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>Creates the specified employee.</summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,Email")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }
        #endregion

        #region Check Email Availability
        /// <summary>Determines whether [is email available] [the specified email].</summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public JsonResult IsEmailAvailable(string Email)
        {
            return Json(!db.Employees.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Dispose Database
        /// <summary>Releases unmanaged resources and optionally releases managed resources.</summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
