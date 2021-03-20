using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Infrastructure.EF;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Responses;
using Microsoft.Extensions.Logging;

namespace FishUp.Identity.Infrastructure
{
    public class IdentityUserService : IIdentityUserService
    {
        private readonly IdentityDbContext _identityDbContext;
        private readonly ILogger<IdentityUserService> _logger;

        public IdentityUserService(IdentityDbContext identityDbContext, ILogger<IdentityUserService> logger)
        {
            _identityDbContext = identityDbContext;
            _logger = logger;
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.Username, request.Email, request.Password, request.Password);
                await _identityDbContext.Users.AddAsync(user);
                await _identityDbContext.SaveChangesAsync();
                
                return new CreateUserResponse() 
                {
                    Created = true
                };
            }
            catch(Exception ex)
            {
                _logger.LogError($"Registration error: {ex.Message}");
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
    }
}