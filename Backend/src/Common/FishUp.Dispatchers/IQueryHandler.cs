using MediatR;

namespace FishUp.Dispatchers
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TResponse: IQueryResponse
        where TRequest: IQuery<TResponse>
    {
        
    }
}