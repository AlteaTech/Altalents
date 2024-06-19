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
    }
}
