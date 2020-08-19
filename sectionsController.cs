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
    public class sectionsController : Controller
    {
        private SUPPORT_SYSTEMEntities db = new SUPPORT_SYSTEMEntities();

        // GET: sections
        public ActionResult Index()
        {
            var sections = db.sections.Include(s => s.user);
            return View(sections.ToList());
        }

      
        public ActionResult Deleted()
        {
            var sections = db.sections.Where(u => u.active != true);
            return View(sections.ToList());
        }


        // GET: sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: sections/Create
        public ActionResult Create()
        {
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name");
            return View("Create2");

        }

        // POST: sections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_sections,section_name,description,ID_user, active")] section section)
        {
            if (ModelState.IsValid)
            {
                db.sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", section.ID_user);
            return View(section);
        }

        // GET: sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", section.ID_user);
            return View(section);
        }

        // POST: sections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_sections,section_name,description,ID_user, active")] section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", section.ID_user);
            return View(section);
        }

        // GET: sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section section = db.sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            section section = db.sections.Find(id);
            db.sections.Remove(section);
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
