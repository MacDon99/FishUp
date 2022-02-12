using FishUp.Domain;
using FishUp.Domain.Types;
using System;

namespace FishUp.Mailing.Models
{
    public class Attachment : Entity
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public string FileName { get; set; }

        public Attachment(Guid fileId, string fileName)
        {
            FileId = fileId;
            FileName = fileName;

            Valid();
        }

        public override void Valid()
        {
            if (Id == Guid.Empty)
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(FileName));
            }

            if (FileId == Guid.Empty)
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(FileId));
            }

            if (string.IsNullOrEmpty(FileName))
            {
                throw new DomainException(ExceptionCode.CanNotBeNull, nameof(FileName));
            }
        }
    }
}
