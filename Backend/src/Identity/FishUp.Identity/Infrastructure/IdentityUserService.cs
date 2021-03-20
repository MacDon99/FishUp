using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FishUp.Domain.Types;
using FishUp.Identity.Infrastructure.EF;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FishUp.Identity.Infrastructure
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly IdentityDbContext _identityDbContext;
        private readonly ILogger<IdentityUserService> _logger;
        private readonly IConfiguration _configuration;

        public IdentityUserService(IdentityDbContext identityDbContext, ILogger<IdentityUserService> logger, IConfiguration configuration)
        {
            _identityDbContext = identityDbContext;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (await _identityDbContext.Users.AnyAsync(user => 
                        user.NormalizedEmail == request.Email.ToUpper() || user.NormalizedUsername == request.Username.ToUpper()))
                    {
                        return new CreateUserResponse() 
                        {
                            Created = false,
                            Errors = new List<string>()
                            {
                                "User already exists."
                            }
                        };
                    }

                    var (passwordHash, securityStamp) = GetPasswordHashAndSecurityStamp(request.Password);

                    var user = new User(request.Username, request.Email, passwordHash, securityStamp);

                    await _identityDbContext.Users.AddAsync(user);
                    await _identityDbContext.SaveChangesAsync();

                    transaction.Complete();
                    
                    return new CreateUserResponse() 
                    {
                        Created = true
                    };
                }
                catch(Exception ex)
                {
                    _logger.LogError($"Registration error: {ex.Message}");
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            return new CreateUserResponse()
            {
                Created = false,
                Errors = new List<string>()
                    {
                        "An error occured while registering user."
                    }
            };
        }

        private (byte[], byte[]) GetPasswordHashAndSecurityStamp(string password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.ASCII.GetBytes(_configuration.GetSection("Security:Salt").Value)))
            {
                var passwordInBytes = Encoding.UTF8.GetBytes(password);
                var hashedPassword = hmac.ComputeHash(passwordInBytes);
                byte[] key;
                
                using(var secondHmac = new System.Security.Cryptography.HMACSHA512())
                {
                    hashedPassword = secondHmac.ComputeHash(hashedPassword);
                    key = secondHmac.Key;
                };

                return (hashedPassword, key);
            };
        }
    }
}