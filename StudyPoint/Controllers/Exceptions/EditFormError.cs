using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyPoint.Controllers
{
    public class EditFormError : Exception
    {
        public string FormErrorPath()
        {
            return "~/Views/Exception/EditFormError.cshtml";
        }
    }
}