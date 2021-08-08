using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoint.Controllers
{
    public class NewFormError : Exception
    {
        public string FormErrorPath()
        {
            return "~/Views/Exception/NewFormError.cshtml";
        }
    }
}