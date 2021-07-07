using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LockStep.Library.Domain;
using LockStep.Library.Domain.DTO.Common;
using LockStepNew.Models;

namespace LockStepNew.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            List<Book> books = db.Books.ToList();
            return View(books.Select(b => new CreateBookVM() { Name=b.Name}));
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            CreateBookVM viewModel = new CreateBookVM { Name = book.Name };
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] CreateBookVM book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(new Book() {Name=book.Name});
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);

            CreateBookVM viewModel = new CreateBookVM() { Name = book.Name };
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Books/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name")] CreateBookVM book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new Book() { Name=book.Name}).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            CreateBookVM viewModel = new CreateBookVM() { Name = book.Name };
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        // POST: Books/Delete/5
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
