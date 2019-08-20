using Assignment.Models;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using System;
using System.Collections.Generic;

namespace Assignment.Controllers
{
    public class Assignment9Controller : Controller
    {
        #region Database
        /// <summary>The database</summary>
        private UserDetailsContext db = new UserDetailsContext();
        #endregion

        #region View Departments
        /// <summary>Indexes the specified search.</summary>
        /// <param name="search">The search.</param>
        /// <param name="page">The page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <returns></returns>
        public ActionResult Index(string search, int? page, string sortBy)
        {
            ViewBag.DeptNameSort = String.IsNullOrEmpty(sortBy) ? "DeptName desc" : "";
            ViewBag.DeptLocationSort = String.IsNullOrEmpty(sortBy) ? "DeptLocation desc" : "";

            var department = db.Departments.AsQueryable();

            switch (sortBy)
            {
                case "DeptName desc":
                    department = department.OrderByDescending(x => x.DeptName);
                    break;
                case "DeptLocation desc":
                    department = department.OrderByDescending(x => x.DeptLocation);
                    break;
                default:
                    department = department.OrderBy(x => x.DeptName);
                    break;
            }

            return View(department.Where(d => d.DeptName.StartsWith(search) || d.DeptLocation.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 3));
        }
        #endregion

        #region Delete Multiple Departments
        /// <summary>Deletes the specified department ids to delete.</summary>
        /// <param name="departmentIdsToDelete">The department ids to delete.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IEnumerable<int> departmentIdsToDelete)
        {
            db.Departments.Where(x => departmentIdsToDelete.Contains(x.DeptId)).ToList().ForEach(x => db.Departments.Remove(x));
            db.SaveChanges();
            return RedirectToAction("Index");
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
