using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        BookDataEntities db = new BookDataEntities();
        // GET: Home
        public ActionResult Index()
        {
            var BookData = db.tBookData.OrderBy(m => m.BOOK_ID).ToList();
            return View(BookData);
        }

        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Create(tBookData vBookData)
        {
            db.tBookData.Add(vBookData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int BOOK_ID)
        {
            var BookData = db.tBookData.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            db.tBookData.Remove(BookData);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int BOOK_ID)
        {
            var BookData = db.tBookData.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            return View(BookData);
        }

        [HttpPost]
        public ActionResult Edit(tBookData vBookData)
        {
            int BOOK_ID = vBookData.BOOK_ID;
            var BookData = db.tBookData.Where(m => m.BOOK_ID == BOOK_ID).FirstOrDefault();
            BookData.BOOK_NAME = vBookData.BOOK_NAME;
            BookData.BOOK_AUTHOR = vBookData.BOOK_AUTHOR;
            BookData.BOOK_BOUGHT_DATE = vBookData.BOOK_BOUGHT_DATE;
            BookData.BOOK_CLASS_ID = vBookData.BOOK_CLASS_ID;
            BookData.BOOK_KEEPER = vBookData.BOOK_KEEPER;
            BookData.BOOK_NOTE = vBookData.BOOK_NOTE;
            BookData.BOOK_PUBLISHER = vBookData.BOOK_PUBLISHER;
            BookData.BOOK_STATUS = vBookData.BOOK_STATUS;
            BookData.CREATE_DATE = vBookData.CREATE_DATE;
            BookData.CREATE_USER = vBookData.CREATE_USER;
            BookData.MODIFY_DATE = vBookData.MODIFY_DATE;
            BookData.MODIFY_USER = vBookData.MODIFY_USER;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}