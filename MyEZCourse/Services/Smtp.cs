using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;

namespace MyEZCourse.Services
{
    public class Smtp
    {
        readonly SmtpOptions _smtpOptions;


        public Smtp(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions.Value;
        }

        public void SendSingle(string subject, string htmlBody, string textBody, string toName, string toAddress, string fromName, string fromAddress)
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_smtpOptions.SmtpAddress);
                client.Authenticate(_smtpOptions.SmtpUsername, _smtpOptions.SmtpPassword);
                var bodybuilder = new BodyBuilder();
                bodybuilder.HtmlBody = htmlBody;
                bodybuilder.TextBody = textBody;

                var message = new MimeMessage();
                message.Body = bodybuilder.ToMessageBody();
                message.From.Add(new MailboxAddress(fromName, fromAddress));
                message.To.Add(new MailboxAddress(toName, toAddress));
                message.Subject = "Contact Form";
                client.Send(message);
                client.Disconnect(true);

            }

        }

    }
}
