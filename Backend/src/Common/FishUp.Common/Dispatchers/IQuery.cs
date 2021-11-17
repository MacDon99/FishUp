using MediatR;

namespace FishUp.Common.Dispatchers
{
    public interface IQuery<QueryResponse> : IRequest<QueryResponse>
    {
        
    }
}