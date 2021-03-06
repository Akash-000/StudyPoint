using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Landing page of the web application
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// About the web application(StudyPoint)
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// Contact Us page of the web application
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }
        /// <summary>
        /// All the major technologies we deal with
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Services()
        {
            return View();
        }
        /// <summary>
        /// Team members
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult Department()
        {
            return View();
        }
        /// <summary>
        /// Gallery
        /// </summary>
        /// <returns>View</returns>
        [AllowAnonymous]
        public ActionResult Gallery()
        {
            return View();
        }
    }
}