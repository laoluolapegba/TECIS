using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECIS.Web.ViewModels
{
    public class GuestViewModel
    {
        
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string NearestBusstop { get; set; }
        public string ClusterArea { get; set; }
        public string OfficeAddress { get; set; }
        public string Occupation { get; set; }
        public string WouldJoin { get; set; }
        public string MemberShipInfo { get; set; }
        public string Updates { get; set; }
        public string HowdidyouKnow { get; set; }
        public string PrayerComments { get; set; }
        public string PrefModeofContact { get; set; }
        public bool SMSsent { get; set; }
        public string Createdby { get; set; }
        public DateTime WorshipDate { get; set; }
        public DateTime TimeCaptured { get; set; }
        
    }
}