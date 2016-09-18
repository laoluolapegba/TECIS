using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECIS.Web.ViewModels
{
    public class ReportsViewModels
    {
        public ReportsViewModels()
        {
            //initiation for the data set holder
            ReportDataSets = new List<ReportDataSet>();
        }
        public List<ReportDataSet> ReportDataSets { get; set; }
        public class ReportDataSet
        {
            public string DatasetName { get; set; }
            public List<GuestViewModel> GuestData { get; set; }
        }
        public string Name { get; set; }

        //Language of the report
        public string ReportLanguage { get; set; }

        //Reference to the RDLC file that contain the report definition
        public string FileName { get; set; }

        //The main title for the reprt
        public string ReportTitle { get; set; }

        //The right and left titles and sub title for the report
        public string RightMainTitle { get; set; }
        public string RightSubTitle { get; set; }
        public string LeftMainTitle { get; set; }
        public string LeftSubTitle { get; set; }
        public string ReportLogo { get; set; }

        //date for printing the report
        public DateTime ReportDate { get; set; }

        //the user name that is printing the report
        public string UserNamPrinting { get; set; }
        public bool ViewAsAttachment { get; set; }
    }
}