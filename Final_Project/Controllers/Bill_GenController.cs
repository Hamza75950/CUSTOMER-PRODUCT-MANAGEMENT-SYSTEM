using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class Bill_GenController : Controller
    {
        // GET: Bill_Gen
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bill_Gen/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bill_Gen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bill_Gen/Create
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

        // GET: Bill_Gen/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bill_Gen/Edit/5
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

        // GET: Bill_Gen/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bill_Gen/Delete/5
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
