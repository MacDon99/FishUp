using FishUp.Dispatchers;
using FishUp.Identity.Models.Responses;
using System.ComponentModel.DataAnnotations;

namespace FishUp.Identity.Messages.Commands
{
    public class CreateUserCommand : ICommand<SignUpResponse>
    {
        public string? SecondName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}