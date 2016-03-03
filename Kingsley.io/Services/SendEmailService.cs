using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace Kingsley.io.Services
{
    public class SendEmailService
    {
        public SendEmailService()
        {

        }
        public void SendOneEmail(string from, string toAddress, string subject, string body, bool isHTML)
        {
            string smtpServer = WebConfigurationManager.AppSettings["SMTPServer"];
            string userName = WebConfigurationManager.AppSettings["MailUsername"];
            string password = WebConfigurationManager.AppSettings["MailPassword"];
            string email = WebConfigurationManager.AppSettings["MailEmail"];

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient(smtpServer, 25);
            smtpClient.Credentials = new NetworkCredential(userName, password);

            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(toAddress));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isHTML;

            smtpClient.Send(mail);
        }
    }
}