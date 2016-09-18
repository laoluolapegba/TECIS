using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TECIS.Data.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using TECIS.Data.Models;
using System.Web;
using TECIS.Web.ActionFilters;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
//using OfficeOpenXml;
using TECIS.Web.ViewModels;
using OfficeOpenXml;
using System.Web.Security;
namespace TECIS.Web.Controllers
{
    public class MembersController : BaseController
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Members/
        public ActionResult Index()
        {
            var members = db.Members.Include(m => m.cluster).Include(m => m.maritalstats).Include(m => m.serviceunit);
            return View(members.ToList());
        }

        // GET: /Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: /Members/Create
        public ActionResult Create()
        {
            ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName");
            ViewBag.preferred_cluster = new SelectList(db.Clusters, "Id", "ClusterName");
            ViewBag.maritalstatus = new SelectList(db.MaritalStats, "Id", "Description");
            ViewBag.serviceunit_id = new SelectList(db.ServiceUnits, "Id", "UnitName");
            ViewBag.preferred_serviceunit = new SelectList(db.ServiceUnits, "Id", "UnitName");
            return View();
        }

        // POST: /Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,merberid,surname,firstname,othernames,address,telephone,email_address,dob,gender,maritalstatus,wedding_anniv,occupation,no_of_children,officeaddress,flg_attends_cluster,clusterid,preferred_cluster,flg_serving,serviceunit_id,preferred_serviceunit,child_1,child_1_birthday,child_2,child_2_birthday,child_3,child_3_birthday")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                { member.createdby = User.Identity.Name; }
                member.createddate = DateTime.Now;
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName", member.clusterid);
            ViewBag.preferred_cluster = new SelectList(db.Clusters, "Id", "ClusterName", member.preferred_cluster);
            ViewBag.maritalstatus = new SelectList(db.MaritalStats, "Id", "Description", member.maritalstatus);
            ViewBag.serviceunit_id = new SelectList(db.ServiceUnits, "Id", "UnitName", member.serviceunit_id);
            ViewBag.preferred_serviceunit = new SelectList(db.ServiceUnits, "Id", "UnitName", member.preferred_serviceunit);

