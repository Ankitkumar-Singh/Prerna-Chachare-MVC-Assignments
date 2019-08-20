using Assignment.Models;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment7Controller : Controller
    {
        #region "Database Context"
        /// <summary>The database</summary>
        private UserDetailsContext db = new UserDetailsContext();
        #endregion

        #region "List of Users and their comments"
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.userResponses.ToList());
        }
        #endregion

        #region "Add a new comment"
        /// <summary>Creates this instance.</summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,Comments")] userResponse userResponse)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(HttpUtility.HtmlEncode(userResponse.Comments));
            stringBuilder.Replace("&lt;b&gt;", "<b>");
            stringBuilder.Replace("&lt;/b&gt;", "</b>");
            stringBuilder.Replace("&lt;u&gt;", "<u>");
            stringBuilder.Replace("&lt;/u&gt;", "</u>");
            stringBuilder.Replace("&lt;i&gt;", "<i>");
            stringBuilder.Replace("&lt;/i&gt;", "</i>");
            userResponse.Comments = stringBuilder.ToString();

            string strEncodedName = HttpUtility.HtmlEncode(userResponse.Name);
            userResponse.Name = strEncodedName;
            if (ModelState.IsValid)
            {
                db.userResponses.Add(userResponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userResponse);
        }
        #endregion

        #region "Dispose"
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
