using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SMSServiceApi;
using System.Diagnostics;
using System.Configuration;

namespace TECIS.Web.Helpers.CrossCutting.SMSService
{
    public class SMSLive247Service
    {
        public async Task SendSMSAsync(String[] recipients, string shortmessage, bool SendConfirmation)
        {
            var myMessage = new MessageInfo();
            myMessage.Destination = recipients;

            myMessage.MessageType = SMSTypeEnum.TEXT;
            myMessage.Message = shortmessage;

            //.From = new System.Net.Mail.MailAddress(
            //    ConfigurationManager.AppSettings["mailSender"],
            //           ConfigurationManager.AppSettings["maildisplayName"]);


            var callback = ConfigurationManager.AppSettings["SMSSender"];
            var apiKey = ConfigurationManager.AppSettings["SMSAPIKey"];
            // Create a Web transport for sending email.
            //var transportWeb = new SendGrid.Web(credentials);
            SMSSiteAdminClient client = new SMSSiteAdminClient();
            if (callback != null)
            {
                myMessage.CallBack = callback;
            }

                // Send the email.
            if (apiKey != null)
            {
                ResponseInfo transportWeb = await client.SendSMSAsync(apiKey, myMessage);
                //await transportWeb.DeliverAsync(myMessage);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}