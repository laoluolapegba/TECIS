
namespace TECIS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("smsresponse")]
    public class SmsResponse
    {
        public SmsResponse()
        {
            this.Guests = new HashSet<Guest>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Error Description")]
        public string Description { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }
    }
}
