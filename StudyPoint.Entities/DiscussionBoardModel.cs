using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudyPoint.Models
{
    public class DiscussionBoardModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name ="Your Thoughts")]
        public string DiscussionMessage { get; set; }
        public string CustomerUserName { get; set; }
        public string Name { get; set; }
        public string  Occupation { get; set; }
        public string MobileNumber { get; set; }
    }
}