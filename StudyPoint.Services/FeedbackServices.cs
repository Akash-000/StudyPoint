using StudyPoint.Data;
using StudyPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using PagedList.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace StudyPoint.Services
{
    public class FeedbackServices
    {
        private StudyPointContext _context;
        public FeedbackServices()
        {
            _context = new StudyPointContext();
        }

        public IPagedList<FeedbackMsg> GetFeedBacks(int? Page)
        {
            return _context.FeedbackMsgs.OrderByDescending(c => c.Id).ToList().ToPagedList(Page ?? 1, 5);
        }

        public void AddFeedback(FeedbackMsg Msg)
        {
            _context.FeedbackMsgs.Add(Msg);
            _context.SaveChanges();
        }
    }
}
