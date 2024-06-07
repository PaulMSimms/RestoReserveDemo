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
    public class reservationInfoesController : Controller
    {
        private restoReservationEntities1 db = new restoReservationEntities1();

        // GET: reservationInfoes
        public ActionResult Index()
        {
            var reservationInfoes = db.reservationInfoes.Include(r => r.customerInfo);
            return View(reservationInfoes.ToList());
        }

        // GET: reservationInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservationInfo reservationInfo = db.reservationInfoes.Find(id);
            if (reservationInfo == null)
            {
                return HttpNotFound();
            }
            return View(reservationInfo);
        }

        // GET: reservationInfoes/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.customerInfoes, "customer_id", "email");
            return View();
        }

        // POST: reservationInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reservation_id,date_of_reservation,number_of_guests,time_of_reservation,customer_id")] reservationInfo reservationInfo)
        {
            if (ModelState.IsValid)
            {
                db.reservationInfoes.Add(reservationInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customerInfoes, "customer_id", "email", reservationInfo.customer_id);
            return View(reservationInfo);
        }

        // GET: reservationInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservationInfo reservationInfo = db.reservationInfoes.Find(id);
            if (reservationInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customerInfoes, "customer_id", "email", reservationInfo.customer_id);
            return View(reservationInfo);
        }

        // POST: reservationInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reservation_id,date_of_reservation,number_of_guests,time_of_reservation,customer_id")] reservationInfo reservationInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customerInfoes, "customer_id", "email", reservationInfo.customer_id);
            return View(reservationInfo);
        }

        // GET: reservationInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reservationInfo reservationInfo = db.reservationInfoes.Find(id);
            if (reservationInfo == null)
            {
                return HttpNotFound();
            }
            return View(reservationInfo);
        }

        // POST: reservationInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            reservationInfo reservationInfo = db.reservationInfoes.Find(id);
            db.reservationInfoes.Remove(reservationInfo);
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
