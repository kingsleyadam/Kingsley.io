using Kingsley.io.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Kingsley.io.Controllers
{
    [Authorize]
    public class KingsleyAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: KingsleyAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: KingsleyAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var kingsleyAccount = db.KingsleyAccounts.Where(c => c.ApplicationUserID == userId).First();
            return View(kingsleyAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsForAdmin(int id)
        {
            var kingsleyAccount = db.KingsleyAccounts.Find(id);

            return View("Details", kingsleyAccount);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            return View(db.KingsleyAccounts.ToList());
        }

        // GET: KingsleyAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KingsleyAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KingsleyAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KingsleyAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: KingsleyAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KingsleyAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
