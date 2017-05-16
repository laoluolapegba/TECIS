namespace TECIS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("aspnetusers")]   //userprofile
    public partial class UserProfile
    {
        [Key]
        public string Id { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }

        //[StringLength(128)]
        public string PasswordSalt { get; set; }

        //[StringLength(10)]
        //public string MobilePin { get; set; }

        //[StringLength(255)]
        //public string PasswordQuestion { get; set; }

        //[StringLength(255)]
        //public string PasswordAnswer { get; set; }

        public int? AdminConfirmed { get; set; }

        //public int? IsLocked { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        //public DateTime? LastPasswordChangedDate { get; set; }

        //public DateTime? LastLockoutDate { get; set; }

        //public int? FailedPasswordAttemptCount { get; set; }

        
        public string RoleId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(20)]
        public string DisplayName { get; set; }
        public string TeamLeader { get; set; }
        [ForeignKey("RoleId")]        
        public virtual UserRole UserRole { get; set; }
    }
}
