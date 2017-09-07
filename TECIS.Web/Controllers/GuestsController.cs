using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using TECIS.Data.Models;
using System.Web;
using TECIS.Web.ActionFilters;
using System.IO;
using TECIS.Web.ViewModels;
using System.Web.UI;
using System.Web.UI.WebControls;
//using OfficeOpenXml;
using OfficeOpenXml;
using System.Web.Security;
using System.Configuration;
using System.Data.Entity.SqlServer;
using TECIS.Data.ViewModels;
using TECIS.Web.Helpers.CrossCutting.SMSService;
using System.Threading.Tasks;
using Elmah;

namespace TECIS.Web.Controllers
{
    public class GuestsController : BaseController
    {
        private TecIsEntities db = new TecIsEntities();

        // GET: /Guests/
        public ActionResult Index()
        {
            return View(db.Guests.Where(x => x.SmsSent == false).OrderByDescending(v => v.worshipdate).ToList());
        }

        // GET: /Guests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // GET: /Guests/Create
        public ActionResult Create()
        {
            ViewBag.AgeGroup = new SelectList(db.AgeGroups, "Id", "Description");
            ViewBag.MembershipInfo = new SelectList(db.Answers, "Id", "Description");
            ViewBag.MoreAboutChurch = new SelectList(db.Answers, "Id", "Description");
            ViewBag.Joining = new SelectList(db.Answers, "Id", "Description");


            List<SelectListItem> cluster = new SelectList(db.ClusterAreas.OrderBy(x => x.Description), "Id", "Description").ToList();

            cluster.Insert(0, (new SelectListItem { Text = "Others", Value = "64" }));
            ViewBag.ClusterArea = cluster;
            ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description");
            ViewBag.ServiceType = new SelectList(db.ServicesTypes, "Id", "ServiceName");
            return View(new Guest());
        }
        

