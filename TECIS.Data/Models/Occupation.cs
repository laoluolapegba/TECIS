
namespace TECIS.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("occupation")]
    public class Occupation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
