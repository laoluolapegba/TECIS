using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("answer")]
    public class Answer
    {
        
        public Answer()
        {
            this.Guest = new HashSet<Guest>();
            this.Guest1 = new HashSet<Guest>();
            this.Guest2 = new HashSet<Guest>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Description")]
        public string Description { get; set; }

        public virtual ICollection<Guest> Guest { get; set; }
        public virtual ICollection<Guest> Guest1 { get; set; }
        public virtual ICollection<Guest> Guest2 { get; set; }
    }
}
