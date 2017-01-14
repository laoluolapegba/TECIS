using FluentSecurity;
using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using TECIS.Web.Controllers;
using Elmah;
namespace TECIS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //SecurityConfigurator.Configure(configuration =>
            //{
            //    // Let FluentSecurity know how to get the authentication status of the current user
            //    configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);

            //    // This is where you set up the policies you want FluentSecurity to enforce on your controllers and actions
            //    configuration.For<HomeController>().Ignore();
            //    configuration.For<AccountController>().DenyAuthenticatedAccess();
            //    //configuration.For<AccountController>(x => x.()).DenyAnonymousAccess();
            //    configuration.For<AccountController>(x => x.LogOff()).DenyAnonymousAccess();
            //    configuration.For<AccountController>(x => x.Login("")).Ignore();
            //    configuration.Advanced.IgnoreMissingConfiguration();

            //    //configuration.For<GuestsController>(x => x.Index()).Ignore();
            //    //configuration.For<GuestsController>(x => x.Create()).RequireRole(BlogRole.Writer);
            //});
            //GlobalFilters.Filters.Add(new HandleSecurityAttribute(), -1);
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                //var identity = new CustomIdentity(HttpContext.Current.User.Identity);
                //var principal = new CustomPrincipal(identity);
                //HttpContext.Current.User = principal;
            }

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var newCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            newCulture.NumberFormat.CurrencySymbol = "₦";

            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = newCulture;
        }
        //protected void ErrorLog_Filtering(object sender, ExceptionFilterEventArgs e)
        //{
        //    e.Dismiss();
        //    return;

        //    //var httpContext = e.Context as HttpContext;
        //    //if (httpContext == null)
        //    //{
        //    //    return;
        //    //}

        //    //var error = new Error(e.Exception, httpContext);
        //    //ErrorLog.GetDefault(httpContext).Log(error);
        //    //e.Dismiss();
        //}
    }
}
