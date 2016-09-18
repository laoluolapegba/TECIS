using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TECIS.Data.Models
{
    [Table("cluster")]
    public class Cluster
    {
        public Cluster()
        {
            this.Guests = new HashSet<Guest>();
            this.Members = new HashSet<Member>();
            this.PrefMembers = new HashSet<Member>();
            this.GuestContacts = new HashSet<GuestContact>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(45, MinimumLength = 2)]
        [DisplayName("Clustername")]
        public string ClusterName { get; set; }
        [DisplayName("ClusterDescription")]
        [DataType(DataType.MultilineText)]
        public string ClusterDesc { get; set; }
        [DisplayName("ClusterAddress")]
        public string ClusterAddress { get; set; }
        [DisplayName("ClusterLeader")]
        public string ClusterLeader { get; set; }
        [DisplayName("ClusterEmail")]
        public string ClusterEmail { get; set; }
        [DisplayName("ClusterPhone")]
        public string ClusterPhone { get; set; }
        [DisplayName("MeetingTime")]
        public string ClusterTime { get; set; }
        public int ClusterType { get; set; }
        [DisplayName("ClusterArea")]
        public int? ClusterArea { get; set; }
        public int? ClusterZone { get; set; }
        public int? ClusterSection { get; set; }
        public int? clusterhead { get; set; }
        [DisplayName("Is Active?")]
        public bool status { get; set; }
        //public virtual ClusterArea clusterareas { get; set; }
        public virtual ClusterType clustertypes { get; set; }
        public virtual CArea clustareas { get; set; }
        public virtual CSection clustersections { get; set; }
        public virtual CZone clusterzones { get; set; }
        public virtual Member clusterheads { get; set; }
        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Member> PrefMembers { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<GuestContact> GuestContacts { get; set; }
    }
}
