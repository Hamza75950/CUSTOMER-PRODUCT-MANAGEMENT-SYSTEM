using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class Bill_GenController : Controller
    {
     
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult YourAction()
        {
            List<Final_Project.Models.Bill_Payment> model = Billpayment();

    // Check if model is null and provide an empty list if needed
            if (model == null)
            {
                model = new List<Final_Project.Models.Bill_Payment>();
            }

            return View(model);
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
        public List<Bill_Payment> Billpayment()
        {
            List<Bill_Payment> BillList = new List<Bill_Payment>();

         
            return BillList;

        }
    }
}
