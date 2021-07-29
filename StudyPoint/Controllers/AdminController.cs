using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    [Authorize(Roles = "CanManageCourseAndCustomer")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin
        /// <summary>
        /// Shows Admin Landing Page
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }
        // GET: Admin/FeedbackManagement
        /// <summary>
        /// Shows feedbacks to Admin
        /// </summary>
        /// <returns>View</returns>
        public ActionResult FeedbackManagement()
        {
            var Feedback = _context.FeedbackMsgs.ToList();
            return View(Feedback);
        }
        // GET: Admin/EnquiryManagement
        /// <summary>
        /// Get Enquiry From Admin
        /// </summary>
        /// <returns>View</returns>
        public ActionResult EnquiryManagement()
        {
            var Discussions = _context.DiscussionBoardModels.OrderByDescending(m => m.Id).Take(3).ToList();
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
        public ActionResult EnquiryManagement(DiscussionViewModel Discussion)
        {
            var Msg = new DiscussionBoardModel
            {
                CustomerUserName = User.Identity.GetUserName(),
                DiscussionMessage = Discussion.SingleUser.DiscussionMessage
            };
            _context.DiscussionBoardModels.Add(Msg);
            _context.SaveChanges();
            return RedirectToAction("EnquiryManagement", "Admin");
        }
        // GET: Admin/ShareFileManagement
        /// <summary>
        /// Shows list of files shared by users to Admin
        /// </summary>
        /// <returns>View</returns>
        public ActionResult ShareFileManagement()
        {
            string[] FilePaths = Directory.GetFiles(Server.MapPath("~/App_Data/UserUploadedFiles"));
            List<UserSharedFileModel> Files = new List<UserSharedFileModel>();
            foreach(string FilePath in FilePaths)
            {
                Files.Add(new UserSharedFileModel { FileName = Path.GetFileName(FilePath) });
            }
            return View(Files);
        }
        // GET: Admin/WhatsNew
        /// <summary>
        /// Shows 5 recently added course to Admin
        /// </summary>
        /// <returns></returns>
        public ActionResult WhatsNew()
        {
            var NewData = _context.Courses.OrderByDescending(m => m.Id).Take(5).ToList();
            return View(NewData);
        }
    }
}