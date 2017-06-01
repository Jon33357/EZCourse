using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace MyEZCourse.Services
{
    public class Smtp
    {

        public void SendSingle(string subject, string htmlBody, string textBody, string toName, string toAddress, string fromName, string fromAddress)
        {
            using (var client = new SmtpClient())
            {
                client.Connect("imap.gmail.com");
                client.Authenticate("joao.caselli@lisbonworks.com", "Isel2008");
                var bodybuilder = new BodyBuilder();
                bodybuilder.HtmlBody = $"<p>{formData.Name} ({formData.Email})</p><p>{formData.Phone}</p><p>{formData.Message}</p>";
                bodybuilder.TextBody = "{ formData.Name} ({formData.Email})\r\n{formData.Phone}\r\n{formData.Message}";

                var message = new MimeMessage();
                message.Body = bodybuilder.ToMessageBody();
                message.From.Add(new MailboxAddress("RM", "joao.caselli@lisbonworks.com"));
                message.To.Add(new MailboxAddress("RM", "joaocaselli@hotmail.com"));
                message.Subject = "Contact Form";
                client.Send(message);
                client.Disconnect(true);

            }

        }

    }
}
