using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TECIS.Data.Models
{
    [Table("decisioncard")]
    public partial class Decisioncard
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("GENDER")]
        public string Gender { get; set; }
        [DisplayName("I responded to the invitation to:")]
        public Nullable<int> ResponseType { get; set; }
        [DisplayName("STATUS")]
        public Nullable<int> MaritalStat { get; set; }
        [DisplayName("BIRTH DATE")]
        public string BirthDate { get; set; }
        [DisplayName("SURNAME")]

        public string Surname { get; set; }
        [DisplayName("OTHERNAMES")]
        public string OtherNames { get; set; }
        [DisplayName("HOME ADDRESS")]
        public string HomeAddress { get; set; }
        [DisplayName("TELEPHONE")]
        public string PhoneNumber { get; set; }
        [DisplayName("OFFICE ADDRESS")]
        public string OfficeAddress { get; set; }
        [DisplayName("E-MAIL")]
        public string EmailAddress { get; set; }
        [DisplayName("PRAYER REQUEST")]
        public string PrayerRequest { get; set; }

        public DateTime? timecaptured { get; set; }
        public DateTime worshipdate { get; set; }
        public string createdby { get; set; }
    }
}
