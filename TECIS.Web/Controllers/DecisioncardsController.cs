using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TECIS.Data.Models;
using TECIS.Web.ActionFilters;

namespace TECIS.Web.Controllers
{
    public class DecisioncardsController : BaseController
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Decisioncards/
        public ActionResult Index()
        {
            return View(db.Decisioncards.ToList());
        }

        // GET: /Decisioncards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decisioncard decisioncard = db.Decisioncards.Find(id);
            if (decisioncard == null)
            {
                return HttpNotFound();
            }
            return View(decisioncard);
        }

        // GET: /Decisioncards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Decisioncards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Create")]
        public ActionResult Create([Bind(Include="Id,Gender,ResponseType,MaritalStat,BirthDate,Surname,OtherNames,HomeAddress,PhoneNumber,OfficeAddress,EmailAddress,PrayerRequest,timecaptured,worshipdate,createdby")] Decisioncard decisioncard)
        {
            if (ModelState.IsValid)
            {
                decisioncard.timecaptured = DateTime.Now;
                decisioncard.worshipdate = DateTime.Now;

                if (Request.IsAuthenticated)
                { decisioncard.createdby = User.Identity.Name; }
                db.Decisioncards.Add(decisioncard);
                db.SaveChanges();
                Success(string.Format("<b>Card {0}</b> was successfully added.", decisioncard.PhoneNumber), true);
                return RedirectToAction("Index");
            }
                ViewBag.MaritalStatus = new SelectList(db.MaritalStats, "Id", "Description", decisioncard.MaritalStat);
            
                Danger("Looks like something went wrong. Please check your form.");
            //    return View(card);
            return View(decisioncard);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "CreateNNew")]
        public ActionResult CreateNNew([Bind(Include = "Id,Gender,ResponseType,MaritalStat,BirthDate,Surname,OtherNames,HomeAddress,PhoneNumber,OfficeAddress,EmailAddress,PrayerRequest,timecaptured,worshipdate,createdby")] Decisioncard decisioncard)
        {
            if (ModelState.IsValid)
            {
                decisioncard.timecaptured = DateTime.Now;
                decisioncard.worshipdate = DateTime.Now;

                if (Request.IsAuthenticated)
                { decisioncard.createdby = User.Identity.Name; }
                db.Decisioncards.Add(decisioncard);
                db.SaveChanges();
                Success(string.Format("<b>Card {0}</b> was successfully added.", decisioncard.PhoneNumber), true);
                return RedirectToAction("Create");
            }
            ViewBag.MaritalStatus = new SelectList(db.MaritalStats, "Id", "Description", decisioncard.MaritalStat);

            Danger("Looks like something went wrong. Please check your form.");
            
            return View(decisioncard);
        }

        // GET: /Decisioncards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decisioncard decisioncard = db.Decisioncards.Find(id);
            if (decisioncard == null)
            {
                return HttpNotFound();
            }
            return View(decisioncard);
        }

        // POST: /Decisioncards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Gender,ResponseType,MaritalStat,BirthDate,Surname,OtherNames,HomeAddress,PhoneNumber,OfficeAddress,EmailAddress,PrayerRequest,timecaptured,worshipdate,createdby")] Decisioncard decisioncard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decisioncard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decisioncard);
        }

        // GET: /Decisioncards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decisioncard decisioncard = db.Decisioncards.Find(id);
            if (decisioncard == null)
            {
                return HttpNotFound();
            }
            return View(decisioncard);
        }

        // POST: /Decisioncards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decisioncard decisioncard = db.Decisioncards.Find(id);
            db.Decisioncards.Remove(decisioncard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ExportDecisionCard")]
        [Authorize(Roles = "TeamLeader")]
        public void ExportDecisionCard(FormCollection collection)
        {
            string exportoptions = collection["export-options"].ToString();
            var grid = new System.Web.UI.WebControls.GridView();

            var today = DateTime.Now.Date;
            var query = from g in db.Decisioncards
                        select g;
            if (exportoptions == "all-day")
                query = query.Where(g => g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day);
            else if (exportoptions == "user-all")
                query = query.Where(g => g.createdby == User.Identity.Name);
            else if (exportoptions == "user-day")
                query = query.Where(g => g.createdby == User.Identity.Name && g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day);
            else if (exportoptions == "team-day")
            {
                var myteamuserIds = (from p in db.UserProfiles
                                     where p.AdminConfirmed == 1
                                     where p.TeamLeader == User.Identity.Name
                                     select p.UserName).ToList();
                DateTime _today = DateTime.Now.Date;
               
                query = query.Where(g => g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day).Where(a => a.PhoneNumber != "").Where(x => myteamuserIds.Contains(x.createdby));
            }

          

            var exportguests = query.Select(d => new
            {
                Surname = d.Surname,
                Othernames = d.OtherNames,                
                Gender = d.Gender,
                MaritalStatus = d.MaritalStat,
                PhoneNumber = d.PhoneNumber,
                Email = d.EmailAddress,
                Birthdate = d.BirthDate,
                ResponseType = d.ResponseType,
                PrayerRequest = d.PrayerRequest,
                HomeAddress = d.HomeAddress,
                OfficeAddress = d.OfficeAddress,
                Createdby = d.createdby,
                WorshipDate = d.timecaptured
            }).ToList();
            

            grid.DataSource = exportguests;
            grid.DataBind();

            Response.ClearContent();
            var fName = string.Format("Decicsioncards{0}", DateTime.Now.ToString("dd.MM.yyyy"));
            Response.AddHeader("content-disposition", "attachment; filename=" + fName + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

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
