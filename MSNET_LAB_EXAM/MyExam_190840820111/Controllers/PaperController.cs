using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyExam_190840820111.Models;
using MyExam_190840820111.Filters;

namespace MyExam_190840820111.Controllers
{
    [PaperFilter]
    public class PaperController : Controller
    {
        MyExamDBEntities1 dalObject = new MyExamDBEntities1();
        
        public ActionResult PaperList()
        {
            
            return View(dalObject.NewsPaperTbls.ToList());
        }

        public ActionResult EditResult()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View(dalObject.NewsPaperTbls.Find(id));
        }

        
        [HttpPost]
        public ActionResult Edit(NewsPaperTbl newpaper)
        {
            try
            {
                NewsPaperTbl paperToBeModified = dalObject.NewsPaperTbls.Find(newpaper.PaperId);
                paperToBeModified.PaperName = newpaper.PaperName;
                paperToBeModified.Price = newpaper.Price;
                paperToBeModified.TotalNoOfReaders = newpaper.TotalNoOfReaders;
                paperToBeModified.EditorName = newpaper.EditorName;
                dalObject.SaveChanges();
                
                
                return Redirect("/Paper/EditResult");
            }
            catch
            {
                ViewBag.message = "Something Went wrong ...try Again";
                return View();
            }
        }

        
    }
}
