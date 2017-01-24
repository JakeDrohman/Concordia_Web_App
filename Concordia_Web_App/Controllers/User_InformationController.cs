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
    public class User_InformationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: User_Information
        public ActionResult Index()
        {
            var user_Information = db.User_Information.Include(u => u.User);
            return View(user_Information.ToList());
        }

        // GET: User_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Information user_Information = db.User_Information.Find(id);
            if (user_Information == null)
            {
                return HttpNotFound();
            }
            return View(user_Information);
        }

        // GET: User_Information/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: User_Information/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,User_Id,First_Name,Last_Name,Middle_Initial,Alt_First_Name,Alt_Last_Name,Alt_Middle_Initial")] User_Information user_Information)
        {
            if (ModelState.IsValid)
            {
                db.User_Information.Add(user_Information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.Users, "Id", "Email", user_Information.User_Id);
            return View(user_Information);
        }

        // GET: User_Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Information user_Information = db.User_Information.Find(id);
            if (user_Information == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Email", user_Information.User_Id);
            return View(user_Information);
        }

        // POST: User_Information/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,User_Id,First_Name,Last_Name,Middle_Initial,Alt_First_Name,Alt_Last_Name,Alt_Middle_Initial")] User_Information user_Information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Email", user_Information.User_Id);
            return View(user_Information);
        }

        // GET: User_Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Information user_Information = db.User_Information.Find(id);
            if (user_Information == null)
            {
                return HttpNotFound();
            }
            return View(user_Information);
        }

        // POST: User_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Information user_Information = db.User_Information.Find(id);
            db.User_Information.Remove(user_Information);
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
