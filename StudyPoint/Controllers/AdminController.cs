using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StudyPoint.Data;
using StudyPoint.Services;
using PagedList;
using PagedList.Mvc;

namespace StudyPoint.Controllers
{
    public class AdminController : Controller
    {
        private StudyPointContext _context;
        public AdminController()
        {
            _context = new StudyPointContext();
        }
        // GET: Admin
        /// <summary>
        /// Shows Admin Landing Page
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/FeedbackManagement
        /// <summary>
        /// Shows feedbacks to Admin
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult FeedbackManagement(int? Page)
        {
            var FeedbackServiceObj = new FeedbackServices();
            var Feedback = FeedbackServiceObj.GetFeedBacks(Page);
            try
            {
                if(Feedback.Count == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            return View(Feedback);
        }
        // GET: Admin/EnquiryManagement
        /// <summary>
        /// Get Enquiry From Admin
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult EnquiryManagement(int? Page)
        {
            //var Discussions = _context.DiscussionBoardModels.OrderByDescending(m => m.Id).Take(3).ToList();
            var EnquiryServicesObj = new EnquiryServices();
            var Discussions = EnquiryServicesObj.GetDiscussions(Page);
            try
            {
                if(Discussions.Count == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            var ViewModel = new DiscussionViewModel
            {
                Discussions = Discussions
            };
            return View(ViewModel);
        }
        // POST: Admin/EnquiryManagement
        /// <summary>
        /// Posts the enquiry of Admin to database
        /// </summary>
        /// <param name="Discussion">Contains Discussion Message and List of discussions with usernames</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EnquiryManagement(DiscussionViewModel Discussion)
        {
            if(string.IsNullOrWhiteSpace(Discussion.SingleUser.DiscussionMessage))
            {
                return RedirectToAction("EnquiryManagement","Admin");
            }

            var Msg = new DiscussionBoardModel
            {
                CustomerUserName = User.Identity.GetUserName(),
                DiscussionMessage = Discussion.SingleUser.DiscussionMessage,
                Name = HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindById(User.Identity.GetUserId()).Name,
                Occupation = HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindById(User.Identity.GetUserId()).Occupation,
                MobileNumber = HttpContext.GetOwinContext()
                        .GetUserManager<ApplicationUserManager>()
                        .FindById(User.Identity.GetUserId()).MobileNumber
            };
            //_context.DiscussionBoardModels.Add(Msg);
            //_context.SaveChanges();

            var EnquiryServicesObj = new EnquiryServices();
            EnquiryServicesObj.AddDiscussion(Msg);
            return RedirectToAction("EnquiryManagement", "Admin");
        }
        // GET: Admin/ShareFileManagement
        /// <summary>
        /// Shows list of files shared by users to Admin
        /// </summary>
        /// <returns>View</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult ShareFileManagement(int? Page)
        {
            string[] FilePaths = Directory.GetFiles(Server.MapPath("~/App_Data/UserUploadedFiles"));
            try
            {
                if(FilePaths.Length == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            List<UserSharedFileModel> Files = new List<UserSharedFileModel>();
            foreach(string FilePath in FilePaths)
            {
                Files.Add(new UserSharedFileModel { FileName = Path.GetFileName(FilePath) });
            }
            IPagedList<UserSharedFileModel> IPagedFiles =  Files.ToPagedList(Page ?? 1, 5);

            return View(IPagedFiles);
        }
        // GET: Admin/WhatsNew
        /// <summary>
        /// Shows 5 recently added course to Admin
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult WhatsNew()
        {
            //var NewData = _context.Courses.OrderByDescending(m => m.Id).Take(5).ToList();
            var CoursesServicesObj = new CoursesServices();
            var NewData = CoursesServicesObj.GetLatestFive();
            try
            {
                if (NewData.Count == 0)
                {
                    throw new NoDataFound();
                }
            }
            catch(NoDataFound exp)
            {
                return View(exp.NoDataFoundPath());
            }
            return View(NewData);
        }
    }
}