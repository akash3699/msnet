using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandsOnLab.Models;
using System.Web.Security;
using HandsOnLab.Filters;

namespace HandsOnLab.Controllers
{
    [HOLFilter]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(HOLUser user,string ReturnUrl)
        {
            
            if (CheckUserInDB(user))
            {
                FormsAuthentication.SetAuthCookie(user.UName, false);
                if (ReturnUrl!=null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return Redirect("/Home/Index");
                }
            }
            else
            {
                ViewBag.Message = "UserName / Password is incorrect";
                return View(user);
            }
            
        }

        private bool CheckUserInDB(HOLUser user)
        {
            return (user.UName == "abc" && user.Password == "abc@123");
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}