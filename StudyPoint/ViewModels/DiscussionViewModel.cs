using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyPoint.Models;

namespace StudyPoint.ViewModels
{
    public class DiscussionViewModel
    {
        public List<DiscussionBoardModel> Discussions { get; set; }
        public DiscussionBoardModel SingleUser { get; set; }
    }
}