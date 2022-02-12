using FishUp.Dispatchers;
using FishUp.Identity.Responses;
using System.ComponentModel.DataAnnotations;

namespace FishUp.Identity.Messages.Commands
{
    public class SignInCommand : ICommand<SignInResponse>
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
    }
}