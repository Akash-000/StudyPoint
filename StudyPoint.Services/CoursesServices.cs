using StudyPoint.Data;
using StudyPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace StudyPoint.Services
{
    public class CoursesServices
    {
        StudyPointContext _context;
        public CoursesServices()
        {
            _context = new StudyPointContext();
        }

        public List<Course> GetLatestFive()
        {
            return _context.Courses.OrderByDescending(m => m.Id).Take(5).ToList();
        }

        public Course GetCourse(int Id)
        {
            return _context.Courses.Include(c => c.CourseDifficultyLevel).SingleOrDefault(c => c.Id == Id);
        }
        public IPagedList<Course> GetAllCourses(int? Page)
        {
            return _context.Courses.ToList().ToPagedList(Page ?? 1, 5);
        }

        public List<CourseDifficultyLevel> GetCourseDifficulty()
        {
            return _context.CourseDifficultyLevels.ToList();
        }

        public void AddCourse(Course CourseInMemory)
        {
            _context.Courses.Add(CourseInMemory);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
