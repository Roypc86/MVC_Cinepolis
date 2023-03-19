using Newtonsoft.Json;
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
        public ActionResult Index(bool gen_view, int id)
        {
            if (id < 1)
            {
                return RedirectToAction("DBVacia", "Home");
            }
            var sala = db.Sala.Include(s => s.Cine);
            ViewBag.VistaGeneral = gen_view;
            ViewBag.IdCine = id;
            if (!gen_view)
            {
                sala = from s in sala where s.CineId == id select s;
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
        public ActionResult Create(int cine_id)
        {
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", cine_id);

            ViewBag.IdSalaPosible = getNuevoIdSala(cine_id);
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Capacidad,CineId")] Sala sala)
        {
            sala.Id = getNuevoIdSala(sala.CineId);
            if (ModelState.IsValid)
            {
                db.Sala.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index", new { gen_view = false,id = sala.CineId });
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
                return RedirectToAction("Index", new { gen_view = false, id = sala.CineId });
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
            return RedirectToAction("Index", new { gen_view = false, id = cine_id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        // Método de actualización del id de la sala al crearla respecto al Cine seleccionado
        public JsonResult ObtenerSalaId(int id_cine)
        {
            var json = JsonConvert.SerializeObject(getNuevoIdSala(id_cine));
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // Método privado de obtención del último id de sala para el cine de entrada
        private int getNuevoIdSala(int id_cine)
        {
            var consulta = db.Sala.Where(s => s.CineId == id_cine);
            var nuevo_id = 1;
            if (consulta.Count() != 0)
            {
                nuevo_id = consulta.Max(s => s.Id) + 1;

            }
            return nuevo_id;
        }
    }
}
