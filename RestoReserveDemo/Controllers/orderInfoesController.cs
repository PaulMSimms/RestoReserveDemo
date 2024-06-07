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
    public class orderInfoesController : Controller
    {
        private restoReservationEntities1 db = new restoReservationEntities1();

        // GET: orderInfoes
        public ActionResult Index()
        {
            var orderInfoes = db.orderInfoes.Include(o => o.foodInfo).Include(o => o.reservationInfo);
            return View(orderInfoes.ToList());
        }

        // GET: orderInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderInfo orderInfo = db.orderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // GET: orderInfoes/Create
        public ActionResult Create()
        {
            ViewBag.dish_id = new SelectList(db.foodInfoes, "dish_id", "dish_name");
            ViewBag.reservation_id = new SelectList(db.reservationInfoes, "reservation_id", "reservation_id");
            return View();
        }

        // POST: orderInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,reservation_id,dish_id,quantity")] orderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.orderInfoes.Add(orderInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dish_id = new SelectList(db.foodInfoes, "dish_id", "dish_name", orderInfo.dish_id);
            ViewBag.reservation_id = new SelectList(db.reservationInfoes, "reservation_id", "reservation_id", orderInfo.reservation_id);
            return View(orderInfo);
        }

        // GET: orderInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderInfo orderInfo = db.orderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.dish_id = new SelectList(db.foodInfoes, "dish_id", "dish_name", orderInfo.dish_id);
            ViewBag.reservation_id = new SelectList(db.reservationInfoes, "reservation_id", "reservation_id", orderInfo.reservation_id);
            return View(orderInfo);
        }

        // POST: orderInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,reservation_id,dish_id,quantity")] orderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dish_id = new SelectList(db.foodInfoes, "dish_id", "dish_name", orderInfo.dish_id);
            ViewBag.reservation_id = new SelectList(db.reservationInfoes, "reservation_id", "reservation_id", orderInfo.reservation_id);
            return View(orderInfo);
        }

        // GET: orderInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderInfo orderInfo = db.orderInfoes.Find(id);
            if (orderInfo == null)
            {
                return HttpNotFound();
            }
            return View(orderInfo);
        }

        // POST: orderInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            orderInfo orderInfo = db.orderInfoes.Find(id);
            db.orderInfoes.Remove(orderInfo);
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
