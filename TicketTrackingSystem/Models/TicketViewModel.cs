using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrackingSystem.Models
{
    public class TicketViewModel
    {
        public Ticket Ticket { get; set; }
        public User User { get; set; }
        public string UserRole { get; set; }
        public int TicketID { get; set; }
        public int SortBy { get; set; }
        public IEnumerable<Models.Ticket> Tickets { get; set; }
    }
}