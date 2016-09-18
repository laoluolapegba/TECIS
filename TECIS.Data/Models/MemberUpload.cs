using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("memberupload")]
    public class MemberUpload
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Date Joined")]
        public string datejoined { get; set; }
        [DisplayName("Surname")]
        public string surname { get; set; }
        [DisplayName("Firstname")]
        public string firstname { get; set; }
        [DisplayName("Other names")]
        public string othernames { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Telephone")]
        public string telephone { get; set; }
        [DisplayName("Email Address")]
        public string email_address { get; set; }
        [DisplayName("Date of Birth")]
        public string dob { get; set; }
        [DisplayName("Age")]
        public string age { get; set; }
        [DisplayName("Gender")]
        public string gender { get; set; }
        [DisplayName("Marital Status")]
        public string maritalstatus { get; set; }
        [DisplayName("Wedding Anniversary")]
        public string wedding_anniv { get; set; }

        [DisplayName("Occupation")]
        public string occupation { get; set; }
        [DisplayName("Office Address")]
        public string officeaddress { get; set; }
        [DisplayName("Cluster")]
        public string cluster { get; set; }
        [DisplayName("ServiceUnit")]
        public string serviceunit { get; set; }
        [DisplayName("No of Children")]
        public string no_of_children { get; set; }

        [DisplayName("Child Name")]
        public string child_1 { get; set; }
        [DisplayName("Child Age")]
        public string child_1_age { get; set; }
        [DisplayName("Birthday")]
        public string child_1_birthday { get; set; }
        [DisplayName("Child Name")]
        public string child_2 { get; set; }
        [DisplayName("Child Age")]
        public string child_2_age { get; set; }
        public string child_2_birthday { get; set; }
        [DisplayName("Child Name")]
        public string child_3 { get; set; }
        [DisplayName("Child Age")]
        public string child_3_age { get; set; }

        [DisplayName("Birthday")]
        public string child_3_birthday { get; set; }

        [DisplayName("Child Name")]
        public string child_4 { get; set; }
        [DisplayName("Child Age")]
        public string child_4_age { get; set; }

        [DisplayName("Birthday")]
        public string child_4_birthday { get; set; }       
        
        public string createdby { get; set; }
        public DateTime? createddate { get; set; }



    }
}
