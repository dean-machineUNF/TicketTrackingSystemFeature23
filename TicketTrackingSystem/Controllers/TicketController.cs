using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketTrackingSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Data;
using System.Data.Entity;

namespace TicketTrackingSystem.Controllers
{
    public class TicketController : Controller
    {
        public TicketController()
        {

        }


        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: OpenTickets
        public ActionResult OpenTickets()
        {


            using (var db = new ApplicationDbContext())
            {
                //var ticketsList = db.Tickets2.ToList();
                Ticket tempTicket = db.Tickets2.Find(1);

                //return View(ticketsList);
                return View(tempTicket);

            }
             

                   


            
            

        }

        // GET: ClosedTickets
        public ActionResult ClosedTickets()
        {
            
            return View();
        }


        // GET: EditTicket
        public ActionResult EditTicket()
        {
            return View();
        }

        // GET: CreateTicket
        public ActionResult CreateTicket()
        {
            return View();
        }

        // GET: CloseTicket
        public ActionResult CloseTicket()
        {
            return View();
        }
    }
}