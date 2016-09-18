using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TECIS.Data.Models;
using System;
using System.IO;
using Newtonsoft.Json;

namespace TECIS.Web.Controllers
{

    [RequireHttps]
    public class HomeController : BaseController
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ActionResult Index()
        {
            var db = new TecIsEntities();

            //var Service1 = GetAttendancebyType(1);
            //var Service2 = GetAttendancebyType(2);
            //var Service3 = GetAttendancebyType(4);
            //var Service4 = GetAttendancebyType(4);

            var Service1 = (from o in db.vwAttendance
                            //join sv in db.ServicesTypes on o.servicetype equals sv.Id                         
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

            var attendance = new[]
            {
                new {label="1st Service", data = Service2.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })},
                new {label="2nd Service", data = Service1.Select(x => new string[]{ GetJavascriptTimestamp(x.ServiceDate).ToString(), x.TotalAttendance.ToString() })}

            };


            //using (FileStream fs = System.IO.File.Open(@"f:\utildata" + DateTime.Now.Ticks + ".json", FileMode.Append))
            //using (StreamWriter sw = new StreamWriter(fs))
            //using (JsonWriter jw = new JsonTextWriter(sw))
            //{
            //    jw.Formatting = Formatting.Indented;

            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(jw, attendance);
            //}
            if (Request.IsAuthenticated)
            {
                //var user = UserManager.FindById(User.Identity.GetUserId());
                //ViewBag.userfirstname = user.Firstname;
                //ViewBag.userlastname = user.Lastname;
                //var userRoles = UserManager.GetRoles(user.Id);
                //ViewBag.Rolename = userRoles[0];
            }
            //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View();
        }
        public static long GetJavascriptTimestamp(System.DateTime input)
        {
            System.TimeSpan span = new System.TimeSpan(System.DateTime.Parse("1/1/1970").Ticks);
            System.DateTime time = input.Subtract(span);
            return (long)(time.Ticks / 10000);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}