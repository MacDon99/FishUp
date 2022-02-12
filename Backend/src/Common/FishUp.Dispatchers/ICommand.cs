using MediatR;

namespace FishUp.Dispatchers
{
    public interface ICommand : IRequest
    {
        
    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}