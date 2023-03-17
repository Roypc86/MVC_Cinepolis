using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp_Cinepolis.Models;

namespace WebApp_Cinepolis.Controllers
{
    public class SalasController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();

        // GET: Salas
        public ActionResult Index(int? id)
        {
            var sala = db.Sala.Include(s => s.Cine);
            ViewBag.VistaGeneral = true;
            if (id != null)
            {
                sala = from s in sala where s.CineId == id select s;
                ViewBag.VistaGeneral = false;

            }
            
            return View(sala.OrderBy(s => s.CineId).ThenBy(s => s.Id).ToList());
        }

        // GET: Salas/Details/5
        public ActionResult Details(int? id, int? cine_id)
        {
            if (id == null || cine_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id, cine_id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: Salas/Create
        public ActionResult Create()
        {
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre");
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Capacidad,CineId")] Sala sala)
        {
            sala.Id = db.Sala.Max(s => s.Id) + 1;
            if (ModelState.IsValid)
            {
                db.Sala.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = sala.CineId });
            }

            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", sala.CineId);
            return View(sala);
        }

        // GET: Salas/Edit/5
        public ActionResult Edit(int? id, int? cine_id)
        {
            if (id == null || cine_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id, cine_id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", sala.CineId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Capacidad,CineId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = sala.CineId });
            }
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", sala.CineId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        public ActionResult Delete(int? id, int? cine_id)
        {
            if (id == null || cine_id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sala sala = db.Sala.Find(id, cine_id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? cine_id)
        {
            Sala sala = db.Sala.Find(id, cine_id);
            db.Sala.Remove(sala);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = cine_id });
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
