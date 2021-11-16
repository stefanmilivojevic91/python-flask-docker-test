using Boundary.Core;
using MediatR;
using System;

namespace Boundary.Context.Property
{
    public record CreatePropertyAdCommand :
        ICommand<Unit>
    {
        public Guid UserId { get; init; }
        public string Title { get; init; }
    }
}
