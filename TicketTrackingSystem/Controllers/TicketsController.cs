using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketTrackingSystem.Models;

namespace TicketTrackingSystem.Controllers
{
    public class TicketsController : Controller
    {
      
      
        private TicketTrackingSystemContext db = new TicketTrackingSystemContext();

        // GET: Tickets/ReopenTicket/5
        public ActionResult ReopenTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ReopenConfirmed(id);
            return RedirectToAction("ResolvedTickets");
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("ReopenTicket")]
        [ValidateAntiForgeryToken]
        public ActionResult ReopenConfirmed(int? id)
        {
            Ticket ticket = db.Tickets.Find(id);
            ticket.TicketIsResolved = false;
            db.SaveChanges();
            
            return View("ResolvedTickets");
        }

        // GET: Tickets/ResolveATicket/5
        public ActionResult ResolveATicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ResolveConfirmed(id);
            return RedirectToAction("OpenTickets");
        }

        // POST: Tickets/ResolveATicket/5
       [HttpPost, ActionName("ResolveATicket")]
        [ValidateAntiForgeryToken]
        public ActionResult ResolveConfirmed(int? id)
        {
            Ticket ticket = db.Tickets.Find(id);
            ticket.TicketIsResolved = true;
            db.SaveChanges();

            return View("OpenTickets");
        }
        
       

        // GET: Tickets/ResolvedTickets
        public ActionResult ResolvedTickets(int? sortBy)
        {
            using (var db = new TicketTrackingSystemContext())
            {
                var resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).ToList();
                

                if (sortBy == 1)
                {

                        resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).OrderBy(d => d.TicketID).ToList();
                        
                                
                }

                if (sortBy == 2)
                {
                    resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).OrderBy(d => d.TicketDescription).ToList();
                }

                if (sortBy == 3)
                {
                    resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).OrderBy(d => d.TicketComment).ToList();
                }

                if (sortBy == 4)
                {
                    resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).OrderByDescending(d => d.TicketSeverity).ToList();
                }

                if (sortBy == 5)
                {
                    resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).OrderBy(d => d.TicketDateCreated).ToList();
                }

                //var resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).ToList();



                return View(resolvedTickets);
            }

            
        }

        // GET: Tickets/OpenTickets
        public ActionResult OpenTickets(int? sortBy)
        {
            using (var db = new TicketTrackingSystemContext())
            {
                var openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).ToList();

                if (sortBy == 1)
                {
                    openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).OrderBy(d => d.TicketID).ToList();
                }

                if (sortBy == 2)
                {
                    openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).OrderBy(d => d.TicketDescription).ToList();
                }

                if (sortBy == 3)
                {
                    openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).OrderBy(d => d.TicketComment).ToList();
                }

                if (sortBy == 4)
                {
                    openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).OrderByDescending(d => d.TicketSeverity).ToList();
                }

                if (sortBy == 5)
                {
                    openTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(false)).OrderBy(d => d.TicketDateCreated).ToList();
                }

                //var resolvedTickets = db.Tickets.Where(e => e.TicketIsResolved.Equals(true)).ToList();



                return View(openTickets);
            }
        }

        // GET: Tickets
        public ActionResult Home()
        {
            return View();
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,TicketDescription,TicketComment,TicketSeverity,TicketDateCreated,TicketIsResolved")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,TicketDescription,TicketComment,TicketSeverity,TicketDateCreated,TicketIsResolved")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Home");
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
