using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Processors.Services
{
    public class EmailService
    {
        public static void SendEmail( string receipientName, string receiptientEmail, string Subject, string message)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress("UMaT SPS", "akwofie1@umat.edu.gh"));
            email.To.Add(new MailboxAddress(receipientName, receiptientEmail));

            email.Subject = Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var smtp = new SmtpClient())
            {
                //smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("akwofie1@umat.edu.gh", "14030415");

                smtp.Send(email);
                smtp.Disconnect(true);
            }

        }
    }
}
