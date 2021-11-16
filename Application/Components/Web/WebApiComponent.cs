using Application.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Components.Web
{
    public class WebApiComponent :
        IComponent
    {
        public void AddServices(IServiceCollection services)
        {
            services.ConfigureOptions<RouteOptionsConfigurator>();
            services.AddRouting()
                .AddControllers();
        }
    }
}
