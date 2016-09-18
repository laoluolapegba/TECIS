namespace TECIS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tecis.rolepermxref")]
    public partial class RolePermXref
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roleid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int permissionid { get; set; }

        public int parenttask { get; set; }

        [StringLength(20)]
        public string createdby { get; set; }

        public DateTime? createddate { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
