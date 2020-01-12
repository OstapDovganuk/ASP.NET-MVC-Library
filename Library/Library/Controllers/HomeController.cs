using Library.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Library.Controllers
{
    public class HomeController : Controller
    {

        LibraryContex LibraryDB = new LibraryContex();
        //Метод Index виводить всі книги 
        //також він виконує сортування по назві книги, якщо нажати на посилання "Назва книжки" у таблиці
        public ActionResult Index(string sort)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sort) ? "name" : "";
            if (String.IsNullOrEmpty(sort))
            {
                var books = LibraryDB.Books.Include(a => a.Authors).ToList();
                ViewBag.Books = books;
            }
            else
            {
                var books = LibraryDB.Books.Include(a => a.Authors).ToList().OrderBy(s => s.Name);
                ViewBag.Books = books;
            }
            return View();
        }

        //Виконуємо пошук всіх книг автора, якого ми задаємо у стрічці пошуку
        [HttpPost]
        public ActionResult BookSearch(string name)
        {
            var books = LibraryDB.Books.ToList();
            var author = LibraryDB.Authors.ToList();
            name = name.Replace(" ", "").ToLower();

            if (!String.IsNullOrEmpty(name))
            {
                books = books.Where(s => s.Name.ToLower().Contains(name)).ToList();
                author = author.Where(s => s.FirstName.ToLower().Contains(name) || s.LastName.ToLower().Contains(name)).ToList();
                foreach (var t in author)
                {
                    books.AddRange(t.Books.ToList());
                }
            }
            return PartialView(books.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                LibraryDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}