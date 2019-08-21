using System.Linq;
using System.Web.Mvc;
using Assignment.Models;
namespace Assignment.Controllers
{
    public class Assignment6Controller : Controller
    {
        UserDetailsContext db = new UserDetailsContext();

        #region View List of Employees
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        #endregion
    }
}
