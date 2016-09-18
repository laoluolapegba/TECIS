using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("member")]
    public class Member
    {
        public Member()
        {
            this.ClusterHeads = new HashSet<Cluster>();
            this.UnitHeads = new HashSet<ServiceUnit>();
        }
        [Key]
        public int Id { get; set; }
        [DisplayName("MemberNumber")]
        public string merberid { get; set; }
        [DisplayName("Surname")]
        public string surname { get; set; }
        [DisplayName("Firstname")]
        public string firstname { get; set; }
        [DisplayName("Other-names")]
        public string othernames { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Telephone")]
        public string telephone { get; set; }
        [DisplayName("EmailAddress")]
        public string email_address { get; set; }
        [DisplayName("DateofBirth")]
        public DateTime? dob { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("MaritalStatus")]
        public int? maritalstatus { get; set; }
        [DisplayName("WeddingAnniversary")]
        [DataType(DataType.Date)]
        public DateTime? wedding_anniv { get; set; }
        [DisplayName("Occupation")]
        public string occupation { get; set; }
        [DisplayName("NoofChildren")]
        public int? no_of_children { get; set; }
        [DisplayName("OfficeAddress")]
        public string officeaddress { get; set; }
        [DisplayName("Do you attend a Connect Group?")]
        public int? flg_attends_cluster { get; set; }
        [DisplayName("If yes which one?")]
        public int? clusterid { get; set; }
        [DisplayName("If no which would you love to attend?")]
        public int? preferred_cluster { get; set; }
        [DisplayName("Are you in a server unit(s) ?")]
        public int? flg_serving { get; set; }
        [DisplayName("If yes which one?")]
        public int? serviceunit_id { get; set; }
        [DisplayName("If no which would you love to join?")]
        public int? preferred_serviceunit { get; set; }
        [DisplayName("Name")]
        public string child_1 { get; set; }
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        public DateTime? child_1_birthday { get; set; }
        [DisplayName("Name")]
        public string child_2 { get; set; }
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        public DateTime? child_2_birthday { get; set; }
        [DisplayName("Name")]
        public string child_3 { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Birthday")]
        public DateTime? child_3_birthday { get; set; }
        public string createdby { get; set; }
        public DateTime? createddate { get; set; }
        public int? agegroup { get; set; }
        public virtual Cluster cluster { get; set; }
        public virtual Cluster cluster1 { get; set; }
        public virtual MaritalStat maritalstats { get; set; }
        public virtual ServiceUnit serviceunit { get; set; }
        public virtual ServiceUnit serviceunit1 { get; set; }
        public virtual ICollection<ServiceUnit> UnitHeads { get; set; }
        public virtual ICollection<Cluster> ClusterHeads { get; set; }


    }
}
