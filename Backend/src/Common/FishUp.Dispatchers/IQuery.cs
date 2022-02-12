using MediatR;

namespace FishUp.Dispatchers
{
    public interface IQuery<QueryResponse> : IRequest<QueryResponse>
    {
        
    }
}