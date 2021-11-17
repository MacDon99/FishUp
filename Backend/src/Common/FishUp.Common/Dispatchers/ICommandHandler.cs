using MediatR;

namespace FishUp.Common.Dispatchers
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest: ICommand
    {
        
    }
}