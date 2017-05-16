namespace TECIS.Data.Models
{
    using System.Data.Entity;

    using System.Data.Entity.Validation;
    using System.Linq;
    public partial class TecIsEntities : DbContext
    {
        public TecIsEntities()
            : base("name=DefaultConnection")
        {
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
        public virtual DbSet<AgeGroup> AgeGroups { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<ClusterArea> ClusterAreas { get; set; }
        public virtual DbSet<MaritalStat> MaritalStats { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<ServicesType> ServicesTypes { get; set; }
        public virtual DbSet<SmsResponse> smsresponses { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermXref> RolePermXrefs { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserRoleXref> UserRoleXrefs { get; set; } 
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }

        public virtual DbSet<AttendanceReg> AttendanceRegs { get; set; }
        public virtual DbSet<AddressLocator> AddressLocators { get; set; }

        public virtual DbSet<ClusterType> ClusterTypes { get; set; }
        public virtual DbSet<Cluster> Clusters { get; set; }
        
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<ServiceUnit> ServiceUnits { get; set; }
        public virtual DbSet<vwAttendance> vwAttendance { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<GuestUpload> GuestUpload { get; set; }
        public virtual DbSet<MemberUpload> MemberUploads {get; set; }
        public virtual DbSet<Idea> Ideas { get; set; }
        public virtual DbSet<IdeaCategory> IdeaCategory { get; set; }
        public virtual DbSet<IdeaStatus> IdeaStatus { get; set; }
        public virtual DbSet<CZone> CZones { get; set; }
        public virtual DbSet<CSection> CSections { get; set; }
        public virtual DbSet<CArea> CAreas { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<ReportStatus> ReportStats { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<MeetingAttendee> MeetingAttendees { get; set; }
        public virtual DbSet<GuestContact> GuestContacts { get; set; }
        //public virtual DbSet<SmUserProfile> SmUserProfile { get; set; }
        public System.Data.Entity.DbSet<SMSObject> SMSObjects { get; set; }
        public virtual DbSet<RptDefn> RptDefinition { get; set; }
        public virtual DbSet<TecSchoolAttendance> TecSchools { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>()
                .Property(e => e.PermissionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.actionname)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.controllername)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.formurl)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.imageurl)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.iconclass)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.isopenclass)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.toggleicon)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.RolePermXref)
                .WithRequired(e => e.Permission)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RolePermXref>()
                .Property(e => e.createdby)
                .IsUnicode(false);

           

            //modelBuilder.Entity<UserProfile>()
            //    .Property(e => e.Cod_Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserProfile>()
            //    .Property(e => e.PasswordSalt)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserProfile>()
            //    .Property(e => e.MobilePin)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserProfile>()
            //    .Property(e => e.PasswordQuestion)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserProfile>()
            //    .Property(e => e.PasswordAnswer)
            //    .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<UserProfile>()
                .Property(e => e.Email)
                .IsUnicode(false);

            //modelBuilder.Entity<UserRole>()
            //    .Property(e => e.RoleName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserRole>()
            //    .Property(e => e.createdby)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserRole>()
            //    .Property(e => e.lastmodifiedby)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserRole>()
            //    .HasMany(e => e.RolePermXref)
            //    .WithRequired(e => e.UserRole)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserRole>()
            //    .HasMany(e => e.UserRoleXref)
            //    .WithRequired(e => e.UserRole)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRoleXref>()
                .Property(e => e.userid)
                .IsUnicode(false);
            modelBuilder.Entity<Guest>().HasOptional(e => e.age).WithMany(t => t.Guests).HasForeignKey(e => e.agegroup).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Guest>()
            //        .HasRequired(m => m.answer)
            //        .WithMany(t => t.Guest)
            //        .HasForeignKey(m => m.flg_join)
            //        .WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasOptional(e => e.answer).WithMany(t => t.Guest).HasForeignKey(e => e.flg_join).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasOptional(e => e.answer1).WithMany(t => t.Guest1).HasForeignKey(e => e.flg_membershipinfo).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasOptional(e => e.answer2).WithMany(t => t.Guest2).HasForeignKey(e => e.flg_moreinfo).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasRequired(e => e.clusters).WithMany(t => t.Guests).HasForeignKey(e => e.ClusterArea).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasOptional(e => e.maritalstats).WithMany(t => t.Guests).HasForeignKey(e => e.MaritalStat).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasRequired(e => e.svctypes).WithMany(t => t.Guests).HasForeignKey(e => e.servicetype).WillCascadeOnDelete(false);
            modelBuilder.Entity<Guest>().HasRequired(e => e.smserrors).WithMany(t => t.Guests).HasForeignKey(e => e.SmsResponse).WillCascadeOnDelete(false);


            modelBuilder.Entity<TecSchoolAttendance>().HasOptional(e => e.age).WithMany(t => t.TecSchAttds).HasForeignKey(e => e.agegroup).WillCascadeOnDelete(false);
            modelBuilder.Entity<TecSchoolAttendance>().HasOptional(e => e.maritalstats).WithMany(t => t.TecSchAttds).HasForeignKey(e => e.MaritalStat).WillCascadeOnDelete(false);


            modelBuilder.Entity<AttendanceReg>().HasRequired(e => e.svctypes).WithMany(t => t.AttendanceRegs).HasForeignKey(e => e.servicetype).WillCascadeOnDelete(false);
            modelBuilder.Entity<AttendanceReg>().HasRequired(e => e.locations).WithMany(t => t.AttendanceRegs).HasForeignKey(e => e.location).WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>().HasOptional(e => e.cluster).WithMany(t => t.Members).HasForeignKey(e => e.clusterid).WillCascadeOnDelete(false);
            modelBuilder.Entity<Member>().HasOptional(e => e.cluster1).WithMany(t => t.PrefMembers).HasForeignKey(e => e.preferred_cluster).WillCascadeOnDelete(false);
            modelBuilder.Entity<Member>().HasOptional(e => e.serviceunit).WithMany(t => t.Members).HasForeignKey(e => e.serviceunit_id).WillCascadeOnDelete(false);
            modelBuilder.Entity<Member>().HasOptional(e => e.serviceunit1).WithMany(t => t.PrefMembers).HasForeignKey(e => e.preferred_serviceunit).WillCascadeOnDelete(false);
            modelBuilder.Entity<Member>().HasOptional(e => e.maritalstats).WithMany(t => t.Members).HasForeignKey(e => e.maritalstatus).WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Cluster>().HasRequired(e => e.clustertypes).WithMany(t => t.Clusters).HasForeignKey(e => e.ClusterType).WillCascadeOnDelete(false);

            modelBuilder.Entity<Cluster>().HasOptional(e => e.clustersections).WithMany(t => t.Clusters).HasForeignKey(e => e.ClusterSection).WillCascadeOnDelete(false);
            modelBuilder.Entity<Cluster>().HasOptional(e => e.clustareas).WithMany(t => t.Clusters).HasForeignKey(e => e.ClusterArea).WillCascadeOnDelete(false);            
            modelBuilder.Entity<Cluster>().HasOptional(e => e.clusterzones).WithMany(t => t.Clusters).HasForeignKey(e => e.ClusterZone).WillCascadeOnDelete(false);
            modelBuilder.Entity<Cluster>().HasOptional(e => e.clusterheads).WithMany(t => t.ClusterHeads).HasForeignKey(e => e.clusterhead).WillCascadeOnDelete(false);

            modelBuilder.Entity<Idea>().HasRequired(e => e.ideacategory).WithMany(t => t.Ideas).HasForeignKey(e => e.Category).WillCascadeOnDelete(false);
            modelBuilder.Entity<Idea>().HasRequired(e => e.ideastatus).WithMany(t => t.Ideas).HasForeignKey(e => e.Status).WillCascadeOnDelete(false);

            modelBuilder.Entity<CSection>().HasRequired(e => e.SectAreas).WithMany(t => t.Sections).HasForeignKey(e => e.SectArea).WillCascadeOnDelete(false);
            modelBuilder.Entity<CArea>().HasRequired(e => e.AreaZones).WithMany(t => t.Areas).HasForeignKey(e => e.AreaZone).WillCascadeOnDelete(false);


            modelBuilder.Entity<ServiceUnit>().HasOptional(e => e.unitheads).WithMany(t => t.UnitHeads).HasForeignKey(e => e.unitleader).WillCascadeOnDelete(false);

            modelBuilder.Entity<MeetingAttendee>().HasRequired(e => e.Meeting).WithMany(t => t.MeetingAttendees).HasForeignKey(e => e.MeetingId).WillCascadeOnDelete(false);

            modelBuilder.Entity<GuestContact>().HasRequired(e => e.GuestId).WithMany(t => t.GuestContacts).HasForeignKey(e => e.theguestid).WillCascadeOnDelete(false);
            modelBuilder.Entity<GuestContact>().HasRequired(e => e.GuestCluster).WithMany(t => t.GuestContacts).HasForeignKey(e => e.clusterid).WillCascadeOnDelete(false);
            //modelBuilder.Entity<MeetingAttendee>().HasRequired(e => e.Meeting).WithMany(t => t.MeetingAttendees).HasForeignKey(e => e.MeetingId).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Appointment>().HasRequired(e => e.Appointment1).WithMany(t => t.Appointments1).HasForeignKey(e => e.Id).WillCascadeOnDelete(false);


        }

        



    }
}
