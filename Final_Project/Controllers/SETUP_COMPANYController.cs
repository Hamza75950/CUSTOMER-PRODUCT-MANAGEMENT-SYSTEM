using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_Project;

namespace Final_Project.Controllers
{
    public class SETUP_COMPANYController : Controller
    {
        private FabricEntities db = new FabricEntities();

        // GET: SETUP_COMPANY
        public ActionResult Index()
        {
            return View(db.SETUP_COMPANY.ToList());
        }

        // GET: SETUP_COMPANY/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETUP_COMPANY sETUP_COMPANY = db.SETUP_COMPANY.Find(id);
            if (sETUP_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(sETUP_COMPANY);
        }

        // GET: SETUP_COMPANY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SETUP_COMPANY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "company_code,company_name,mobile_no,maker,mak_dt,record_id,addresss")] SETUP_COMPANY sETUP_COMPANY)
        {
            if (ModelState.IsValid)
            {
                db.SETUP_COMPANY.Add(sETUP_COMPANY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sETUP_COMPANY);
        }

        // GET: SETUP_COMPANY/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETUP_COMPANY sETUP_COMPANY = db.SETUP_COMPANY.Find(id);
            if (sETUP_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(sETUP_COMPANY);
        }

        // POST: SETUP_COMPANY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "company_code,company_name,mobile_no,maker,mak_dt,record_id,addresss")] SETUP_COMPANY sETUP_COMPANY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sETUP_COMPANY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sETUP_COMPANY);
        }

        // GET: SETUP_COMPANY/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SETUP_COMPANY sETUP_COMPANY = db.SETUP_COMPANY.Find(id);
            if (sETUP_COMPANY == null)
            {
                return HttpNotFound();
            }
            return View(sETUP_COMPANY);
        }

        // POST: SETUP_COMPANY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SETUP_COMPANY sETUP_COMPANY = db.SETUP_COMPANY.Find(id);
            db.SETUP_COMPANY.Remove(sETUP_COMPANY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
