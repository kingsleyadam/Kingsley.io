using Kingsley.io.Models;
using Kingsley.io.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingsley.io.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }
        
        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactSubmit cSubmit)
        {
            if (ModelState.IsValid)
            {
                cSubmit.SubmitDate = DateTime.Now;
                db.ContactSubmits.Add(cSubmit);
                db.SaveChanges();

                if (!System.Web.HttpContext.Current.IsDebuggingEnabled)
                { 
                    SendEmailService es = new SendEmailService();
                    es.SendOneEmail(cSubmit.Email, "adam@kingsley.io", "Kingsley.io - Contact Form Submission", cSubmit.Name + " (" + cSubmit.Email + ") has submited the contact form on Kingsley.io. <br /><br /><strong>Message:</strong>" + cSubmit.Message, true);
                }
            }

            return PartialView("_ContactThanks");
        }
    }
}