using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_app_consoleApp.Services;

namespace Test_app_consoleApp
{
    public class MailService
    {
        private readonly string from = ConfigurationDataService.Instance.Data.mailFromAddress;
        private readonly string password = ConfigurationDataService.Instance.Data.smtpHostPassword;

        private static MailService _instance;
        private MailService() { }
        public static MailService Instance => _instance ?? (_instance = new MailService());


        public void SendMessage(string to, string subject, string bodyText)
        {
            MimeMessage message = new();
            message.From.Add(new MailboxAddress(from));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = bodyText };

            using var client = new SmtpClient();
            //Demo no validation
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("testcnpck", password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
