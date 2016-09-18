using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
//using System.Web.Http.Cors;
using TECIS.Data.Models;
using TECIS.Data.ViewModels;

namespace TECIS.Web.Controllers
{
    public class ChartController : ApiController
    {
        //[EnableCors(origins: "https://localhost:44300", headers: "*", methods: "*")]
        public dynamic Get()
        {
            var db = new TecIsEntities();
            int serviceType = 1;


            //var alldata = (from o in db.AttendanceRegs
            //               join sv in db.ServicesTypes on o.servicetype equals sv.Id
            //               where o.servicetype == serviceType
            //               select new
            //               {
            //                   o.servicedate,
            //                   o.malecount
            //               }).ToList();
            var Service1 = GetAttendancebyType(1);
            var Service2 = GetAttendancebyType(2);
            var Service3 = GetAttendancebyType(4);
            var Service4 = GetAttendancebyType(4);

            var attendance = new[]
            {
                new {label="1st Service", data = Service1.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })},
                new {label="2nd Service", data = Service2.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })},
                new {label="3rd Service", data = Service3.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })},
                new {label="4th Service", data = Service4.Select(x => new string[]{ x.servicedate.ToString(), x.TotalAttendance.ToString() })}

            };
            //var ret = new[] { new { label="Open Tickets", data = Tickets.Select(x=>new string[]{ x.MonthYear, x.OpenTickets.ToString() })},

            //                    new { label="Resolved Tickets", data = Tickets.Select(x=>new string[]{ x.MonthYear, x.ResolvedTickets.ToString() })},

            //                    new { label="Total Tickets", data = Tickets.Select(x=>new string[]{ x.MonthYear, x.TotalTickets.ToString() })},
            // };

            return attendance; //Json(attendance, JsonRequestBehavior.AllowGet);
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

        //var dataurl = 'api/Chart/';
        // setup plot
        //var options = {
        //    legend: {
        //        show: true,
        //        margin: 10,
        //        backgroundOpacity: 0.9
        //    },
        //    points: {
        //        show: true,
        //        radius: 3
        //    },
        //    lines: {
        //        show: true
        //    },
        //    grid: { hoverable: true, clickable: true },
        //    yaxis: { min: 0, tickFormatter: formatter },
        //    xaxis: { ticks: [[1, "Jan"], [2, "Feb"], [3, "Mar"], [4, "Apr"], [5, "May"], [6, "Jun"], [7, "Jul"], [8, "Aug"], [9, "Sep"], [10, "Oct"], [11, "Nov"], [12, "Dec"]] }

        //};
        //function formatter(val, axis) {
        //    return val.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        //}
        //$.ajax({
        //    url: dataurl,
        //    method: 'GET',
        //    dataType: 'json',
        //    success: function (data) {
        //        $.plot($("#plot_area"), data, options);
        //    }
        //});
    }
}
