using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Models.Responses;
using FishUp.Identity.Responses;
using MediatR;

namespace FishUp.Identity.Infrastructure
{
    public interface IIdentityUserService
    {
        Task<SignUpResponse> CreateUserAsync(CreateUserCommand request, CancellationToken cancellationToken); 
        Task<SignInResponse> SignInAsync(SignInCommand request, CancellationToken cancellationToken);  
    }
}