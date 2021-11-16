using Application.Base;
using Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using System;

namespace Application.Components.Web
{
    public class PersistenceComponent :
        IComponent
    {
        private const string CONNECTION_STRING_NAME = "ApplicationDatabase";

        public void AddServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(WithDbContextConfiguration);
            services.AddScoped<IApplicationUnitOfWork, UnitOfWork>();
        }

        private static void WithDbContextConfiguration(IServiceProvider provider, DbContextOptionsBuilder builder)
        {
            var configurationProvider = provider.GetRequiredService<IConfiguration>();
            var connectionString = configurationProvider.GetConnectionString(CONNECTION_STRING_NAME);
            builder.UseNpgsql(connectionString);
        }
    }
}
