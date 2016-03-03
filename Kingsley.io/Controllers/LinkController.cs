using Kingsley.io.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kingsley.io.Controllers
{
    public class LinkController : Controller
    {
        // GET: Link
        public ActionResult Index()
        {
            return View();
        }

        // GET: Link/Details/5
        public ActionResult Details()
        {
            var link = new Link { Name = "Google.com", Address = "http://google.com", TypeID = 1 };
            return View(link);
        }

        // GET: Link/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Link/Create
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

        // GET: Link/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Link/Edit/5
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

        // GET: Link/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Link/Delete/5
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
