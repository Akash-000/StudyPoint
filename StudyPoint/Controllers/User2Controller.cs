using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public class User2Controller : Controller
    {
        private ApplicationDbContext _context;
        public User2Controller()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ShareFile()
        {
            return View();
        }
        /// <summary>
        /// Posts the file in User Shared Folder
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ShareFile(HttpPostedFileBase File)
        {
            if (File == null)
            {
                return View("NoFileChoosen");
            }
            string FolderPath = Server.MapPath("~/App_Data/UserUploadedFiles");
            string FileName = Path.GetFileName(File.FileName);
            string FullPath = Path.Combine(FolderPath, FileName);
            File.SaveAs(FullPath);
            return View("FileUploaded");
        }
        /// <summary>
        /// Shows previous discussions and allows User to comment
        /// </summary>
        /// <returns>View</returns>
        public ActionResult DiscussionBoard()
        {
            var Discussions = _context.DiscussionBoardModels.OrderByDescending(m => m.Id).Take(3).ToList();
            var ViewModel = new DiscussionViewModel
            {
                Discussions = Discussions
            };
            return View(ViewModel);
        }
        /// <summary>
        /// Posts the comment in the database
        /// </summary>
        /// <param name="Discussion">Contains discussion and username</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DiscussionBoard(DiscussionViewModel Discussion)
        {
            var Msg = new DiscussionBoardModel
            {
                CustomerUserName = User.Identity.GetUserName(),
                DiscussionMessage = Discussion.SingleUser.DiscussionMessage
            };
            _context.DiscussionBoardModels.Add(Msg);
            _context.SaveChanges();
            return RedirectToAction("DiscussionBoard", "User2");
        }
        /// <summary>
        /// feedback layout for the user
        /// </summary>
        /// <returns></returns>
        public ActionResult Feedback()
        {
            return View();
        }
        /// <summary>
        /// posts the feedback to the database
        /// </summary>
        /// <param name="Feedback"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Feedback(FeedbackMsg Feedback)
        {
            var Msg = new FeedbackMsg
            {
                Message = Request["Message"].ToString(),
                CustomerUserName = User.Identity.GetUserName()
            };
            _context.FeedbackMsgs.Add(Msg);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }
    }
}