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
    [Table("clusterzone")]
    public class CZone
    {

        public CZone()
            {
                this.Clusters = new HashSet<Cluster>();
                this.Areas = new HashSet<CArea>();
            }
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Description is required")]
            [StringLength(45, MinimumLength = 2)]
            [DisplayName("Description")]
            public string Description { get; set; }
            public string ZonalCoordinator { get; set; }
            public string ZoneEmail { get; set; }
            public virtual ICollection<Cluster> Clusters { get; set; }
            public virtual ICollection<CArea> Areas { get; set; }
    }
}
