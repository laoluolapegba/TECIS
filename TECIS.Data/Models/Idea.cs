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
    [Table("idea")]
    public class Idea
    {
        [Key]
        public int ididea { get; set; }
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, MinimumLength = 2)]
        [DisplayName("Description")]
        public string Description { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public int votecount { get; set; }
        public virtual IdeaCategory ideacategory {get;set;}
        
        public virtual IdeaStatus ideastatus {get;set;}
    }
}
