namespace TECIS.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("permission")]
    public partial class Permission
    {
        public Permission()
        {
            RolePermXref = new HashSet<RolePermXref>();
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PermissionDescription { get; set; }

        [Required]
        [StringLength(20)]
        public string actionname { get; set; }

        [Required]
        [StringLength(20)]
        public string controllername { get; set; }

        public int? parentpermission { get; set; }

        [StringLength(20)]
        public string formurl { get; set; }

        [StringLength(20)]
        public string imageurl { get; set; }

        [StringLength(20)]
        public string iconclass { get; set; }

        [StringLength(20)]
        public string isopenclass { get; set; }

        [StringLength(20)]
        public string toggleicon { get; set; }

        public int? isactive { get; set; }

        public virtual ICollection<RolePermXref> RolePermXref { get; set; }
    }
}
