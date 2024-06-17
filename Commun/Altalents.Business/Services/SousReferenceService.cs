using AnyAscii;

namespace Altalents.Business.Services
{
    public partial class SousReferenceService : BaseAppService<CustomDbContext>, ISousReferenceService
    {
        public SousReferenceService(
            ILogger<SousReferenceService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
        }

        public async Task DeleteSousReferenceAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<SousReference>.CheckIdExistAsync(DbContext.SousReferences, id, cancellationToken);
            SousReference sousReference = await DbContext.SousReferences.SingleAsync(x => x.Id == id, cancellationToken);
            DbContext.SousReferences.Remove(sousReference);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<IQueryable<SousReferenceDto>> GetSousReferencesByReferenceIdAsync(Guid referenceId, CancellationToken cancellationToken = default)
        {
            if (!await DbContext.References.Where(w => w.Id == referenceId).AnyAsync(cancellationToken))
            {
                throw new BusinessException(BusinessExceptionsResources.REFERENCE_INCONNUE);
            }

            return DbContext.SousReferences
                .Where(w => w.Reference.Id == referenceId)
                .OrderBy(x => x.OrdreFr)
                .ProjectTo<SousReferenceDto>(Mapper.ConfigurationProvider);
        }

        public async Task<Guid> InsertSousReferenceAsync(SousReferenceDto sousReference, CancellationToken cancellationToken = default)
        {
            await CheckLibelleFrExistForReferenceIdAsync(sousReference.LibelleFr, sousReference.ReferenceId, cancellationToken: cancellationToken);
            SousReference nouvelleSousReference = Mapper.Map<SousReference>(sousReference);

            await DbContext.SousReferences.AddAsync(nouvelleSousReference, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return nouvelleSousReference.Id;
        }

        public async Task UpdateSousReferenceAsync(SousReferenceDto sousReferenceModifie, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<SousReference>.CheckIdExistAsync(DbContext.SousReferences, sousReferenceModifie.SousReferenceId, cancellationToken);
            await CheckLibelleFrExistForReferenceIdAsync(sousReferenceModifie.LibelleFr, sousReferenceModifie.ReferenceId, sousReferenceModifie.SousReferenceId, cancellationToken);

            SousReference sousReference = await DbContext.SousReferences.AsTracking().SingleAsync(x => x.Id == sousReferenceModifie.SousReferenceId, cancellationToken);
            sousReference.Libelle2 = sousReferenceModifie.Libelle2;
            sousReference.LibelleFr = sousReferenceModifie.LibelleFr;
            sousReference.LibelleTransLitLower2 = sousReferenceModifie.Libelle2?.Transliterate()?.ToLower();
            sousReference.LibelleTransLitLowerFr = sousReferenceModifie.LibelleFr?.Transliterate()?.ToLower();
            sousReference.Ordre2 = sousReferenceModifie.Ordre2;
            sousReference.OrdreFr = sousReferenceModifie.OrdreFr;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private async Task CheckLibelleFrExistForReferenceIdAsync(string libelleFr, Guid referenceId, Guid? idExclu = null, CancellationToken cancellationToken = default)
        {
            IQueryable<SousReference> queryable = DbContext.SousReferences.AsQueryable();
            if (idExclu.HasValue)
            {
                queryable = queryable.Where(x => x.Id != idExclu);
            }

            if (await queryable.AnyAsync(x => x.ReferenceId == referenceId && x.LibelleFr == libelleFr, cancellationToken))
            {
                throw new BusinessException($"Le mot-clé '{libelleFr}' existe déjà pour le mot-clé parent.");
            }
        }

        public async Task<List<SousReferenceLightDto>> GetAllSousReferencesAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default)
        {
            return await DbContext.SousReferences.Where(x => referenceIds.Contains(x.ReferenceId))
                                                 .OrderBy(x => x.Reference.Ordre)
                                                    .ThenBy(x => x.Reference.LibelleFr)
                                                        .ThenBy(x => x.OrdreFr)
                                                            .ThenBy(x => x.LibelleFr)
                                                 .ProjectTo<SousReferenceLightDto>(Mapper.ConfigurationProvider)
                                                 .ToListAsync(cancellationToken);
        }
    }
}
