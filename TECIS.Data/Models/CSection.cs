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
    [Table("clustersection")]
    public class CSection
    {

        public CSection()
            {
                this.Clusters = new HashSet<Cluster>();
            }
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Description is required")]
            [StringLength(45, MinimumLength = 2)]
            [DisplayName("Description")]
            public string Description { get; set; }
            public string SectionLeader { get; set; }
            public int SectArea { get; set; }
            public string SectionEmail { get; set; }
            public virtual CArea SectAreas { get; set; }
            public virtual ICollection<Cluster> Clusters { get; set; }
    }
}
