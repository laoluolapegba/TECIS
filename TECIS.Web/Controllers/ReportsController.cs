using OfficeOpenXml;
using OfficeOpenXml.Table;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TECIS.Data.Models;
using TECIS.Web.Helpers.CrossCutting.Export;
using TECIS.Web.Helpers.CrossCutting.SendGridEmailService;
using TECIS.Web.ViewModels;

namespace TECIS.Web.Controllers
{
    public class ReportsController : BaseController
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Reports/
        public ActionResult Index()
        {
            return View(db.ReportStats.ToList());
        }
        public ActionResult GuestReport()
        {
            return View(db.ReportStats.ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> GuestReport(FormCollection collection)
        {
            string rptoption = collection["report-option"];
            DateTime rptDate = DateTime.Parse(collection["ServiceDate"]);
            await GenGuestReport(rptoption, rptDate);
            Success(string.Format("<b>Guest Report</b> has been sent."), true);

            return View(db.ReportStats.ToList());
        }
        public PartialViewResult ReportStatuspartial(string id)
        {
            int rptId = int.Parse(id);
            return PartialView(db.ReportStats.Where(r => r.reportid == rptId).OrderByDescending(r => r.datesent)
                );
        }
        //public PartialViewResult RacersByCountryPartial(string id)
        //{
        //    return PartialView(
        //        db.Racers.Where(r => r.Country == id).OrderByDescending(r => r.Wins)
        //            .ThenBy(r => r.Lastname).ToList());
        //}
        private async Task GenGuestReport(string rptoption, DateTime rptDate)
        {
            //string xxxx = "";
            if(rptoption == "0")
            {
                #region Connect Group Leader
                    //get all clusters with guests on selected date
                var guestspercluster = (from o in db.Guests
                                        join cl in db.Clusters on o.ClusterArea equals cl.Id
                                        where o.worshipdate == rptDate.Date
                                        group new { o, cl } by new { o.ClusterArea, cl.ClusterEmail }
                                            into grp
                                            select new
                                            {
                                                ClusterId = grp.Key.ClusterArea,
                                                ClusterLeader = grp.Key.ClusterEmail,
                                                TotalGuests = grp.Count()
                                            });
                var gpersec = guestspercluster.ToList();
                foreach (var item in gpersec)
                    {
                        if (item.ClusterLeader != string.Empty)
                        {
                            ReportStatus reportStatus = new ReportStatus();
                            reportStatus.datesent = DateTime.Now;
                            reportStatus.recipient = item.ClusterLeader;
                            reportStatus.reportid = int.Parse(rptoption);
                            reportStatus.reportdate = rptDate;
                            reportStatus.status = true;
                            try
                            {
                                ExportHelper xpt = new ExportHelper();
                                SendGridEmailService svc = new SendGridEmailService();


                                var query = from g in db.Guests
                                            select g;
                                query = query.Where(a => a.worshipdate == rptDate && a.ClusterArea == item.ClusterId);

                                var exportguests = query.Select(d => new GuestViewModel
                                {
                                    Surname = d.Surname,
                                    Othernames = d.OtherNames,
                                    Age = d.age.Description,
                                    Gender = d.Gender,
                                    MaritalStatus = d.maritalstats.Description,
                                    PhoneNumber = d.PhoneNumber,
                                    Email = d.EmailAddress,
                                    HomeAddress = d.HomeAddress,
                                    NearestBusstop = d.NearestBStop,
                                    ClusterArea = d.clusters.ClusterName,
                                    OfficeAddress = d.OfficeAdress,
                                    Occupation = d.Occupation,
                                    WouldJoin = d.answer.Description,
                                    MemberShipInfo = d.answer1.Description,
                                    Updates = d.answer2.Description,
                                    HowdidyouKnow = d.Entrychannel,
                                    PrayerComments = d.PrayerComments,
                                    Createdby = d.createdby,
                                    SMSsent = d.SmsSent

                                }).ToList();

                                var fName = string.Format("Group_GuestList{0}{1}", item.ClusterId, DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff"));

                                string filePhysicalPath = Server.MapPath("~/App_Data/" + fName + ".xlsx");
                                Response.Clear();
                                Response.Charset = "";
                                Response.ContentEncoding = System.Text.Encoding.UTF8;
                                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=\"" + fName + "\"");

                                using (ExcelPackage pck = new ExcelPackage())
                                {
                                    ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
                                    wsDt.Cells["A1"].LoadFromCollection(exportguests, true, TableStyles.None);
                                    wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                                    //Response.BinaryWrite(pck.GetAsByteArray());

                                    System.IO.File.WriteAllBytes(filePhysicalPath, pck.GetAsByteArray());
                                }

                                Response.Flush();
                                Response.End();
                                Response.BufferOutput = true;
                                //xpt.ToExcel(HttpContext.Response, exportguests, dataFile);

                                MailAddress from = new MailAddress(item.ClusterLeader);
                                MailAddress to = new MailAddress(item.ClusterLeader);
                                MailMessage msg = new MailMessage(from, to);
                                var sb = new System.Text.StringBuilder(137);
                                sb.AppendLine(@"Dear Leaders").Append(Environment.NewLine);
                                sb.AppendLine(@"Please find attached guest list from your area for today's service").Append(Environment.NewLine);
                                sb.AppendLine(@"Kindly get in touch with them").Append(Environment.NewLine);
                                sb.AppendLine(@"Regards.");

                                msg.Body = sb.ToString();
                                msg.Subject = "Guest Report";

                                msg.IsBodyHtml = true;
                                await svc.SendGridMail(msg, filePhysicalPath);

                                //Log it

                            }
                            catch (Exception e)
                            {
                                Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(e));
                                reportStatus.status = false;
                            }
                            finally
                            {
                                db.ReportStats.Add(reportStatus);
                                db.SaveChanges();
                            }

                        }

                    }
                 #endregion
            }
            else if (rptoption =="1")
            {
                #region Section Leaders
                var guestspersection = (from o in db.Guests
                                        join cl in db.Clusters on o.ClusterArea equals cl.Id
                                        join sec in db.CSections on cl.ClusterSection equals sec.Id
                                        where o.worshipdate == rptDate.Date
                                        group new { cl, sec } by new { cl.ClusterSection, sec.SectionEmail }
                                            into grp
                                            select new
                                            {
                                                SectionId = grp.Key.ClusterSection,
                                                SectionEmail = grp.Key.SectionEmail,
                                                TotalGuests = grp.Count()
                                            });
                var gpersec = guestspersection.ToList();
                foreach (var item in gpersec)
                {
                    if (item.SectionEmail != string.Empty)
                    {
                        ReportStatus reportStatus = new ReportStatus();
                        reportStatus.datesent = DateTime.Now;
                        reportStatus.recipient = item.SectionEmail;
                        reportStatus.reportid = int.Parse(rptoption);
                        reportStatus.reportdate = rptDate;
                        reportStatus.status = true;
                        try
                        {
                            ExportHelper xpt = new ExportHelper();
                            SendGridEmailService svc = new SendGridEmailService();


                            var query = (from o in db.Guests
                                         join cl in db.Clusters on o.ClusterArea equals cl.Id
                                         join sec in db.CSections on cl.ClusterSection equals sec.Id
                                         where o.worshipdate == rptDate.Date
                                         where cl.ClusterSection == item.SectionId
                                         where o.worshipdate == rptDate
                                        select o);
                            //query = query.Where(a => a.worshipdate == rptDate);

                            var exportguests = query.Select(d => new GuestViewModel
                            {
                                Surname = d.Surname,
                                Othernames = d.OtherNames,
                                Age = d.age.Description,
                                Gender = d.Gender,
                                MaritalStatus = d.maritalstats.Description,
                                PhoneNumber = d.PhoneNumber,
                                Email = d.EmailAddress,
                                HomeAddress = d.HomeAddress,
                                NearestBusstop = d.NearestBStop,
                                ClusterArea = d.clusters.ClusterName,
                                OfficeAddress = d.OfficeAdress,
                                Occupation = d.Occupation,
                                WouldJoin = d.answer.Description,
                                MemberShipInfo = d.answer1.Description,
                                Updates = d.answer2.Description,
                                HowdidyouKnow = d.Entrychannel,
                                PrayerComments = d.PrayerComments,
                                Createdby = d.createdby,
                                SMSsent = d.SmsSent

                            }).ToList();

                            var fName = string.Format("Section_GuestList{0}{1}", item.SectionId, DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff"));

                            string filePhysicalPath = Server.MapPath("~/App_Data/" + fName + ".xlsx");
                            Response.Clear();
                            Response.Charset = "";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + fName + "\"");

                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
                                wsDt.Cells["A1"].LoadFromCollection(exportguests, true, TableStyles.None);
                                wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                                //Response.BinaryWrite(pck.GetAsByteArray());

                                System.IO.File.WriteAllBytes(filePhysicalPath, pck.GetAsByteArray());
                            }

                            Response.Flush();
                            Response.End();

                            //xpt.ToExcel(HttpContext.Response, exportguests, dataFile);

                            MailAddress from = new MailAddress(item.SectionEmail);
                            MailAddress to = new MailAddress(item.SectionEmail);
                            MailMessage msg = new MailMessage(from, to);
                            var sb = new System.Text.StringBuilder(137);
                            sb.AppendLine(@"Dear Leaders").Append(Environment.NewLine);
                            sb.AppendLine(@"Please find attached guest list from your area for today's service").Append(Environment.NewLine);
                            sb.AppendLine(@"Kindly get in touch with them").Append(Environment.NewLine);
                            sb.AppendLine(@"Regards.");

                            msg.Body = sb.ToString();
                            msg.Subject = "Guest Report";

                            msg.IsBodyHtml = true;
                            await svc.SendGridMail(msg, filePhysicalPath);

                            //Log it

                        }
                        catch (Exception e)
                        {
                            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(e));
                            reportStatus.status = false;
                        }
                        finally
                        {
                            db.ReportStats.Add(reportStatus);
                            db.SaveChanges();
                        }

                    }

                }
                #endregion
                
            }
            else if (rptoption == "2")
            {
                #region Area Leaders
                var guestsperarea = (from o in db.Guests
                                     join cl in db.Clusters on o.ClusterArea equals cl.Id
                                     join area in db.CAreas on cl.ClusterArea equals area.Id
                                     where o.worshipdate == rptDate.Date
                                     group new { cl, area } by new { cl.ClusterArea, area.AreaEmail }
                                         into grp
                                         select new
                                         {
                                             AreaId = grp.Key.ClusterArea,
                                             AreaEmail = grp.Key.AreaEmail,
                                             TotalGuests = grp.Count()
                                         });
                var gperarea = guestsperarea.ToList();
                foreach (var item in gperarea)
                {
                    if (item.AreaEmail != string.Empty && item.AreaEmail != null)
                    {
                        ReportStatus reportStatus = new ReportStatus();
                        reportStatus.datesent = DateTime.Now;
                        reportStatus.recipient = item.AreaEmail;
                        reportStatus.reportid = int.Parse(rptoption);
                        reportStatus.reportdate = rptDate;
                        reportStatus.status = true;
                        try
                        {
                            ExportHelper xpt = new ExportHelper();
                            SendGridEmailService svc = new SendGridEmailService();


                            var query = (from o in db.Guests
                                         join cl in db.Clusters on o.ClusterArea equals cl.Id
                                         join sec in db.CSections on cl.ClusterSection equals sec.Id
                                         where o.worshipdate == rptDate.Date
                                         where cl.ClusterArea == item.AreaId
                                         where o.worshipdate == rptDate
                                         select o);
                            //query = query.Where(a => a.worshipdate == rptDate);

                            var exportguests = query.Select(d => new GuestViewModel
                            {
                                Surname = d.Surname,
                                Othernames = d.OtherNames,
                                Age = d.age.Description,
                                Gender = d.Gender,
                                MaritalStatus = d.maritalstats.Description,
                                PhoneNumber = d.PhoneNumber,
                                Email = d.EmailAddress,
                                HomeAddress = d.HomeAddress,
                                NearestBusstop = d.NearestBStop,
                                ClusterArea = d.clusters.ClusterName,
                                OfficeAddress = d.OfficeAdress,
                                Occupation = d.Occupation,
                                WouldJoin = d.answer.Description,
                                MemberShipInfo = d.answer1.Description,
                                Updates = d.answer2.Description,
                                HowdidyouKnow = d.Entrychannel,
                                PrayerComments = d.PrayerComments,
                                Createdby = d.createdby,
                                SMSsent = d.SmsSent

                            }).ToList();

                            var fName = string.Format("Area_GuestList{0}{1}", item.AreaId, DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff"));

                            string filePhysicalPath = Server.MapPath("~/App_Data/" + fName + ".xlsx");
                            Response.Clear();
                            Response.Charset = "";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + fName + "\"");

                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
                                wsDt.Cells["A1"].LoadFromCollection(exportguests, true, TableStyles.None);
                                wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                                //Response.BinaryWrite(pck.GetAsByteArray());

                                System.IO.File.WriteAllBytes(filePhysicalPath, pck.GetAsByteArray());
                            }

                            Response.Flush();
                            Response.End();

                            //xpt.ToExcel(HttpContext.Response, exportguests, dataFile);

                            MailAddress from = new MailAddress(item.AreaEmail);
                            MailAddress to = new MailAddress(item.AreaEmail);
                            MailMessage msg = new MailMessage(from, to);
                            var sb = new System.Text.StringBuilder(137);
                            sb.AppendLine(@"Dear Leaders").Append(Environment.NewLine);
                            sb.AppendLine(@"Please find attached guest list from your area for today's service").Append(Environment.NewLine);
                            sb.AppendLine(@"Kindly get in touch with them").Append(Environment.NewLine);
                            sb.AppendLine(@"Regards.");

                            msg.Body = sb.ToString();
                            msg.Subject = "Guest Report";

                            msg.IsBodyHtml = true;
                            await svc.SendGridMail(msg, filePhysicalPath);

                            //Log it

                        }
                        catch (Exception e)
                        {
                            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(e));
                            reportStatus.status = false;
                        }
                        finally
                        {
                            db.ReportStats.Add(reportStatus);
                            db.SaveChanges();
                        }

                    }

                }
                #endregion

            }
            else if (rptoption == "3")
            {
                #region Zonal Leaders
                var guestsperzone = (from o in db.Guests
                                     join cl in db.Clusters on o.ClusterArea equals cl.Id
                                     join zone in db.CZones on cl.ClusterZone equals zone.Id
                                     where o.worshipdate == rptDate.Date
                                     group new { cl, zone } by new { cl.ClusterZone, zone.ZoneEmail }
                                         into grp
                                         select new
                                         {
                                             ZoneId = grp.Key.ClusterZone,
                                             ZoneEmail = grp.Key.ZoneEmail,
                                             TotalGuests = grp.Count()
                                         });
                var gperzone = guestsperzone.ToList();
                foreach (var item in gperzone)
                {
                    if (item.ZoneEmail != string.Empty && item.ZoneEmail != null)
                    {
                        ReportStatus reportStatus = new ReportStatus();
                        reportStatus.datesent = DateTime.Now;
                        reportStatus.recipient = item.ZoneEmail;
                        reportStatus.reportid = int.Parse(rptoption);
                        reportStatus.reportdate = rptDate;
                        reportStatus.status = true;
                        try
                        {
                            ExportHelper xpt = new ExportHelper();
                            SendGridEmailService svc = new SendGridEmailService();


                            var query = (from o in db.Guests
                                         join cl in db.Clusters on o.ClusterArea equals cl.Id
                                         join sec in db.CSections on cl.ClusterSection equals sec.Id
                                         where o.worshipdate == rptDate.Date
                                         where cl.ClusterZone == item.ZoneId
                                         where o.worshipdate == rptDate
                                         select o);
                            //query = query.Where(a => a.worshipdate == rptDate);

                            var exportguests = query.Select(d => new GuestViewModel
                            {
                                Surname = d.Surname,
                                Othernames = d.OtherNames,
                                Age = d.age.Description,
                                Gender = d.Gender,
                                MaritalStatus = d.maritalstats.Description,
                                PhoneNumber = d.PhoneNumber,
                                Email = d.EmailAddress,
                                HomeAddress = d.HomeAddress,
                                NearestBusstop = d.NearestBStop,
                                ClusterArea = d.clusters.ClusterName,
                                OfficeAddress = d.OfficeAdress,
                                Occupation = d.Occupation,
                                WouldJoin = d.answer.Description,
                                MemberShipInfo = d.answer1.Description,
                                Updates = d.answer2.Description,
                                HowdidyouKnow = d.Entrychannel,
                                PrayerComments = d.PrayerComments,
                                Createdby = d.createdby,
                                SMSsent = d.SmsSent

                            }).ToList();

                            var fName = string.Format("Zone_GuestList{0}{1}", item.ZoneId, DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff"));

                            string filePhysicalPath = Server.MapPath("~/App_Data/" + fName + ".xlsx");
                            Response.Clear();
                            Response.Charset = "";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=\"" + fName + "\"");

                            using (ExcelPackage pck = new ExcelPackage())
                            {
                                ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
                                wsDt.Cells["A1"].LoadFromCollection(exportguests, true, TableStyles.None);
                                wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

                                //Response.BinaryWrite(pck.GetAsByteArray());

                                System.IO.File.WriteAllBytes(filePhysicalPath, pck.GetAsByteArray());
                            }

                            Response.Flush();
                            Response.End();

                            //xpt.ToExcel(HttpContext.Response, exportguests, dataFile);

                            MailAddress from = new MailAddress(item.ZoneEmail);
                            MailAddress to = new MailAddress(item.ZoneEmail);
                            MailMessage msg = new MailMessage(from, to);
                            var sb = new System.Text.StringBuilder(137);
                            sb.AppendLine(@"Dear Leaders").Append(Environment.NewLine);
                            sb.AppendLine(@"Please find attached guest list from your area for today's service").Append(Environment.NewLine);
                            sb.AppendLine(@"Kindly get in touch with them").Append(Environment.NewLine);
                            sb.AppendLine(@"Regards.");

                            msg.Body = sb.ToString();
                            msg.Subject = "Guest Report";

                            msg.IsBodyHtml = true;
                            await svc.SendGridMail(msg, filePhysicalPath);

                            //Log it

                        }
                        catch (Exception e)
                        {
                            Elmah.ErrorLog.GetDefault(null).Log(new Elmah.Error(e));
                            reportStatus.status = false;
                        }
                        finally
                        {
                            db.ReportStats.Add(reportStatus);
                            db.SaveChanges();
                        }

                    }

                }
                #endregion
            }
            
        }
        private string SaveExcelFile(object dt, string reportName)
        {
            ////string reportName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss-fff") + ".xlsx";

            //Response.Clear();
            //Response.Charset = "";
            //Response.ContentEncoding = System.Text.Encoding.UTF8;
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment;filename=\"" + reportName + "\"");
            
            //using (ExcelPackage pck = new ExcelPackage())
            //{
            //    ExcelWorksheet wsDt = pck.Workbook.Worksheets.Add("Sheet1");
            //    wsDt.Cells["A1"].LoadFromCollection(dt, true, TableStyles.None);
            //    wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

            //    //Response.BinaryWrite(pck.GetAsByteArray());
            //    string filePhysicalPath = Server.MapPath("~/App_Data/" + reportName);
            //    System.IO.File.WriteAllBytes(filePhysicalPath, pck.GetAsByteArray());
            //}

            //Response.Flush();
            //Response.End();

            return reportName;
        }
        // GET: /Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportStatus reportStatus = db.ReportStats.Find(id);
            if (reportStatus == null)
            {
                return HttpNotFound();
            }
            return View(reportStatus);
        }

        // GET: /Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,reportid,recipient,status,reportdate")] ReportStatus reportStatus)
        {
            if (ModelState.IsValid)
            {
                db.ReportStats.Add(reportStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportStatus);
        }

        // GET: /Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportStatus reportStatus = db.ReportStats.Find(id);
            if (reportStatus == null)
            {
                return HttpNotFound();
            }
            return View(reportStatus);
        }

        // POST: /Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,reportid,recipient,status,reportdate")] ReportStatus reportStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportStatus);
        }

        // GET: /Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportStatus reportStatus = db.ReportStats.Find(id);
            if (reportStatus == null)
            {
                return HttpNotFound();
            }
            return View(reportStatus);
        }

        // POST: /Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportStatus reportStatus = db.ReportStats.Find(id);
            db.ReportStats.Remove(reportStatus);
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
        public ActionResult ReportViewer()
        {
            //decimal BranchID = Convert.ToDecimal(Request.QueryString["BranchID"]);
            //switch (id)
            //{case 101:

            //    default:
            //        break;
            //}
            ViewBag.ShowIFrame = false;
            ViewBag.REPORT_ID = new SelectList(db.RptDefinition, "REPORT_ID", "REPORT_NAME");
            ViewBag.SearchMode = 1;
            ReportRequestViewModel model = new ReportRequestViewModel();
            model.FROM_DATE = DateTime.Now;
            model.TO_DATE = DateTime.Now;
            model.SearchMode = 1;
            //ViewBag.CURRENCY_ID = new SelectList(db.Currency, "CURR_ID", "CURR_NAME");
            //ViewBag.BRANCH_ID = new SelectList(db.Branch, "BRANCH_ID", "BRANCH_NAME");
            //RptDefn rptDefn = db.RptDefinition.Find(id);
            //ViewBag.REPORT_NAME = rptDefn.Report_Name;
            //ViewBag.REPORT_DESCRIPTION = rptDefn.Report_Description;

            return View(model);
        }
        [HttpPost]
        public ActionResult ReportViewer(ReportRequestViewModel reportDefn, FormCollection formitems)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ShowIFrame = true;
                

                RptDefn report = db.RptDefinition.Find(reportDefn.REPORT_ID);
                reportDefn.REPORT_DESCRIPTION = report.Report_Description;
                reportDefn.REPORT_NAME = report.Report_Name;
                reportDefn.REPORT_URL = report.Report_Url;
                reportDefn.DATASETNAME = report.DatasetName;

                Session["ReportModel"] = reportDefn;
            }
            else { ViewBag.ShowIFrame = false; }
            ViewBag.REPORT_ID = new SelectList(db.RptDefinition, "REPORT_ID", "REPORT_NAME");
            
            //ViewBag.CURRENCY_ID = new SelectList(db.Currency, "CURR_ID", "CURR_NAME");
            //ViewBag.BRANCH_ID = new SelectList(db.Branch, "BRANCH_ID", "BRANCH_NAME");
            return View();
        }
        public JsonResult GetReports()
        {
            return Json(db.RptDefinition.Select(c => new { REPORT_ID = c.Report_Id, REPORT_NAME = c.Report_Name }), JsonRequestBehavior.AllowGet);
        }
      
    }
}
