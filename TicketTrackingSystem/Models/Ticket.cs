using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketTrackingSystem.Models
{
    public class Ticket
    {
        [DisplayName("ID")]
        public int TicketID { get; set; }

        [DisplayName("Description")]
        public string TicketDescription { get; set; }

        [DisplayName("Comment")]
        public string TicketComment { get; set; }

        [DisplayName("Severity")]
        public string TicketSeverity { get; set; }

        [DisplayName("Date Created"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TicketDateCreated { get; set; }

        [DisplayName("Is Resolved?")]
        public Boolean TicketIsResolved { get; set; }



    }

    public enum Severity
    {
        Low,
        Moderate,
        Urgent 
    }

}