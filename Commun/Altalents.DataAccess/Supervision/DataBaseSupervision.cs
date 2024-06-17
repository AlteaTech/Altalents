using Microsoft.Extensions.DependencyInjection;

using Template.SupervisionMiddleware;

namespace Altalents.DataAccess.Supervision
{
    [Readiness(IsSuccessRequired = true, IsAlwaysChecked = true)]
    public class DataBaseSupervision : IMonitoringElement
    {
        private readonly IServiceProvider _serviceProvider;

        public DataBaseSupervision(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string ServiceName => "DataBase";

        public string ServiceCategoryCode => "DataBase";

        public string Tips => "Erreurs de la DataBase.";

        public double? MaxResponseTime => 100;

        public async Task<MonitoringCheckResult> Check()
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                CustomDbContext dbContext = scope.ServiceProvider.GetService<CustomDbContext>();
                return await Task.Run(() =>
                {
                    bool requestFailed = dbContext.Utilisateurs.Any();

                    return new MonitoringCheckResult()
                    {
                        ResultDescription = requestFailed ? "Ok" : "Ko",
                        Status = requestFailed ? MonitoringCheckStatus.Healthy : MonitoringCheckStatus.Degraded
                    };
                });
            }
        }
    }
}
