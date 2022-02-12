using MediatR;

namespace FishUp.Dispatchers
{
    public interface IQueryHandler<TResponse> : IRequestHandler<IQuery<TResponse>, TResponse> where TResponse: IQueryResponse
    {
        
    }
}