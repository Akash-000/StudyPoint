using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyPoint.Models;

namespace StudyPoint.ViewModels
{
    public class CourseFormViewModel
    {
        public IEnumerable<CourseDifficultyLevel> CourseDifficultyLevels { get; set; }
        public Course Course { get; set; }
    }
}