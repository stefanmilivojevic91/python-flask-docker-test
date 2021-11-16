using MediatR;

namespace Boundary.Core
{
    public interface ICommand<TResponse> :
        IRequest<TResponse>
    {
    }
}
