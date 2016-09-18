﻿namespace TECIS.Web.Models.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Kendo.Mvc.UI;
    using TECIS.Data.Models;
    public class MeetingViewModel : ISchedulerEvent
    {
        public int MeetingID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        public string StartTimezone { get; set; }

        private DateTime end;

        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }
        public int? RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }
        public string Timezone { get; set; }
        public int? RoomID { get; set; }
        public IEnumerable<int> Attendees { get; set; }

        public Meeting ToEntity()
        {
            var meeting = new Meeting
            {
                MeetingID = MeetingID,
                Title = Title,
                StartDate = Start,
                StartTimezone = StartTimezone,
                EndDate = End,
                EndTimezone = EndTimezone,
                Description = Description,
                IsAllDay = IsAllDay,
                RecurrenceRule = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                RecurrenceID = RecurrenceID,
                RoomID = RoomID
            };

            return meeting;
        }
    }
}