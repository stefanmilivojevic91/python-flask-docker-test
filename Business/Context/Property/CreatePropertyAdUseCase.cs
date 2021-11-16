using Boundary.Context.Property;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Context.Property
{
    public class CreatePropertyAdUseCase :
        IRequestHandler<CreatePropertyAdCommand, Unit>
    {
        public Task<Unit> Handle(CreatePropertyAdCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
