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
    public class RestauranteComidasController : Controller
    {
        private RestaurantGoEntities1 db = new RestaurantGoEntities1();

        // GET: RestauranteComidas
        public ActionResult Index()
        {
            var restauranteComida = db.RestauranteComida.Include(r => r.Comida).Include(r => r.Restaurante);
            return View(restauranteComida.ToList());
        }

        // GET: RestauranteComidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteComida restauranteComida = db.RestauranteComida.Find(id);
            if (restauranteComida == null)
            {
                return HttpNotFound();
            }
            return View(restauranteComida);
        }

        // GET: RestauranteComidas/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1");
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE");
            return View();
        }

        // POST: RestauranteComidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_RESTAURANTE,ID_COMIDA")] RestauranteComida restauranteComida)
        {
            if (ModelState.IsValid)
            {
                db.RestauranteComida.Add(restauranteComida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", restauranteComida.ID_COMIDA);
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteComida.ID_RESTAURANTE);
            return View(restauranteComida);
        }

        // GET: RestauranteComidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteComida restauranteComida = db.RestauranteComida.Find(id);
            if (restauranteComida == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", restauranteComida.ID_COMIDA);
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteComida.ID_RESTAURANTE);
            return View(restauranteComida);
        }

        // POST: RestauranteComidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_RESTAURANTE,ID_COMIDA")] RestauranteComida restauranteComida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restauranteComida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", restauranteComida.ID_COMIDA);
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteComida.ID_RESTAURANTE);
            return View(restauranteComida);
        }

        // GET: RestauranteComidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteComida restauranteComida = db.RestauranteComida.Find(id);
            if (restauranteComida == null)
            {
                return HttpNotFound();
            }
            return View(restauranteComida);
        }

        // POST: RestauranteComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestauranteComida restauranteComida = db.RestauranteComida.Find(id);
            db.RestauranteComida.Remove(restauranteComida);
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
