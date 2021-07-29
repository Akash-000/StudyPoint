using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using StudyPoint.ViewModels;
using System.IO;

namespace StudyPoint.Controllers
{
    [HandleError(ExceptionType = typeof(Exception), View ="ExceptionView")]
    [Authorize(Roles ="CanManageCourseAndCustomer")]
    public class CourseController : Controller
    {
        private ApplicationDbContext _context;
        public CourseController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        /// Shows All Courses in the database to Admin
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Shows Details of a course to Admin
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        public ActionResult Details(int Id)
        {
            var Course = _context.Courses.Include(c => c.CourseDifficultyLevel).SingleOrDefault(c => c.Id == Id);
            return View(Course);
        }
        /// <summary>
        /// Form to add new Course to the database
        /// </summary>
        /// <returns>View</returns>
        public ActionResult New()
        {
            var CourseDifficultyLevels = _context.CourseDifficultyLevels.ToList();
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
        [ValidateAntiForgeryToken]
        public ActionResult Save(Course Course, HttpPostedFileBase file)
        {
            if (file != null)
                {
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
                    _context.Courses.Add(courseInMemory);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Course");
                }
                else
                {
                return View("NoFileChoosen");
                }
        }  
    }
}