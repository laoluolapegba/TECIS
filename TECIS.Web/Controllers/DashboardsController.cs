using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TECIS.Data.Models;
using TECIS.Data.ViewModels;
namespace TECIS.Web.Controllers
{
    public class DashboardsController : Controller
    {
        public ActionResult Index()
        {
            DateTime Last1month = DateTime.Now.AddDays(-30);
            var db = new TecIsEntities();
            int guestCount = db.Guests.Where(o => o.worshipdate >= Last1month).Count();
            int memberCount = db.Members.Where(o => o.createddate >= Last1month).Count();
            ViewBag.GuestCount = guestCount;
            ViewBag.MemberCount = memberCount;

            int guestmaleCount = db.Guests.Where(o => o.worshipdate >= Last1month && o.Gender == "Male").Count();
            int guestFemaleCount = db.Guests.Where(o => o.worshipdate >= Last1month && o.Gender == "Female").Count();
            int undefinedCount = db.Guests.Where(o => o.worshipdate >= Last1month && o.Gender == "").Count();            
            ViewBag.GuestMaleCount = guestmaleCount;
            ViewBag.GuestFemaleCount = guestFemaleCount;
            ViewBag.GuestUndefinedCount = undefinedCount;

            int memmaleCount = db.Members.Where(o => o.createddate >= Last1month && o.gender == "Male").Count();
            int memFemaleCount = db.Members.Where(o => o.createddate >= Last1month && o.gender == "Female").Count();
            int memundefinedCount = db.Members.Where(o => o.createddate >= Last1month && o.gender == "").Count();
            ViewBag.MemberMaleCount = memmaleCount;
            ViewBag.MemberFemaleCount = memFemaleCount;
            ViewBag.MemberUndefinedCount = memundefinedCount;

            return View();
        }
        public ActionResult Dashboard_1()
        {
            return View();
        }

        public ActionResult Dashboard_2()
        {
            return View();
        }

        public ActionResult Dashboard_3()
        {
            return View();
        }
        
        public ActionResult Dashboard_4()
        {
            return View();
        }
        
        public ActionResult Dashboard_4_1()
        {
            return View();
        }

        public ActionResult Dashboard_5()
        {
            return View();
        }

    }
}