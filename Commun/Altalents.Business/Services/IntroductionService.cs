namespace Altalents.Business.Services
{
    public partial class IntroductionService : BaseAppService<CustomDbContext>, IIntroductionService
    {
        public IntroductionService(
            ILogger<IntroductionService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
        }

        public async Task DeleteIntroductionAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Introduction>.CheckIdExistAsync(DbContext.Introductions, id, cancellationToken);
            Introduction introduction = await DbContext.Introductions.AsTracking()
                                                                     .SingleAsync(x => x.Id == id, cancellationToken);

            DbContext.Introductions.Remove(introduction);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<IntroductionDto> GetIntroductionByIdAsync(Guid introductionId, CancellationToken cancellationToken = default)
        {
            return await DbContext.Introductions.ProjectTo<IntroductionDto>(Mapper.ConfigurationProvider)
                                                .SingleAsync(x => x.Id == introductionId, cancellationToken);
        }

        public async Task<List<IntroductionDto>> GetIntroductionsAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.Introductions.ProjectTo<IntroductionDto>(Mapper.ConfigurationProvider)
                                                .OrderBy(x => x.OrdreFr)
                                                .ToListAsync(cancellationToken);
        }

        public async Task<Guid> InsertIntroductionAsync(IntroductionDto introduction, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(introduction.TitreFr)
                || string.IsNullOrWhiteSpace(introduction.TitreEn))
            {
                throw new BusinessException(BusinessExceptionsResources.TITRES_INTRODUCTION_REQUIRED);
            }

            if (introduction.OrdreFr < 1
                || introduction.OrdreEn < 1)
            {
                throw new BusinessException(BusinessExceptionsResources.ORDRES_INTRODUCTION_REQUIRED);
            }

            Introduction nouvelleIntroduction = Mapper.Map<Introduction>(introduction);
            await DbContext.Introductions.AddAsync(nouvelleIntroduction, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return nouvelleIntroduction.Id;
        }

        public async Task UpdateIntroductionAsync(IntroductionDto introductionModifiee, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Introduction>.CheckIdExistAsync(DbContext.Introductions, introductionModifiee.Id, cancellationToken);
            Introduction introduction = await DbContext.Introductions.AsTracking()
                                                                     .SingleAsync(x => x.Id == introductionModifiee.Id, cancellationToken);

            introduction.OrdreFr = introductionModifiee.OrdreFr;
            introduction.OrdreEn = introductionModifiee.OrdreEn;
            introduction.TitreFr = introductionModifiee.TitreFr;
            introduction.DetailFr = introductionModifiee.DetailFr;
            introduction.TitreEn = introductionModifiee.TitreEn;
            introduction.DetailEn = introductionModifiee.DetailEn;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }
    }
}
