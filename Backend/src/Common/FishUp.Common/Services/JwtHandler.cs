using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FishUp.Common.DTO;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace FishUp.Common.Services
{
public class JwtHandler : IJwtHandler
    {
        public string BuildToken(string key, string audience, string issuer, int expirationTime, UserDTO user)
        {            
            var claims = new[] {    
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.NameIdentifier,
                    Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));        
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);           
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims, 
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(expirationTime)), signingCredentials: credentials);        
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);  
        }

        public bool IsTokenValid(string key, string issuer, string audience, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);           
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler(); 
            try 
            {
                tokenHandler.ValidateToken(token, 
                new TokenValidationParameters   
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true, 
                    ValidateAudience = true,    
                    ValidIssuer = issuer,
                    ValidAudience = audience, 
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);            
            }
            catch
            {
                return false;
            }
            return true;    
        }
    }
}