using FishUp.Dispatchers;
using FishUp.Domain.Types;
using FishUp.Mailing.Messages.Commands;
using FishUp.Mailing.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Attachment = System.Net.Mail.Attachment;

namespace FishUp.Mailing.Handlers
{
    public class SendMessageCommandHandler : ICommandHandler<SendMessageCommand>
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly SmtpClient _smtpClient;
        private readonly ILogger<SendMessageCommandHandler> _logger;

        public SendMessageCommandHandler(EmailConfiguration emailConfig, ILogger<SendMessageCommandHandler> logger)
        {
            _emailConfig = emailConfig;
            _logger = logger;
        }
        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var mailMessage = CreateEmailMessage(request);

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Port = _emailConfig.Port;
                    client.Host = _emailConfig.SmtpServer;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    await client.SendMailAsync(mailMessage);
                }
                catch(SmtpException ex)
                {
                    _logger.LogError("Failed to send an email due to error: ", ex.Message);
                    _logger.LogDebug($"Given params: Subject: {mailMessage.Subject}, From: {mailMessage.From}, To: {mailMessage.To}, Host: {client.Host}, " +
                        $"Port: {client.Port }");
                    throw new MailingException(ExceptionCode.ExternalServiceError, ex.Message);
                }
                finally
                {
                    client.Dispose();
                }
            }
            return Unit.Value;
        }
        private MailMessage CreateEmailMessage(SendMessageCommand message)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.From, message.Subject);
            mailMessage.To.Add(new MailAddress(message.To));
            mailMessage.Subject = message.Subject;
            mailMessage.ReplyToList.Add(new MailAddress(message.From));
            if (message.Attachments != null)
            {
                foreach (var file in message.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            Attachment att = new Attachment(new MemoryStream(fileBytes), file.FileName);
                            mailMessage.Attachments.Add(att);
                        }
                    }
                }
            }
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = message.Content;
            return mailMessage;
        }
    }
}