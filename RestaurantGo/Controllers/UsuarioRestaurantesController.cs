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
    public class UsuarioRestaurantesController : Controller
    {
        private RestaurantGoEntities1 db = new RestaurantGoEntities1();

        // GET: UsuarioRestaurantes
        public ActionResult Index()
        {
            var usuarioRestaurante = db.UsuarioRestaurante.Include(u => u.Restaurante).Include(u => u.Usuario);
            return View(usuarioRestaurante.ToList());
        }

        // GET: UsuarioRestaurantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRestaurante usuarioRestaurante = db.UsuarioRestaurante.Find(id);
            if (usuarioRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRestaurante);
        }

        // GET: UsuarioRestaurantes/Create
        public ActionResult Create()
        {
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE");
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE");
            return View();
        }

        // POST: UsuarioRestaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USUARIO,ID_RESTAURANTE")] UsuarioRestaurante usuarioRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioRestaurante.Add(usuarioRestaurante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", usuarioRestaurante.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioRestaurante.ID_USUARIO);
            return View(usuarioRestaurante);
        }

        // GET: UsuarioRestaurantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRestaurante usuarioRestaurante = db.UsuarioRestaurante.Find(id);
            if (usuarioRestaurante == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", usuarioRestaurante.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioRestaurante.ID_USUARIO);
            return View(usuarioRestaurante);
        }

        // POST: UsuarioRestaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USUARIO,ID_RESTAURANTE")] UsuarioRestaurante usuarioRestaurante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioRestaurante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_RESTAURANTE = new SelectList(db.Restaurante, "ID", "NOMBRE", usuarioRestaurante.ID_RESTAURANTE);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioRestaurante.ID_USUARIO);
            return View(usuarioRestaurante);
        }

        // GET: UsuarioRestaurantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRestaurante usuarioRestaurante = db.UsuarioRestaurante.Find(id);
            if (usuarioRestaurante == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRestaurante);
        }

        // POST: UsuarioRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioRestaurante usuarioRestaurante = db.UsuarioRestaurante.Find(id);
            db.UsuarioRestaurante.Remove(usuarioRestaurante);
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
