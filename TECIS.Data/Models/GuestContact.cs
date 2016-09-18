using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TECIS.Data.Models
{
    [Table("guestcontact")]
    public class GuestContact
    {
        [Key]
        public int id { get; set; }
        [DisplayName("Guest")]
        public int theguestid { get; set; }
        
        [DisplayName("Firstname")]
        public string guest_firstname { get; set; }
        [DisplayName("Lastname")]
        public string guest_lastname { get; set; }
        public int clusterid { get; set; }
        [DisplayName("Contact Date")]
        public DateTime contact_date { get; set; }
        [DisplayName("Contacted By")]
        [Required(ErrorMessage = "This field can not be empty.")]
        public string contacted_by { get; set; }
        [DisplayName("Created Date")]
        [DataType(DataType.Date)]
        public DateTime created_date { get; set; }
        [DisplayName("Created By")]
        public string created_by { get; set; }
        [DisplayName("I would Like to Join")]
        public bool WouldJoin { get; set; }
        [DisplayName("I have my own Church")]
        public bool HasChurch { get; set; }
        [DisplayName("Don't bother about me")]
        public bool Forgetme { get; set; }
        public virtual Guest GuestId { get; set; }
        public virtual Cluster GuestCluster { get; set; }

    }
}
