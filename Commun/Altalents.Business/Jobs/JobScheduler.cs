using Hangfire;
using Hangfire.Server;

namespace Altalents.Business.Jobs
{
    public static class JobScheduler
    {
        /// <summary>
        /// ScheduleRecurringJobs
        /// </summary>
        public static void ScheduleRecurringJobs(string name)
        {
            RecurringJob.AddOrUpdate<IJobService>(name + "PurgeTrigrammeLocks", job => job.PurgeTrigrammeLocks(), Cron.Daily);
        }
    }
}
