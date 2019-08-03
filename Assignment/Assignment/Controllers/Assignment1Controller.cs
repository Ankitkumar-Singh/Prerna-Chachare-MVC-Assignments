using System;
using System.Web.Mvc;
using Assignment.Models;

namespace Assignment.Controllers
{
    public class Assignment1Controller : Controller
    {
        #region "Display in Index view of Assignment1 controller"
        /// <summary>
        /// Display Greetings according to the time to the view
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            ViewBag.Greeting = (DateTime.Now.Hour < 12) ? "Good Morning" : (((DateTime.Now.Hour >= 12) && (DateTime.Now.Hour <= 17)) ? "Good Afternoon" : (((DateTime.Now.Hour >= 17) && (DateTime.Now.Hour <= 20)) ? "Good Evening" : "Good Night"));
            return View();
        }
        #endregion

        #region "RSVP Form to get Guest data"
        /// <summary>
        /// Show Invitation form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RSVPForm()
        {
            return View();
        }
        #endregion

        #region "Check whether form is valid and redirect to thanks view"
        /// <summary>
        /// Check whether RSVP Form is valid and redirect to Thanks view
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult RSVPForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }
        #endregion
    }
}