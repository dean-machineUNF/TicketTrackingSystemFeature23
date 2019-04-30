using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrackingSystem.Models
{
    public class Ticket
    {

        public int TicketID { get; set; }
        public string TicketDescription { get; set; }
        public string TicketComment { get; set; }
        public string TicketSeverity { get; set; }
        public DateTime TicketDateCreated { get; set; }
        public Boolean TicketIsResolved { get; set; }


    }

}