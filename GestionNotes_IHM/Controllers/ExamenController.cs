using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionNotes_DAO.Models;

namespace GestionNotes_IHM.Controllers
{
    public class ExamenController : Controller
    {
        private GestionNotesContext db = new GestionNotesContext();

        // GET: Examen
        public ActionResult Index()
        {
            return View(db.Examens.ToList());
        }

        // GET: Examen/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examen/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifiant,Libelle,Date")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Examens.Add(examen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examen);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // POST: Examen/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifiant,Libelle,Date")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examen);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examens.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Examen examen = db.Examens.Find(id);
            db.Examens.Remove(examen);
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
