using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book.Models;
using Book.Filters;
namespace Book.Controllers
{
    [AkashFilter]
    [HandleError(ExceptionType =typeof(Exception),View ="Err" )]
    public class BookController : Controller
    {
        BookDBEntities dalObject = new BookDBEntities();
        // GET: Book
        public ActionResult Index()
        {
            return View(dalObject.Books.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book.Models.Book book)
        {
            dalObject.Books.Add(book);
            dalObject.SaveChanges();
            return Redirect("/Book/Index");
        }

        public ActionResult Edit(int id)
        {
            return View(dalObject.Books.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Book.Models.Book book )
        {
            Book.Models.Book bookToNeModified =dalObject.Books.Find(book.ISBN);
            bookToNeModified.Name = book.Name;
            bookToNeModified.Author = book.Author;
            dalObject.SaveChanges();
            return Redirect("/Book/Index");
        }

        
        public ActionResult Delete(int id)
        {
            Book.Models.Book bookToBeDeleted = dalObject.Books.Find(id);
            dalObject.Books.Remove(bookToBeDeleted);
            dalObject.SaveChanges();
            return Redirect("/Book/Index");
        }
    }
}