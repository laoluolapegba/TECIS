
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("tecschlattend")]
    public partial class TecSchoolAttendance
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        [DisplayName("Age Group")]
        public Nullable<int> agegroup { get; set; }

        [DisplayName("Marital Status ")]
        public Nullable<int> MaritalStat { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string PhoneNumber { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public string createdby { get; set; }
        [DisplayName("Date")]
        public DateTime createddate { get; set; }
        [DisplayName("Membership Class Attended")]
        public bool membership_class { get; set; }
        [DisplayName("Date Attended")]
        public DateTime? membership_class_date { get; set; }
        [DisplayName("Development Class Attended")]
        public bool development_class { get; set; }
        [DisplayName("Date Attended")]
        public DateTime? development_class_date { get; set; }
        [DisplayName("Maturity Class Attended")]
        public bool maturity_class { get; set; }
        [DisplayName("Date Attended")]
        public DateTime? maturity_class_date { get; set; }
        [DisplayName("Age")]
        public virtual AgeGroup age { get; set; }
        [DisplayName("Marital Status")]
        public virtual MaritalStat maritalstats { get; set; }
        
        [NotMapped]
        public bool Selected { get; set; }
        
    }
}
