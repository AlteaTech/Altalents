using Altalents.IBusiness.Enums;

namespace Altalents.Business.Services
{
    public partial class SousReferenceService : BaseAppService<CustomDbContext>, ISousReferenceService
    {
        public async Task<List<SousReferenceByLangueDto>> GetSousReferenceByLangueByReferenceIdAsync(Guid referenceId, EnumLangue langue, CancellationToken cancellationToken = default)
        {
            IQueryable<SousReferenceDto> sousReferences = await GetSousReferencesByReferenceIdAsync(referenceId, cancellationToken);
            List<SousReferenceByLangueDto> sousReferencesByLangue = new();

            switch (langue)
            {
                case EnumLangue.Français:
                default:
                {
                    sousReferences = sousReferences.OrderBy(x => x.OrdreFr).ThenBy(x => x.LibelleFr);
                    await sousReferences.ForEachAsync(x => sousReferencesByLangue.Add(new()
                    {
                        SousReferenceId = x.SousReferenceId,
                        Libelle = x.LibelleFr
                    }), cancellationToken);
                    break;
                }
                case EnumLangue.SecondeLangue:
                {
                    sousReferences = sousReferences.OrderBy(x => x.Ordre2).ThenBy(x => x.Libelle2);
                    await sousReferences.ForEachAsync(x => sousReferencesByLangue.Add(new()
                    {
                        SousReferenceId = x.SousReferenceId,
                        Libelle = x.Libelle2
                    }), cancellationToken);
                    break;
                }
            };
            return sousReferencesByLangue;
        }

        public async Task<string> GetLibelleByLangueBySousReferenceIdAsync(EnumLangue langue, Guid sousReferenceId, CancellationToken cancellationToken = default)
        {
            if (!(await DbContext.SousReferences.AnyAsync(x => x.Id == sousReferenceId, cancellationToken)))
            {
                return string.Empty;
            }

            SousReference sousReference = await DbContext.SousReferences.Where(w => w.Id == sousReferenceId).SingleAsync(cancellationToken);

            switch (langue)
            {
                case EnumLangue.SecondeLangue:
                    return string.IsNullOrEmpty(sousReference.Libelle2) ? sousReference.LibelleFr : sousReference.Libelle2;
                case EnumLangue.Français:
                default:
                    return sousReference.LibelleFr;
            };
        }
    }
}
