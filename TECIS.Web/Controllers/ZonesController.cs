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
    public class ZonesController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Zones/
        public ActionResult Index()
        {
            return View(db.CZones.ToList());
        }

        // GET: /Zones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CZone cZone = db.CZones.Find(id);
            if (cZone == null)
            {
                return HttpNotFound();
            }
            return View(cZone);
        }

        // GET: /Zones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Zones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Description,ZonalCoordinator,ZoneEmail")] CZone cZone)
        {
            if (ModelState.IsValid)
            {
                db.CZones.Add(cZone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cZone);
        }

        // GET: /Zones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CZone cZone = db.CZones.Find(id);
            if (cZone == null)
            {
                return HttpNotFound();
            }
            return View(cZone);
        }

        // POST: /Zones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,ZonalCoordinator,ZoneEmail")] CZone cZone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cZone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cZone);
        }

        // GET: /Zones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CZone cZone = db.CZones.Find(id);
            if (cZone == null)
            {
                return HttpNotFound();
            }
            return View(cZone);
        }

        // POST: /Zones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CZone cZone = db.CZones.Find(id);
            db.CZones.Remove(cZone);
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
