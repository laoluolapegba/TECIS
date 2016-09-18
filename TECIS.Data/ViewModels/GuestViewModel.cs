using System;
using System.Collections.Generic;
using TECIS.Data.Models;

namespace TECIS.Data.ViewModels
{


    public class GenderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }
    public class GuestViewModeler
    {

        public GuestViewModeler()
        {
            this.Genders = new List<GenderViewModel>();
            this.Genders.Add(new GenderViewModel()
            {
                Id = 1,
                Name = "Male",
                Checked = false
            });
            this.Genders.Add(new GenderViewModel()
            {
                Id = 2,
                Name = "Female",
                Checked = false
            });

        }
        public int Id { get; set; }
        public string Gender { get; set; }
        public Nullable<int> AgeGroup { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
        public string Surname { get; set; }
        public string OtherNames { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public string NearestBStop { get; set; }
        public Nullable<int> ClusterArea { get; set; }
        public string OfficeAdress { get; set; }
        public string Occupation { get; set; }
        public Nullable<int> flg_join { get; set; }
        public Nullable<int> flg_membershipinfo { get; set; }
        public Nullable<int> flg_moreinfo { get; set; }
        public string PrayerComments { get; set; }
        public Nullable<System.DateTime> worshipdate { get; set; }
        public Nullable<int> servicetype { get; set; }
        public Nullable<System.DateTime> timecaptured { get; set; }
        public string createdby { get; set; }
        public string Entrychannel { get; set; }
        public string EntrychannelOther { get; set; }

        public virtual AgeGroup agegroup1 { get; set; }
        public virtual Answer answer { get; set; }
        public virtual Answer answer1 { get; set; }
        public virtual Answer answer2 { get; set; }
        public virtual ClusterArea clusterarea1 { get; set; }
        public virtual MaritalStat maritalstat { get; set; }
        public virtual Occupation occupation1 { get; set; }
        //public IList<GenderViewModel> Genders { get; set; }
        public List<GenderViewModel> Genders { get; set; }

    }

}
