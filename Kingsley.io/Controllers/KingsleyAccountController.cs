using Kingsley.io.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingsley.io.Controllers
{
    public class KingsleyAccountController : Controller
    {
        // GET: KingsleyAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: KingsleyAccount/Details/5
        public ActionResult Details()
        {
            var kingsleyAccount = new KingsleyAccount { FirstName = "Adam", LastName = "Kingsley", JoinDate = DateTime.Now };
            return View(kingsleyAccount);
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
