namespace TECIS.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("userrolexref")]
    public partial class UserRoleXref
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string userid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roleid { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
