using Kingsley.io.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingsley.io.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Splash()
        {
            return View();
        }

        public ActionResult Links()
        {
            return View();
        }

        public ActionResult _Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult _Contact(ContactSubmit cSubmit)
        {
            if (ModelState.IsValid)
            {
                cSubmit.SubmitDate = DateTime.Now;
                db.ContactSubmits.Add(cSubmit);
                db.SaveChanges();
                ViewBag.Success = "1";
            }

            return PartialView();
        }
    }
}