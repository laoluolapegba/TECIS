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
    public class IdeasController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Ideas/
        public ActionResult Index()
        {
            var ideas = db.Ideas.Include(i => i.ideacategory).Include(i => i.ideastatus);
            ViewBag.IdeaCount = db.Ideas.Count();
            return View(ideas.ToList());
        }

        // GET: /Ideas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // GET: /Ideas/Create
        public ActionResult Create()
        {
            ViewBag.category = new SelectList(db.IdeaCategory, "Id", "Description");
            ViewBag.status = new SelectList(db.IdeaStatus, "Id", "Description");
            return View();
        }

        // POST: /Ideas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ididea,Title,Description,category")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                idea.Status = 1;
                idea.CreatedDate = DateTime.Now;
                idea.Createdby = User.Identity.Name;
                db.Ideas.Add(idea);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category = new SelectList(db.IdeaCategory, "Id", "Description", idea.Category);
            ViewBag.status = new SelectList(db.IdeaStatus, "Id", "Description", idea.Status);
            return View(idea);
        }

        // GET: /Ideas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            ViewBag.category = new SelectList(db.IdeaCategory, "Id", "Description", idea.Category);
            ViewBag.status = new SelectList(db.IdeaStatus, "Id", "Description", idea.Status);
            return View(idea);
        }

        // POST: /Ideas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ididea,Title,Description,category,status")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category = new SelectList(db.IdeaCategory, "Id", "Description", idea.Category);
            ViewBag.status = new SelectList(db.IdeaStatus, "Id", "Description", idea.Status);
            return View(idea);
        }

        // GET: /Ideas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idea idea = db.Ideas.Find(id);
            if (idea == null)
            {
                return HttpNotFound();
            }
            return View(idea);
        }

        // POST: /Ideas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Idea idea = db.Ideas.Find(id);
            db.Ideas.Remove(idea);
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
