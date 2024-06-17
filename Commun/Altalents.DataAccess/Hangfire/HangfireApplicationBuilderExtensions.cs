using AlteaTools.Hangfire;

using Hangfire;

using Microsoft.AspNetCore.Builder;

namespace Altalents.DataAccess.Hangfire
{
    public static class HangfireApplicationBuilderExtensions
    {

        public static IApplicationBuilder AddHangfireDashboard(
            this IApplicationBuilder app)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            DashboardOptions dashboardOptions = new DashboardOptions
            {
                Authorization = new[] { new HangfireAuthorizationFilter() },
                IgnoreAntiforgeryToken = true,
            };

            return app;
        }
    }
}
