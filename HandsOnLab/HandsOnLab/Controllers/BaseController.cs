using HandsOnLab.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandsOnLab.Controllers
{
    [Authorize]
    [HOLFilter]
    //[HandleError(ExceptionType = typeof(Exception), View = "Err")]
    public class BaseController : Controller
    {
        
    }
}