using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantGo.Models;

namespace RestaurantGo.Controllers
{
    public class ComidasController : Controller
    {
        private RestaurantGoEntities1 db = new RestaurantGoEntities1();

        // GET: Comidas
        public ActionResult Index()
        {
            return View(db.Comida.ToList());
        }

        // GET: Comidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comida.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // GET: Comidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,COMIDA1")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                db.Comida.Add(comida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comida);
        }

        // GET: Comidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comida.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,COMIDA1")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comida);
        }

        // GET: Comidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comida comida = db.Comida.Find(id);
            if (comida == null)
            {
                return HttpNotFound();
            }
            return View(comida);
        }

        // POST: Comidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comida comida = db.Comida.Find(id);
            db.Comida.Remove(comida);
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
