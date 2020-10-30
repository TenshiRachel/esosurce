using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GemBox.Email;
using GemBox.Email.Smtp;

namespace Esource.Utilities
{
    public static class Email
    {
        public static void Send(string senderEmail, string receiverEmail, string subject, string body)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            MailMessage mailMessage = new MailMessage(
                new MailAddress(senderEmail, "Sender"),
                new MailAddress(receiverEmail, "First receiver"));

            mailMessage.Subject = subject;
            mailMessage.BodyHtml = body;

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.Connect();
                smtp.Authenticate("<USERNAME>", "<PASSWORD>");
                smtp.SendMessage(mailMessage);
            }
        }
    }
}