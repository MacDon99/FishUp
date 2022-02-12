using FishUp.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace FishUp.Domain.Types
{
    public class BaseController : ControllerBase
    {
        private string Token { get => HttpContext.Request.Headers["Authorization"]; }
        private JwtSecurityToken DecodedToken { get => new JwtSecurityTokenHandler().ReadJwtToken(Token); }
        public Guid UserId { get => DecodedToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value.ToGuid(); }
        public string UserName { get => DecodedToken.Claims.First(claim => claim.Type == ClaimTypes.Name).Value; }
        public string Role { get => DecodedToken.Claims.First(claim => claim.Type == ClaimTypes.Role).Value; }
    }
}
