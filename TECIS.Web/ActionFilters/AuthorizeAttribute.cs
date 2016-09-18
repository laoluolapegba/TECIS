using System;

namespace TECIS.Web
{
    /// <summary>
    /// This function was written to solve the problem of 
    /// HTTP specification used status code 401 for both "unauthorized" and "unauthenticated"
    /// asp.net mvc will redirect to the Login Page if the currently authenticated user is not authorized to view the resource or page
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                filterContext.Result = new System.Web.Mvc.HttpStatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}