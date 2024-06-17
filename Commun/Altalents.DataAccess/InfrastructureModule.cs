using Altalents.DataAccess.Supervision;

using Microsoft.Extensions.DependencyInjection;

using Template.SupervisionMiddleware;

namespace Altalents.DataAccess
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString,
            Dictionary<string, string> apiExternesRoutes)
        {
            services.AddDbContext<CustomDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
#if DEBUG
                x.EnableSensitiveDataLogging();
#endif
            });

            services.AddScoped<IMonitoringElement, DataBaseSupervision>();

            return services;
        }
    }
}
