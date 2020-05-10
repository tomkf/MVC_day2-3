using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace portfolio_mvc.Models
{
    public class EmailHelper
    {
        private EmailSettings _eSettings;
        public EmailHelper(EmailSettings _eSettings)
        {
            this._eSettings = _eSettings;
        }

        public bool SendMail(string recipient, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_eSettings.FromEmail, _eSettings.DisplayName)
                };

                string toEmail = string.IsNullOrEmpty(recipient)
                                 ? _eSettings.ToEmail : recipient;

                mail.To.Add(new MailAddress(toEmail));

                foreach (string bcc in _eSettings.BccEmails)
            {
                    mail.Bcc.Add(new MailAddress(bcc));
                }

                // Subject and multipart/alternative Body
                mail.Subject = subject;

                string text = "Plain text version of a message body. ";
                string html = @"<p>HTML version of a message body. </p>";

                mail.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(text,
                        null, MediaTypeNames.Text.Plain));
                mail.AlternateViews.Add(
                        AlternateView.CreateAlternateViewFromString(html,
                        null, MediaTypeNames.Text.Html));

                //optional priority setting
                mail.Priority = MailPriority.High;

                // you can add attachments
                //mail.Attachments.Add(new Attachment(@"C:\mind.gif"));

                // Init SmtpClient and send
                SmtpClient smtp = new SmtpClient(_eSettings.Domain, _eSettings.Port);
                smtp.Credentials = new NetworkCredential(_eSettings.UsernameLogin, _eSettings.UsernamePassword);
                smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }

}
