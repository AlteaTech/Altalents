using AlteaTools.Api.Core.Extensions;
using AnyAscii;
using Altalents.Entities.Enum;
using Altalents.IBusiness.Enums;
using Altalents.IBusiness.Models;

namespace Altalents.Business.Services
{
    public partial class ReferenceService : BaseAppService<CustomDbContext>, IReferenceService
    {
        public async Task<List<ReferenceByLangueDto>> GetReferenceByLangueByTypeReferenceIdAsync(Guid typeReferenceId, EnumLangue langue, CancellationToken cancellationToken = default)
        {
            IQueryable<Reference> queryReference = await GetQueryReferenceAsync(typeReferenceId, cancellationToken);
            List<ReferenceByLangueDto> referencesByLangue = await queryReference.ProjectTo<ReferenceByLangueDto>(Mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            switch (langue)
            {
                case EnumLangue.Français:
                default:
                {
                    referencesByLangue = referencesByLangue.OrderBy(x => x.OrdreFr).ThenBy(x => x.LibelleFr).ToList();
                    referencesByLangue.ForEach(x =>
                    {
                        x.Libelle = x.LibelleFr;
                    });
                    break;
                }
                case EnumLangue.SecondeLangue:
                {
                    referencesByLangue = referencesByLangue.OrderBy(x => x.Ordre2).ThenBy(x => x.Libelle2).ToList();
                    referencesByLangue.ForEach(x =>
                    {
                        x.Libelle = x.Libelle2;
                    });
                    break;
                }
            };
            return referencesByLangue;
        }

        public async Task<string> GetLibelleByLangueByReferenceIdAsync(EnumLangue langue, Guid referenceId, CancellationToken cancellationToken = default)
        {
            if (!(await DbContext.References.AnyAsync(x => x.Id == referenceId, cancellationToken)))
            {
                return string.Empty;
            }

            Reference reference = await DbContext.References.Where(w => w.Id == referenceId).SingleAsync(cancellationToken);

            switch (langue)
            {
                case EnumLangue.SecondeLangue:
                    return string.IsNullOrEmpty(reference.Libelle2) ? reference.LibelleFr : reference.Libelle2;
                case EnumLangue.Français:
                default:
                    return reference.LibelleFr;
            };
        }

        public async Task<List<TypeReferenceLightDto>> GetTypeReferencesLightAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.TypeReferences.OrderBy(x => x.Ordre)
                                                    .ThenBy(x => x.Libelle)
                                                 .ProjectTo<TypeReferenceLightDto>(Mapper.ConfigurationProvider)
                                                 .ToListAsync(cancellationToken);
        }

        public async Task<List<NomDto>> GetNomsFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(texteAutoComplete))
            {
                return new List<NomDto>();
            }
            texteAutoComplete = texteAutoComplete.Transliterate().ToLower();
            IQueryable<Reference> referenceDtosQuery = await GetQueryReferenceAsync(EnumTypeReference.Nom.GetBddId(), cancellationToken);
            referenceDtosQuery = referenceDtosQuery.Where(x => x.LibelleTransLitLowerFr.Contains(texteAutoComplete));

            return await referenceDtosQuery.ProjectTo<NomDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }

        public async Task<List<LieuDto>> GetLieuxFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(texteAutoComplete))
            {
                return new List<LieuDto>();
            }
            texteAutoComplete = texteAutoComplete.Transliterate().ToLower();
            Guid typeReferencePaysId = EnumTypeReference.Pays.GetBddId();

            using (CustomDbContext contextePaysFr = GetScopedDbContexte())
            using (CustomDbContext contextePays2 = GetScopedDbContexte())
            using (CustomDbContext contexteVilleFr = GetScopedDbContexte())
            using (CustomDbContext contexteVille2 = GetScopedDbContexte())
            {
                IQueryable<Reference> paysFrQuery = contextePaysFr.References.Where(x => x.TypeReferenceId == typeReferencePaysId)
                                                                             .Where(x => x.LibelleTransLitLowerFr.Contains(texteAutoComplete));
                IQueryable<Reference> pays2Query = contextePays2.References.Where(x => x.TypeReferenceId == typeReferencePaysId)
                                                                           .Where(x => x.LibelleTransLitLower2.Contains(texteAutoComplete));
                IQueryable<SousReference> villeFrQuery = contexteVilleFr.SousReferences.Where(x => x.Reference.TypeReferenceId == typeReferencePaysId)
                                                                                       .Where(x => x.LibelleTransLitLowerFr.Contains(texteAutoComplete));
                IQueryable<SousReference> ville2Query = contexteVille2.SousReferences.Where(x => x.Reference.TypeReferenceId == typeReferencePaysId)
                                                                                     .Where(x => x.LibelleTransLitLower2.Contains(texteAutoComplete));

                Task<List<LieuModel>> runnerPaysFr = paysFrQuery.Select(x => new LieuModel()
                {
                    Libelle = x.LibelleFr,
                    Id = x.Id,
                    Ordre = x.Ordre,
                    LibelleTransLit = x.LibelleTransLitLowerFr
                }).ToListAsync(cancellationToken);
                Task<List<LieuModel>> runnerPays2 = pays2Query.Select(x => new LieuModel()
                {
                    Libelle = x.Libelle2,
                    Id = x.Id,
                    Ordre = x.Ordre2,
                    LibelleTransLit = x.LibelleTransLitLowerFr
                }).ToListAsync(cancellationToken);
                Task<List<LieuModel>> runnerVilleFr = villeFrQuery.Select(x => new LieuModel()
                {
                    Libelle = x.LibelleFr,
                    Id = x.Id,
                    Ordre = x.OrdreFr,
                    LibelleTransLit = x.LibelleTransLitLowerFr
                }).ToListAsync(cancellationToken);
                Task<List<LieuModel>> runnerVille2 = ville2Query.Select(x => new LieuModel()
                {
                    Libelle = x.Libelle2,
                    Id = x.Id,
                    Ordre = x.Ordre2,
                    LibelleTransLit = x.LibelleTransLitLowerFr
                }).ToListAsync(cancellationToken);

                List<LieuModel> lieux = new();
                lieux.AddRange(await runnerPaysFr);
                lieux.AddRange(await runnerPays2);
                lieux.AddRange(await runnerVilleFr);
                lieux.AddRange(await runnerVille2);

                return lieux.DistinctBy(x => $"{x.Id}{x.Libelle}")
                    .OrderBy(x => x.Ordre)
                    .ThenBy(x => x.Libelle)
                    .Select(x => new LieuDto()
                    {
                        Libelle = x.Libelle,
                        Id = x.Id,
                        LibelleTransLit = x.LibelleTransLit
                    })
                    .ToList();
            }
        }
    }
}
