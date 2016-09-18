using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("agegroup")]
    public class AgeGroup
    {
        public AgeGroup()
        {
            this.Guests = new HashSet<Guest>();
            this.TecSchAttds = new HashSet<TecSchoolAttendance>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<TecSchoolAttendance> TecSchAttds { get; set; }
    }
}
