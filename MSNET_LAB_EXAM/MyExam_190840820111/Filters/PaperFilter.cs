using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace MyExam_190840820111.Filters
{
    public class PaperFilter:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;
            string datetime = DateTime.Now.ToString();
            string logstr = string.Format("Logged on {0}: /{1}/{2} is Executing", datetime, controller, method);
            Debug.WriteLine(logstr);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;
            string datetime = DateTime.Now.ToString();
            string logstr = string.Format("Logged on {0}: /{1}/{2} is Executed", datetime, controller, method);
            Debug.WriteLine(logstr);
        }
    }
}