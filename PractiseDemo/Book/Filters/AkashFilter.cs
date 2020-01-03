using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Filters
{
    public class AkashFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName; 
            Debug.WriteLine("/{0}/{1} is Executing",controller,method);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;
            Debug.WriteLine("/{0}/{1} is Executed", controller, method);
        }
    }
}