using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketTrackingSystem.Models
{
    public class User
    {
        
        public int UserID { get; set; }

        
        public string UserEmail { get; set; }

        public string Password { get; set; }
        
        public string UserRole { get; set; }

    }
}