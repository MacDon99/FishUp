using FishUp.Dispatchers;

namespace FishUp.Identity.Responses
{
    public class SignInResponse : ICommandResponse
    {
        public string Token { get; set; }
    }
}