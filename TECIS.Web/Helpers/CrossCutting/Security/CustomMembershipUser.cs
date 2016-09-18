using System;
using System.Web.Security;

namespace TECIS.Web.Helpers.CrossCutting.Security
{
    public class CustomMembershipUser : MembershipUser
    {
        #region Properties

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }

        public string DisplayName { get; set; }

        public int ProfileId { get; set; }

        #endregion

        public CustomMembershipUser(TECIS.Data.Models.UserProfile user)
            : base("CustomMembershipProvider", user.UserId, user.ProfileId, user.EmailAddress, string.Empty, string.Empty, true, false,
            (DateTime)user.CreatedDate, (DateTime)user.LastLoginDate, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            FirstName = user.Firstname;
            LastName = user.Lastname;
            UserRoleId = (int)user.RoleId;
            UserRoleName = user.UserRole.RoleName;
            DisplayName = user.DisplayName;
            ProfileId = (int)user.ProfileId;
            //BranchId = 0; // (int)user.BRANCH_ID;
            //BranchName = user.CM_BRANCH.BRANCH_NAME;

        }

    }
}