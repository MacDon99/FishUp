using System.ComponentModel.DataAnnotations;

namespace FishUp.Identity.Messages.Commands
{
    public class CreateUserRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}