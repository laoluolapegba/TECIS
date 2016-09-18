using TECIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class RBACUser
{
    public int Profile_Id { get; set; }
    public bool IsSysAdmin { get; set; }
    public string UserId { get; set; }
    private List<UserRole> Roles = new List<UserRole>();

    public RBACUser(string _username)
    {
        this.UserId = _username;
        this.IsSysAdmin = false;
        GetDatabaseUserRolesPermissions();
    }

    private void GetDatabaseUserRolesPermissions()
    {
        using (TecIsEntities _data = new TecIsEntities())
        {
            UserProfile _user = _data.UserProfiles.Where(u => u.UserId == this.UserId).FirstOrDefault();
            if (_user != null)
            {
                this.Profile_Id = (int)_user.ProfileId;
                TECIS.Data.Models.UserRole _role = _user.UserRole;
                UserRole _userRole = new UserRole { Role_Id = _role.RoleID, RoleName = _role.RoleName };
                foreach (RolePermXref _permission in _role.RolePermXref)
                {
                    _userRole.Permissions.Add(new RolePermission { Permission_Id = (int)_permission.Permission.PermissionId, PermissionDescription = _permission.Permission.PermissionDescription });
                }

                //foreach (TECIS.Data.Models.UserRole _role in _user.UserRole)
                //{
                //    UserRole _userRole = new UserRole { Role_Id = _role.RoleID, RoleName = _role.RoleName };
                //    //Attention laolu
                //    //foreach (Permission _permission in _role.Permissions)
                //    //{
                //    //    _userRole.Permissions.Add(new RolePermission { Permission_Id = (int)_permission.PermissionId, PermissionDescription = _permission.PermissionDescription });
                //    //}
                //    this.Roles.Add(_userRole);

                //    if (!this.IsSysAdmin)
                //        this.IsSysAdmin = (bool)!_role.IsDefault;
                //}
            }
        }
    }

    public bool HasPermission(string requiredPermission)
    {
        bool bFound = false;
        foreach (UserRole role in this.Roles)
        {
            bFound = (role.Permissions.Where(p => p.PermissionDescription.ToLower() == requiredPermission.ToLower()).ToList().Count > 0);
            if (bFound)
                break;
        }
        return bFound;
    }

    public bool HasRole(string role)
    {
        return (Roles.Where(p => p.RoleName == role).ToList().Count > 0);
    }

    public bool HasRoles(string roles)
    {
        bool bFound = false;
        string[] _roles = roles.ToLower().Split(';');
        foreach (UserRole role in this.Roles)
        {
            try
            {
                bFound = _roles.Contains(role.RoleName.ToLower());
                if (bFound)
                    return bFound;
            }
            catch (Exception)
            {
            }
        }
        return bFound;
    }
}

public class UserRole
{
    public int Role_Id { get; set; }
    public string RoleName { get; set; }
    public List<RolePermission> Permissions = new List<RolePermission>();
}

public class RolePermission
{
    public int Permission_Id { get; set; }
    public string PermissionDescription { get; set; }
}