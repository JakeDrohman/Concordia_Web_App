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
    public class Student_Graduation_InfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Graduation_Info
        public ActionResult Index()
        {
            var student_Graduation_Info = db.Student_Graduation_Info.Include(s => s.Student);
            return View(student_Graduation_Info.ToList());
        }

        // GET: Student_Graduation_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Graduation_Info student_Graduation_Info = db.Student_Graduation_Info.Find(id);
            if (student_Graduation_Info == null)
            {
                return HttpNotFound();
            }
            return View(student_Graduation_Info);
        }

        // GET: Student_Graduation_Info/Create
        public ActionResult Create()
        {
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name");
            return View();
        }

        // POST: Student_Graduation_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Credits_Needed,Credits_Completed,Track,Withdrawn,Graduated,Dismissed,Student_Id")] Student_Graduation_Info student_Graduation_Info)
        {
            if (ModelState.IsValid)
            {
                db.Student_Graduation_Info.Add(student_Graduation_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Graduation_Info.Student_Id);
            return View(student_Graduation_Info);
        }

        // GET: Student_Graduation_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Graduation_Info student_Graduation_Info = db.Student_Graduation_Info.Find(id);
            if (student_Graduation_Info == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Graduation_Info.Student_Id);
            return View(student_Graduation_Info);
        }

        // POST: Student_Graduation_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Credits_Needed,Credits_Completed,Track,Withdrawn,Graduated,Dismissed,Student_Id")] Student_Graduation_Info student_Graduation_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Graduation_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Graduation_Info.Student_Id);
            return View(student_Graduation_Info);
        }

        // GET: Student_Graduation_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Graduation_Info student_Graduation_Info = db.Student_Graduation_Info.Find(id);
            if (student_Graduation_Info == null)
            {
                return HttpNotFound();
            }
            return View(student_Graduation_Info);
        }

        // POST: Student_Graduation_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Graduation_Info student_Graduation_Info = db.Student_Graduation_Info.Find(id);
            db.Student_Graduation_Info.Remove(student_Graduation_Info);
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
