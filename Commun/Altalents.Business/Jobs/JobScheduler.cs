using Hangfire;

namespace Altalents.Business.Jobs
{
    public static class JobScheduler
    {
        /// <summary>
        /// ScheduleRecurringJobs
        /// </summary>
        public static void ScheduleRecurringJobs(string name)
        {
            RecurringJob.AddOrUpdate<IMarqueService>(name+ "PurgeMarquesRenvoisTemporaires", job => job.PurgeMarquesRenvoisTemporaires(), Cron.Daily);
            RecurringJob.AddOrUpdate<IMarqueService>(name + "RepriseDeDonneesReferenceLugtLightEtNoticesTextesBruts", job => job.RepriseDeDonneesReferenceLugtLightEtNoticesTextesBruts(), Cron.Never);
            RecurringJob.AddOrUpdate<IMarqueService>(name + "RepriseDeDonneesReferencSousRef", job => job.RepriseDeDonneesReferenceSousRefTransliteration(), Cron.Never);
            RecurringJob.AddOrUpdate<IMarqueService>(name + "RepriseDeDonneesReferenceLibreMarquesTransliteration", job => job.RepriseDeDonneesReferenceLibreMarquesTransliteration(), Cron.Never);
            RecurringJob.AddOrUpdate<IMarqueService>(name + "RepriseDeDonneesInitialesMarquesTransliteration", job => job.RepriseDeDonneesInitialesMarquesTransliteration(), Cron.Never);
            RecurringJob.AddOrUpdate<IMarqueService>(name + "RepriseDeDonneesInitiales", job => job.RepriseDeDonneesInitiales(), Cron.Never);
            RecurringJob.AddOrUpdate<IJobService>(name + "IntegrationBdd", job => job.IntegrationBdd(), Cron.Never);
        }
    }
}
