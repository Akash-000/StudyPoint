using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;
using StudyPoint.Data;
using StudyPoint.Services;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public partial class UserController : Controller
    {
        private StudyPointContext _context;
        public UserController()
        {
            _context = new StudyPointContext();
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
            //var NewData = _context.Courses.OrderByDescending(m => m.Id).Take(5).ToList();
            var CoursesServicesObj = new CoursesServices();
            var NewData = CoursesServicesObj.GetLatestFive();
            try
            {
                if(NewData.Count == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            return View(NewData);
        }
        /// <summary>
        /// Shows Details of a particular course to User
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        public ActionResult Details(int Id)
        {
            var CoursesServicesObj = new CoursesServices();
            //var Course = _context.Courses.Include(c => c.CourseDifficultyLevel).SingleOrDefault(c => c.Id == Id);
            var Course = CoursesServicesObj.GetCourse(Id);
            try
            {
                if(Course == null)
                {
                    throw new RequestNotFound();
                }
            }
            catch(RequestNotFound exp)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(exp);
                return View(exp.RequestNotFoundPath());
            }
            return View(Course);
        }
        /// <summary>
        /// Shows Profile of the User
        /// </summary>
        /// <param name="Id">Id of the user</param>
        /// <returns>View</returns>
        public ActionResult UserProfile(string Id)
        {
            //StudyPointUsers Customer = _context.Users.SingleOrDefault(c => c.Id == Id);
            var CustomerServicesObj = new CustomerServices();
            StudyPointUsers Customer = CustomerServicesObj.GetCustomer(Id);
            try
            {
                if(Customer == null)
                {
                    throw new RequestNotFound();
                }
            }
            catch(RequestNotFound exp)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(exp);
                return View(exp.RequestNotFoundPath());
            }
            return View(Customer);
        }
        /// <summary>
        /// Shows all the courses with link to download
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Download(int? Page)
        {
            //var Courses = _context.Courses.ToList();
            var CoursesServicesObj = new CoursesServices();
            var Courses = CoursesServicesObj.GetAllCourses(Page);
            try
            {
                if (Courses.Count == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            return View(Courses);
        }
        /// <summary>
        /// Download the study tutorial with the course Id given
        /// </summary>
        /// <param name="Id">Id of the course whose study material is downloaded</param>
        /// <returns></returns>
        public FileContentResult DownloadTutorial(int Id)
        {
            //var Course = _context.Courses.SingleOrDefault(c => c.Id == Id);
            var CoursesServicesObj = new CoursesServices();
            var Course = CoursesServicesObj.GetCourse(Id);
            return File(Course.Data, "application/pdf");
        }
    }
}