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
    public class RestauranteValoracionsController : Controller
    {
        private RestaurantGoEntities1 db = new RestaurantGoEntities1();

        // GET: RestauranteValoracions
        public ActionResult Index()
        {
            var restauranteValoracion = db.RestauranteValoracion.Include(r => r.Restaurante).Include(r => r.Usuario);
            return View(restauranteValoracion.ToList());
        }

        // GET: RestauranteValoracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteValoracion restauranteValoracion = db.RestauranteValoracion.Find(id);
            if (restauranteValoracion == null)
            {
                return HttpNotFound();
            }
            return View(restauranteValoracion);
        }

        // GET: RestauranteValoracions/Create
        public ActionResult Create()
        {
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE");
            return View();
        }

        // POST: RestauranteValoracions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USUARIO,ID_RESTAURANTE,VALOR")] RestauranteValoracion restauranteValoracion)
        {
            if (ModelState.IsValid)
            {
                db.RestauranteValoracion.Add(restauranteValoracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteValoracion.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", restauranteValoracion.ID_USUARIO);
            return View(restauranteValoracion);
        }

        // GET: RestauranteValoracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteValoracion restauranteValoracion = db.RestauranteValoracion.Find(id);
            if (restauranteValoracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteValoracion.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", restauranteValoracion.ID_USUARIO);
            return View(restauranteValoracion);
        }

        // POST: RestauranteValoracions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USUARIO,ID_RESTAURANTE,VALOR")] RestauranteValoracion restauranteValoracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restauranteValoracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", restauranteValoracion.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", restauranteValoracion.ID_USUARIO);
            return View(restauranteValoracion);
        }

        // GET: RestauranteValoracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestauranteValoracion restauranteValoracion = db.RestauranteValoracion.Find(id);
            if (restauranteValoracion == null)
            {
                return HttpNotFound();
            }
            return View(restauranteValoracion);
        }

        // POST: RestauranteValoracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestauranteValoracion restauranteValoracion = db.RestauranteValoracion.Find(id);
            db.RestauranteValoracion.Remove(restauranteValoracion);
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
