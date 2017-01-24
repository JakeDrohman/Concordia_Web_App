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
    public class Course_ClassController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Course_Class
        public ActionResult Index()
        {
            var course_Class = db.Course_Class.Include(c => c.Alt_Professor).Include(c => c.Course).Include(c => c.Professor);
            return View(course_Class.ToList());
        }

        // GET: Course_Class/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Class course_Class = db.Course_Class.Find(id);
            if (course_Class == null)
            {
                return HttpNotFound();
            }
            return View(course_Class);
        }

        // GET: Course_Class/Create
        public ActionResult Create()
        {
            ViewBag.Alt_Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            ViewBag.Course_Id = new SelectList(db.Courses, "Id", "Course_Name");
            ViewBag.Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Course_Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course_Id,Professor_Id,Alt_Professor_Id")] Course_Class course_Class)
        {
            if (ModelState.IsValid)
            {
                db.Course_Class.Add(course_Class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alt_Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Alt_Professor_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Id", "Course_Name", course_Class.Course_Id);
            ViewBag.Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Professor_Id);
            return View(course_Class);
        }

        // GET: Course_Class/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Class course_Class = db.Course_Class.Find(id);
            if (course_Class == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alt_Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Alt_Professor_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Id", "Course_Name", course_Class.Course_Id);
            ViewBag.Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Professor_Id);
            return View(course_Class);
        }

        // POST: Course_Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course_Id,Professor_Id,Alt_Professor_Id")] Course_Class course_Class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alt_Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Alt_Professor_Id);
            ViewBag.Course_Id = new SelectList(db.Courses, "Id", "Course_Name", course_Class.Course_Id);
            ViewBag.Professor_Id = new SelectList(db.ApplicationUsers, "Id", "Email", course_Class.Professor_Id);
            return View(course_Class);
        }

        // GET: Course_Class/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Class course_Class = db.Course_Class.Find(id);
            if (course_Class == null)
            {
                return HttpNotFound();
            }
            return View(course_Class);
        }

        // POST: Course_Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Class course_Class = db.Course_Class.Find(id);
            db.Course_Class.Remove(course_Class);
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
