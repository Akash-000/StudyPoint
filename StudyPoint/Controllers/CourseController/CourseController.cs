using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using StudyPoint.ViewModels;
using System.IO;
using StudyPoint.Data;
using StudyPoint.Services;

namespace StudyPoint.Controllers
{
    public partial class CourseController : Controller
    {
        private StudyPointContext _context;
        public CourseController()
        {
            _context = new StudyPointContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        /// Shows All Courses in the database to Admin
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Shows Details of a course to Admin
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int Id)
        {
            //var Course = _context.Courses.Include(c => c.CourseDifficultyLevel).SingleOrDefault(c => c.Id == Id);
            var CoursesServicesObj = new CoursesServices();
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
        /// Form to add new Course to the database
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            //var CourseDifficultyLevels = _context.CourseDifficultyLevels.ToList();
            var CoursesServicesObj = new CoursesServices();
            var CourseDifficultyLevels = CoursesServicesObj.GetCourseDifficulty();
            var ViewModel = new CourseFormViewModel
            {
                CourseDifficultyLevels = CourseDifficultyLevels
            };
            return View("CourseForm",ViewModel);
        }
        /// <summary>
        /// Saves the course to the database
        /// </summary>
        /// <param name="Course">all the details of the course are in course object</param>
        /// <param name="file">file uploaded with the course</param>
        /// <returns>View</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course Course, HttpPostedFileBase file)
        {
            try
            {
                if(file == null || file.ContentLength ==0)
                {
                    throw new FileNotFoundException();
                }
                else if(Course.Name == null)
                {
                    throw new NewFormError();
                }
            }
            catch(NewFormError exp)
            {
                return View(exp.FormErrorPath());
            }
            catch
            {
                return View("NoFileChoosen");
            }
            byte[] FileData;
            Course courseInMemory = new Course
            {
                Name = Course.Name,
                Category = Course.Category,
                InstructorName = Course.InstructorName,
                Price = Course.Price,
                CourseDifficultyLevelId = Course.CourseDifficultyLevelId
            };
            using (BinaryReader br = new BinaryReader(file.InputStream))
            {
                FileData = br.ReadBytes(file.ContentLength);
            }
            courseInMemory.Data = FileData;
            //_context.Courses.Add(courseInMemory);
            //_context.SaveChanges();

            var CoursesServicesObj = new CoursesServices();
            CoursesServicesObj.AddCourse(courseInMemory);
            return RedirectToAction("Index", "Course");
        }  
    }
}