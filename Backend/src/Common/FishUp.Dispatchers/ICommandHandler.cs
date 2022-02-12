using MediatR;

namespace FishUp.Dispatchers
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest> where TRequest: ICommand
    {
        
    }
}