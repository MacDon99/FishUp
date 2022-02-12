using FishUp.Common.DTO;

namespace FishUp.Services
{
    public interface IJwtHandler
    {
        string BuildToken(string key, string audience, string issuer, int expirationTime, UserDTO user);
        bool IsTokenValid(string key, string issuer, string audience, string token);
    }
}