            return View(member);
        }

        // GET: /Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            ViewBag.preferred_cluster = new SelectList(db.Clusters, "Id", "ClusterName", member.preferred_cluster);
            ViewBag.maritalstatus = new SelectList(db.MaritalStats, "Id", "Description", member.maritalstatus);
            ViewBag.preferred_serviceunit = new SelectList(db.ServiceUnits, "Id", "UnitName", member.preferred_serviceunit);
            return View(member);
        }

        // POST: /Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,merberid,surname,firstname,othernames,address,telephone,email_address,dob,gender,maritalstatus,wedding_anniv,occupation,no_of_children,officeaddress,flg_attends_cluster,clusterid,preferred_cluster,flg_serving,serviceunit_id,preferred_serviceunit,child_1,child_1_birthday,child_2,child_2_birthday,child_3,child_3_birthday,clusterhead")] Member member)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.preferred_cluster = new SelectList(db.Clusters, "Id", "ClusterName", member.preferred_cluster);
            ViewBag.maritalstatus = new SelectList(db.MaritalStats, "Id", "Description", member.maritalstatus);
            ViewBag.preferred_serviceunit = new SelectList(db.ServiceUnits, "Id", "UnitName", member.preferred_serviceunit);
            return View(member);
        }

        // GET: /Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: /Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: /GuestUploads/
        public ActionResult UploadView()
        {
            return View(db.MemberUploads.ToList().OrderByDescending(a => a.createddate));
        }
        public ActionResult ImportMembers()
        {
            return View();
        }

        //[HttpPost, HttpParamAction("ImportGuests"), ValidateAntiForgeryToken]
        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ImportMembers")]
        public ActionResult ImportMembers(FormCollection collection)
        {

            //return Json(new { Message = "File saved" });

            //publish content
            if (Request != null)
            {
                foreach (var fileKey in Request.Files.AllKeys)
                {
                    try
                    {
                        HttpPostedFileBase file = Request.Files[fileKey];
                        if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                        {
                            string fileName = file.FileName;
                            string fileContentType = file.ContentType;
                            byte[] fileBytes = new byte[file.ContentLength];
                            var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                            var guestList = new List<MemberUpload>();
                            //GuestUpload upld = new GuestUpload();
                            using (var package = new ExcelPackage(file.InputStream))
                            {
                                var currentSheet = package.Workbook.Worksheets;
                                var workSheet = currentSheet.First();
                                var noOfCol = workSheet.Dimension.End.Column;
                                var noOfRow = workSheet.Dimension.End.Row;
                                //S/No	SURNAME	OTHERNAMES	AGE	GENDER	MARITAL STATUS	PHONE  NUMBER	EMAIL	HOME  ADDRESS	NEAREST BUS STOP 	CLUSTER AREA 
                                //OFFICE ADDRESS	OCCUPATION	WOULD YOU CONSIDER JOINING ELEVATION CHURCH	WOULD YO LIKE TO RECEIVE MEMBERSHIP INFO	WOULD YOU LIKE TO RECEIVE UPDATES ABOUT OUR EVENTS	HOW DID YOU GET TO KNOW ABOUT OUR CHURCH	PRAYER/SERVICE COMMENTS																

                                System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
                                for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                                {
                                    var member = new MemberUpload();
                                    member.datejoined = workSheet.Cells[rowIterator, 1].Value == null ? string.Empty : workSheet.Cells[rowIterator, 1].Value.ToString().Trim();
                                    member.surname = workSheet.Cells[rowIterator, 2].Value == null ? string.Empty : workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                                    member.firstname = workSheet.Cells[rowIterator, 3].Value == null ? string.Empty : workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                    member.othernames = workSheet.Cells[rowIterator, 4].Value == null ? string.Empty : workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                    member.address = workSheet.Cells[rowIterator, 5].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                    member.telephone = workSheet.Cells[rowIterator, 6].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                    member.email_address = workSheet.Cells[rowIterator, 7].Value == null ? string.Empty : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                    member.dob = workSheet.Cells[rowIterator, 8].Value == null ? string.Empty : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                    member.age = workSheet.Cells[rowIterator, 9].Value == null ? string.Empty : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                    member.gender = workSheet.Cells[rowIterator, 10].Value == null ? string.Empty : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                    member.maritalstatus = workSheet.Cells[rowIterator, 11].Value == null ? string.Empty : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                    member.wedding_anniv = workSheet.Cells[rowIterator, 12].Value == null ? string.Empty : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                    member.occupation = workSheet.Cells[rowIterator, 13].Value == null ? string.Empty : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                    member.officeaddress = workSheet.Cells[rowIterator, 14].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 14].Value.ToString().Trim());
                                    member.cluster = workSheet.Cells[rowIterator, 15].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                                    member.serviceunit = workSheet.Cells[rowIterator, 16].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 16].Value.ToString().Trim());
                                    member.no_of_children = workSheet.Cells[rowIterator, 17].Value == null ? string.Empty : workSheet.Cells[rowIterator, 17].Value.ToString().Trim();
                                    member.child_1 = workSheet.Cells[rowIterator, 18].Value == null ? string.Empty : workSheet.Cells[rowIterator, 18].Value.ToString().Trim();
                                    member.child_1_age = workSheet.Cells[rowIterator, 19].Value == null ? string.Empty : workSheet.Cells[rowIterator, 19].Value.ToString().Trim();
                                    member.child_1_birthday = workSheet.Cells[rowIterator, 20].Value == null ? string.Empty : workSheet.Cells[rowIterator, 20].Value.ToString().Trim();

                                    member.child_2 = workSheet.Cells[rowIterator, 21].Value == null ? string.Empty : workSheet.Cells[rowIterator, 21].Value.ToString().Trim();
                                    member.child_2_age = workSheet.Cells[rowIterator, 22].Value == null ? string.Empty : workSheet.Cells[rowIterator, 22].Value.ToString().Trim();
                                    member.child_2_birthday = workSheet.Cells[rowIterator, 23].Value == null ? string.Empty : workSheet.Cells[rowIterator, 23].Value.ToString().Trim();

                                    member.child_3 = workSheet.Cells[rowIterator, 24].Value == null ? string.Empty : workSheet.Cells[rowIterator, 24].Value.ToString().Trim();
                                    member.child_3_age = workSheet.Cells[rowIterator, 25].Value == null ? string.Empty : workSheet.Cells[rowIterator, 25].Value.ToString().Trim();
                                    member.child_3_birthday = workSheet.Cells[rowIterator, 26].Value == null ? string.Empty : workSheet.Cells[rowIterator, 26].Value.ToString().Trim();

                                    member.child_4 = workSheet.Cells[rowIterator, 27].Value == null ? string.Empty : workSheet.Cells[rowIterator, 27].Value.ToString().Trim();
                                    member.child_4_age = workSheet.Cells[rowIterator, 28].Value == null ? string.Empty : workSheet.Cells[rowIterator, 28].Value.ToString().Trim();
                                    member.child_4_birthday = workSheet.Cells[rowIterator, 29].Value == null ? string.Empty : workSheet.Cells[rowIterator, 29].Value.ToString().Trim();
                                
                                    //guestList.Add(guest);
                                    member.createddate = DateTime.Now;
                                    member.createdby = User.Identity.Name;
                                    db.MemberUploads.Add(member);
                                }

                                db.SaveChanges();
                                Success(string.Format("<b> {0}</b> rows successfully added.", noOfRow), true);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return Json(new { Message = "Error in uploading file" });
                    }
                }
                return Json(new { Message = "File Uploaded" });
                //HttpPostedFileBase file = Request.Files["UploadedFile"];

            }
            else
            { return View(); }
            //return RedirectToAction("Index");
        }
        public JsonResult GetMembers()
        {
            var db = new TecIsEntities();
            var members = from Members in db.Members
                           select new
                           {
                               MemberId = Members.Id,
                               MemberName = Members.surname + " - " + Members.othernames
                           };

            //var clusters =
            //    db.Clusters.Select(c => new { ClusterId = c.Id, ClusterName = c.ClusterName })

            return Json(members.OrderBy(a => a.MemberName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult MyMembers()
        {
            //role must have hierarchies cos to select data the highest level must be used. 
            //e.g if a user has both connect group leader and area leader, area leader should be used to select data 
            //get the current users role
            //string[] roleNames = Roles.GetRolesForUser(User.Identity.Name);
            //var query = from g in db.Guests
            //            select g;

            if (User.IsInRole("ClusterLeader"))
            {
                int myclusterId = ClustersController.GetClustIdByLeaderEmail(User.Identity.Name);
                return View(db.Guests.Where(x => x.ClusterArea == myclusterId).OrderByDescending(v => v.worshipdate).ToList());
            }
            else if (User.IsInRole("SectionLeader"))
            {
                //select * from guests where clusterarea in select id from clusters where sectionid = sectionleaderid
                int mysectionId = ClustersController.GetSectIdbyLeaderEmail(User.Identity.Name);
                var clustersinmysection = db.Clusters.Where(a => a.ClusterSection == mysectionId).ToList();
                var myclusterList = new List<Int32>();
                foreach (var item in clustersinmysection)
                {
                    myclusterList.Add(item.Id);
                }

                return View(db.Guests.Where(x => myclusterList.Contains(x.ClusterArea)).OrderByDescending(v => v.worshipdate).ToList());
            }
            else if (User.IsInRole("AreaLeader"))
            {

                int myareaId = ClustersController.GetAreaIdbyLeaderEmail(User.Identity.Name);
                var clustersinmyarea = db.Clusters.Where(a => a.ClusterArea == myareaId).ToList();
                var myclusterList = new List<Int32>();
                foreach (var item in clustersinmyarea)
                {
                    myclusterList.Add(item.Id);
                }
                //var userProfiles = _dataContext.UserProfile
                //               .Where(t => idList.Contains(t.Id));
                return View(db.Guests.Where(x => myclusterList.Contains(x.ClusterArea)).OrderByDescending(v => v.worshipdate).ToList());
            }
            else if (User.IsInRole("ZonalLeader"))
            {

                int myzonalId = ClustersController.GetZoneIdbyLeaderEmail(User.Identity.Name);
                var clustersinmyzone = db.Clusters.Where(a => a.ClusterZone == myzonalId).ToList();
                var myclusterList = new List<Int32>();
                foreach (var item in clustersinmyzone)
                {
                    myclusterList.Add(item.Id);
                }
                //var userProfiles = _dataContext.UserProfile
                //               .Where(t => idList.Contains(t.Id));
                return View(db.Guests.Where(x => myclusterList.Contains(x.ClusterArea)).OrderByDescending(v => v.worshipdate).ToList());
            }
            else
            {
                return View(db.Guests.OrderByDescending(v => v.worshipdate).ToList());
            }

        }
        public ActionResult GetMembersResource()
        {

            var members = new TecIsEntities().Members.Select(e => new MembersViewModel
            {
                MemberId = e.Id,
                MemberName = e.surname,
                MemberSchedulerColor = "#F9722E"
            });

            return Json(members, JsonRequestBehavior.AllowGet);
            //return View();
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
