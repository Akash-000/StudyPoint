using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoint.Controllers
{
    public class RequestNotFound : Exception
    {
        public string RequestNotFoundPath()
        {
            return "~/Views/Exception/NoRequestFound.cshtml";
        }
    }
}