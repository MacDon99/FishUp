using FishUp.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace FishUp.Domain.Types
{
    public class BaseController : ControllerBase
    {
        private string GetToken() => HttpContext.Request.Headers["Authorization"]
            .ToString()
            .Replace("{", string.Empty)
            .Replace("}", string.Empty)
            .Replace("Bearer ", string.Empty);
        private JwtSecurityToken GetDecodedToken() => new JwtSecurityTokenHandler().ReadJwtToken(GetToken());
        protected Guid GetUserId() => GetDecodedToken().Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value.ToGuid();
        protected string GetUserName() => GetDecodedToken().Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        protected string GetRole() => GetDecodedToken().Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
    }
}
