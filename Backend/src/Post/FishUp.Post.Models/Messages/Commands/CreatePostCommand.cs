using System.ComponentModel.DataAnnotations;
using FishUp.Dispatchers;
using Microsoft.AspNetCore.Http;

namespace FishUp.Post.Models.Messages.Commands
{
    public record CreatePostCommand : ICommand
    {
        [Required]
        public string Message { get; set; }
        public Guid AuthorId { get; set; }
        public IEnumerable<IFormFile> Photos { get; set; }
    }
}