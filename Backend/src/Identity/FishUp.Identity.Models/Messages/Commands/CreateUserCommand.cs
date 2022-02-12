using FishUp.Dispatchers;
using System.ComponentModel.DataAnnotations;

namespace FishUp.Identity.Messages.Commands
{
    public class CreateUserCommand : ICommand
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}