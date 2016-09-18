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
    public class GuestContactController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Xcont/
        public ActionResult Index()
        {
            ViewBag.GuestId = 2580;
            var guestcontacts = db.GuestContacts.Include(g => g.GuestCluster).Include(g => g.GuestId);
            return View(guestcontacts.ToList());
        }

        // GET: /Xcont/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestContact guestContact = db.GuestContacts.Find(id);
            if (guestContact == null)
            {
                return HttpNotFound();
            }
            return View(guestContact);
        }
        [ChildActionOnly]
        public ActionResult List(int id)
        {
            ViewBag.GuestId = id;
            //List<GuestContact> guestcontacts = new List<GuestContact>();
            var guestcontacts = db.GuestContacts.Where(a => a.theguestid == id);

            return PartialView("_GuestContactHistory", guestcontacts.ToList());
        }

        // GET: /Xcont/Create
        public ActionResult Create(int GuestId)
        {
            //ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName");
            //ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender");
            //ViewBag.GuestId 
            GuestContact guestcontact = new GuestContact();
            Guest guest = db.Guests.Find(GuestId);
            guestcontact.guest_firstname = guest.OtherNames;
            guestcontact.guest_lastname = guest.Surname;
            guestcontact.theguestid = GuestId;
            guestcontact.clusterid = guest.ClusterArea;
            guestcontact.contact_date = DateTime.Now;
            return PartialView("_Create", guestcontact);
        }
        public ActionResult CreateNew()
        {
            //ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName");
            //ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender");
            //ViewBag.GuestId 
            GuestContact guestcontact = new GuestContact();
            //Guest guest = db.Guests.Find(GuestId);
            //guestcontact.guest_firstname = guest.OtherNames;
            //guestcontact.guest_lastname = guest.Surname;
            //guestcontact.theguestid = 2580;
            //guestcontact.clusterid = guest.ClusterArea;
            guestcontact.contact_date = DateTime.Now;
            return PartialView("_CreateNew", guestcontact);
        }
        // POST: /Xcont/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,theguestid,guest_firstname,guest_lastname,clusterid,contact_date,contacted_by,WouldJoin,HasChurch,Forgetme")] GuestContact guestContact)
        {
            if (ModelState.IsValid)
            {
                guestContact.created_by = User.Identity.Name;
                guestContact.created_date = DateTime.Now;
                db.GuestContacts.Add(guestContact);
                db.SaveChanges();

                string url = Url.Action("List", "GuestContact", new { id = guestContact.GuestId });
                return Json(new { success = true, url = url });
                //return RedirectToAction("Index");
            }

            ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName", guestContact.clusterid);
            ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender", guestContact.theguestid);
            return PartialView("_Create", guestContact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Include = "id,theguestid,guest_firstname,guest_lastname,clusterid,contact_date,contacted_by,WouldJoin,HasChurch,Forgetme")] GuestContact guestContact)
        {
            if (ModelState.IsValid)
            {
                guestContact.created_by = User.Identity.Name;
                guestContact.created_date = DateTime.Now;
                db.GuestContacts.Add(guestContact);
                db.SaveChanges();

                string url = Url.Action("List", "GuestContact", new { id = guestContact.GuestId });
                return Json(new { success = true, url = url });
                //return RedirectToAction("Index");
            }

            ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName", guestContact.clusterid);
            ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender", guestContact.theguestid);
            return PartialView("_Create", guestContact);
        }

        // GET: /Xcont/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestContact guestContact = db.GuestContacts.Find(id);
            
            
            if (guestContact == null)
            {
                return HttpNotFound();
            }
            //ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName", guestContact.clusterid);
            //ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender", guestContact.theguestid);
            return PartialView("_Edit",guestContact);
        }

        // POST: /Xcont/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,theguestid,guest_firstname,guest_lastname,clusterid,contact_date,contacted_by,WouldJoin,HasChurch,Forgetme")] GuestContact guestContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestContact).State = EntityState.Modified;
                db.SaveChanges();
                string url = Url.Action("List", "GuestContact", new { id = guestContact.GuestId });
                return Json(new { success = true, url = url });
                //return RedirectToAction("Index");
            }
            //ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName", guestContact.clusterid);
            //ViewBag.theguestid = new SelectList(db.Guests, "Id", "Gender", guestContact.theguestid);
            return PartialView(guestContact);
        }

        // GET: /Xcont/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestContact guestContact = db.GuestContacts.Find(id);
            if (guestContact == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete",guestContact);
        }

        // POST: /Xcont/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestContact guestContact = db.GuestContacts.Find(id);
            db.GuestContacts.Remove(guestContact);
            db.SaveChanges();
            string url = Url.Action("List", "GuestContact", new { id = guestContact.GuestId });
            return Json(new { success = true, url = url });
            //return RedirectToAction("Index");
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
