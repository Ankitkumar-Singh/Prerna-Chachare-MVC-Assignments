using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class Assignment6Controller : Controller
    {
        #region View List of Employees
        /// <summary>Indexes this instance.</summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
