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

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    [Authorize(Roles = "CanManageCourseAndCustomer")]
    public class Course2Controller : Controller
    {
        private ApplicationDbContext _context;
        public Course2Controller()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        /// Edits a particular course
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        public ActionResult Edit(int Id)
        {
            var Course = _context.Courses.SingleOrDefault(c => c.Id == Id);
            if (Course == null)
                return HttpNotFound();
            var ViewModel = new CourseFormViewModel
            {
                Course = Course,
                CourseDifficultyLevels = _context.CourseDifficultyLevels.ToList()
            };
            return View("EditCourseForm", ViewModel);
        }
        /// <summary>
        /// Saves the edited course in the database
        /// </summary>
        /// <param name="course">Course object with all the course fields</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(Course course)
        {
            var CourseInDb = _context.Courses.Single(c => c.Id == course.Id);
            CourseInDb.Name = course.Name;
            CourseInDb.Category = course.Category;
            CourseInDb.InstructorName = course.InstructorName;
            CourseInDb.Price = course.Price;
            CourseInDb.CourseDifficultyLevelId = course.CourseDifficultyLevelId;
            _context.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}