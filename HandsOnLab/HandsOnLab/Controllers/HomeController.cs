using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HandsOnLab.Models;
using System.Data.Entity.Infrastructure;


namespace HandsOnLab.Controllers
{
    //[HandleError(ExceptionType =typeof(Exception),View ="Err")]
    public class HomeController : BaseController
    {
        HOLEntities dalObject = new HOLEntities();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.UName = User.Identity.Name;
            return View(dalObject.Emps.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [HandleError(ExceptionType = typeof(Exception), View = "Err")]
        public ActionResult Create(Emp emp)
        {
            if(ModelState.IsValid)
            {
                dalObject.Emps.Add(emp);
                dalObject.SaveChanges();
                return Redirect("/Home/Index");
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            Emp empToBeModified = dalObject.Emps.Find(id);
            return View(empToBeModified);
        }

        [HttpPost]
        public ActionResult Edit(Emp emp)
        {
            if (ModelState.IsValid)
            {
                Emp empToBeModified = dalObject.Emps.Find(emp.No);
                empToBeModified.Name = emp.Name;
                empToBeModified.Address = emp.Address;
                dalObject.SaveChanges();
                return Redirect("/Home/Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Emp empToBeDeleted = dalObject.Emps.Find(id);
            dalObject.Emps.Remove(empToBeDeleted);
            dalObject.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}