using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using StudyPoint.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using StudyPoint.Data;
using StudyPoint.Services;
using PagedList;
using PagedList.Mvc;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public class CustomerController : Controller
    {
        private StudyPointContext _context;
        public CustomerController()
        {
            _context = new StudyPointContext();
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
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string Id)
        {
            //StudyPointUsers Customer = _context.Users.SingleOrDefault(c => c.Id == Id);

            var CustomerServicesObj = new CustomerServices();
            StudyPointUsers Customer = CustomerServicesObj.GetCustomer(Id);
            try
            {
                if(Customer == null)
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
            return View(Customer);
        }
        /// <summary>
        /// All the users in the database
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index(int? Page)
        {
            //IEnumerable<StudyPointUsers> Customer = _context.Users.ToList();
            var CustomerServicesObj = new CustomerServices();
            IPagedList<StudyPointUsers> Customer = CustomerServicesObj.GetAllCustomers(Page);
            try
            {
                if(Customer == null)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            return View(Customer);
        }
    }
}