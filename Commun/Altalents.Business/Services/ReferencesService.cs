
using System.Reflection.Metadata;

using Altalents.Commun.Enums;
using Altalents.Entities;
using DocumentFormat.OpenXml.InkML;

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



        public async Task DeleteReference(Guid idRef, CancellationToken cancellationToken)
        {
            using CustomDbContext context = GetScopedDbContexte();

            Entities.Reference toDelete = await context.References
                .AsTracking()
                .SingleOrDefaultAsync(x => x.Id == idRef);

            if (toDelete == null)
            {
                throw new BusinessException("Impossible de supprimer une référence qui n'existe pas en BDD");
            }

            // Suppression des liaisons en fonction du type de référence
            if (toDelete.Type == TypeReferenceEnum.Competence)
            {
                var liaisons = context.LiaisonProjetCompetences.Where(x => x.CompetenceId == toDelete.Id);
                context.LiaisonProjetCompetences.RemoveRange(liaisons);
            }
            else if (toDelete.Type == TypeReferenceEnum.Methodologies)
            {
                var liaisons = context.LiaisonProjetMethodologies.Where(x => x.MethodologieId == toDelete.Id);
                context.LiaisonProjetMethodologies.RemoveRange(liaisons);
            }
            else if (toDelete.Type == TypeReferenceEnum.Outil)
            {
                var liaisons = context.LiaisonProjetOutils.Where(x => x.OutilId == toDelete.Id);
                context.LiaisonProjetOutils.RemoveRange(liaisons);
            }
            else if (toDelete.Type == TypeReferenceEnum.Technologie)
            {
                var liaisons = context.LiaisonProjetTechnologies.Where(x => x.TechnologieId == toDelete.Id);
                context.LiaisonProjetTechnologies.RemoveRange(liaisons);
            }

            // Sauvegarde après suppression des liaisons
            await context.SaveBaseEntityChangesAsync(cancellationToken);

            // Suppression de la référence
            context.References.Remove(toDelete);
            await context.SaveBaseEntityChangesAsync(cancellationToken);
        }



        public async Task UpdateReferenceAsync(ReferenceRequestDto referenceDto, CancellationToken cancellationToken)
        {

            if(!referenceDto.Id.HasValue)
                throw new BusinessException("Format de l'id incorrect");

            using CustomDbContext customDbContext = GetScopedDbContexte();

            Entities.Reference toUpdate = await customDbContext.References
                .AsTracking()
                .SingleOrDefaultAsync(x => x.Id == referenceDto.Id);

            if (toUpdate == null)
            {
                throw new BusinessException("Impossible de mettre à jour une référence qui n'existe pas en BDD");
            }

            toUpdate.IsValide = referenceDto.IsValide;
            toUpdate.Libelle = referenceDto.Libelle;
            toUpdate.CommentaireFun = referenceDto.Commentaire;

            await customDbContext.SaveBaseEntityChangesAsync(cancellationToken);

        }
    }
}
