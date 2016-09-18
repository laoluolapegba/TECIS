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
    [Table("clustarea")]
    public class CArea
    {

        public CArea()
            {
                this.Clusters = new HashSet<Cluster>();
                this.Sections = new HashSet<CSection>();
            }
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Description is required")]
            [StringLength(45, MinimumLength = 2)]
            [DisplayName("Description")]
            public string Description { get; set; }
            public string AreaCoordinator { get; set; }
            public int AreaZone { get; set; }
            public string AreaEmail { get; set; }
            public virtual CZone AreaZones { get; set; }
            public virtual ICollection<Cluster> Clusters { get; set; }
            public virtual ICollection<CSection> Sections { get; set; }
    }
}
