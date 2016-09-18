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
    [Table("appointment")]
    public class Appointment
    {
        //public Appointment()
        //{
        //    this.Appointments1 = new HashSet<Appointment>();
        //}
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }

        public int? RoomID { get; set; }
        public bool Status { get; set; }
        
        public bool IsAllDay { get; set; }
        public int? OwnerID { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string RecurrenceRule { get; set; }
        //public virtual ICollection<Appointment> Appointments1 { get; set; }
        //public virtual Appointment Appointment1 { get; set; }
    }
}
