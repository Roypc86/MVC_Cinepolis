using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApp_Cinepolis.Models;

namespace WebApp_Cinepolis.Controllers
{
    public class PeliculasController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();

        // GET: Peliculas
        public ActionResult Index()
        {
            var listaPeliculas = new List<Pelicula>() { };
            foreach (Pelicula pelicula in db.Pelicula.ToList())
            {
                listaPeliculas.Add(pelicula);
            }

            return View(db.Pelicula.ToList());
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Genero,Director,EsAdultos,Acciones,Actores,Resumen")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelicula);
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Genero,Director,EsAdultos,Acciones,Actores,Resumen")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelicula);
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Pelicula.Find(id);
            db.Pelicula.Remove(pelicula);
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

        // GET: mostrado de vista con la información del director
        public ActionResult VerDirector(string nombre)
        {
            
            foreach (var director in callAPI())
            {
                if (director.Nombre == nombre)
                {
                    ViewBag.DirectorInfo = director;
                    return View();
                }
            }

            ViewBag.DirectorInfo = new ViewModel.DirectorViewModel { Id = 0, Nombre = "", Biografia = ""};
            
            return View();
        }
        private IEnumerable<ViewModel.DirectorViewModel> callAPI()
        {
            IEnumerable<ViewModel.DirectorViewModel> directores = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44322/api/");
                //Get
                var getTarea = cliente.GetAsync("Director");
                getTarea.Wait();

                var resultado = getTarea.Result;
                if (resultado.IsSuccessStatusCode)
                {
                    var lecturaTarea = resultado.Content.ReadAsAsync<IList<ViewModel.DirectorViewModel>>();
                    lecturaTarea.Wait();
                    directores = lecturaTarea.Result;
                    
                }
                
            }
            return directores;

            
        }
    }
}
