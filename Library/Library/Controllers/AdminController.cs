using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private LibraryContex db = new LibraryContex();

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Authors = db.Authors.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book, int[] idAuthors)
        {
            Book update_book = book;
            if (ModelState.IsValid)
            {
                if (idAuthors != null)
                {
                    foreach (var auth in db.Authors.Where(a => idAuthors.Contains(a.AuthorId)))
                    {
                        update_book.Authors.Add(auth);
                    }
                }
                db.Books.Add(update_book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Authors = db.Authors.ToList();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book, int[] idAuthors)
        {
            Book update_book = db.Books.Find(book.BookId);
            update_book.Name = book.Name;
            update_book.Pages = book.Pages;
            update_book.Edition = book.Edition;
            if (ModelState.IsValid)
            {
                update_book.Authors.Clear();
                if (idAuthors != null)
                {
                    foreach (var auth in db.Authors.Where(a => idAuthors.Contains(a.AuthorId)))
                    {
                        update_book.Authors.Add(auth);
                    }
                }
                db.Entry(update_book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
