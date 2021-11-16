using Application.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Application.Components.Documentation
{
    public class SwaggerComponent :
        IComponent
    {
        public void AddServices(IServiceCollection services)
        {
            services.AddSwaggerGen(WithSwaggerGenOptions);
        }

        private static void WithSwaggerGenOptions(SwaggerGenOptions entry)
        {
            entry.SwaggerDoc("v1", new OpenApiInfo { Title = "Application", Version = "v1" });
        }
    }
}
