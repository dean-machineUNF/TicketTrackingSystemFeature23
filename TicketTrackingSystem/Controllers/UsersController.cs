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

        // GET: Users/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Users/Index
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserEmail,Password")] User user)
        {

            bool found = false;
            User userFound = new User();
            string userFoundRole = "";

            if (user.UserEmail == null || user.Password == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            var lastUsersTableEntry = db.Users.OrderByDescending(p => p.UserID).FirstOrDefault();
            string lastUsersTableEntryIDString = lastUsersTableEntry.UserID.ToString();
            int lastUsersTableEntryID = Convert.ToInt32(lastUsersTableEntryIDString);

            for (int i = 1; i <= lastUsersTableEntryID; i++)
            {

                User tempUser = db.Users.SingleOrDefault(m => m.UserID == i);
                if (tempUser != null)
                {


                    if (tempUser.UserEmail.Equals(user.UserEmail))
                    {
                        if(tempUser.Password.Equals(user.Password))
                        {
                            userFound = db.Users.SingleOrDefault(m => m.UserID == i);
                            found = true;
                        }
                    }
                }
            }

            if (found)
            {
                
               userFoundRole = userFound.UserRole;
               return RedirectToAction("LoginConfirmed", userFound); 
            }
            else
            {
                return RedirectToAction("LoginFailed", user);
            }
            
            
        }

        // GET: Users/LoginRedirect
        public ActionResult LoginRedirect(User user)
        {


            if (user.UserRole.Equals("USER"))
            {
                return RedirectToAction("LandingPage", "Tickets", user);
            }
            else if (user.UserRole.Equals("ADMIN"))
            {
                return RedirectToAction("LandingPageAdmin", "Tickets", user);
            }
            else
            {
                return RedirectToAction("RedirectFailed");
            }
            
        }



        // GET: Users/RedirectFailed
        public ActionResult RedirectFailed()
        {


            return View();
        }

        // GET: Users/LoginConfirmed
        public ActionResult LoginConfirmed(User user)
        {
            User thisUser = new User();
            thisUser = user;

            return RedirectToAction("LoginRedirect", thisUser);
        }

        // GET: Users/LoginFailed
        public ActionResult LoginFailed(User failedLoginUser)
        {


            return View(failedLoginUser);
        }



        // GET: Users/Register
        public ActionResult Register()
        {
            return View();
        }


        // GET: Users/Register
        public ActionResult RegistrationFailed()
        {
            return View();
        }


        // POST: Users/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,UserEmail,Password,UserRole")] User user)
        {
            if (ModelState.IsValid)
            {
                int tempHRReferralCode = Convert.ToInt32(user.UserRole);
                
                
                HRReferralCode verifiedHRReferralCode = db.HRReferralCodes.SingleOrDefault(e => e.Code == tempHRReferralCode);
                if (verifiedHRReferralCode != null)
                {
                    if (verifiedHRReferralCode.Role == "ADMIN")
                    {
                        user.UserRole = "ADMIN";
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else if (verifiedHRReferralCode.Role == "USER")
                    {
                        user.UserRole = "USER";
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        RegistrationFailed();
                    }
                }
                else
                {
                    RegistrationFailed();
                }
              
            }
            
            return RedirectToAction("RegistrationFailed");
        }
    }
}