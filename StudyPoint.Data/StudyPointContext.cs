using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudyPoint.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace StudyPoint.Data
{
    public class StudyPointUsers : IdentityUser
    {
        [StringLength(255)]
        public string Address { get; set; }


        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^(\d{10})$")]
        public string MobileNumber { get; set; }

        public string Occupation { get; set; }
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<StudyPointUsers> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }





    public class StudyPointContext : IdentityDbContext<StudyPointUsers>
    {

        public StudyPointContext()
        : base("StudyPointConnection")
        {

        }
        public static StudyPointContext Create()
        {
            return new StudyPointContext();
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseDifficultyLevel> CourseDifficultyLevels { get; set; }
        public DbSet<FeedbackMsg> FeedbackMsgs { get; set; }
        public DbSet<DiscussionBoardModel> DiscussionBoardModels { get; set; }
    }
}
