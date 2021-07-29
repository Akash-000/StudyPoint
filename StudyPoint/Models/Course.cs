using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudyPoint.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Price")]
        public int Price { get; set; }

        [Display(Name ="Instructor Name")]
        public string InstructorName { get; set; }

        [Required]
        [Display(Name ="Category")]
        public string Category { get; set; }

        public CourseDifficultyLevel CourseDifficultyLevel { get; set; }

        [Display(Name = "Difficulty")]
        [Required]
        public int CourseDifficultyLevelId { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}