using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyPoint.Models;
using AutoMapper;
using System.Data.Entity;
using StudyPoint.Data;

namespace StudyPoint.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private StudyPointContext _context;
        public CoursesController()
        {
            _context = new StudyPointContext();
        }

        [Authorize(Roles = "Admin")]
        //GET /api/courses
        public IHttpActionResult GetCourses()
        {
            var courseDtos = _context.Courses.Include(c => c.CourseDifficultyLevel)
                .ToList();

            return Ok(courseDtos);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        //DELETE /api/courses/1
        public void DeleteCourse(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
        }
    }
}
