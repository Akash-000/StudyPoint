using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyPoint.Models;
using PagedList;

namespace StudyPoint.ViewModels
{
    public class DiscussionViewModel
    {
        public IPagedList<DiscussionBoardModel> Discussions { get; set; }
        public DiscussionBoardModel SingleUser { get; set; }
    }
}