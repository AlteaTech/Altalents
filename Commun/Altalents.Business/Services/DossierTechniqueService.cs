

using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Requesst;

namespace Altalents.Business.Services
{
    public class DossierTechniqueService : BaseAppService<CustomDbContext>, IDossierTechniqueService
    {
        public DossierTechniqueService(ILogger<DossierTechniqueService> logger, CustomDbContext contexte, IMapper mapper, IServiceProvider serviceProvider) : base(logger, contexte, mapper, serviceProvider)
        {
        }

        public async Task<Guid> AddDossierTechniqueAsync(DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            DossierTechnique dt = Mapper.Map<DossierTechnique>(dossierTechnique);
            dt.Personne.Contacts.RemoveAll(x => string.IsNullOrWhiteSpace(x.Valeur));
            await DbContext.DossierTechniques.AddAsync(dt, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return dt.Id;

        }

        public async Task ChangerStatutDossierTechniqueAsync(Guid id, Guid statutId, CancellationToken cancellationToken)
        {
            DossierTechnique dt = await DbContext.DossierTechniques.AsTracking().SingleAsync(x => x.Id == id, cancellationToken);
            bool statutExist = await DbContext.References.AnyAsync(x => x.Id == statutId && x.Type == TypeReferenceEnum.StatutDt, cancellationToken);
            if (!statutExist)
            {
                throw new BusinessException("Statut inexistant");
            }
            dt.StatutId = statutId;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public IQueryable<DossierTechniqueDto> GetBibliothequeDossierTechniques()
        {
            return DbContext.DossierTechniques
                                         .ProjectTo<DossierTechniqueDto>(Mapper.ConfigurationProvider);
        }

        public IQueryable<DossierTechniqueEnCoursDto> GetDtsEnCours(EtatFiltreDtEnum etat)
        {
            if (etat == EtatFiltreDtEnum.InProgress)
            {
                return DbContext.DossierTechniques
                    .Where(x => x.Statut.Type == TypeReferenceEnum.StatutDt)
                    .Where(x => x.Statut.Code == CodeReferenceEnum.EnCours.ToString("g") || x.Statut.Code == CodeReferenceEnum.Inactif.ToString("g") || x.Statut.Code == CodeReferenceEnum.Cree.ToString("g"))
                                             .ProjectTo<DossierTechniqueEnCoursDto>(Mapper.ConfigurationProvider);
            }

            return DbContext.DossierTechniques
                    .Where(x => x.Statut.Type == TypeReferenceEnum.StatutDt)
                    .Where(x => x.Statut.Code == CodeReferenceEnum.AModifier.ToString("g") || x.Statut.Code == CodeReferenceEnum.NonValide.ToString("g") || x.Statut.Code == CodeReferenceEnum.Valide.ToString("g"))
                                         .ProjectTo<DossierTechniqueEnCoursDto>(Mapper.ConfigurationProvider);
        }
    }
}
