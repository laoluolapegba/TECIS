using System.Web.Mvc;

//Get requesting user's roles/permissions from database tables...      
public static class RBAC_ExtendedMethods
{
    public static bool HasRole(this ControllerBase controller, string role)
    {
        bool bFound = false;
        try
        {
            //Check if the requesting user has the specified role...
            bFound = new RBACUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasRole(role);
        }
        catch { }
        return bFound;
    }

    public static bool HasRoles(this ControllerBase controller, string roles)
    {
        bool bFound = false;
        try
        {
            //Check if the requesting user has any of the specified roles...
            //Make sure you separate the roles using ; (ie "Sales Manager;Sales Operator"
            bFound = new RBACUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasRoles(roles);
        }
        catch { }
        return bFound;
    }

    public static bool HasPermission(this ControllerBase controller, string permission)
    {
        bool bFound = false;
        try
        {
            //Check if the requesting user has the specified application permission...
            bFound = new RBACUser(controller.ControllerContext.HttpContext.User.Identity.Name).HasPermission(permission);
        }
        catch { }
        return bFound;
    }

    public static bool IsSysAdmin(this ControllerBase controller)
    {
        bool bIsSysAdmin = false;
        try
        {
            //Check if the requesting user has the System Administrator privilege...
            bIsSysAdmin = new RBACUser(controller.ControllerContext.HttpContext.User.Identity.Name).IsSysAdmin;
        }
        catch { }
        return bIsSysAdmin;
    }
}
