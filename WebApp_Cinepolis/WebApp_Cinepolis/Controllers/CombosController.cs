﻿using System;
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
    public class CombosController : Controller
    {
        private Database_CinepolisEntities db = new Database_CinepolisEntities();

        // GET: Combos
        public ActionResult Index(int id)
        {
            var combo = db.Combo.Include(c => c.Cine).Include(c => c.Tiquete);
            combo = from c in combo where c.CineId == id select c;
            return View(combo.ToList());
        }

        // GET: Combos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combo combo = db.Combo.Find(id);
            if (combo == null)
            {
                return HttpNotFound();
            }
            return View(combo);
        }

        // GET: Combos/Create
        public ActionResult Create()
        {
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre");
            ViewBag.TiqueteId = new SelectList(db.Tiquete, "Id", "Nombre");
            return View();
        }

        // POST: Combos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CineId,EsAdulto,Juguete,TiqueteId,Productos")] Combo combo)
        {
            if (!combo.EsAdulto && combo.Juguete == null)
            {
                ModelState.AddModelError(nameof(combo.Juguete), "Este campo no puede estar vacío.");
            }
            if (combo.Productos == null)
            {
                ModelState.AddModelError(nameof(combo.Productos), "Este campo no puede estar vacío.");
            }
            if (ModelState.IsValid)
            {
                db.Combo.Add(combo);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = combo.CineId });
            }

            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", combo.CineId);
            ViewBag.TiqueteId = new SelectList(db.Tiquete, "Id", "Nombre", combo.TiqueteId);
            return View(combo);
        }

        // GET: Combos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combo combo = db.Combo.Find(id);
            if (combo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", combo.CineId);
            ViewBag.TiqueteId = new SelectList(db.Tiquete, "Id", "Nombre", combo.TiqueteId);
            return View(combo);
        }

        // POST: Combos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CineId,EsAdulto,Juguete,TiqueteId,Productos")] Combo combo)
        {
            if (!combo.EsAdulto && combo.Juguete == null)
            {
                ModelState.AddModelError(nameof(combo.Juguete), "Este campo no puede estar vacío.");
            }
            if (combo.Productos == null)
            {
                ModelState.AddModelError(nameof(combo.Productos), "Este campo no puede estar vacío.");
            }

            if (ModelState.IsValid)
            {
                db.Entry(combo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = combo.CineId});
            }
            ViewBag.CineId = new SelectList(db.Cine, "Id", "Nombre", combo.CineId);
            ViewBag.TiqueteId = new SelectList(db.Tiquete, "Id", "Nombre", combo.TiqueteId);
            return View(combo);
        }

        // GET: Combos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Combo combo = db.Combo.Find(id);
            if (combo == null)
            {
                return HttpNotFound();
            }
            return View(combo);
        }

        // POST: Combos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combo combo = db.Combo.Find(id);
            int? cine_id = combo.CineId;
            db.Combo.Remove(combo);
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
