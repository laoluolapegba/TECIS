using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System;
using TECIS.Data.Models;
using TECIS.Data.ViewModels;
using MySql.Data.MySqlClient;
using System.IO;
using Newtonsoft.Json;

namespace TECIS.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private TecIsEntities db = new TecIsEntities();
        // GET: Dashboard
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult GetAttendanceData()
        {
            var db = new TecIsEntities();
            CultureInfo ci = CultureInfo.CreateSpecificCulture("en-GB");
            var Service1 = (from o in db.vwAttendance
                            //join sv in db.ServicesTypes on o.servicetype equals sv.Id
                            //where o.servicetype == 2
                            select new
                            {
                                ServiceDate = o.servicedate,
                                WeekNo = o.WeekNo,
                                TotalAttendance = o.service1
                            }).ToList();

            var Service2 = (from o in db.vwAttendance
                            //join sv in db.ServicesTypes on o.servicetype equals sv.Id
                            //where o.servicetype == 2
                            select new
                            {
                                ServiceDate = o.servicedate,
                                WeekNo = o.WeekNo,
                                TotalAttendance = o.service2
                            }).ToList();
            var Service3 = (from o in db.vwAttendance
                            //join sv in db.ServicesTypes on o.servicetype equals sv.Id
                            //where o.servicetype == 2
                            select new
                            {
                                ServiceDate = o.servicedate,
                                WeekNo = o.WeekNo,
                                TotalAttendance = o.service3
                            }).ToList();
            var Service4 = (from o in db.vwAttendance
                            //join sv in db.ServicesTypes on o.servicetype equals sv.Id
                            //where o.servicetype == 2
                            select new
                            {
                                ServiceDate = o.servicedate,
                                WeekNo = o.WeekNo,
                                TotalAttendance = o.service4
                            }).ToList();
            //var Service1 = GetAttendancebyType(1);
            //var Service2 = GetAttendancebyType(2);
            //var Service3 = GetAttendancebyType(4);
            //var Service4 = GetAttendancebyType(4);

            var attendance = new[]
            {
                new {label="1st Service", data = Service1.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })},
                new {label="2nd Service", data = Service2.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })},
                new {label="3rd Service", data = Service3.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })},
                new {label="4th Service", data = Service4.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })}
               // new {label="3rd Service", data = Service3.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })},
                //new {label="4th Service", data = Service4.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })}

            };


            return Json(attendance, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getGuestSparkLineData()
        {   // Dim report As New List(Of YourCustomClass) = (From p In pFilter
           //Group p By WeekYear = New With {Key .week = GetISOWeek(p.CreatedOn), Key .year = p.CreatedOn.Year} Into Group
           //Select New YourCustomClass() With {
           //    .Name = "Week " + GetISOWeek(Group.ToList.Item(0).CreatedOn).ToString(),
           //    .Count = Group.Count
           //}).ToList()
            DateTime fromDate = DateTime.Now.AddDays(-45);
            //http://blog.ijasoneverett.com/2014/06/linq-to-sql-group-by-date-weekly-monthly-quaterly-yearly/
            //var guests = (from o in db.Guests
            //              where o.worshipdate >= fromDate
            //              group o by new { Year = o.worshipdate.Year, Week = GetISOWeek(o.worshipdate) } into OGroup
            //              orderby OGroup.Key.Year, OGroup.Key.Week
            //              select new
            //              {
            //                  Year = OGroup.Key.Year,
            //                  Week = OGroup.Key.Week,
            //                  Count = OGroup.Count()
            //              });

            IList<WeekSparkViewModel> dbguests;
            var sparklist = new List<Int32>();
            using (var context = new TecIsEntities())
            {
                MySqlParameter dateParam = new MySqlParameter("@var_p_fromdate", fromDate.Date);
                dbguests = context.Database.SqlQuery<WeekSparkViewModel>("ap_getGuests").ToList();
                foreach (var item in dbguests)
                {
                    sparklist.Add(item.ItemCount);
                }
            }

            
            
            return Json(sparklist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemberSparkLineData()
        {
            var db = new TecIsEntities();


            IList<WeekSparkViewModel> dbmembers;
            var sparklist = new List<Int32>();
            using (var context = new TecIsEntities())
            {
                //MySqlParameter dateParam = new MySqlParameter("@var_p_fromdate", fromDate.Date);
                dbmembers = context.Database.SqlQuery<WeekSparkViewModel>("ap_getMembers").ToList();
                foreach (var item in dbmembers)
                {
                    sparklist.Add(item.ItemCount);
                }
            }



            return Json(sparklist, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getGuestGenderPieData()
        {
            IList<GenderPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                //male = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").Where(a => a.gender == "Male").ToList();
                //female = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").Where(a => a.gender == "Female").ToList();
                all = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").ToList(); 
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.pct);
            }
           // var piedata = new[]
           // {
           //     new {label="Female", data = female.Select(x => x.pct).FirstOrDefault()},
           //     new {label="Male", data = male.Select(x => x.pct).FirstOrDefault()}
           //};
            //using (FileStream fs = System.IO.File.Open(@"c:\temp\utildata" + DateTime.Now.Ticks + ".json", FileMode.Append))
            //using (StreamWriter sw = new StreamWriter(fs))
            //using (JsonWriter jw = new JsonTextWriter(sw))
            //{
            //    jw.Formatting = Formatting.Indented;

            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(jw, piedata);
            //}
            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemberGenderPieData()
        {
            IList<GenderPieViewModel> allmembers;
            using (var context = new TecIsEntities())
            {
                allmembers = context.Database.SqlQuery<GenderPieViewModel>("ap_getmembergenderdist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in allmembers)
            {
                piedata.Add(item.pct);
            }
           
            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getGuestAgegroupPieData()
        {
            IList<AgegroupPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                all = context.Database.SqlQuery<AgegroupPieViewModel>("ap_getguestagedist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.cnt);
            }
           
            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemberAgegroupPieData()
        {
            IList<AgegroupPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                all = context.Database.SqlQuery<AgegroupPieViewModel>("ap_getmemberagedist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.cnt);
            }

            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemberClusterPieData()
        {
            IList<ClusterPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                all = context.Database.SqlQuery<ClusterPieViewModel>("ap_getmemberclusterdist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.pct);
            }

            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemberUnitPieData()
        {
            IList<ServiceUnitPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                all = context.Database.SqlQuery<ServiceUnitPieViewModel>("ap_getmemberunitdist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.pct);
            }

            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getMemClusterPieData()
        {
            IList<GenderPieViewModel> all;
            //IList<GenderPieViewModel> female;
            using (var context = new TecIsEntities())
            {
                //male = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").Where(a => a.gender == "Male").ToList();
                //female = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").Where(a => a.gender == "Female").ToList();
                all = context.Database.SqlQuery<GenderPieViewModel>("ap_getguestgenderdist").ToList();
            }
            var piedata = new List<Int32>();
            foreach (var item in all)
            {
                piedata.Add(item.pct);
            }
            // var piedata = new[]
            // {
            //     new {label="Female", data = female.Select(x => x.pct).FirstOrDefault()},
            //     new {label="Male", data = male.Select(x => x.pct).FirstOrDefault()}
            //};
            //using (FileStream fs = System.IO.File.Open(@"c:\temp\utildata" + DateTime.Now.Ticks + ".json", FileMode.Append))
            //using (StreamWriter sw = new StreamWriter(fs))
            //using (JsonWriter jw = new JsonTextWriter(sw))
            //{
            //    jw.Formatting = Formatting.Indented;

            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(jw, piedata);
            //}
            return Json(piedata, JsonRequestBehavior.AllowGet);
        }
        public static long GetJavascriptTimestamp(System.DateTime input)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
        public List<AttendanceRptViewModel> GetAttendancebyType(int serviceType)
        {
            var db = new TecIsEntities();



            List<AttendanceRptViewModel> alldata = (from o in db.AttendanceRegs
                                                    join sv in db.ServicesTypes on o.servicetype equals sv.Id
                                                    where o.servicetype == serviceType
                                                    group o by o.servicedate.Month into grp
                                                    select new AttendanceRptViewModel
                                                    {
                                                        servicedate = grp.Key,
                                                        TotalAttendance = grp.Sum(x => x.malecount).Value
                                                    }).ToList();
            return alldata;
        }
        private int GetISOWeek(DateTime day)
        {
            return System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(day, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }
        //static IEnumerable<User> FindUsersByBirthday(DateTime currentDate, int daysToLookup)
        //{
        //    DataClasses1DataContext db = new DataClasses1DataContext();
        //    var query = from v in db.Users
        //                where ((new DateTime(currentDate.Year, v.Birthday.Month, v.Birthday.Day) < currentDate) ?
        //                (currentDate <= new DateTime(currentDate.AddDays(daysToLookup).Year, v.Birthday.Month, v.Birthday.Day) && new DateTime(currentDate.AddDays(daysToLookup).Year, v.Birthday.Month, v.Birthday.Day) <= currentDate.AddDays(daysToLookup)) :
        //                (currentDate <= new DateTime(currentDate.Year, v.Birthday.Month, v.Birthday.Day) && new DateTime(currentDate.Year, v.Birthday.Month, v.Birthday.Day) <= currentDate.AddDays(daysToLookup))) && (v.Active == 1)
        //                orderby v.Birthday.Month, v.Birthday.Day
        //                select v;

        //    return query;
        //}
    }
}