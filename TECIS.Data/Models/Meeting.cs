
namespace TECIS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("meeting")]
    public class Meeting
    {
        public Meeting()
        {
            this.MeetingAttendees = new HashSet<MeetingAttendee>();
            //this.Meetings1 = new HashSet<Meeting>();
        }
    
        [Key]
        public int MeetingID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> RoomID { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }    
        public virtual ICollection<MeetingAttendee> MeetingAttendees { get; set; }
        //public virtual ICollection<Meeting> Meetings1 { get; set; }
        //public virtual Meeting Meeting1 { get; set; }
    }
}
