using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailsettings;

        public EmailSender(EmailSettings emailConfig)
        {
            _emailsettings = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {
            var mailMessage = CreateEmailMessage(message);

            await SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailsettings.Sender));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<div>{0}</div>", message.Content) };

            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();   
            try
            {
                client.Connect(_emailsettings.MailServer, _emailsettings.MailPort, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailsettings.SenderName, _emailsettings.Password);

                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
            }
        }

        private async Task SendAsync(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();           
            try
            {
                await client.ConnectAsync(_emailsettings.MailServer, _emailsettings.MailPort, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(_emailsettings.SenderName, _emailsettings.Password);

                await client.SendAsync(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception, or both.
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
           
        }
    }
}
