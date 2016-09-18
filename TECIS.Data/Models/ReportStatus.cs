
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TECIS.Data.Models
{
    [Table("reportstatus")]
    public class ReportStatus
    {
        [Key]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Description is required")]
        //[StringLength(45, MinimumLength = 2)]
        //[DisplayName("Description")]
        public int reportid { get; set; }
        public string recipient { get; set; }
        public bool status { get; set; }
        public DateTime reportdate { get; set; }
        public DateTime datesent { get; set; }
    }
}
