using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {
        #region "Index View of Home page"
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}