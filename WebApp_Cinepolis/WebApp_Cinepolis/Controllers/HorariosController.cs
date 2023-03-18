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
    public class HorariosController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();
        

        // GET: Horarios
        public ActionResult Index(int? id)
        {
            var horario = db.Horario.Include(h => h.Pelicula).Include(h => h.Sala);
            ViewBag.VistaGeneral = true;

            if (id != null) {
                horario = from h in horario where h.CineId == id select h;
                ViewBag.VistaGeneral = false;
            }
            ViewBag.IdCineView = id;
            return View(horario.OrderBy(h => h.CineId).ThenBy(h => h.SalaId).ThenBy(h => h.Fecha).ThenBy(h => h.Hora_inicial).ToList()) ;
        }

        // GET: Horarios para una sala en específico
        public ActionResult IndexHorariosSala(int sala_id, int cine_id)
        {
            var horario = db.Horario.Include(h => h.Pelicula).Include(h => h.Sala);
           
            horario = from h in horario where h.CineId == cine_id && h.SalaId == sala_id select h;
            
            ViewBag.IdSalaView = sala_id;
            ViewBag.IdCineView = cine_id;

            return View(horario.OrderBy(h => h.SalaId).ThenBy(h => h.Fecha).ThenBy(h => h.Hora_inicial).ToList());
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
        public ActionResult Create(int? sala_id, int? cine_id)
        {
            ViewBag.PeliculaId = new SelectList(db.Pelicula, "Id", "Nombre");
            if (cine_id != null)
            {
                ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", cine_id);
            }
            else
            {
                ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre");
            }
            if (sala_id != null)
            {

                ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id", sala_id);
            }
            else
            {
                ViewBag.SalaId = new SelectList(db.Sala, "Id", "Id");
            }
            TempData["sala_id"] = sala_id;
            TempData["cine_id"] = cine_id;
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,Hora_inicial,Hora_final,SalaId,CineId,PeliculaId")] Horario horario)
        {
            //Revisión de las horas
            if (checkHoras(horario))
            {
                if (ModelState.IsValid)
                {
                    db.Horario.Add(horario);
                    db.SaveChanges();
                    if (TempData["sala_id"] == null)
                    {
                        return RedirectToAction("Index", new { id = TempData["cine_id"] });
                    }
                    return RedirectToAction("IndexHorariosSala", new { sala_id = TempData["sala_id"] , cine_id = TempData["cine_id"] });
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
            ViewBag.SalaId = new SelectList(db.Sala.Where(s => s.CineId == horario.CineId), "Id", "Id", horario.SalaId);
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", horario.CineId);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,Hora_inicial,Hora_final,SalaId,CineId,PeliculaId")] Horario horario)
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

        [HttpPost]
        public JsonResult ActualizarSalasId(int id)
        {
            var sala = db.Sala.Include(s => s.Cine);
            sala = from s in sala where s.CineId == id select s;
            var selectListItems = new Dictionary<int, int>();

            foreach (var s in sala)
            {
                selectListItems.Add(s.Id, s.Id);
            }
            var json = JsonConvert.SerializeObject(selectListItems);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
