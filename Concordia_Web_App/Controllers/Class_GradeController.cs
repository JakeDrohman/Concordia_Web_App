using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Concordia_Web_App.Models;

namespace Concordia_Web_App.Controllers
{
    public class Class_GradeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Class_Grade
        public ActionResult Index()
        {
            return View(db.Class_Grade.ToList());
        }

        // GET: Class_Grade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Grade class_Grade = db.Class_Grade.Find(id);
            if (class_Grade == null)
            {
                return HttpNotFound();
            }
            return View(class_Grade);
        }

        // GET: Class_Grade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class_Grade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Grade_Percentage,Passed,Failed")] Class_Grade class_Grade)
        {
            if (ModelState.IsValid)
            {
                db.Class_Grade.Add(class_Grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(class_Grade);
        }

        // GET: Class_Grade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Grade class_Grade = db.Class_Grade.Find(id);
            if (class_Grade == null)
            {
                return HttpNotFound();
            }
            return View(class_Grade);
        }

        // POST: Class_Grade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Grade_Percentage,Passed,Failed")] Class_Grade class_Grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(class_Grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(class_Grade);
        }

        // GET: Class_Grade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class_Grade class_Grade = db.Class_Grade.Find(id);
            if (class_Grade == null)
            {
                return HttpNotFound();
            }
            return View(class_Grade);
        }

        // POST: Class_Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Class_Grade class_Grade = db.Class_Grade.Find(id);
            db.Class_Grade.Remove(class_Grade);
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
