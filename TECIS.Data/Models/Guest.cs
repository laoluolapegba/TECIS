using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("guest")]
    public partial class Guest
    {
        public Guest()
        {
            this.GuestContacts = new HashSet<GuestContact>();
        }
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
        public string HomeAddress { get; set; }
        public string NearestBStop { get; set; }
        public int ClusterArea { get; set; }
        public string OfficeAdress { get; set; }
        public string Occupation { get; set; }

        //[ForeignKey("answer")]
        public Nullable<int> flg_join { get; set; }

        public Nullable<int> flg_membershipinfo { get; set; }

        public Nullable<int> flg_moreinfo { get; set; }
        public string PrayerComments { get; set; }

        [DisplayName("Date")]
        public System.DateTime worshipdate { get; set; }
        public int? servicetype { get; set; }
        [DisplayName("Date")]
        public Nullable<System.DateTime> timecaptured { get; set; }
        public string createdby { get; set; }
        public string Entrychannel { get; set; }
        public string PrefContactMode { get; set; }
        //public bool Selected { get; set; }
        public bool SmsSent { get; set; }
        public Nullable<int> SmsResponse { get; set; }
        public bool ismember { get; set; } 
        public virtual AgeGroup age { get; set; }
        public virtual Answer answer { get; set; }
        public virtual Answer answer1 { get; set; }
        public virtual Answer answer2 { get; set; }
        public virtual Cluster clusters { get; set; }
        public virtual MaritalStat maritalstats { get; set; }
        public virtual ServicesType svctypes { get; set; }
        public virtual SmsResponse smserrors { get; set; }

        [NotMapped]
        public string EntrychannelOther { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
        public virtual ICollection<GuestContact> GuestContacts { get; set; }
        
    }
}
