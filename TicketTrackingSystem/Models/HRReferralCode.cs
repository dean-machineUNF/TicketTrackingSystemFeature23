using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketTrackingSystem.Models
{
    public class HRReferralCode
    {

       [Key]
       public int Code { get; set; }

        
        public string Role { get; set; }
    }
}