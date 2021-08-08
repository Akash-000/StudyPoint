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
using StudyPoint.Services;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public partial class CourseController : Controller
    {
        /// <summary>
        /// Edits a particular course
        /// </summary>
        /// <param name="Id">Id of the course</param>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int Id)
        {
            //var Course = _context.Courses.SingleOrDefault(c => c.Id == Id);
            var CoursesServicesObj = new CoursesServices();
            var Course = CoursesServicesObj.GetCourse(Id);
            try
            {
                if (Course == null)
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

            var ViewModel = new CourseFormViewModel
            {
                Course = Course,
                CourseDifficultyLevels = CoursesServicesObj.GetCourseDifficulty()
            };
            return View("EditCourseForm", ViewModel);
        }
        /// <summary>
        /// Saves the edited course in the database
        /// </summary>
        /// <param name="course">Course object with all the course fields</param>
        /// <returns>View</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditCourse(Course course)
        {
            try
            {
                if(course.Name == null || course.Category == null || course.Price == 0 || course.CourseDifficultyLevelId == 0)
                {
                    throw new EditFormError();
                }
            }
            catch(EditFormError exp)
            {
                return View(exp.FormErrorPath());
            }

            var CoursesServicesObj = new CoursesServices();
            //var CourseInDb = _context.Courses.Single(c => c.Id == course.Id);
            var CourseInDb = CoursesServicesObj.GetCourse(course.Id);
            CourseInDb.Name = course.Name;
            CourseInDb.Category = course.Category;
            CourseInDb.InstructorName = course.InstructorName;
            CourseInDb.Price = course.Price;
            CourseInDb.CourseDifficultyLevelId = course.CourseDifficultyLevelId;
            //_context.SaveChanges();
            CoursesServicesObj.SaveChanges();
            return RedirectToAction("Index", "Course");
        }
    }
}