using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("serviceunit")]
    public class ServiceUnit
    {
        public ServiceUnit()
        {
            this.Members = new HashSet<Member>();
            this.PrefMembers = new HashSet<Member>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Unitname")]
        public string UnitName { get; set; }
        [DisplayName("Unit Description")]
        public string UnitDesc { get; set; }
        public int? unitleader { get; set; }
        public virtual Member unitheads { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Member> PrefMembers { get; set; }

    }
}
