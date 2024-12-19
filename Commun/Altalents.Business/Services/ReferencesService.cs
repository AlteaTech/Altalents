
using System.Reflection.Metadata;

using Altalents.Commun.Enums;

namespace Altalents.Business.Services
{
    public class ReferencesService : BaseAppService<CustomDbContext>, IReferencesService
    {
        public ReferencesService(ILogger<ReferencesService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
        }

        public async Task<Guid> CreateReferencesAsync(ReferenceRequestDto reference, CancellationToken cancellationToken)
        {
            TypeReferenceEnum typeReference = (TypeReferenceEnum)Enum.Parse(typeof(TypeReferenceEnum), reference.TypeReference);
            using CustomDbContext customDbContext = GetScopedDbContexte();
            Reference refe = new()
            {
                Type = typeReference,
                Code = reference.Libelle.Replace(" ", ""),
                Libelle = reference.Libelle,
                IsValide = false,
            };
            await customDbContext.References.AddAsync(refe, cancellationToken);
            await customDbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return refe.Id;
        }

        public async Task<List<ReferenceDto>> GetReferencesAsync(string typeReferenceCode, string startWith, CancellationToken cancellationToken)
        {
            TypeReferenceEnum typeReference = (TypeReferenceEnum)Enum.Parse(typeof(TypeReferenceEnum), typeReferenceCode);
            IQueryable<Reference> referencesQuery = DbContext.References
                             .Where(x => x.Type == typeReference && x.IsValide);

            if (!string.IsNullOrEmpty(startWith))
            {
                referencesQuery = referencesQuery.Where(x => x.Libelle.StartsWith(startWith.ToLower()));
            }

            return await referencesQuery
                 .OrderBy(x => x.OrdreTri)
                 .ThenBy(x => x.Libelle)
                 .ProjectTo<ReferenceDto>(Mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);
        }

        public IQueryable<ReferenceAValiderDto> GetReferencesAValider(bool showAll)
        {
            List<TypeReferenceEnum> listType = [TypeReferenceEnum.Competence, TypeReferenceEnum.Technologie, TypeReferenceEnum.Methodologies, TypeReferenceEnum.Outil];
            IQueryable<Reference> references = DbContext.References.Where(x => listType.Contains(x.Type)).AsQueryable();
            if (!showAll)
            {
                references = references.Where(x => !x.IsValide);
            }
            return references.ProjectTo<ReferenceAValiderDto>(Mapper.ConfigurationProvider);
        }

        public Task UpdateReferenceAsync(ReferenceAValiderDto reference)
        {
            throw new NotImplementedException();
        }
    }
}
