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
    public class UsuarioComidasController : Controller
    {
        private RestaurantGoEntities1 db = new RestaurantGoEntities1();

        // GET: UsuarioComidas
        public ActionResult Index()
        {
            var usuarioComida = db.UsuarioComida.Include(u => u.Comida).Include(u => u.Usuario);
            return View(usuarioComida.ToList());
        }

        // GET: UsuarioComidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioComida usuarioComida = db.UsuarioComida.Find(id);
            if (usuarioComida == null)
            {
                return HttpNotFound();
            }
            return View(usuarioComida);
        }

        // GET: UsuarioComidas/Create
        public ActionResult Create()
        {
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1");
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE");
            return View();
        }

        // POST: UsuarioComidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USUARIO,ID_COMIDA")] UsuarioComida usuarioComida)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioComida.Add(usuarioComida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", usuarioComida.ID_COMIDA);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioComida.ID_USUARIO);
            return View(usuarioComida);
        }

        // GET: UsuarioComidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioComida usuarioComida = db.UsuarioComida.Find(id);
            if (usuarioComida == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", usuarioComida.ID_COMIDA);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioComida.ID_USUARIO);
            return View(usuarioComida);
        }

        // POST: UsuarioComidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USUARIO,ID_COMIDA")] UsuarioComida usuarioComida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioComida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COMIDA = new SelectList(db.Comida, "ID", "COMIDA1", usuarioComida.ID_COMIDA);
            ViewBag.ID_USUARIO = new SelectList(db.Usuario, "ID", "NOMBRE", usuarioComida.ID_USUARIO);
            return View(usuarioComida);
        }

        // GET: UsuarioComidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioComida usuarioComida = db.UsuarioComida.Find(id);
            if (usuarioComida == null)
            {
                return HttpNotFound();
            }
            return View(usuarioComida);
        }

        // POST: UsuarioComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioComida usuarioComida = db.UsuarioComida.Find(id);
            db.UsuarioComida.Remove(usuarioComida);
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
