using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicketTrackingSystem.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

        // GET: OpenTickets
        public ActionResult OpenTickets()
        {
            return View();
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