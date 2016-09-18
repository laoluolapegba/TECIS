namespace TECIS.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("meetingattendees")]
    public class MeetingAttendee
    {
        [Key, Column(Order = 0)]
        public int MeetingId { get; set; }
        [Key, Column(Order = 1)]
        public int AttendeeId { get; set; }
    
        public virtual Meeting Meeting { get; set; }
    }
}
