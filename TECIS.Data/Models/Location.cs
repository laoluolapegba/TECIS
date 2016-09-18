using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TECIS.Data.Models
{
    [Table("location")]
    public class Location
    {
        public Location()
        {
            this.AttendanceRegs = new HashSet<AttendanceReg>();
        }
        [Key]
        public int idloc { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Name")]
        public string locationname { get; set; }
        [DisplayName("Description")]
        public string locationdesc { get; set; }

        public virtual ICollection<AttendanceReg> AttendanceRegs { get; set; }
    }
}
