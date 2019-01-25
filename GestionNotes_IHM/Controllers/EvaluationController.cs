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
    public class EvaluationController : Controller
    {
        private GestionNotesContext db = new GestionNotesContext();

        // GET: Evaluation
        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Eleve).Include(e => e.Examen);
            return View(evaluations.ToList());
        }

        // GET: Evaluation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // GET: Evaluation/Create
        public ActionResult Create()
        {
            ViewBag.IdEleve = new SelectList(db.Eleves, "Identifiant", "Nom");
            ViewBag.IdExamen = new SelectList(db.Examens, "Identifiant", "Libelle");
            return View();
        }

        // POST: Evaluation/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifiant,IdExamen,IdEleve,Note")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Evaluations.Add(evaluation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEleve = new SelectList(db.Eleves, "Identifiant", "Nom", evaluation.IdEleve);
            ViewBag.IdExamen = new SelectList(db.Examens, "Identifiant", "Libelle", evaluation.IdExamen);
            return View(evaluation);
        }

        // GET: Evaluation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEleve = new SelectList(db.Eleves, "Identifiant", "Nom", evaluation.IdEleve);
            ViewBag.IdExamen = new SelectList(db.Examens, "Identifiant", "Libelle", evaluation.IdExamen);
            return View(evaluation);
        }

        // POST: Evaluation/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifiant,IdExamen,IdEleve,Note")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEleve = new SelectList(db.Eleves, "Identifiant", "Nom", evaluation.IdEleve);
            ViewBag.IdExamen = new SelectList(db.Examens, "Identifiant", "Libelle", evaluation.IdExamen);
            return View(evaluation);
        }

        // GET: Evaluation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation evaluation = db.Evaluations.Find(id);
            if (evaluation == null)
            {
                return HttpNotFound();
            }
            return View(evaluation);
        }

        // POST: Evaluation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Evaluation evaluation = db.Evaluations.Find(id);
            db.Evaluations.Remove(evaluation);
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
