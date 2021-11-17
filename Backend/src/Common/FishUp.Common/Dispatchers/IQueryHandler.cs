using MediatR;

namespace FishUp.Common.Dispatchers
{
    public interface IQueryHandler<TResponse> : IRequestHandler<IQuery<TResponse>, TResponse> where TResponse: IQueryResponse
    {
        
    }
}