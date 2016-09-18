﻿using System;
using System.Security.Principal;
using System.Web.Security;

namespace TECIS.Web.Helpers.CrossCutting.Security
{
    /// <summary>
    /// An identity object represents the user on whose behalf the code is running.
    /// </summary>
    [Serializable]
    public class CustomIdentity : IIdentity
    {
        #region Properties

        public IIdentity Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }
        public string DisplayName { get; set; }

        //public int BranchId { get; set; }
        //public string BranchName { get; set; }

        public int ProfileId { get; set; }
        #endregion

        #region Implementation of IIdentity

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>
        /// The name of the user on whose behalf the code is running.
        /// </returns>
        public string Name
        {
            get { return Identity.Name; }
        }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>
        /// The type of authentication used to identify the user.
        /// </returns>
        public string AuthenticationType
        {
            get { return Identity.AuthenticationType; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>
        /// true if the user was authenticated; otherwise, false.
        /// </returns>
        public bool IsAuthenticated { get { return Identity.IsAuthenticated; } }
        //laolu Added GetUserId
        public string GetUserId { get { return Identity.Name; } }

        #endregion

        #region Constructor

        public CustomIdentity(IIdentity identity)
        {
            Identity = identity;

            var customMembershipUser = (CustomMembershipUser)Membership.GetUser(identity.Name);
            if (customMembershipUser != null)
            {
                FirstName = customMembershipUser.FirstName;
                LastName = customMembershipUser.LastName;
                Email = customMembershipUser.Email;
                UserRoleId = customMembershipUser.UserRoleId;
                UserRoleName = customMembershipUser.UserRoleName;
                DisplayName = customMembershipUser.DisplayName;
                //BranchId = customMembershipUser.BranchId;
                //BranchName = customMembershipUser.BranchName;
                ProfileId = customMembershipUser.ProfileId;



            }
        }

        #endregion
    }
}