namespace TECIS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("aspnetroles")]
    public partial class UserRole
    {
        public UserRole()
        {
            //RolePermXref = new HashSet<RolePermXref>();
            UserProfile = new HashSet<UserProfile>();
            //UserRoleXref = new HashSet<UserRoleXref>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        //public int? pswdlifedays { get; set; }

        //public int? userlevel { get; set; }

        //[StringLength(20)]
        //public string createdby { get; set; }

        //public DateTime? createddate { get; set; }

        //[StringLength(20)]
        //public string lastmodifiedby { get; set; }

        //public DateTime? lastmodifieddate { get; set; }

        //public int? isdefault { get; set; }

        //public virtual ICollection<RolePermXref> RolePermXref { get; set; }

        public virtual ICollection<UserProfile> UserProfile { get; set; }

        //public virtual ICollection<UserRoleXref> UserRoleXref { get; set; }
    }
}
