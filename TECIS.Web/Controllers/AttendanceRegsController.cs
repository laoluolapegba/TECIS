using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TECIS.Data.Models;

namespace TECIS.Web.Controllers
{
    public class AttendanceRegsController : Controller
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /AttendanceRegs/
        public ActionResult Index()
        {
            return View(db.AttendanceRegs.ToList());
        }

        // GET: /AttendanceRegs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceReg attendanceReg = db.AttendanceRegs.Find(id);
            if (attendanceReg == null)
            {
                return HttpNotFound();
            }
            return View(attendanceReg);
        }

        // GET: /AttendanceRegs/Create
        public ActionResult Create()
        {
            var locs = db.Locations.OrderBy(a => a.idloc);
            ViewBag.Location = new SelectList(locs, "idloc", "locationname");
            return View();
        }

        // POST: /AttendanceRegs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,servicedate,servicetype,location,malecount,femalecount,childcount,guestcount,convertcount,childboyscount,childgirlscount,childnannies,childteachers,pteenboys,pteengirls,pteenteachers,teenboys,teengirls,teenteachers,carscount,security,service_start_time,service_end_time,message_title,speaker")] AttendanceReg attendanceReg)
        {

            if (ModelState.IsValid)
            {
                using (var reg = new TecIsEntities())
                {
                    var existingEntity = reg.AttendanceRegs.FirstOrDefault(a => a.servicedate == attendanceReg.servicedate && attendanceReg.servicetype == a.servicetype);
                    //var existingEntity = reg..FirstOrDefault(detail => detail.ORDERID == ParentID && detail.PRODUCTID == order.ProductID);
                    if (existingEntity != null)
                    {
                        string errorMessage = string.Format("Attendance for service {0}  on {1} has been registered.", attendanceReg.servicetype, attendanceReg.servicedate);
                        ModelState.AddModelError("", errorMessage);
                    }
                    else
                    {
                        reg.AttendanceRegs.Add(attendanceReg);
                        reg.SaveChanges();
                        return RedirectToAction("Index");
                    }


                }


            }
            var locs = db.Locations.OrderBy(a => a.idloc);
            ViewBag.Location = new SelectList(locs, "idloc", "locationname");
            return View(attendanceReg);
        }

        // GET: /AttendanceRegs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceReg attendanceReg = db.AttendanceRegs.Find(id);
            if (attendanceReg == null)
            {
                return HttpNotFound();
            }
            return View(attendanceReg);
        }

        // POST: /AttendanceRegs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,servicedate,servicetype,location,malecount,femalecount,childcount,guestcount,convertcount,childboyscount,childgirlscount,childnannies,childteachers,pteenboys,pteengirls,pteenteachers,teenboys,teengirls,teenteachers,carscount,security,service_start_time,service_end_time,message_title,speaker")] AttendanceReg attendanceReg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendanceReg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendanceReg);
        }

        // GET: /AttendanceRegs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceReg attendanceReg = db.AttendanceRegs.Find(id);
            if (attendanceReg == null)
            {
                return HttpNotFound();
            }
            return View(attendanceReg);
        }

        // POST: /AttendanceRegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttendanceReg attendanceReg = db.AttendanceRegs.Find(id);
            db.AttendanceRegs.Remove(attendanceReg);
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
