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
    public class HorariosController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();

        // GET: Horarios
        public ActionResult Index()
        {
            var horario = db.Horario.Include(h => h.Pelicula).Include(h => h.Sala);
            return View(horario.OrderBy(h => h.SalaId).ToList()) ;
        }

        // GET: Horarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: Horarios/Create
        public ActionResult Create()
        {
            ViewBag.PeliculaId = new SelectList(db.Pelicula, "Id", "Nombre");
            ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora_inicial,Hora_final,SalaId,PeliculaId")] Horario horario)
        {
            //Revisión de las horas
            if (checkHoras(horario))
            {
                if (ModelState.IsValid)
                {
                    db.Horario.Add(horario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }


            ViewBag.PeliculaId = new SelectList(db.Pelicula, "Id", "Nombre", horario.PeliculaId);
            ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id", horario.SalaId);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
           
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeliculaId = new SelectList(db.Pelicula, "Id", "Nombre", horario.PeliculaId);
            ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id", horario.SalaId);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora_inicial,Hora_final,SalaId,PeliculaId")] Horario horario)
        {
            //revisión de las horas
            if (checkHoras(horario))
            {
                if (ModelState.IsValid)
                {
                    db.Entry(horario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            
            ViewBag.PeliculaId = new SelectList(db.Pelicula, "Id", "Nombre", horario.PeliculaId);
            ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id", horario.SalaId);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horario horario = db.Horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horario horario = db.Horario.Find(id);
            db.Horario.Remove(horario);
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

        // Método para la revisión de las horas de inicio y finalización de un horario, se verifica
        // que la inicial sea menor a la de finalización.
        private bool checkHoras(Horario horario)
        {
            if (TimeSpan.Compare(horario.Hora_inicial, horario.Hora_final) == 1 || TimeSpan.Compare(horario.Hora_inicial, horario.Hora_final) == 0)
            {
                ModelState.AddModelError(nameof(horario.Hora_final), "La hora final debe ser mayor a la inicial.");
                return false;
            }
            return true;
        }
    }
}
