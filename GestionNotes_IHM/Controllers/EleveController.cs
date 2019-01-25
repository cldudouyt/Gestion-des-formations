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
    public class EleveController : Controller
    {
        private GestionNotesContext db = new GestionNotesContext();

        // GET: Eleve
        public ActionResult Index()
        {
            return View(db.Eleves.ToList());
        }

        // GET: Eleve/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // GET: Eleve/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eleve/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Identifiant,Nom,Prenom")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Eleves.Add(eleve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eleve);
        }

        // GET: Eleve/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleve/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Identifiant,Nom,Prenom")] Eleve eleve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eleve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eleve);
        }

        // GET: Eleve/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Eleve eleve = db.Eleves.Find(id);
            if (eleve == null)
            {
                return HttpNotFound();
            }
            return View(eleve);
        }

        // POST: Eleve/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Eleve eleve = db.Eleves.Find(id);
            db.Eleves.Remove(eleve);
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
        public ActionResult Evaluations(long id)
        {
            List<Evaluation> oListeEval = this.db.Evaluations.Include(o => o.Examen).Include(o => o.Eleve).Where(o => o.IdEleve == id).ToList();
            return View(oListeEval);
        }
    }
}
