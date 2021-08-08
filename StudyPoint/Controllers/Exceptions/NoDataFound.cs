using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoint.Controllers
{
    public class NoDataFound : Exception
    {
        public string NoDataFoundPath()
        {
            return "~/Views/Exception/NoData.cshtml";
        }
    }
}