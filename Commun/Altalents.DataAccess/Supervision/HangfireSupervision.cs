using Hangfire;

using Template.SupervisionMiddleware;

namespace Altalents.DataAccess.Supervision
{
    [Readiness]
    public class HangfireSupervision : IMonitoringElement
    {
        public string ServiceName => "Hangfire";

        public string ServiceCategoryCode => "Hangfire";

        public string Tips => "Contacter le support de niveau 2 pour analyser les erreurs Hangfire.";

        public double? MaxResponseTime => 100;

        public async Task<MonitoringCheckResult> Check()
        {
            return await Task.Run(() =>
            {
                long failedJobsCount = JobStorage.Current.GetMonitoringApi().FailedCount();

                if (failedJobsCount > 0)
                {
                    return new MonitoringCheckResult()
                    {
                        ResultDescription = $"Ko, il y a {failedJobsCount} job(s) en erreur",
                        Status = MonitoringCheckStatus.Unhealthy
                    };
                }

                return new MonitoringCheckResult()
                {
                    ResultDescription = "Ok",
                    Status = MonitoringCheckStatus.Healthy
                };
            });
        }
    }
}
