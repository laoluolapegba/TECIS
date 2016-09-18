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
    public class CAreasController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /CAreas/
        public ActionResult Index()
        {
            var careas = db.CAreas.Include(c => c.AreaZones);
            return View(careas.ToList());
        }

        // GET: /CAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CArea cArea = db.CAreas.Find(id);
            if (cArea == null)
            {
                return HttpNotFound();
            }
            return View(cArea);
        }

        // GET: /CAreas/Create
        public ActionResult Create()
        {
            ViewBag.AreaZone = new SelectList(db.CZones, "Id", "Description");
            return View();
        }

        // POST: /CAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,AreaCoordinator,AreaZone,AreaEmail")] CArea cArea)
        {
            if (ModelState.IsValid)
            {
                db.CAreas.Add(cArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AreaZone = new SelectList(db.CZones, "Id", "Description", cArea.AreaZone);
            return View(cArea);
        }

        // GET: /CAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CArea cArea = db.CAreas.Find(id);
            if (cArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.AreaZone = new SelectList(db.CZones, "Id", "Description", cArea.AreaZone);
            return View(cArea);
        }

        // POST: /CAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,AreaCoordinator,AreaZone,AreaEmail")] CArea cArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AreaZone = new SelectList(db.CZones, "Id", "Description", cArea.AreaZone);
            return View(cArea);
        }

        // GET: /CAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CArea cArea = db.CAreas.Find(id);
            if (cArea == null)
            {
                return HttpNotFound();
            }
            return View(cArea);
        }

        // POST: /CAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CArea cArea = db.CAreas.Find(id);
            db.CAreas.Remove(cArea);
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
