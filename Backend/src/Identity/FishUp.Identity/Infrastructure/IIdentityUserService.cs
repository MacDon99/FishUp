using System.Threading;
using System.Threading.Tasks;
using FishUp.Identity.Messages.Commands;
using FishUp.Identity.Responses;

namespace FishUp.Identity.Infrastructure
{
    public interface IIdentityUserService
    {
        Task<CreateUserResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken); 
        Task<SignInResponse> SignInAsync(SignInRequest request, CancellationToken cancellationToken);  
    }
}