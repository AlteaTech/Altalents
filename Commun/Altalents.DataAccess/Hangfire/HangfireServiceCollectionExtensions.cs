using Altalents.Commun.Constants;
using Altalents.Commun.Settings;

using Hangfire;

using Microsoft.Extensions.DependencyInjection;

namespace Altalents.DataAccess.Hangfire
{
    public static class HangfireServiceCollectionExtensions
    {
        public static void AddHangfire(
            this IServiceCollection services, string connectionString, HangfireSettings hangfireSettings)
        {

            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            if (hangfireSettings is null)
            {
                throw new ArgumentNullException(nameof(hangfireSettings));
            }

            services.AddHangfire(hangfireConfiguration => hangfireConfiguration
                   .UseFilter(new AutomaticRetryAttribute
                   {
                       Attempts = 3,
                       DelayInSecondsByAttemptFunc = (nbRetry) => (int)nbRetry * 20,
                       OnAttemptsExceeded = AttemptsExceededAction.Fail
                   })
                   .UseSimpleAssemblyNameTypeSerializer()
                   .UseRecommendedSerializerSettings()
                   .UseSqlServerStorage(connectionString));

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = hangfireSettings.WorkerCount;
                options.Queues = new[] { HangfireQueueConstants.Critical, HangfireQueueConstants.Default };
            });
        }
    }


}

