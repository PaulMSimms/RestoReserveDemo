using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestoReserveDemo.Models;

namespace RestoReserveDemo.Controllers
{
    public class customerInfoesController : Controller
    {
        private restoReservationEntities1 db = new restoReservationEntities1();

        // GET: customerInfoes
        public ActionResult Index()
        {
            return View(db.customerInfoes.ToList());
        }

        // GET: customerInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerInfo customerInfo = db.customerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // GET: customerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,email,name,contact_number")] customerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.customerInfoes.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerInfo);
        }

        // GET: customerInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerInfo customerInfo = db.customerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: customerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,email,name,contact_number")] customerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInfo);
        }

        // GET: customerInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customerInfo customerInfo = db.customerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: customerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            customerInfo customerInfo = db.customerInfoes.Find(id);
            db.customerInfoes.Remove(customerInfo);
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
