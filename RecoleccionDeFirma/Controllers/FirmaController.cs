using RecoleccionDeFirma.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace RecoleccionDeFirma.Controllers
{
    public class FirmaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Firma
        public ActionResult Index()
        {
            return View(db.Firmas.ToList());
        }

        public ActionResult Thanks()
        {
            return View();
        }

        // GET: Firma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmaModels firmaModels = db.Firmas.Find(id);
            if (firmaModels == null)
            {
                return HttpNotFound();
            }
            return View(firmaModels);
        }

        // GET: Firma/Create
        public ActionResult Create()
        {
            var count = db.Firmas.Count();
            string countFixed = string.Format("{0:n0}", count); //para que traiga las comas 1,000
            ViewBag.Counter = countFixed;
            return View();
        }

        // POST: Firma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "firmaID,primerNombre,primerApellido,cedula,telefono")] FirmaModels firmaModels)
        {
            bool contactExists = db.Firmas.Any(a => a.cedula.Equals(firmaModels.cedula)); //verifica si la cedula existe

            if (ModelState.IsValid && contactExists == false)
            {
                db.Firmas.Add(firmaModels);
                db.SaveChanges();
                return RedirectToAction("Thanks");
            }

            var count = db.Firmas.Count();
            string countFixed = string.Format("{0:n0}", count); //para que traiga las comas 1,000
            ViewBag.Counter = countFixed;
            ViewBag.cedula = "Esta cédula ya fue introducidad";
            return View(firmaModels);
        }

        // GET: Firma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmaModels firmaModels = db.Firmas.Find(id);
            if (firmaModels == null)
            {
                return HttpNotFound();
            }
            return View(firmaModels);
        }

        // POST: Firma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "firmaID,primerNombre,primerApellido,cedula,telefono")] FirmaModels firmaModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firmaModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firmaModels);
        }

        // GET: Firma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirmaModels firmaModels = db.Firmas.Find(id);
            if (firmaModels == null)
            {
                return HttpNotFound();
            }
            return View(firmaModels);
        }

        // POST: Firma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirmaModels firmaModels = db.Firmas.Find(id);
            db.Firmas.Remove(firmaModels);
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

