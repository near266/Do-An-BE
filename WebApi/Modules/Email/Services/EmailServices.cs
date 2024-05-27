using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using System.Net;
using WebApi.Application.Exceptions;
using WebApi.Modules.Email.Interface;
using WebApi.Wrappers.DTOS.EmailDtos;

namespace WebApi.Modules.Email.Services
{
    public class EmailServices : IEmailServices

    {
        public MailSettings _mailSettings { get; }
        public ILogger<EmailServices> _logger { get; }

        public EmailServices(IOptions<MailSettings> mailSettings, ILogger<EmailServices> logger)
        {
            _mailSettings = mailSettings.Value;
            _logger = logger;
        }
        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.Sender = new MailboxAddress(_mailSettings.DisplayName, request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);


            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        public async Task SendAsyncV2(EmailSend rq)
        {
            string fromMail = "thedotnetchannelsender22@gmail.com";
            string fromPassword = "lgioehkvchemfkrw";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = rq.Sub;
            message.To.Add(new MailAddress(rq.to));
            message.Body = rq.body;
            message.IsBodyHtml = true;

            var smtpClient = new System.Net.Mail.SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };

            smtpClient.Send(message);
        }
    }
}
