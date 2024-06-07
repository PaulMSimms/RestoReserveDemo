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
    public class foodInfoesController : Controller
    {
        private restoReservationEntities1 db = new restoReservationEntities1();

        // GET: foodInfoes
        public ActionResult Index()
        {
            return View(db.foodInfoes.ToList());
        }

        // GET: foodInfoes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodInfo foodInfo = db.foodInfoes.Find(id);
            if (foodInfo == null)
            {
                return HttpNotFound();
            }
            return View(foodInfo);
        }

        // GET: foodInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: foodInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dish_id,dish_name,price,description,image_url,type")] foodInfo foodInfo)
        {
            if (ModelState.IsValid)
            {
                db.foodInfoes.Add(foodInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodInfo);
        }

        // GET: foodInfoes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodInfo foodInfo = db.foodInfoes.Find(id);
            if (foodInfo == null)
            {
                return HttpNotFound();
            }
            return View(foodInfo);
        }

        // POST: foodInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dish_id,dish_name,price,description,image_url,type")] foodInfo foodInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodInfo);
        }

        // GET: foodInfoes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            foodInfo foodInfo = db.foodInfoes.Find(id);
            if (foodInfo == null)
            {
                return HttpNotFound();
            }
            return View(foodInfo);
        }

        // POST: foodInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            foodInfo foodInfo = db.foodInfoes.Find(id);
            db.foodInfoes.Remove(foodInfo);
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
