using System.Security.Cryptography.Xml;
using System.Threading;

using AlteaTools.Api.Core.Extensions;

using AnyAscii;

using Altalents.Business.Extensions;
using Altalents.Entities.Enum;
using Altalents.IBusiness.Enums;

namespace Altalents.Business.Services
{
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        public async Task<List<LugtDto>> GetLugtsFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken)
        {
            List<LugtDto> tmp = await PartialGetLugtsFromAutoCompleteAsync(texteAutoComplete, cancellationToken);

            return tmp.Where(x => x.ReferenceLugtLight.ToLower() == $"l.{texteAutoComplete.ToLower().TrimStart('l').TrimStart('.').TrimStart(' ').TrimStart('0')}").ToList();
        }
        public async Task<List<LugtDto>> GetLugtByOldIdAltalentsAsync(string oldId, CancellationToken cancellationToken)
        {
            return await DbContext.Marques.Where(x => x.AncienIdAltalents == oldId)
                                           .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }

        public async Task<List<LugtDto>> PartialGetLugtsFromAutoCompleteAsync(string texteAutoComplete, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(texteAutoComplete))
            {
                return new List<LugtDto>();
            }

            texteAutoComplete = texteAutoComplete.ToLower();
            if (texteAutoComplete.StartsWith("l"))
            {
                List<LugtDto> lugts = await DbContext.Marques.Where(x => x.ReferenceLugt.ToLower().StartsWith(texteAutoComplete))
                    .Where(x => x.Notices.Any(y => y.IsPublie))
                    .OrderBy(x => x.ReferenceLugt)
                                           .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);

                if (lugts.Any())
                {
                    return lugts;
                }

                string recherche = $"l. {texteAutoComplete.Replace("l", "").Replace(".", "").Trim()}";
                lugts = await DbContext.Marques.Where(x => x.ReferenceLugt.ToLower().StartsWith(recherche))
                                        .Where(x => x.Notices.Any(y => y.IsPublie))

                                   .OrderBy(x => x.ReferenceLugt)
                                   .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);
                if (lugts.Any())
                {
                    return lugts;
                }

                lugts = await DbContext.Marques.Where(x => x.ReferenceLugtLight.ToLower().StartsWith(texteAutoComplete))
                                        .Where(x => x.Notices.Any(y => y.IsPublie))

                                           .OrderBy(x => x.ReferenceLugt)
                                           .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
                if (lugts.Any())
                {
                    return lugts;
                }


                recherche = $"l.{texteAutoComplete.Replace("l", "").Replace(".", "").Trim()}";
                return await DbContext.Marques.Where(x => x.ReferenceLugtLight.ToLower().StartsWith(recherche))
                                        .Where(x => x.Notices.Any(y => y.IsPublie))

                                   .OrderBy(x => x.ReferenceLugt)
                                   .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                   .ToListAsync(cancellationToken);

            }
            return await DbContext.Marques.Where(x => x.ReferenceLugt.ToLower().Contains(texteAutoComplete))
                                    .Where(x => x.Notices.Any(y => y.IsPublie))

                                           .OrderBy(x => x.ReferenceLugt)
                                           .ProjectTo<LugtDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken);
        }

        public async Task<MarqueFullDto> GetMarqueFullByIdAsync(EnumLangue langue, Guid marqueId, bool isPrevisualisation, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            Marque marque = await DbContext.Marques.Include(x => x.Images)
                                                   .Include(x => x.Notices.Where(a => a.IsPublie || isPrevisualisation))
                                                     .ThenInclude(x => x.OngletNoticeMarque)
                                                   .SingleAsync(x => x.Id == marqueId, cancellationToken);

            MarqueFullDto marqueFull = Mapper.Map<MarqueFullDto>(marque);
            marqueFull.Notices = marqueFull.Notices.OrderBy(x => x.Titre).ToList();
            marqueFull.Images = marqueFull.Images.OrderBy(x => x.Ordre).ToList();
            marqueFull.NomPrincipal = await GetNomPrincipalLibelleFrByMarqueIdAsync(marqueFull.IdMarque, cancellationToken);
            await PopulateReferencesMarqueFullAsync(langue, marqueFull, cancellationToken);
            await PopulateRenvoisMarquesFullAsync(marqueFull, isPrevisualisation, cancellationToken);
            return marqueFull;
        }

        private async Task PopulateRenvoisMarquesFullAsync(MarqueFullDto marqueFull, bool isPrevisualisation, CancellationToken cancellationToken)
        {
            List<MarqueRenvoisLightDto> marquesRenvois = new();
            List<Guid> renvoisIds = await GetMarquesRenvoisIdsByMarqueIdTravailAsync(marqueFull.IdMarque, cancellationToken, !isPrevisualisation);
            renvoisIds.Remove(marqueFull.IdMarque);

            foreach (Guid id in renvoisIds)
            {
                marquesRenvois.Add(new MarqueRenvoisLightDto()
                {
                    IdMarque = id,
                    ReferenceLugt = await GetReferenceLugtByMarqueIdAsync(id, true, cancellationToken)
                });
            }
            marqueFull.Renvois = marquesRenvois.OrderBy(x => x.ReferenceLugt).ToList();
        }

        private static IQueryable<MarqueSousReferenceReference> GetQueryableMarqueSousReferenceReferenceForContexte(CustomDbContext contexte, Guid typeReferenceId, Guid marqueId)
        {
            return contexte.MarqueSousReferenceReferences.Where(x => x.MarqueId == marqueId)
                                                         .Where(x => x.Reference.TypeReferenceId == typeReferenceId);
        }

        private async Task PopulateReferencesMarqueFullAsync(EnumLangue langue, MarqueFullDto marqueFull, CancellationToken cancellationToken)
        {
            Guid marqueId = marqueFull.IdMarque;
            using (CustomDbContext contexteTechniqueReference = GetScopedDbContexte())
            using (CustomDbContext contexteTechniqueSousReference = GetScopedDbContexte())
            using (CustomDbContext contexteCouleurReference = GetScopedDbContexte())
            using (CustomDbContext contexteCouleurSousReference = GetScopedDbContexte())
            using (CustomDbContext contexteLocalisationReference = GetScopedDbContexte())
            using (CustomDbContext contexteLocalisationSousReference = GetScopedDbContexte())
            {
                IQueryable<MarqueSousReferenceReference> referencesTechniqueQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteTechniqueReference, EnumTypeReference.Technique.GetBddId(), marqueId);
                IQueryable<MarqueSousReferenceReference> sousReferencesTechniqueQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteTechniqueSousReference, EnumTypeReference.Technique.GetBddId(), marqueId);
                IQueryable<MarqueSousReferenceReference> referencesCouleurQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteCouleurReference, EnumTypeReference.Couleur.GetBddId(), marqueId);
                IQueryable<MarqueSousReferenceReference> sousReferencesCouleurQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteCouleurSousReference, EnumTypeReference.Couleur.GetBddId(), marqueId);
                IQueryable<MarqueSousReferenceReference> referencesLocalisationQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteLocalisationReference, EnumTypeReference.Localisation.GetBddId(), marqueId);
                IQueryable<MarqueSousReferenceReference> sousReferencesLocalisationQuery = GetQueryableMarqueSousReferenceReferenceForContexte(contexteLocalisationSousReference, EnumTypeReference.Localisation.GetBddId(), marqueId);

                Task<List<string>> runnerTechniqueReference;
                Task<List<string>> runnerTechniqueSousReference;
                Task<List<string>> runnerCouleurReference;
                Task<List<string>> runnerCouleurSousReference;
                Task<List<string>> runnerLocalisationReference;
                Task<List<string>> runnerLocalisationSousReference;

                switch (langue)
                {
                    case EnumLangue.Français:
                    default:
                    {
                        runnerTechniqueReference = referencesTechniqueQuery.Select(x => x.Reference.LibelleFr).ToListAsync(cancellationToken);
                        runnerTechniqueSousReference = sousReferencesTechniqueQuery.Select(x => x.SousReference.LibelleFr).ToListAsync(cancellationToken);
                        runnerCouleurReference = referencesCouleurQuery.Select(x => x.Reference.LibelleFr).ToListAsync(cancellationToken);
                        runnerCouleurSousReference = sousReferencesCouleurQuery.Select(x => x.SousReference.LibelleFr).ToListAsync(cancellationToken);
                        runnerLocalisationReference = referencesLocalisationQuery.Select(x => x.Reference.LibelleFr).ToListAsync(cancellationToken);
                        runnerLocalisationSousReference = sousReferencesLocalisationQuery.Select(x => x.SousReference.LibelleFr).ToListAsync(cancellationToken);
                        break;
                    }
                    case EnumLangue.SecondeLangue:
                    {
                        runnerTechniqueReference = referencesTechniqueQuery.Select(x => x.Reference.Libelle2).ToListAsync(cancellationToken);
                        runnerTechniqueSousReference = sousReferencesTechniqueQuery.Select(x => x.SousReference.Libelle2).ToListAsync(cancellationToken);
                        runnerCouleurReference = referencesCouleurQuery.Select(x => x.Reference.Libelle2).ToListAsync(cancellationToken);
                        runnerCouleurSousReference = sousReferencesCouleurQuery.Select(x => x.SousReference.Libelle2).ToListAsync(cancellationToken);
                        runnerLocalisationReference = referencesLocalisationQuery.Select(x => x.Reference.Libelle2).ToListAsync(cancellationToken);
                        runnerLocalisationSousReference = sousReferencesLocalisationQuery.Select(x => x.SousReference.Libelle2).ToListAsync(cancellationToken);
                        break;
                    }
                }

                List<string> techniques = new();
                techniques.AddRange(await runnerTechniqueReference);
                techniques.AddRange(await runnerTechniqueSousReference);
                techniques.RemoveAll(x => x == null);
                techniques = techniques.Distinct().ToList();

                List<string> couleurs = new();
                couleurs.AddRange(await runnerCouleurReference);
                couleurs.AddRange(await runnerCouleurSousReference);
                couleurs.RemoveAll(x => x == null);
                couleurs = couleurs.Distinct().ToList();

                List<string> localisations = new();
                localisations.AddRange(await runnerLocalisationReference);
                localisations.AddRange(await runnerLocalisationSousReference);
                localisations.RemoveAll(x => x == null);
                localisations = localisations.Distinct().ToList();

                marqueFull.References = new List<MarqueTypeReferenceDto>
                {
                    new MarqueTypeReferenceDto
                    {
                        TypeReference = EnumTypeReference.Technique.GetDisplayName(),
                        References = techniques
                    },
                    new MarqueTypeReferenceDto
                    {
                        TypeReference = EnumTypeReference.Couleur.GetDisplayName(),
                        References = couleurs
                    },
                    new MarqueTypeReferenceDto
                    {
                        TypeReference = EnumTypeReference.Localisation.GetDisplayName(),
                        References = localisations
                    }
                };
            }
        }

        private async Task<string> GetNomPrincipalLibelleFrByMarqueIdAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(idMarque, cancellationToken);
            return await DbContext.MarqueSousReferenceReferences.Where(x => x.MarqueId == idMarque)
                                                                .Where(x => x.IsPrincipal)
                                                                .Where(x => x.Reference.TypeReferenceId == EnumTypeReference.Nom.GetBddId())
                                                                .Select(x => x.Reference == null ? "" : x.Reference.LibelleFr)
                                                                .SingleAsync(cancellationToken);
        }

        public async Task<List<MarqueRechercheDto>> GetMarquesRechercheAsync(EnumLangue langue, RechercheRequestDto rechercheRequest, CancellationToken cancellationToken = default)
        {
            if (rechercheRequest.IsEmpty)
            {
                return await DbContext.Marques
                                        .Where(x => x.Notices.Any(y => y.IsPublie))
                                        .ProjectTo<MarqueRechercheDto>(Mapper.ConfigurationProvider)
                              .OrderBy(x => x.ReferenceLugtFull)
                              .ToListAsync(cancellationToken);
            }

            if (rechercheRequest.IsUniquementTexteFilter)
            {
                return await GetMarquesRechercheFromNoticesAsync(await DbContext.MarqueNotices.Where(x => x.IsPublie).ToListAsync(cancellationToken), rechercheRequest, cancellationToken);
            }

            IQueryable<Marque> query = DbContext.Marques
                .Where(x => x.Notices.Any(y => y.IsPublie))
                .ApplyFilterNom(rechercheRequest.NomId, rechercheRequest.NomFullText)
                .ApplyFilterLieu(rechercheRequest.LieuId, rechercheRequest.LieuFullText)
                .ApplyFilterReferences(rechercheRequest.Texte1)
                .ApplyFilterReferences(rechercheRequest.Texte2)
                .ApplyFilterReferences(rechercheRequest.Image1)
                .ApplyFilterReferences(rechercheRequest.Image2)
                .ApplyFilterReferences(rechercheRequest.Image3)
                .ApplyFilterReferences(rechercheRequest.Technique)
                .ApplyFilterReferences(rechercheRequest.Couleur);

            if (string.IsNullOrEmpty(rechercheRequest.Texte))
            {
                IQueryable<MarqueRechercheDto> marqueRechercheDtosQuery = query.ProjectTo<MarqueRechercheDto>(Mapper.ConfigurationProvider);
                return await ReturnOrderedMarqueRechercheDto(rechercheRequest, marqueRechercheDtosQuery, cancellationToken);
            }

            List<MarqueNotice> marqueNotices = await query.Include(x => x.Notices).SelectMany(x => x.Notices).ToListAsync(cancellationToken);
            return await GetMarquesRechercheFromNoticesAsync(marqueNotices, rechercheRequest, cancellationToken);
        }

        private async Task<List<MarqueRechercheDto>> GetMarquesRechercheFromNoticesAsync(List<MarqueNotice> marqueNotices, RechercheRequestDto rechercheRequest, CancellationToken cancellationToken = default)
        {
            marqueNotices = FilterNotice(marqueNotices, rechercheRequest);
            IEnumerable<Guid> marquesIds = marqueNotices.Select(x => x.MarqueId).Distinct();
            IQueryable<MarqueRechercheDto> marqueRechercheDtosQuery = DbContext.Marques.Where(x => marquesIds.Contains(x.Id))
                                                      .ProjectTo<MarqueRechercheDto>(Mapper.ConfigurationProvider);

            return await ReturnOrderedMarqueRechercheDto(rechercheRequest, marqueRechercheDtosQuery, cancellationToken);
        }

        private static async Task<List<MarqueRechercheDto>> ReturnOrderedMarqueRechercheDto(RechercheRequestDto rechercheRequest, IQueryable<MarqueRechercheDto> marqueRechercheDtos, CancellationToken cancellationToken)
        {
            if (rechercheRequest?.Texte1?.ReferenceId == EnumReference.Initiale.GetBddId() || rechercheRequest?.Texte2?.ReferenceId == EnumReference.Initiale.GetBddId())
            {
                return await marqueRechercheDtos
                          .OrderBy(x => x.Initiales)
                          .ThenBy(x => x.NumeroLugt)
                          .ThenBy(x => x.ReferenceLugt)
                          .ToListAsync(cancellationToken);
            }
            return await marqueRechercheDtos
                                              .OrderBy(x => x.NumeroLugt)
                                              .ThenBy(x => x.ReferenceLugt)
                                          .ToListAsync(cancellationToken);
        }

        private List<MarqueNotice> FilterNotice(List<MarqueNotice> marqueNotices, RechercheRequestDto rechercheRequest)
        {
            rechercheRequest.Texte = rechercheRequest.Texte.Transliterate();
            marqueNotices = marqueNotices.Where(x => x.IsPublie).ToList();
            if (rechercheRequest.IsExact)
            {
                return marqueNotices
                        .Where(x => x.TexteBrut?.ToLower()?.Contains(rechercheRequest.Texte.ToLower()) ?? false).ToList();
            }

            foreach (string txt in rechercheRequest.Texte.Split(" ").Distinct())
            {
                marqueNotices = marqueNotices.Where(x => x.TexteBrut?.ToLower()?.Contains(txt.ToLower()) ?? false).ToList();
            }
            return marqueNotices;
        }

        public Task<List<MarqueNouveauteDto>> GetMarquesNouveautesAsync(EnumLangue langue, CancellationToken cancellationToken = default)
        {
            return DbContext.Marques.Where(x => x.IsFinalize)
                                    .Where(x => x.DatePublication > DateTime.Now.AddMonths(_marqueSettings.DelaiMoisNouveaute))
                                    .ProjectTo<MarqueNouveauteDto>(Mapper.ConfigurationProvider)
                                    .OrderBy(x => x.ReferenceLugtFull)
                                    .ToListAsync(cancellationToken);
        }
    }
}
