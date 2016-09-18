using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TECIS.Data.Models;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using TECIS.Web.ViewModels;
namespace TECIS.Web.Models
{
    public class ReportBLL
    {
        private TecIsEntities db = new TecIsEntities();
        public List<GuestViewModel> GuestRptDataSet()
        {
            //this is used only to help in adding the dataset of type xxx to the report definition
            return null;
        }
        public ReportsViewModels GetGuestRptViewModel()
        {
            // I will not go through getting data from ef, i will assume some test data here

            //first dataset, employee info
            var GuestDS = db.Guests.Select(d => new GuestViewModel {
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
                WorshipDate = d.worshipdate

            });

            

            //Assuming the person printing the report is me
            //var UserPrinting = "CMU USer";

            var reportViewModel = new ReportsViewModels()
            {
                FileName = "~/Report/GuestReport.rdlc",
                LeftMainTitle = LeftMainTitle,
                LeftSubTitle = LeftSubTitle,
                RightMainTitle = "Shortage / Overage Report",
                RightSubTitle = "Shortage / Overage Report",
                Name = "Shortage / Overage Report",
                ReportDate = DateTime.Now,
                ReportLogo = "~/Content/logo.jpg",
                ReportTitle = "Summary report for This and That",
                ReportLanguage = "en-US",
                UserNamPrinting = PrintUser,
                ViewAsAttachment = false,

            };
            //adding the dataset information to the report view model object
            reportViewModel.ReportDataSets.Add(new ReportsViewModels.ReportDataSet() { GuestData = GuestDS.ToList(), DatasetName = "GuestRptDS" });



            return reportViewModel;

        }
        public string Name { get; set; }
        public string ReportLanguage { get; set; }
        public string FileName { get; set; }
        public string ReportTitle { get; set; }
        public string RightMainTitle { get; set; }
        public string RightSubTitle { get; set; }
        public string LeftMainTitle { get; set; }
        public string LeftSubTitle { get; set; }
        public string PrintUser { get; set; }

    }
}