using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.Diagnostics;
using DemoMVC.Helpers;

namespace HandsOnLab.Filters
{
    public class HOLFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;

            Logger.CurrentLogger.Log(string.Format("/{0}/{1} execution Completed.", controller, method));
            Debug.WriteLine(string.Format("/{0}/{1} execution Completed.", controller, method));
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string method = filterContext.ActionDescriptor.ActionName;

            Logger.CurrentLogger.Log(string.Format("/{0}/{1} execution is about to start.", controller, method));
            Debug.WriteLine(string.Format("/{0}/{1} execution is about to start.", controller, method));
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

            if (filterContext.Result is ViewResult)
            {
                string viewName = (filterContext.Result as ViewResult).ViewName;
                Logger.CurrentLogger.Log(string.Format("View {0} processed.", viewName));
            }
            else
            {
                Logger.CurrentLogger.Log("Redirecting............End");
            }

        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.Result is ViewResult)
            {
                string viewName = (filterContext.Result as ViewResult).ViewName;
                Logger.CurrentLogger.Log(string.Format("View {0} is about to get processed.", viewName));
            }
            else
            {
                Logger.CurrentLogger.Log("Redirecting............Start");
            }
            Debug.WriteLine("UI is about to get process");
        }
    }
}