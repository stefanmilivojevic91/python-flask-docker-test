using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Application.Components.Web
{
    public class RouteOptionsConfigurator :
        IConfigureOptions<RouteOptions>
    {
        public void Configure(RouteOptions options)
        {
            options.LowercaseUrls = true;
        }
    }
}
