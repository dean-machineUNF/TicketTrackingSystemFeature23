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
    public class UsersController : Controller
    {
        private TicketTrackingSystemContext db = new TicketTrackingSystemContext();

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,UserEmail,Password,UserRole")] User user)
        {
            if (ModelState.IsValid)
            {
                // db. .Add(ticket);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}