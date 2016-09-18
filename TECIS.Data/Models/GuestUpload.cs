using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("guestupload")]
    public partial class GuestUpload
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        [DisplayName("Age Group")]
        public string agegroup { get; set; }

        [DisplayName("Marital Status ")]
        public string MaritalStat { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string PhoneNumber { get; set; }

        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string NearestBStop { get; set; }
        public string ClusterArea { get; set; }
        public string OfficeAdress { get; set; }
        public string Occupation { get; set; }

        //[ForeignKey("answer")]
        public string flg_join { get; set; }

        public string flg_membershipinfo { get; set; }

        public string flg_moreinfo { get; set; }
        public string PrayerComments { get; set; }

        [DisplayName("Date")]
        public Nullable<System.DateTime> worshipdate { get; set; }
        [DisplayName("Date")]
        public Nullable<System.DateTime> timecaptured { get; set; }
        public string createdby { get; set; }
        public string Entrychannel { get; set; }
        //public bool Selected { get; set; }
        public bool SmsSent { get; set; }
        public int? SmsResponse { get; set; }
        
    }
}
