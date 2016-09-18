
namespace TECIS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("servicetype")]
    public class ServicesType
    {
        public ServicesType()
        {
            this.Guests = new HashSet<Guest>();
            this.AttendanceRegs = new HashSet<AttendanceReg>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Service Type")]
        public string servicename { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<AttendanceReg> AttendanceRegs { get; set; }
    }
}