        // POST: /Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Create")]
        public ActionResult Create([Bind(Include = "Id,Gender,agegroup,MaritalStat,Surname,OtherNames,PhoneNumber,EmailAddress,HomeAddress,NearestBStop,ClusterArea,  OfficeAdress,Occupation,flg_join,flg_membershipinfo,flg_moreinfo,PrayerComments,worshipdate,servicetype,timecaptured,createdby,Entrychannel,Selected,SmsSent,SmsResponse,PrefContactMode")] Guest guest)
        {
            if (guest.ClusterArea == 0)
            {
                guest.ClusterArea = 64;
            }
            ModelState.Remove("ClusterArea");
            if (ModelState.IsValid)
            {
                guest.timecaptured = DateTime.Now;
                guest.worshipdate = DateTime.Now;
                guest.servicetype = 3;
                if (Request.IsAuthenticated)
                { guest.createdby = User.Identity.Name; }
                //guests.worshipdate = DateTime.Now;
                if (guest.Entrychannel != null)
                {
                    if (guest.Entrychannel.ToString().ToUpper().Contains("OTHERS"))
                    {
                        guest.Entrychannel = guest.Entrychannel + guest.EntrychannelOther;
                    }
                }
                
                db.Guests.Add(guest);
                db.SaveChanges();
                Success(string.Format("<b>Guest {0}</b> was successfully added.", guest.PhoneNumber), true);
                return RedirectToAction("Index");
            }
            ViewBag.AgeGroup = new SelectList(db.AgeGroups, "Id", "Description", guest.agegroup);
            ViewBag.MembershipInfo = new SelectList(db.Answers, "Id", "Description", guest.flg_membershipinfo);
            ViewBag.MoreAboutChurch = new SelectList(db.Answers, "Id", "Description", guest.flg_moreinfo);
            ViewBag.Joining = new SelectList(db.Answers, "Id", "Description", guest.flg_join);
            ViewBag.ClusterArea = new SelectList(db.ClusterAreas, "Id", "Description", guest.ClusterArea);
            ViewBag.MaritalStatus = new SelectList(db.MaritalStats, "Id", "Description", guest.MaritalStat);
            //ViewBag.Occupation = new SelectList(db.occupations, "Id", "description", guests.Occupation);
            Danger("Looks like something went wrong. Please check your form.");
            return View(guest);
        }
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "CreateNNew")]
        public ActionResult CreateNNew([Bind(Include = "Id,Gender,agegroup,MaritalStat,Surname,OtherNames,PhoneNumber,EmailAddress,HomeAddress,NearestBStop,ClusterArea,  OfficeAdress,Occupation,flg_join,flg_membershipinfo,flg_moreinfo,PrayerComments,worshipdate,servicetype,timecaptured,createdby,Entrychannel,Selected,SmsSent,SmsResponse,PrefContactMode")] Guest guest)
        {
            if(guest.ClusterArea == 0)
            {
                guest.ClusterArea = 64;
            }
            ModelState.Remove("ClusterArea");
            //ModelStateErrors(ModelState);
            if (ModelState.IsValid)
            {
                guest.timecaptured = DateTime.Now;
                guest.worshipdate = DateTime.Now;
                guest.servicetype = 3;
                if (Request.IsAuthenticated)
                { guest.createdby = User.Identity.Name; }
                //guests.worshipdate = DateTime.Now;
                if (guest.Entrychannel != null)
                {
                    if (guest.Entrychannel.ToString().ToUpper().Contains("OTHERS"))
                    {
                        guest.Entrychannel = guest.Entrychannel + guest.EntrychannelOther;
                    }
                }

                db.Guests.Add(guest);
                db.SaveChanges();
                Success(string.Format("<b>Guest {0}</b> was successfully added.", guest.PhoneNumber), true);
                return RedirectToAction("Create");
            }
            ViewBag.AgeGroup = new SelectList(db.AgeGroups, "Id", "Description", guest.agegroup);
            
            ViewBag.MembershipInfo = new SelectList(db.Answers, "Id", "Description", guest.flg_membershipinfo);
            ViewBag.MoreAboutChurch = new SelectList(db.Answers, "Id", "Description", guest.flg_moreinfo);
            ViewBag.Joining = new SelectList(db.Answers, "Id", "Description", guest.flg_join);
            ViewBag.ClusterArea = new SelectList(db.ClusterAreas, "Id", "Description", guest.ClusterArea);
            ViewBag.MaritalStatus = new SelectList(db.MaritalStats, "Id", "Description", guest.MaritalStat);
            //ViewBag.Occupation = new SelectList(db.occupations, "Id", "description", guests.Occupation);
            Danger("Looks like something went wrong. Please check your form.");
            return View("Create",guest);
        }

        // GET: /Guests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var guest = db.Guests
                        .Include(p => p.GuestContacts)
                        .Where(p => p.Id == id)
                        .Single();
            //Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: /Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gender,agegroup,MaritalStat,Surname,OtherNames,PhoneNumber,EmailAddress,HomeAddress,NearestBStop,ClusterArea,  OfficeAdress,Occupation,flg_join,flg_membershipinfo,flg_moreinfo,PrayerComments,worshipdate,servicetype,timecaptured,createdby,Entrychannel,Selected,SmsSent,SmsResponse,PrefContactMode")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                //guest.
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        // GET: /Guests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        // POST: /Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public int SMSGate(string msisdn, string smstext)
        {
            int retval = 0;
            try
            {
                string getUri = ConfigurationManager.AppSettings["SMSUri"].ToString();
                string smsUser = ConfigurationManager.AppSettings["SMSUser"].ToString();
                string smsPass = ConfigurationManager.AppSettings["SMSPass"].ToString();
                string Sender = ConfigurationManager.AppSettings["SMSSender"].ToString();
                //http://api.infobip.com/api/v3/sendsms/plain?user=reflex&password=reflexreflex&sender=Friend&SMSText=messagetext&GSM=2348039271234,2348017608899
                StringBuilder sb = new StringBuilder();
                sb.Append(getUri);
                sb.Append("user=");
                sb.Append(smsUser);
                sb.Append("&password=");
                sb.Append(smsPass);
                sb.Append("&sender=");
                sb.Append(Sender);
                sb.Append("&SMSText=");
                sb.Append(smstext);
                sb.Append("&GSM=");
                sb.Append(msisdn);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sb.ToString());
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //read the response

                //StreamReader responseReader = new StreamReader(response.GetResponseStream());

                //String resultmsg = responseReader.ReadToEnd();
                int count = 0;
                using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
                {
                    String resultmsg = responseReader.ReadToEnd();
                    using (XmlReader xmlReader = XmlReader.Create(new StringReader(resultmsg)))
                    {
                        //responseReader.Close();
                        while (xmlReader.Read())
                        {
                            if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "status"))
                            {
                                XElement el = (XElement)XNode.ReadFrom(xmlReader);
                                retval = int.Parse(el.Value);
                                //if (el.Value == "0")
                                //count++;
                            }
                        }
                    }
                }


                //retval = count;


            }
            catch (Exception ex)
            {
                retval = 99;

            }
            return retval;
        }
        [Authorize(Roles = "TeamLeader")]
        public ActionResult SendSMS()
        {
            //var identity = ((CustomPrincipal)User).CustomIdentity;
            // get the ids of everyone in my  team
            var myteamuserIds = (from p in db.UserProfiles
                                 where p.AdminConfirmed == 1
                                 where p.TeamLeader == User.Identity.Name
                                 select p.UserName).ToList();
            DateTime _today = DateTime.Now.Date;
            // Use the ids to retrieve the records for the selected people
            // from the database:
            var selectedRegisters = from x in db.Guests
                                    where x.worshipdate == _today
                                    where x.PhoneNumber != ""
                                    where myteamuserIds.Contains(x.createdby)

                                    select x;
            List<string> recipients = new List<string>();
            foreach (var item in selectedRegisters)
            {
                if (item.PhoneNumber.Trim() != string.Empty) //Add only those with non-empty phone number
                { 
                    recipients.Add(item.PhoneNumber);
                }             
                
            };
            var editorViewModel = new SMSObject()
            {
                msisdn = string.Join(",", recipients.ToArray()) 
            };
            
            return View(editorViewModel);

            //if (Request["Selected"] != null)
            //{
            //    foreach (var selection in Request["Selected"].Split(','))
            //    {
            //        model.msisdn = model.msisdn + selection + ",";
            //    }
            //}
            //else
            //{

            //    Warning("Looks like you didn't select any guests. Please check your");
            //    return RedirectToAction("Index");
            //}



        }

        [HttpPost, ActionName("SendSMS"), ValidateAntiForgeryToken]
        //[MultipleButton(Name = "action", Argument = "SendSMS")]
        //[HttpPost, ActionName("Delete")]
        [Authorize(Roles = "TeamLeader")]
        public async Task<ActionResult> SendSMS(SMSObject model)
        {

            try
            {

                if (ModelState.IsValid)
                {
                    //List<string> recipients = new List<string>();
                    String[] recipients = model.msisdn.Split(',');
                    SMSLive247Service smssvc = new SMSLive247Service();
                    await smssvc.SendSMSAsync(recipients, model.SMSText, model.SendConfirmation);
                    //Success(string.Format("<b>{0}</b> Messages successfully sent .", model.msisdn.Length), true);
                    Success(string.Format("Messages successfully sent."), true);
                }
                #region Oldmethod
                //if (Request["Selected"] != null)
                //{
                //    model.msisdn = string.Empty;
                //    model.MessageId = string.Empty;
                //    foreach (var selection in Request["Selected"].Split(','))
                //    {

                //        try
                //        {
                //            model.MessageId = model.MessageId + int.Parse(selection) + ",";
                //            model.msisdn = model.msisdn + GetMsisdn(int.Parse(selection)) + ",";
                //        }
                //        catch (Exception ex)
                //        { }
                //    }
                //}
                //if (Request["Selected"] == null || model.msisdn == string.Empty)
                //{

                //    Warning("Looks like you didn't select any guests. Please check your form.");
                //    return RedirectToAction("Index");
                //}
                //model.SMSText = "SMS Text goes here";
                //if (ModelState.IsValid)
                //{
                //    //ViewBag.msisdn = model.msisdn;
                //    //ViewBag.SMSText = model.SMSText;
                //    string[] tmpMsisdn = model.msisdn.TrimEnd(',').Split(',');
                //    string[] tmpMsgId = model.MessageId.TrimEnd(',').Split(',');
                //    int i = 0; int isent = 0;
                //    foreach (var item in tmpMsisdn)
                //    {
                //        try
                //        {
                //            string tmp = "234" + item.Remove(0, 1);
                //            int MsgId = int.Parse(tmpMsgId[i]);
                //            i++;
                //            //recipients = recipients + tmp;
                //            //guests guests = db.guestss.Find(model.MessageId);
                //            int response = SMSGate(tmp, model.SMSText);
                //            if (response != 99)
                //            {
                //                UpdateStatus(MsgId, response);
                //                isent++;
                //            }

                //        }
                //        catch (Exception ex)
                //        { }
                //    }



                //    Success(string.Format("<b>{0}</b> Messages successfully sent .", isent), true);
                //    return RedirectToAction("Index");

                //}
                #endregion

            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                //ModelState.AddModelError("", "Unable to send action. Please contact us.");
                Danger("Oops, something went wrong. Please retry and contact the admin guy.");
                
            }
            return View(model);

        }

        public ActionResult ImportGuests()
        {
            return View();
        }
        [Authorize(Roles = "TeamLeader")]
        public ActionResult GuestImport()
        {
            return View();
        }

        //[HttpPost, HttpParamAction("ImportGuests"), ValidateAntiForgeryToken]
        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ImportGuests")]
        [Authorize(Roles = "TeamLeader")]
        public ActionResult ImportGuests(FormCollection collection)
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
                            var guestList = new List<GuestUpload>();
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
                                    var guest = new GuestUpload();
                                    guest.Surname = workSheet.Cells[rowIterator, 2].Value == null ? string.Empty : workSheet.Cells[rowIterator, 2].Value.ToString().Trim();
                                    guest.OtherNames = workSheet.Cells[rowIterator, 3].Value == null ? string.Empty :  workSheet.Cells[rowIterator, 3].Value.ToString().Trim();
                                    guest.agegroup = workSheet.Cells[rowIterator, 4].Value == null ? string.Empty : workSheet.Cells[rowIterator, 4].Value.ToString().Trim();
                                    guest.Gender = workSheet.Cells[rowIterator, 5].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 5].Value.ToString().Trim());
                                    guest.MaritalStat = workSheet.Cells[rowIterator, 6].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 6].Value.ToString().Trim());
                                    guest.PhoneNumber = workSheet.Cells[rowIterator, 7].Value == null ? string.Empty : workSheet.Cells[rowIterator, 7].Value.ToString().Trim();
                                    guest.EmailAddress = workSheet.Cells[rowIterator, 8].Value == null ? string.Empty : workSheet.Cells[rowIterator, 8].Value.ToString().Trim();
                                    guest.HomeAddress = workSheet.Cells[rowIterator, 9].Value == null ? string.Empty : workSheet.Cells[rowIterator, 9].Value.ToString().Trim();
                                    guest.NearestBStop = workSheet.Cells[rowIterator, 10].Value == null ? string.Empty : workSheet.Cells[rowIterator, 10].Value.ToString().Trim();
                                    guest.ClusterArea = workSheet.Cells[rowIterator, 11].Value == null ? string.Empty : workSheet.Cells[rowIterator, 11].Value.ToString().Trim();
                                    guest.OfficeAdress = workSheet.Cells[rowIterator, 12].Value == null ? string.Empty : workSheet.Cells[rowIterator, 12].Value.ToString().Trim();
                                    guest.Occupation = workSheet.Cells[rowIterator, 13].Value == null ? string.Empty : workSheet.Cells[rowIterator, 13].Value.ToString().Trim();
                                    guest.flg_join = workSheet.Cells[rowIterator, 14].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 14].Value.ToString().Trim());
                                    guest.flg_membershipinfo = workSheet.Cells[rowIterator, 15].Value == null ? string.Empty :ti.ToTitleCase( workSheet.Cells[rowIterator, 15].Value.ToString().Trim());
                                    guest.flg_moreinfo = workSheet.Cells[rowIterator, 16].Value == null ? string.Empty : ti.ToTitleCase(workSheet.Cells[rowIterator, 16].Value.ToString().Trim());
                                    guest.Entrychannel = workSheet.Cells[rowIterator, 17].Value == null ? string.Empty : workSheet.Cells[rowIterator, 17].Value.ToString().Trim();
                                    guest.PrayerComments = workSheet.Cells[rowIterator, 18].Value == null ? string.Empty : workSheet.Cells[rowIterator, 18].Value.ToString().Trim();
                                    //guestList.Add(guest);
                                    guest.timecaptured = DateTime.Now;
                                    db.GuestUpload.Add(guest);
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
        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ConverToMember")]
        public ActionResult ConverToMember(SMSObject model)
        {
            try
            {
                if (Request["Selected"] != null)
                {
                    int i = 0; 
                    foreach (var selection in Request["Selected"].Split(','))
                    {

                        try
                        {
                            Member nMember = new Member();
                            int guestid = int.Parse(selection);
                            var guest = db.Guests.Where(a => a.Id == guestid).FirstOrDefault();
                            if (guest.ismember != true)
                            {
                                nMember.surname = guest.Surname;
                                nMember.address = guest.HomeAddress;
                                nMember.agegroup = guest.agegroup;
                                nMember.email_address = guest.EmailAddress;
                                nMember.maritalstatus = guest.MaritalStat;
                                nMember.occupation = guest.Occupation;
                                nMember.officeaddress = guest.OfficeAdress;
                                nMember.othernames = guest.OtherNames;
                                nMember.telephone = guest.PhoneNumber;
                                nMember.gender = guest.Gender;

                                if (Request.IsAuthenticated)
                                { nMember.createdby = User.Identity.Name; }
                                nMember.createddate = DateTime.Now;
                                db.Members.Add(nMember);

                                Guest g = db.Guests.Find(guestid);
                                g.ismember = true;
                                db.Entry(g).State = EntityState.Modified;

                                db.SaveChanges();
                                //model.MessageId = model.MessageId + int.Parse(selection) + ",";
                                //model.msisdn = model.msisdn + GetMsisdn(int.Parse(selection)) + ",";
                                i++;
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                    Success(string.Format("<b>{0}</b> Guests successfully converted .", i), true);
                    return RedirectToAction("Index");
                }
                if (Request["Selected"] == null || model.msisdn == string.Empty)
                {

                    Warning("Looks like you didn't select any guests. Please check your form.");
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception ex)
            {
                //ModelState.AddModelError("", "Unable to send action. Please contact us.");
                Danger("Oops, something went wrong. Please retry and contact the admin guy.");
                return RedirectToAction("Index", "Guests");
            }
            return View("Index");
        }
        public bool UpdateStatus(int id, int response)
        {
            Guest guests = db.Guests.Find(id);
            guests.SmsSent = true;
            guests.SmsResponse = response;
            //db.guestss.Remove(guests);
            db.Entry(guests).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }
        public string GetMsisdn(int id)
        {
            Guest guests = db.Guests.Find(id);
            string msisdn = guests.PhoneNumber;
            return msisdn;
        }
        public ActionResult ViewAll()
        {
            return View(db.Guests.OrderByDescending(v => v.worshipdate).ToList());



        }
        // GET: /GuestUploads/
        public ActionResult GuestUploadView()
        {
            return View(db.GuestUpload.ToList().OrderByDescending(a => a.timecaptured));
        }
        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ExportGuests")]
        [Authorize(Roles = "TeamLeader")]
        public void ExportGuests(FormCollection collection)
        {
            string exportoptions = collection["export-options"].ToString();
            var grid = new System.Web.UI.WebControls.GridView();

            var today = DateTime.Now.Date;
            var query = from g in db.Guests
                        select g;
            if (exportoptions == "all-day")
                query = query.Where(g => g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day);
            else if (exportoptions == "user-all")
                query = query.Where(g => g.createdby == User.Identity.Name);
            else if (exportoptions == "user-day")
                query = query.Where(g => g.createdby == User.Identity.Name &&  g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day);
            else if(exportoptions == "team-day")
            {
                var myteamuserIds = (from p in db.UserProfiles
                                     where p.AdminConfirmed == 1
                                     where p.TeamLeader == User.Identity.Name
                                     select p.UserName).ToList();
                DateTime _today = DateTime.Now.Date;
                // Use the ids to retrieve the records for the selected people
                // from the database:
                //var selectedRegisters = from x in db.Guests
                //                        where x.worshipdate == _today
                //                        where x.PhoneNumber != ""
                //                        where myteamuserIds.Contains(x.createdby)
                //                        select x;
                query = query.Where(g => g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day).Where(a =>a.PhoneNumber != "").Where(x => myteamuserIds.Contains(x.createdby));
            }

   //         var xquery =
   //(from guests in db.Guests
   // join marit in db.MaritalStats on guests.maritalstats equals marit.Description
   // join ageg in db.AgeGroups on guests.agegroup equals ageg.Description
   // select new
   // {

   // });

            var exportguests = query.Select(d => new
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
                PrefModeofContact = d.PrefContactMode,
                HowdidyouKnow = d.Entrychannel,
                PrayerComments = d.PrayerComments,
                Createdby = d.createdby,
                SMSsent = d.SmsSent,
                WorshipDate = d.timecaptured
            }).ToList();
            //var exportguests = query.Select(d => new GuestViewModel
            //                        {
            //                            Surname = d.Surname,
            //                            Othernames = d.OtherNames,
            //                            Age = d.age.Description,
            //                            Gender = d.Gender,
            //                            MaritalStatus = d.maritalstats.Description,
            //                            PhoneNumber = d.PhoneNumber,
            //                            Email = d.EmailAddress,
            //                            HomeAddress = d.HomeAddress,
            //                            NearestBusstop = d.NearestBStop,
            //                            ClusterArea = d.clusters.ClusterName,
            //                            OfficeAddress = d.OfficeAdress,
            //                            Occupation = d.Occupation,
            //                            WouldJoin = d.answer.Description,
            //                            MemberShipInfo = d.answer1.Description,
            //                            Updates = d.answer2.Description,
            //                            HowdidyouKnow = d.Entrychannel,
            //                            PrayerComments = d.PrayerComments,
            //                            Createdby = d.createdby,
            //                            SMSsent = d.SmsSent,
            //                            WorshipDate = d.worshipdate
            //                        }).Where(x => x.SMSsent == false).ToList();
            
            grid.DataSource = exportguests;
            grid.DataBind();

            Response.ClearContent();
            var fName = string.Format("GuestListSvc{0}", DateTime.Now.ToString("dd.MM.yyyy"));
            Response.AddHeader("content-disposition", "attachment; filename=" + fName + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

        }

        [HttpPost, ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "ExportMyGuests")]
        [Authorize(Roles = "TeamLeader")]
        public void ExportMyGuests(FormCollection collection)
        {
            string exportoptions = collection["export-options"].ToString();
            var grid = new System.Web.UI.WebControls.GridView();

            var today = DateTime.Now.Date;
            var query = from g in db.Guests
                        select g;
            //var data = db.Guests.ToList();
            //if (User.IsInRole("ClusterLeader"))
            //{
            //    int myclusterId = ClustersController.GetClustIdByLeaderEmail(User.Identity.Name);
            //    data = data.Where(x => x.ClusterArea == myclusterId);
            //}
            //else if (User.IsInRole("SectionLeader"))
            //{
            //    //select * from guests where clusterarea in select id from clusters where sectionid = sectionleaderid
            //    int mysectionId = ClustersController.GetSectIdbyLeaderEmail(User.Identity.Name);
            //    var clustersinmysection = db.Clusters.Where(a => a.ClusterSection == mysectionId).ToList();
            //    var myclusterList = new List<Int32>();
            //    foreach (var item in clustersinmysection)
            //    {
            //        myclusterList.Add(item.Id);
            //    }

            //    data = db.Guests.Where(x => myclusterList.Contains(x.ClusterArea));
            //}
            //else if (User.IsInRole("AreaLeader"))
            //{

            //    int myareaId = ClustersController.GetAreaIdbyLeaderEmail(User.Identity.Name);
            //    var clustersinmyarea = db.Clusters.Where(a => a.ClusterArea == myareaId).ToList();
            //    var myclusterList = new List<Int32>();
            //    foreach (var item in clustersinmyarea)
            //    {
            //        myclusterList.Add(item.Id);
            //    }
            //    //var userProfiles = _dataContext.UserProfile
            //    //               .Where(t => idList.Contains(t.Id));
            //    return View(db.Guests.Where(x => myclusterList.Contains(x.ClusterArea)).OrderByDescending(v => v.worshipdate).ToList());
            //}
            //else if (User.IsInRole("ZonalLeader"))
            //{

            //    int myzonalId = ClustersController.GetZoneIdbyLeaderEmail(User.Identity.Name);
            //    var clustersinmyzone = db.Clusters.Where(a => a.ClusterZone == myzonalId).ToList();
            //    var myclusterList = new List<Int32>();
            //    foreach (var item in clustersinmyzone)
            //    {
            //        myclusterList.Add(item.Id);
            //    }
            //    //var userProfiles = _dataContext.UserProfile
            //    //               .Where(t => idList.Contains(t.Id));
            //    return View(db.Guests.Where(x => myclusterList.Contains(x.ClusterArea)).OrderByDescending(v => v.worshipdate).ToList());
            //}
            //else
            //{
            //    return View(db.Guests.OrderByDescending(v => v.worshipdate).ToList());
            //}
            if (exportoptions == "all-day")
                query = query.Where(g => g.worshipdate.Year == today.Year &&
                             g.worshipdate.Month == today.Month &&
                             g.worshipdate.Day == today.Day);
           
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
                PrefModeofContact = d.PrefContactMode,
                HowdidyouKnow = d.Entrychannel,
                PrayerComments = d.PrayerComments,
                Createdby = d.createdby,
                SMSsent = d.SmsSent

            }).Where(x => x.SMSsent == false).ToList();

            grid.DataSource = exportguests;
            grid.DataBind();

            Response.ClearContent();
            var fName = string.Format("GuestListSvc{0}", DateTime.Now.ToString("dd.MM.yyyy"));
            Response.AddHeader("content-disposition", "attachment; filename=" + fName + ".xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();

        }
        public ActionResult MyGuests()
        {
            //role must have hierarchies cos to select data the highest level must be used. 
            //e.g if a user has both connect group leader and area leader, area leader should be used to select data 
            //get the current users role
            string[] roleNames = Roles.GetRolesForUser(User.Identity.Name);
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

        //protected void FindCoordinates(object sender, EventArgs e)
        //{
        //    string url = "http://maps.google.com/maps/api/geocode/xml?address=" + txtLocation.Text + "&sensor=false";
        //    WebRequest request = WebRequest.Create(url);
        //    using (WebResponse response = (HttpWebResponse)request.GetResponse())
        //    {
        //        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
        //        {
        //            DataSet dsResult = new DataSet();
        //            dsResult.ReadXml(reader);
        //            DataTable dtCoordinates = new DataTable();
        //            dtCoordinates.Columns.AddRange(new DataColumn[4] { new DataColumn("Id", typeof(int)),
        //                new DataColumn("Address", typeof(string)),
        //                new DataColumn("Latitude",typeof(string)),
        //                new DataColumn("Longitude",typeof(string)) });
        //            foreach (DataRow row in dsResult.Tables["result"].Rows)
        //            {
        //                string geometry_id = dsResult.Tables["geometry"].Select("result_id = " + row["result_id"].ToString())[0]["geometry_id"].ToString();
        //                DataRow location = dsResult.Tables["location"].Select("geometry_id = " + geometry_id)[0];
        //                dtCoordinates.Rows.Add(row["result_id"], row["formatted_address"], location["lat"], location["lng"]);
        //            }
        //            GridView1.DataSource = dtCoordinates;
        //            GridView1.DataBind();
        //        }
        //    }
        //}

#if DEBUG
        /// <summary> 
        /// Output the properties which are causing the issues when 
        /// the model is binding. 
        /// </summary>
        public static void ModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(a => a.Value.Errors.Count > 0)
                .Select(b => new { b.Key, b.Value.Errors })
                .ToArray();

            foreach (var modelStateErrors in errors)
            {
                System.Diagnostics.Debug.WriteLine("...Errored When Binding.", modelStateErrors.Key.ToString());

            }

        }
#endif
        // GET: /Xcont/Create
        public ActionResult GuestContact()
        {
            ViewBag.clusterid = new SelectList(db.Clusters, "Id", "ClusterName");
            ViewBag.theguestid = new SelectList(db.Guests, "Id", "Surname");
            return View();
        }
        

        // POST: /Xcont/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        
        //public ActionResult GuestContactHistory()
        //{
        //    var guestcontacts = db.GuestContacts.Include(g => g.GuestCluster).Include(g => g.GuestId);
        //    return View(guestcontacts.ToList());
        //}
        public JsonResult GetCascadeGuests(int? clusterid, string guestFilter)
        {
            var northwind = new TecIsEntities();
            var guests = northwind.Guests.AsQueryable();

            if (clusterid != null)
            {
                guests = guests.Where(o => o.ClusterArea == clusterid);
            }

            if (!string.IsNullOrEmpty(guestFilter))
            {
                guests = guests.Where(o => o.Surname.Contains(guestFilter));
            }

            return Json(guests.Select(o => new { GuestId = o.Id, GuestName = o.Surname }), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult AddDecisioncard()
        //{
           
        //    ViewBag.MaritalStat = new SelectList(db.MaritalStats, "Id", "Description");            
        //    return View(new Decisioncard());
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[MultipleButton(Name = "action", Argument = "Create")]
        //public ActionResult AddDecisioncard( Decisioncard card)
        //{            
            
        //    if (ModelState.IsValid)
        //    {
        //        card.timecaptured = DateTime.Now;
        //        card.worshipdate = DateTime.Now;
                
        //        if (Request.IsAuthenticated)
        //        { card.createdby = User.Identity.Name; }
        //        //guests.worshipdate = DateTime.Now;
                

        //        db.Decisioncards.Add(card);
        //        db.SaveChanges();
        //        Success(string.Format("<b>Card {0}</b> was successfully added.", card.PhoneNumber), true);
        //        return RedirectToAction("Index");
        //    }
            
        //    ViewBag.MaritalStatus = new SelectList(db.MaritalStats, "Id", "Description", card.MaritalStat);
        //    //ViewBag.Occupation = new SelectList(db.occupations, "Id", "description", guests.Occupation);
        //    Danger("Looks like something went wrong. Please check your form.");
        //    return View(card);
        //}

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
