namespace Altalents.Business.Services
{
    public class JobService : BaseAppService<CustomDbContext>, IJobService
    {
        public JobService(
            ILogger<JobService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
        }

        public void PurgeTrigrammeLocks()
        {
            DateTime dateLimite = DateTime.UtcNow.AddDays(-1);
            DbContext.TrigrammeLocks.Where(x => x.DateLock <= dateLimite).ExecuteDelete();
        }
    }
}
