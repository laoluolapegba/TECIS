using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TECIS.Web.ViewModels;
using TECIS.Data.Models;
using Microsoft.Reporting.WebForms;
namespace TECIS.Web
{
    public partial class ReportView : System.Web.UI.Page
    {
       
        private TecIsEntities db = new TecIsEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RenderReport();
            }
        }
        private void RenderReport()
        {
            rptViewer.Reset();
            rptViewer.ProcessingMode = ProcessingMode.Local;

            rptViewer.LocalReport.ReportPath = "";
            ReportRequestViewModel model = (ReportRequestViewModel)Session["ReportModel"];
            rptViewer.LocalReport.ReportPath = Server.MapPath(model.REPORT_URL);
            rptViewer.LocalReport.EnableExternalImages = true;

            //rptViewer.LocalReport.

            //rptViewer.LocalReport.SetParameters(new ReportParameter("LeftMainTitle", model.REPORT_NAME));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("LeftSubTitle", model.REPORT_NAME));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("ReportTitle", model.REPORT_DESCRIPTION));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("UserNamPrinting", User.Identity.Name));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("BranchID", model.BRANCH_ID.ToString()));
            //rptViewer.LocalReport.SetParameters(new ReportParameter("CurrencyID", model.CURRENCY_ID.ToString()));

            rptViewer.LocalReport.DataSources.Clear();
            switch (model.REPORT_ID)
            {
                case 101:
                    {

                        if (model.SearchMode == 1)
                        {
                            var GuestDS = db.Guests.Select(d => new
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
                                SMSsent = d.SmsSent,
                                WorshipDate = d.worshipdate,
                                TimeCaptured = d.timecaptured

                            }).Where(d => d.WorshipDate >= model.FROM_DATE && d.WorshipDate <= model.TO_DATE);
                            rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(model.DATASETNAME, GuestDS));
                        }
                        else
                        {
                            var GuestDS = db.Guests.Select(d => new
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
                                SMSsent = d.SmsSent,
                                WorshipDate = d.timecaptured,
                                TimeCaptured = d.timecaptured

                            }).Where(d => d.TimeCaptured >= model.FROM_DATE && d.TimeCaptured <= model.TO_DATE);
                            rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource(model.DATASETNAME, GuestDS));
                        }




                        break;
                    }
                default:
                    break;
            }
            //foreach (var dataset in this.ReportDataSets)
            //{
            //    ReportDataSource reportDataSource = new ReportDataSource(dataset.DatasetName, dataset.DataSetData);
            //    rptViewer.LocalReport.DataSources.Add(reportDataSource);
            //}
            rptViewer.DataBind();

        }
    }
}