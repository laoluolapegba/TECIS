using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECIS.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("reportdefn")]
    public partial class RptDefn
    {
        [Key]
        public int Report_Id { get; set; }
        public string Report_Name { get; set; }
        public string Report_Description { get; set; }
        public string Report_Url { get; set; }
        public string DatasetName { get; set; }
    }
}
