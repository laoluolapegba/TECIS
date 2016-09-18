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
    [Table("ideastatus")]
    public class IdeaStatus
    {
        

            public IdeaStatus()
            {
                this.Ideas = new HashSet<Idea>();
            }
            [Key]
            public int Id { get; set; }
            [Required(ErrorMessage = "Description is required")]
            [StringLength(45, MinimumLength = 2)]
            [DisplayName("Description")]
            public string Description { get; set; }

            public virtual ICollection<Idea> Ideas { get; set; }

        
    }
}
