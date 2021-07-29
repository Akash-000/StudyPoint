using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using StudyPoint.Models;

namespace StudyPoint.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }
        
        public string InstructorName { get; set; }

        [Required]
        public string Category { get; set; }

        public CourseDifficultyLevelDto CourseDifficultyLevel { get; set; }

        [Required]
        public int CourseDifficultyLevelId { get; set; }
    }
}