using PagedList;
using StudyPoint.Data;
using StudyPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPoint.Services
{
    public class EnquiryServices
    {
        StudyPointContext _context;
        public EnquiryServices()
        {
            _context = new StudyPointContext();
        }

        public IPagedList<DiscussionBoardModel> GetDiscussions(int? Page)
        {
            return _context.DiscussionBoardModels.OrderByDescending(m => m.Id).ToList().ToPagedList(Page ?? 1, 3);
        }

        public void AddDiscussion(DiscussionBoardModel Msg)
        {
            _context.DiscussionBoardModels.Add(Msg);
            _context.SaveChanges();
        }
    }
}
