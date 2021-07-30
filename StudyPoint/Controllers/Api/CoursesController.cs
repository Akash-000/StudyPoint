using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyPoint.Models;
using StudyPoint.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace StudyPoint.Controllers.Api
{
    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    [Authorize(Roles = "CanManageCourseAndCustomer")]
    public class CoursesController : ApiController
    {
        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/courses
        public IHttpActionResult GetCourses()
        {
            var courseDtos = _context.Courses.Include(c => c.CourseDifficultyLevel)
                .ToList().Select(Mapper.Map<Course, CourseDto>);

            return Ok(courseDtos);
        }

        //GET /api/courses/1
        public IHttpActionResult GetCourse(int id)
        {
            var course = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null)
                return NotFound();

            return Ok(Mapper.Map<Course, CourseDto>(course));
        }

        [HttpPost]
        //POST /api/courses
        public IHttpActionResult CreateCourse(CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var course = Mapper.Map<CourseDto, Course>(courseDto);
            _context.Courses.Add(course);
            _context.SaveChanges();
            courseDto.Id = course.Id;

            return Created(new Uri(Request.RequestUri + "/" + course.Id), courseDto);
        }

        [HttpPut]
        //PUT /api/course/1
        public void UpdateCourse(int id, CourseDto courseDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);

            if (courseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(courseDto, courseInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
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
