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
    public class Student_AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Student_Address
        public ActionResult Index()
        {
            var student_Address = db.Student_Address.Include(s => s.Student);
            return View(student_Address.ToList());
        }

        // GET: Student_Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Address student_Address = db.Student_Address.Find(id);
            if (student_Address == null)
            {
                return HttpNotFound();
            }
            return View(student_Address);
        }

        // GET: Student_Address/Create
        public ActionResult Create()
        {
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name");
            return View();
        }

        // POST: Student_Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Street_Address,Apartment,City,State,Zipcode,Student_Id")] Student_Address student_Address)
        {
            if (ModelState.IsValid)
            {
                db.Student_Address.Add(student_Address);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Address.Student_Id);
            return View(student_Address);
        }

        // GET: Student_Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Address student_Address = db.Student_Address.Find(id);
            if (student_Address == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Address.Student_Id);
            return View(student_Address);
        }

        // POST: Student_Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Street_Address,Apartment,City,State,Zipcode,Student_Id")] Student_Address student_Address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Student_Id = new SelectList(db.Students, "Id", "First_Name", student_Address.Student_Id);
            return View(student_Address);
        }

        // GET: Student_Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Address student_Address = db.Student_Address.Find(id);
            if (student_Address == null)
            {
                return HttpNotFound();
            }
            return View(student_Address);
        }

        // POST: Student_Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Address student_Address = db.Student_Address.Find(id);
            db.Student_Address.Remove(student_Address);
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
