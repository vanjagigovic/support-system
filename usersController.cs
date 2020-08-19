using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SUPORT_SYSTEM.Models;

namespace SUPORT_SYSTEM.Controllers
{
    public class usersController : Controller
    {
        private SUPPORT_SYSTEMEntities db = new SUPPORT_SYSTEMEntities();

        // GET: users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.country).Include(u => u.role);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            ViewBag.ID_country = new SelectList(db.countries, "ID_country", "country");
            ViewBag.ID_user_role = new SelectList(db.roles, "ID_user_role", "role1");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_user,first_name,last_name,address,city,ID_country,phone,ID_user_role,ID_login")] user user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_country = new SelectList(db.countries, "ID_country", "country", user.ID_country);
            ViewBag.ID_user_role = new SelectList(db.roles, "ID_user_role", "role1", user.ID_user_role);
            return View(user);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_country = new SelectList(db.countries, "ID_country", "country", user.ID_country);
            ViewBag.ID_user_role = new SelectList(db.roles, "ID_user_role", "role1", user.ID_user_role);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_user,first_name,last_name,address,city,ID_country,phone,ID_user_role,ID_login")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_country = new SelectList(db.countries, "ID_country", "country", user.ID_country);
            ViewBag.ID_user_role = new SelectList(db.roles, "ID_user_role", "role1", user.ID_user_role);
            return View(user);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            user user = db.users.Find(id);
            db.users.Remove(user);
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
