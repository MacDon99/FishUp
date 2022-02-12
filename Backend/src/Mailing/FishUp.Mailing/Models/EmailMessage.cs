using FishUp.Domain;
using FishUp.Domain.Types;
using FishUp.Mailing.Messages.Commands;
using System.Collections.Generic;

namespace FishUp.Mailing.Models
{
    public class EmailMessage : Entity
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }

        protected EmailMessage()
        {

        }

        public EmailMessage(SendMessageCommand msg, IEnumerable<Attachment> attachments)
        {
            To = msg.To;
            From = msg.From;
            Subject = msg.Subject;
            Content = msg.Content;
            Attachments = attachments;

            Valid();
        }

        public override void Valid()
        {
            if (string.IsNullOrEmpty(To))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(To));
            }
            
            if (string.IsNullOrEmpty(From))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(From));
            }

            if (string.IsNullOrEmpty(Subject))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(Subject));
            }

            if (string.IsNullOrEmpty(Content))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(Content));
            }
        }
    }
}
