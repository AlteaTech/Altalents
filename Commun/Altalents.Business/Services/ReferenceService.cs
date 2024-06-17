using AlteaTools.Api.Core.Extensions;

using AnyAscii;

using Altalents.Entities.Enum;

using Microsoft.Extensions.DependencyInjection;

namespace Altalents.Business.Services
{
    public partial class ReferenceService : BaseAppService<CustomDbContext>, IReferenceService
    {
        private readonly IServiceProvider _serviceProvider;

        public ReferenceService(
            ILogger<ReferenceService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DeleteReferenceAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Reference>.CheckIdExistAsync(DbContext.References, id, cancellationToken);
            Reference reference = await DbContext.References.Include(x => x.SousReferences)
                                                            .Include(x => x.MarqueSousReferenceReferences)
                                                            .SingleAsync(x => x.Id == id, cancellationToken);

            if (reference.SousReferences.Any() || reference.MarqueSousReferenceReferences.Any())
            {
                throw new BusinessException(BusinessExceptionsResources.REFERENCE_NON_SUPPRIMABLE);
            }

            DbContext.References.Remove(reference);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<IQueryable<ReferenceDto>> GetReferencesByTypeReferenceIdAsync(Guid typeReferenceId, CancellationToken cancellationToken = default)
        {
            IOrderedQueryable<Reference> subQuery = (await GetQueryReferenceAsync(typeReferenceId, cancellationToken)).OrderBy(x => x.Ordre);
            return subQuery.ProjectTo<ReferenceDto>(Mapper.ConfigurationProvider);
        }

        private async Task<IQueryable<Reference>> GetQueryReferenceAsync(Guid typeReferenceId, CancellationToken cancellationToken)
        {
            if (!await DbContext.TypeReferences.Where(w => w.Id == typeReferenceId).AnyAsync(cancellationToken))
            {
                throw new BusinessException(BusinessExceptionsResources.TYPE_REFERENCE_INCONNU);
            }

            return DbContext.References.Where(w => w.TypeReference.Id == typeReferenceId);
        }

        public async Task<List<ReferenceLightDto>> GetReferencesByTypeAsync(string text, EnumTypeReference type, CancellationToken cancellationToken = default)
        {
            IQueryable<Reference> referenceDtosQuery = await GetQueryReferenceAsync(type.GetBddId(), cancellationToken);
            if (!string.IsNullOrEmpty(text))
            {
                if (type == EnumTypeReference.Nom)
                {
                    referenceDtosQuery = referenceDtosQuery.Where(x => x.LibelleFr.Contains(text));
                }
                else
                {
                    referenceDtosQuery = referenceDtosQuery.Where(x => x.LibelleFr.StartsWith(text));
                }
            }
            return await referenceDtosQuery.OrderBy(x => x.Ordre)
                                               .ThenBy(x => x.LibelleFr)
                                           .ProjectTo<ReferenceLightDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }

        public async Task<TypeReferenceDto> GetTypeReferenceByIdAsync(Guid typeId, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<TypeReference>.CheckIdExistAsync(DbContext.TypeReferences, typeId, cancellationToken);
            return await DbContext.TypeReferences.Where(x => x.Id == typeId)
                                                 .ProjectTo<TypeReferenceDto>(Mapper.ConfigurationProvider)
                                                 .SingleAsync(cancellationToken);
        }

        public async Task<TypeReferenceDto> GetTypeReferenceByIdReferenceAsync(Guid idReference, CancellationToken cancellationToken = default)
        {
            return await DbContext.References.Where(x => x.Id == idReference).Select(x => x.TypeReference).ProjectTo<TypeReferenceDto>(Mapper.ConfigurationProvider).SingleAsync(cancellationToken);
        }

        public async Task<List<TypeReferenceDto>> GetTypeReferencesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.TypeReferences.OrderBy(x => x.Libelle)
                                                 .ProjectTo<TypeReferenceDto>(Mapper.ConfigurationProvider)
                                                 .ToListAsync(cancellationToken);
        }

        public async Task<Guid> InsertReferenceAsync(ReferenceDto reference, CancellationToken cancellationToken = default)
        {
            await CheckLibelleFrExistForTypeReferenceIdAsync(reference.LibelleFr, reference.TypeReferenceId, cancellationToken: cancellationToken);
            Reference nouvelleReference = Mapper.Map<Reference>(reference);

            await DbContext.References.AddAsync(nouvelleReference, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return nouvelleReference.Id;
        }

        public async Task UpdateReferenceAsync(ReferenceDto referenceModifie, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Reference>.CheckIdExistAsync(DbContext.References, referenceModifie.ReferenceId, cancellationToken);
            await CheckLibelleFrExistForTypeReferenceIdAsync(referenceModifie.LibelleFr, referenceModifie.TypeReferenceId, referenceModifie.ReferenceId, cancellationToken: cancellationToken);

            Reference reference = await DbContext.References.AsTracking().SingleAsync(x => x.Id == referenceModifie.ReferenceId, cancellationToken);
            reference.Libelle2 = referenceModifie.Libelle2;
            reference.LibelleFr = referenceModifie.LibelleFr;
            reference.LibelleTransLitLower2 = referenceModifie.Libelle2?.Transliterate()?.ToLower();
            reference.LibelleTransLitLowerFr = referenceModifie.LibelleFr?.Transliterate()?.ToLower();
            reference.Ordre = referenceModifie.OrdreFr.Value;
            reference.Ordre2 = referenceModifie.Ordre2.Value;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private async Task CheckLibelleFrExistForTypeReferenceIdAsync(string libelleFr, Guid typeReferenceId, Guid? idExclu = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Reference> queryable = DbContext.References.AsQueryable();
            if (idExclu.HasValue)
            {
                queryable = queryable.Where(x => x.Id != idExclu);
            }

            if (await queryable.AnyAsync(x => x.TypeReferenceId == typeReferenceId && x.LibelleFr == libelleFr, cancellationToken))
            {
                throw new BusinessException($"Le mot-clé '{libelleFr}' existe déjà pour ce type de mot-clé.");
            }
        }

        public async Task<bool> CheckListeReferencesHasAnySousReferenceAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default)
        {
            foreach (Guid referenceId in referenceIds)
            {
                await DbSetHelper<Reference>.CheckIdExistAsync(DbContext.References, referenceId, cancellationToken);
                Reference reference = await DbContext.References.Where(x => x.Id == referenceId)
                                                                .Include(x => x.SousReferences)
                                                                .SingleAsync(cancellationToken);
                if (reference.SousReferences.Any())
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Guid>> GetReferencesIdsWithAnySousReferenceAsync(List<Guid> referenceIds, CancellationToken cancellationToken = default)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                CustomDbContext contexte = scope.ServiceProvider.GetRequiredService<CustomDbContext>();
                return await contexte.References.Where(x => referenceIds.Contains(x.Id) && x.SousReferences.Any())
                                                 .Select(x => x.Id)
                                                 .ToListAsync(cancellationToken);
            }
        }
    }
}
