using MediatR;

namespace Boundary.Core
{
    public interface IQuery<TResponse> :
        IRequest<TResponse>
    {
    }
}
