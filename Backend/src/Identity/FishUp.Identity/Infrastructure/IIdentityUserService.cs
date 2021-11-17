using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Responses;
using MediatR;

namespace FishUp.Identity.Infrastructure
{
    public interface IIdentityUserService
    {
        Task<Unit> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken); 
        Task<SignInResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken);  
    }
}