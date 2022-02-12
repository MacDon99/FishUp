using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FishUp.Dispatchers
{
    public static class DispatchersRegistration
    {
        public static void RegisterMediatR(this IServiceCollection services, Type startupType)
        {
            services.AddMediatR(
                startupType,
                typeof(ICommandHandler<ICommand>),
                typeof(IQueryHandler<IQuery<IQueryResponse>, IQueryResponse>),
                typeof(ICommandHandler<ICommand<ICommandResponse>, ICommandResponse>));
        }
    }
}
