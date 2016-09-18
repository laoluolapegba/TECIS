using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TECIS.Data.Models;

namespace TECIS.Web.Controllers
{
    public class SectionsController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Sections/
        public ActionResult Index()
        {
            var csections = db.CSections.Include(c => c.SectAreas);
            return View(csections.ToList());
        }

        // GET: /Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSection cSection = db.CSections.Find(id);
            if (cSection == null)
            {
                return HttpNotFound();
            }
            return View(cSection);
        }

        // GET: /Sections/Create
        public ActionResult Create()
        {
            ViewBag.SectArea = new SelectList(db.CAreas, "Id", "Description");
            return View();
        }

        // POST: /Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Description,SectionLeader,SectArea, SectionEmail")] CSection cSection)
        {
            if (ModelState.IsValid)
            {
                db.CSections.Add(cSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SectArea = new SelectList(db.CAreas, "Id", "Description", cSection.SectArea);
            return View(cSection);
        }

        // GET: /Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSection cSection = db.CSections.Find(id);
            if (cSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectArea = new SelectList(db.CAreas, "Id", "Description", cSection.SectArea);
            return View(cSection);
        }

        // POST: /Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,SectionLeader,SectArea,SectionEmail")] CSection cSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SectArea = new SelectList(db.CAreas, "Id", "Description", cSection.SectArea);
            return View(cSection);
        }

        // GET: /Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CSection cSection = db.CSections.Find(id);
            if (cSection == null)
            {
                return HttpNotFound();
            }
            return View(cSection);
        }

        // POST: /Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CSection cSection = db.CSections.Find(id);
            db.CSections.Remove(cSection);
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
