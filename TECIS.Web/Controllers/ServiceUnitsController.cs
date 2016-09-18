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
    public class ServiceUnitsController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /ServiceUnits/
        public ActionResult Index()
        {
            return View(db.ServiceUnits.Include(a=>a.unitheads).ToList());
        }

        // GET: /ServiceUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceUnit serviceUnit = db.ServiceUnits.Find(id);
            if (serviceUnit == null)
            {
                return HttpNotFound();
            }
            return View(serviceUnit);
        }

        // GET: /ServiceUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ServiceUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,UnitName,UnitDesc,unitleader")] ServiceUnit serviceUnit)
        {
            if (ModelState.IsValid)
            {
                db.ServiceUnits.Add(serviceUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceUnit);
        }

        // GET: /ServiceUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceUnit serviceUnit = db.ServiceUnits.Find(id);
            if (serviceUnit == null)
            {
                return HttpNotFound();
            }
            return View(serviceUnit);
        }

        // POST: /ServiceUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UnitName,UnitDesc,unitleader")] ServiceUnit serviceUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceUnit);
        }

        // GET: /ServiceUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceUnit serviceUnit = db.ServiceUnits.Find(id);
            if (serviceUnit == null)
            {
                return HttpNotFound();
            }
            return View(serviceUnit);
        }

        // POST: /ServiceUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceUnit serviceUnit = db.ServiceUnits.Find(id);
            db.ServiceUnits.Remove(serviceUnit);
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
