using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TECIS.Data.Models;

namespace TECIS.Web.Controllers
{
    public class ClusterAreasController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /ClusterAreas/
        public ActionResult Index()
        {
            return View(db.ClusterAreas.OrderBy(a => a.Description).ToList());
        }

        // GET: /ClusterAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClusterArea clusterArea = db.ClusterAreas.Find(id);
            if (clusterArea == null)
            {
                return HttpNotFound();
            }
            return View(clusterArea);
        }

        // GET: /ClusterAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ClusterAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] ClusterArea clusterArea)
        {
            if (ModelState.IsValid)
            {
                db.ClusterAreas.Add(clusterArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clusterArea);
        }

        // GET: /ClusterAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClusterArea clusterArea = db.ClusterAreas.Find(id);
            if (clusterArea == null)
            {
                return HttpNotFound();
            }
            return View(clusterArea);
        }

        // POST: /ClusterAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] ClusterArea clusterArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clusterArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clusterArea);
        }

        // GET: /ClusterAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClusterArea clusterArea = db.ClusterAreas.Find(id);
            if (clusterArea == null)
            {
                return HttpNotFound();
            }
            return View(clusterArea);
        }

        // POST: /ClusterAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClusterArea clusterArea = db.ClusterAreas.Find(id);
            db.ClusterAreas.Remove(clusterArea);
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
