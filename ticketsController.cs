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
    public class ticketsController : Controller
    {
        private SUPPORT_SYSTEMEntities db = new SUPPORT_SYSTEMEntities();

        // GET: tickets

        public ActionResult Closed()
        {
            var tickets = db.tickets.Include(t => t.comments).Include(t => t.severity).Include(t => t.status).Include(t => t.user).Where(u => u.ID_status == 2);
            return View(tickets.ToList());
        }
        public ActionResult Index()
        {
            var tickets = db.tickets.Include(t => t.comments).Include(t => t.severity).Include(t => t.status).Include(t => t.user);
            return View(tickets.ToList());
        }

        // GET: tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: tickets/Create
        public ActionResult Create()
        {
            ViewBag.ID_comments = new SelectList(db.comments, "ID_comments", "posted_by");
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "title");
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name");
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name");
            return View("Create");
        }

        // POST: tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ticket,ID_suggestion,title,ID_status,category,ID_severity,priority,ID_user,raised_on,due_on,resolved_on,created_by,created_on,system_section,steps_to_reproduce,resolve_note,ID_comments")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "title", ticket.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", ticket.ID_status);
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", ticket.ID_user);
            return View(ticket);
        }

        // GET: tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "title", ticket.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", ticket.ID_status);
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", ticket.ID_user);
            return View(ticket);
        }

        // POST: tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ticket,ID_suggestion,title,ID_status,category,ID_severity,priority,ID_user,raised_on,due_on,resolved_on,created_by,created_on,system_section,steps_to_reproduce,resolve_note,ID_comments")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ID_severity = new SelectList(db.severities, "ID_severity", "title", ticket.ID_severity);
            ViewBag.ID_status = new SelectList(db.status, "ID_status", "name", ticket.ID_status);
            ViewBag.ID_user = new SelectList(db.users, "ID_user", "first_name", ticket.ID_user);
            return View(ticket);
        }

        // GET: tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }
        

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ticket ticket = db.tickets.Find(id);
            db.tickets.Remove(ticket);
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
