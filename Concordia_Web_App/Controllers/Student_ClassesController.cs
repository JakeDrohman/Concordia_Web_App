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
    public class Student_ClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Classes
        public ActionResult Index()
        {
            var student_Classes = db.Student_Classes.Include(s => s.Class_Grade).Include(s => s.Course_Class).Include(s => s.Student);
            return View(student_Classes.ToList());
        }

        // GET: Student_Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Classes student_Classes = db.Student_Classes.Find(id);
            if (student_Classes == null)
            {
                return HttpNotFound();
            }
            return View(student_Classes);
        }

        // GET: Student_Classes/Create
        public ActionResult Create()
        {
            ViewBag.Class_Grade_Id = new SelectList(db.Class_Grade, "Id", "Id");
            ViewBag.Course_Class_Id = new SelectList(db.Course_Class, "Id", "Professor_Id");
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name");
            return View();
        }

        // POST: Student_Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_Class_Id,Student_Id,Class_Grade_Id")] Student_Classes student_Classes)
        {
            if (ModelState.IsValid)
            {
                db.Student_Classes.Add(student_Classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Class_Grade_Id = new SelectList(db.Class_Grade, "Id", "Id", student_Classes.Class_Grade_Id);
            ViewBag.Course_Class_Id = new SelectList(db.Course_Class, "Id", "Professor_Id", student_Classes.Course_Class_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Classes.Student_Id);
            return View(student_Classes);
        }

        // GET: Student_Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Classes student_Classes = db.Student_Classes.Find(id);
            if (student_Classes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Class_Grade_Id = new SelectList(db.Class_Grade, "Id", "Id", student_Classes.Class_Grade_Id);
            ViewBag.Course_Class_Id = new SelectList(db.Course_Class, "Id", "Professor_Id", student_Classes.Course_Class_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Classes.Student_Id);
            return View(student_Classes);
        }

        // POST: Student_Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Class_Id,Student_Id,Class_Grade_Id")] Student_Classes student_Classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Class_Grade_Id = new SelectList(db.Class_Grade, "Id", "Id", student_Classes.Class_Grade_Id);
            ViewBag.Course_Class_Id = new SelectList(db.Course_Class, "Id", "Professor_Id", student_Classes.Course_Class_Id);
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Classes.Student_Id);
            return View(student_Classes);
        }

        // GET: Student_Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Classes student_Classes = db.Student_Classes.Find(id);
            if (student_Classes == null)
            {
                return HttpNotFound();
            }
            return View(student_Classes);
        }

        // POST: Student_Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Classes student_Classes = db.Student_Classes.Find(id);
            db.Student_Classes.Remove(student_Classes);
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
