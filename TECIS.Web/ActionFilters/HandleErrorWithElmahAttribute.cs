using Elmah;
using System.Web.Mvc;
namespace TECIS.Web.ActionFilters
{
    public class HandleErrorWithELMAHAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        public void OnException(ExceptionContext context)
        {
            // Log only handled exceptions, because all other will be caught by ELMAH anyway.
            if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }
    }
}