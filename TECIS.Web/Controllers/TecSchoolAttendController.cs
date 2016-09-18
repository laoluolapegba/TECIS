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
    public class TecSchoolAttendController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /TecSchoolAttend/
        public ActionResult Index()
        {
            var tecschools = db.TecSchools.Include(t => t.age).Include(t => t.maritalstats);
            return View(tecschools.ToList());
        }
        public ActionResult Membership()
        {
            var tecschools = db.TecSchools.Include(t => t.age).Include(t => t.maritalstats).Where(a => a.membership_class == true);
            return View(tecschools.ToList());
        }
        public ActionResult Development()
        {
            var tecschools = db.TecSchools.Include(t => t.age).Include(t => t.maritalstats).Where(a => a.development_class == true);
            return View(tecschools.ToList());
        }
        public ActionResult Maturity()
        {
            var tecschools = db.TecSchools.Include(t => t.age).Include(t => t.maritalstats).Where(a => a.maturity_class == true);
            return View(tecschools.ToList());
        }
        // GET: /TecSchoolAttend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecSchoolAttendance tecSchoolAttendance = db.TecSchools.Find(id);
            if (tecSchoolAttendance == null)
            {
                return HttpNotFound();
            }
            return View(tecSchoolAttendance);
        }

        // GET: /TecSchoolAttend/Create
        public ActionResult Create()
        {
            ViewBag.agegroup = new SelectList(db.AgeGroups, "Id", "Description");
            ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description");
            return PartialView("_Create");
        }

        // POST: /TecSchoolAttend/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Gender,agegroup,MaritalStat,Surname,OtherNames,PhoneNumber,EmailAddress,createdby,createddate,membership_class,membership_class_date,development_class,development_class_date,maturity_class,maturity_class_date")] TecSchoolAttendance tecSchoolAttendance)
        {
            if (ModelState.IsValid)
            {
                db.TecSchools.Add(tecSchoolAttendance);
                db.SaveChanges();
                return Json(new { success = true });
                //return RedirectToAction("Index");
            }

            ViewBag.agegroup = new SelectList(db.AgeGroups, "Id", "Description", tecSchoolAttendance.agegroup);
            ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description", tecSchoolAttendance.MaritalStat);
            return PartialView("_Create", tecSchoolAttendance);
        }

        // GET: /TecSchoolAttend/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecSchoolAttendance tecSchoolAttendance = db.TecSchools.Find(id);
            if (tecSchoolAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.agegroup = new SelectList(db.AgeGroups, "Id", "Description", tecSchoolAttendance.agegroup);
            ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description", tecSchoolAttendance.MaritalStat);
            return PartialView("_Edit", tecSchoolAttendance);
        }

        // POST: /TecSchoolAttend/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Gender,agegroup,MaritalStat,Surname,OtherNames,PhoneNumber,EmailAddress,createdby,createddate,membership_class,membership_class_date,development_class,development_class_date,maturity_class,maturity_class_date")] TecSchoolAttendance tecSchoolAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tecSchoolAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true });
                //return RedirectToAction("Index");
            }
            ViewBag.agegroup = new SelectList(db.AgeGroups, "Id", "Description", tecSchoolAttendance.agegroup);
            ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description", tecSchoolAttendance.MaritalStat);
            return PartialView("_Edit", tecSchoolAttendance);
        }

        // GET: /TecSchoolAttend/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TecSchoolAttendance tecSchoolAttendance = db.TecSchools.Find(id);
            if (tecSchoolAttendance == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete",tecSchoolAttendance);
        }

        // POST: /TecSchoolAttend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TecSchoolAttendance tecSchoolAttendance = db.TecSchools.Find(id);
            db.TecSchools.Remove(tecSchoolAttendance);
            db.SaveChanges();
           // return RedirectToAction("Index");
            return Json(new { success = true });
        }
        public ActionResult ImportTecSchAttend()
        {
            return View();
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
