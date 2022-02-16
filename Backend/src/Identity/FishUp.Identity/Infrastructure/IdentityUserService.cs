using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FishUp.Common.DTO;
using FishUp.Domain.Types;
using FishUp.Identity.Infrastructure.EF;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Models.Responses;
using FishUp.Identity.Responses;
using FishUp.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly IJwtHandler _jwtHandler;

        public IdentityUserService(IdentityDbContext identityDbContext, ILogger<IdentityUserService> logger,
            IConfiguration configuration, UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager,
            IJwtHandler jwtHandler)
        {
            _identityDbContext = identityDbContext;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<SignUpResponse> CreateUserAsync(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userManager.Users.AnyAsync(user =>
                user.NormalizedEmail == request.Email.ToUpper() || user.NormalizedUserName == request.Username.ToUpper(), cancellationToken))
            {
                throw new DomainException(ExceptionCode.InvalidValue, "User with given username or email already exist.");
            }
            var identityUser = new AppIdentityUser()
            {
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                UserName = request.Username,
                NormalizedUserName = request.Username.ToUpper()
            };

            var creationResult = await _userManager.CreateAsync(identityUser, request.Password);

            if (!creationResult.Succeeded)
            {
                throw new DomainException(ExceptionCode.InvalidValue, "Registration failed.");
            }

            await _identityDbContext.SaveChangesAsync(cancellationToken);

            var identityUserId = await _userManager.Users.Where(u => u.NormalizedEmail == request.Email.ToUpper())
                .Select(u => u.Id)
                .SingleAsync();

            var user = new User(request.FirstName, request.LastName, Guid.Parse(identityUserId), request.SecondName);

            await _identityDbContext.Users.AddAsync(user, cancellationToken);
            await _identityDbContext.SaveChangesAsync(cancellationToken);

            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expirationTime = _configuration["Jwt:ExpirationTime"];

            return new SignUpResponse()
            {
                Token = _jwtHandler.BuildToken(key, audience, issuer,
                    Convert.ToInt32(expirationTime), new UserDTO()
                    {
                        UserName = identityUser.UserName,
                        Role = "DefaultRole",
                        Id = identityUserId
                    })
            };
        }

        public async Task<SignInResponse> SignInAsync(SignInCommand request, CancellationToken cancellationToken)
        {
            if(request.Password != request.RepeatPassword)
            {
                throw new ValidationException(ExceptionCode.InvalidValue, "Password must be equal to repeat password");
            }

            var identityUser = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.NormalizedEmail == request.UsernameOrEmail.ToUpper() ||
                u.NormalizedUserName == request.UsernameOrEmail.ToUpper());

            if (identityUser is null)
            {
                throw new DomainException(ExceptionCode.NotExists, "User does not exist");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(identityUser, request.Password, true);

            if (!signInResult.Succeeded)
            {
                throw new DomainException(ExceptionCode.NotExists, "Authentication failed");
            }

            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expirationTime = _configuration["Jwt:ExpirationTime"];

            return new SignInResponse()
            {
                Token = _jwtHandler.BuildToken(key, audience, issuer,
                    Convert.ToInt32(expirationTime), new UserDTO()
                    {
                        UserName = identityUser.UserName,
                        Role = "DefaultRole",
                        Id = identityUser.Id
                    })
            };
        }
    }
}