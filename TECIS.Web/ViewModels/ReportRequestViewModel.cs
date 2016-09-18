using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TECIS.Web.ViewModels
{
    public class ReportRequestViewModel
    {
        [Required]
        public int REPORT_ID { get; set; }
        public string REPORT_NAME { get; set; }
        public string REPORT_DESCRIPTION { get; set; }
        public string REPORT_URL { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public string DATASETNAME { get; set; }
        public int SearchMode { get; set; }
    }
}
