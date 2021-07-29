using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using StudyPoint.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    [Authorize(Roles = "CanManageCourseAndCustomer")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        /// <summary>
        /// Details of a particular User/Customer
        /// </summary>
        /// <param name="Id">Id of a User</param>
        /// <returns>View</returns>
        public ActionResult Details(string Id)
        {
            ApplicationUser Customer = _context.Users.SingleOrDefault(c => c.Id == Id);
            return View(Customer);
        }
        /// <summary>
        /// All the users in the database
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            IEnumerable<ApplicationUser> Customer = _context.Users.ToList();
            return View(Customer);
        }
    }
}