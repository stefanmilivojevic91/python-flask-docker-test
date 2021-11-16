using Application.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Components.Mediator
{
    public class MediatrComponent :
        IComponent
    {
        public void AddServices(IServiceCollection services)
        {
            var scanningAssemblies = new[]
            {
                typeof(Business.AssemblyReference).Assembly
            };

            services.AddMediatR(scanningAssemblies);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionalBehaviour<,>));
        }
    }
}
