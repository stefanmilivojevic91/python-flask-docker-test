using Microsoft.Extensions.DependencyInjection;

namespace Application.Base
{
    public interface IComponent
    {
        void AddServices(IServiceCollection services);
    }
}
