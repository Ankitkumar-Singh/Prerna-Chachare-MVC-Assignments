using Assignment.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment5Controller : Controller
    {
        #region "Context Declaration"
        // The database
        private UserDetailsContext db = new UserDetailsContext();
        #endregion

        #region "Index View"
        // GET: Assignmnet5        
        /// <summary>
        /// Get user details using Entity Framework
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Department);
            return View(users.ToList());
        }
        #endregion

        #region "Details View"
        // GET: Assignmnet5/Details/5        
        /// <summary>
        /// View Details of particular user using Entity Framework
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        #endregion

        #region "Create View"
        // GET: Assignmnet5/Create        
        /// <summary>
        /// Display form to create user
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();
        }

        // POST: Assignmnet5/Create        
        /// <summary>
        /// Get user details from the user and insert in database
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,DeptId,City,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", user.DeptId);
            return View(user);
        }
        #endregion

        #region "Edit View"
        // GET: Assignmnet5/Edit/5        
        /// <summary>
        /// Display edit form with previous details
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", user.DeptId);
            return View(user);
        }

        // POST: Assignmnet5/Edit/5        
        /// <summary>
        /// Get user changes and update in database
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,DeptId,City,Gender")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", user.DeptId);
            return View(user);
        }
        #endregion

        #region "Delete View"
        // GET: Assignmnet5/Delete/5        
        /// <summary>
        /// Display user details before deleting
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Assignmnet5/Delete/5        
        /// <summary>
        /// Deletes the user from database if user confirms delete
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region "Dispose Method"        
        /// <summary>
        /// Releases unmanaged resources and optionally releases managed resources.
        /// </summary>
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
