using FishUp.Dispatchers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FishUp.Mailing.Messages.Commands
{
    public record SendMessageCommand : ICommand
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}