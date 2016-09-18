using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TECIS.Web.Helpers.CrossCutting.SendGridEmailService
{
    public class SendGridEmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        private async Task configSendGridasync(IdentityMessage message)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new System.Net.Mail.MailAddress(
                ConfigurationManager.AppSettings["mailSender"],
                       ConfigurationManager.AppSettings["maildisplayName"]);
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );

            // Create a Web transport for sending email.
            var transportWeb = new SendGrid.Web(credentials);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }

        public async Task SendGridMail(MailMessage message, string attachment)
        {
            var myMessage = new SendGridMessage();
            foreach (var item in message.To)
            {
                myMessage.AddTo(item.Address);
            }            
            myMessage.From = new System.Net.Mail.MailAddress(
                ConfigurationManager.AppSettings["mailSender"],
                       ConfigurationManager.AppSettings["maildisplayName"]);
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;
            myMessage.Html = message.Body;

            var credentials = new NetworkCredential(
                       ConfigurationManager.AppSettings["mailAccount"],
                       ConfigurationManager.AppSettings["mailPassword"]
                       );
            var apiKey = ConfigurationManager.AppSettings["mailAPIKEY"];
            myMessage.AddAttachment(attachment);
            // Create a Web transport for sending email.
            //var transportWeb = new SendGrid.Web(credentials);
            var transportWeb = new SendGrid.Web(apiKey);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }

        //private void sendMail(System.Net.Mail.MailMessage message)
        //{
        //    #region formatter
        //    string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
        //    string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

        //    html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
        //    #endregion

        //    MailMessage msg = new MailMessage();
        //    msg.From = new MailAddress("joe@contoso.com");
        //    msg.To.Add(new MailAddress(message.Destination));
        //    msg.Subject = message.Subject;
        //    msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
        //    msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

        //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
        //    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("joe@contoso.com", "XXXXXX");
        //    smtpClient.Credentials = credentials;
        //    smtpClient.EnableSsl = true;
        //    smtpClient.Send(msg);
        //}
    }
}