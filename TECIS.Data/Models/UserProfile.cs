namespace TECIS.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("userprofile")]
    public partial class UserProfile
    {
        [Key]
        public int ProfileId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required]
        [StringLength(128)]
        public string Cod_Password { get; set; }

        [StringLength(128)]
        public string PasswordSalt { get; set; }

        [StringLength(10)]
        public string MobilePin { get; set; }

        [StringLength(255)]
        public string PasswordQuestion { get; set; }

        [StringLength(255)]
        public string PasswordAnswer { get; set; }

        public int? IsApproved { get; set; }

        public int? IsLocked { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastPasswordChangedDate { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public int? FailedPasswordAttemptCount { get; set; }

        public int? RoleId { get; set; }

        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(20)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(20)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
