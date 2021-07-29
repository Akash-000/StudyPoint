using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        /// <summary>
        /// Home page of User
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Shows 5 recently added courses in the database to the User
        /// </summary>
        /// <returns>View</returns>
        public ActionResult WhatsNew()
        {
            var NewData = _context.Courses.OrderByDescending(m => m.Id).Take(5).ToList();
            return View(NewData);
        }
        /// <summary>
        /// Shows Details of a particular course to User
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        public ActionResult Details(int Id)
        {
            var Course = _context.Courses.Include(c => c.CourseDifficultyLevel).SingleOrDefault(c => c.Id == Id);
            return View(Course);
        }
        /// <summary>
        /// Shows Profile of the User
        /// </summary>
        /// <param name="Id">Id of the user</param>
        /// <returns>View</returns>
        public ActionResult UserProfile(string Id)
        {
            ApplicationUser Customer = _context.Users.SingleOrDefault(c => c.Id == Id);
            return View(Customer);
        }
        /// <summary>
        /// Shows all the courses with link to download
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Download()
        {
            var Courses = _context.Courses.ToList();
            return View(Courses);
        }
        /// <summary>
        /// Download the study tutorial with the course Id given
        /// </summary>
        /// <param name="Id">Id of the course whose study material is downloaded</param>
        /// <returns></returns>
        public FileContentResult DownloadTutorial(int Id)
        {
            var Course = _context.Courses.SingleOrDefault(c => c.Id == Id);
            return File(Course.Data, "application/pdf");
        }
    }
}