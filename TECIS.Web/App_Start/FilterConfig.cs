using System.Web.Mvc;
using TECIS.Web.ActionFilters;

namespace TECIS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            filters.Add(new HandleErrorWithELMAHAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new NotificationFilter());
            filters.Add(new AuthorizeAttribute());
            
        }
    }
}
