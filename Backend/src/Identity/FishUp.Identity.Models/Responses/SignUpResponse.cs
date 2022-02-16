using FishUp.Dispatchers;

namespace FishUp.Identity.Models.Responses
{
    public class SignUpResponse : ICommandResponse
    {
        public string Token { get; set; }
    }
}
