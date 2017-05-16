using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TECIS.Data.Models;
using TECIS.Data.ViewModels;
using TECIS.Web.Controllers;

namespace TECIS.Web.ActionFilters
{
    public class NotificationFilter : ActionFilterAttribute
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = filterContext.HttpContext.User.Identity.Name; //Identity.Name; GetUserId();

            var context = new TecIsEntities();
            var notifications = context.Notifications
                .Where(n => n.UserId == userId)
                .Where(n => !n.IsDismissed)
                .Where(n => n.NotificationType == 1)
                //.GroupBy(n => n.NOTIFICATIONTYPE)
                .Select(g => new NotificationViewModel
                {
                    Count = 0,
                    Title = g.Title,
                    SenderId = g.SenderId,
                    MsgBody = g.MsgBody,
                    IsDismissed = g.IsDismissed,
                    NotificationType = g.NotificationType,
                    NoteBadge = g.Notebadge,
                    Timestamp = g.NoteDate
                    //NotificationType = g.Key.ToString(),

                    //BadgeClass = NotificationType.Email == g.Key
                    //    ? "success"
                    //    : "info"
                }).ToList();
            var msgs = context.Notifications
               .Where(n => n.UserId == userId)
               .Where(n => n.NotificationType == 2)
                //.GroupBy(n => n.NOTIFICATIONTYPE)
               .Select(g => new NotificationViewModel
               {
                   Count = 0,
                   Title = g.Title,
                   SenderId = g.SenderId,
                   MsgBody = g.MsgBody,
                   IsDismissed = g.IsDismissed,
                   NotificationType = g.NotificationType,
                   NoteBadge = g.Notebadge,
                   Timestamp = g.NoteDate


               }).ToList();

            filterContext.Controller.ViewBag.Notifications = notifications;
            filterContext.Controller.ViewBag.Messages = msgs;
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {

                var user = UserManager.FindById(filterContext.HttpContext.User.Identity.GetUserId());
                if (user.Firstname != null)
                {
                    filterContext.Controller.ViewBag.userfirstname = user.Firstname;
                    filterContext.Controller.ViewBag.userlastname = user.Lastname;
                }
                var userRoles = UserManager.GetRoles(user.Id);
                filterContext.Controller.ViewBag.Rolename = userRoles[0];
                filterContext.Controller.ViewBag.TeamLeader = UsersAdminController.GetUserTeamLeader(filterContext.HttpContext.User.Identity.GetUserId());

            }


        }
        

    }
}