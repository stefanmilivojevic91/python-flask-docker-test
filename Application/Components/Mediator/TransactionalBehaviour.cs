using Boundary.Core;
using Domain.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Components.Mediator
{
    public class TransactionalBehaviour<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TransactionalBehaviour(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var isCommand = typeof(ICommand<TResponse>).IsAssignableFrom(typeof(TRequest));
            if(!isCommand)
            {
                return await next();
            }

            try
            {
                _unitOfWork.Begin();
                var response = await next();
                await _unitOfWork.Complete(cancellationToken);
                return response;
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
