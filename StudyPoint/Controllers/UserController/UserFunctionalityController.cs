using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyPoint.Models;
using System.Data.Entity;
using System.IO;
using StudyPoint.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using StudyPoint.Services;

namespace StudyPoint.Controllers
{

    [HandleError(ExceptionType = typeof(Exception), View = "ExceptionView")]
    public partial class UserController : Controller
    {
        /// <summary>
        /// Share file view
        /// </summary>
        /// <returns></returns>
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
            try
            {
                if (File == null || File.ContentLength == 0)
                {
                    throw new FileNotFoundException();
                }
            }
            catch(FileNotFoundException exp)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(exp);
                return View("NoFileChoosen");
            }
            string FolderPath = Server.MapPath("~/App_Data/UserUploadedFiles");
            if(!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            string FileName = Path.GetFileName(File.FileName);
            string FullPath = Path.Combine(FolderPath, FileName);
            File.SaveAs(FullPath);
            return View("FileUploaded");
        }
        /// <summary>
        /// Shows previous discussions and allows User to comment
        /// </summary>
        /// <returns>View</returns>
        public ActionResult DiscussionBoard(int? Page)
        {
            var DiscussionBoardServicesObj = new DiscussionBoardServices();
            var Discussions = DiscussionBoardServicesObj.GetDiscussions(Page);
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
            if (string.IsNullOrWhiteSpace(Discussion.SingleUser.DiscussionMessage))
            {
                return RedirectToAction("DiscussionBoard", "User");
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
            var DiscussionBoardServicesObj = new DiscussionBoardServices();
            DiscussionBoardServicesObj.AddDiscussion(Msg);
            return RedirectToAction("DiscussionBoard", "User");
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
            if(string.IsNullOrWhiteSpace(Feedback.Message))
            {
                return RedirectToAction("Feedback", "User");
            }

            var Msg = new FeedbackMsg
            {
                Message = Request["Message"].ToString(),
                CustomerUserName = User.Identity.GetUserName(),
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
            //_context.FeedbackMsgs.Add(Msg);
            //_context.SaveChanges();
            var FeedbackServicesObj = new FeedbackServices();
            FeedbackServicesObj.AddFeedback(Msg);
            return RedirectToAction("Index", "User");
        }
    }
}