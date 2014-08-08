using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NumbersSite.Models;
using NumbersSite.DAL;

namespace NumbersSite.Controllers
{
    public class NumbersController : Controller
    {
        private NumbersContext db = new NumbersContext();

        // GET: /Numbers/
        public ActionResult Index()
        {
            return View(db.Numbers.ToList());
        }

        // GET: /Numbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numbers numbers = db.Numbers.Find(id);
            if (numbers == null)
            {
                return HttpNotFound();
            }
            return View(numbers);
        }

        // GET: /Numbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Numbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Value,isPrime")] Numbers numbers)
        {
            if (ModelState.IsValid)
            {
                db.Numbers.Add(numbers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(numbers);
        }

        // GET: /Numbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numbers numbers = db.Numbers.Find(id);
            if (numbers == null)
            {
                return HttpNotFound();
            }
            return View(numbers);
        }

        // POST: /Numbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Value,isPrime")] Numbers numbers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numbers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(numbers);
        }

        // GET: /Numbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numbers numbers = db.Numbers.Find(id);
            if (numbers == null)
            {
                return HttpNotFound();
            }
            return View(numbers);
        }

        // POST: /Numbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Numbers numbers = db.Numbers.Find(id);
            db.Numbers.Remove(numbers);
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
