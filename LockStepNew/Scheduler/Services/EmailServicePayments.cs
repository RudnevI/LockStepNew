using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;


namespace LockStepNew.Scheduler.Services
{
    public class EmailServicePayments
    {

        public EmailServicePayments() { }

        public void Send(string to, string subject, string body)
        {
            var mm = new MailMessage
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure,
                From = new MailAddress("admin@books.kz")


            };

           
            

            mm.To.Add(new MailAddress(to));
            new SmtpClient
            {
                Port = 25,
                Host = "mail.books.kz",
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("admin@books.kz", "password")
            }
            .Send(mm);

       
        }
    }
}