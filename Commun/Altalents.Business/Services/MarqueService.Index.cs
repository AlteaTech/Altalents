using AlteaTools.Api.Core.Extensions;
using AnyAscii;
using Altalents.Commun.Helpers;
using Altalents.Entities.Enum;
using Altalents.IBusiness.DTO.Requests;

namespace Altalents.Business.Services
{
    // PARTIAL INDEX
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        public async Task UpdateIndexMarqueAsync(UpdateIndexMarqueRequestDto data, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(data.IdMarque, cancellationToken);
            Marque marque = await DbContext.Marques.Where(x => x.Id == data.IdMarque)
                                                   .Include(x => x.MarqueSousReferenceReferences)
                                                   .AsTracking()
                                                   .SingleAsync(cancellationToken);

            marque.IsFinalize = true;
            marque.Hauteur = data.Haut;
            marque.Largeur = data.Larg;
            marque.Initiales = data.Initiales;
            marque.InitialesTransLitLowerFr = StringsHelpers.HtmlToPlainText(marque.Initiales).Transliterate();

            if (marque.NumeroLugt == 0)
            {
                await SetNewNumeroLugtAsync(marque, cancellationToken);
            }
            await PopulateMarqueSousReferenceReferencesAsync(data, marque.MarqueSousReferenceReferences, data.IdMarque, cancellationToken);

            if (marque.DatePublication.HasValue)
            {
                await CheckMarqueIsPubliableReferencesAsync(marque.MarqueSousReferenceReferences, cancellationToken);
            }
            await MajDateMajMarqueAsync(marque.Id, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private async Task SetNewNumeroLugtAsync(Marque marque, CancellationToken cancellationToken)
        {
            int lastNumeroLugt = await DbContext.Marques.Select(x => x.NumeroLugt)
                                                        .OrderBy(x => x)
                                                        .LastAsync(cancellationToken);
            int numeroLugt = lastNumeroLugt + 1;
            marque.NumeroLugt = numeroLugt;
            marque.ReferenceLugt = $"L. {numeroLugt:D5}";
            marque.ReferenceLugtLight = $"L.{numeroLugt}";
        }

        private async Task PopulateMarqueSousReferenceReferencesAsync(UpdateIndexMarqueRequestDto data, List<MarqueSousReferenceReference> marqueSousReferenceReferences, Guid marqueId, CancellationToken cancellationToken)
        {
            List<Guid> allReferencesIdsSelected = data.GetAllReferencesIdsSelected();
            List<Guid> allSousReferencesIdsSelected = data.GetAllSousReferencesIdsSelected();

            List<SousReference> allSousReferencesSelected = await DbContext.SousReferences.Where(x => allSousReferencesIdsSelected.Contains(x.Id))
                                                                                          .ToListAsync(cancellationToken);

            allSousReferencesSelected.RemoveAll(x => !allReferencesIdsSelected.Contains(x.ReferenceId));
            allReferencesIdsSelected = PurgeReferencesPresentesDansLesSousReferences(allReferencesIdsSelected, allSousReferencesSelected);
            List<Reference> allReferencesSelectedWithoutSousReference = await DbContext.References.Where(x => allReferencesIdsSelected.Contains(x.Id))
                                                                                                  .ToListAsync(cancellationToken);

            // purge des anciennes valeurs
            marqueSousReferenceReferences.Clear();

            marqueSousReferenceReferences.AddRange(allSousReferencesSelected.Select(x => new MarqueSousReferenceReference()
            {
                ReferenceId = x.ReferenceId,
                SousReferenceId = x.Id,
                IsPrincipal = x.ReferenceId == data.ReferenceNomPrincipalId,
            }));

            marqueSousReferenceReferences.AddRange(allReferencesSelectedWithoutSousReference.Select(x => new MarqueSousReferenceReference()
            {
                ReferenceId = x.Id,
                IsPrincipal = x.Id == data.ReferenceNomPrincipalId,
            }));

            await PurgeMarqueReferencesLibres(marqueId, allSousReferencesIdsSelected, cancellationToken);
        }

        private async Task PurgeMarqueReferencesLibres(Guid marqueId, List<Guid> allSousReferencesIdsSelected, CancellationToken cancellationToken)
        {
            if (!allSousReferencesIdsSelected.Any(x => x == EnumSousReference.MotLatin.GetBddId()))
            {
                List<MarqueReferenceLibre> motsLatinsASupprimer = await DbContext.MarqueReferenceLibres.Where(x => x.MarqueId == marqueId)
                                                                                                       .Where(x => x.Type == EnumTypeMarqueReferenceLibre.MotLatin)
                                                                                                       .ToListAsync(cancellationToken);
                DbContext.MarqueReferenceLibres.RemoveRange(motsLatinsASupprimer);
            }

            if (!allSousReferencesIdsSelected.Any(x => x == EnumSousReference.InitialeLatin.GetBddId()))
            {
                List<MarqueReferenceLibre> initialesLatinesASupprimer = await DbContext.MarqueReferenceLibres.Where(x => x.MarqueId == marqueId)
                                                                                                             .Where(x => x.Type == EnumTypeMarqueReferenceLibre.InitialeLatin)
                                                                                                             .ToListAsync(cancellationToken);
                DbContext.MarqueReferenceLibres.RemoveRange(initialesLatinesASupprimer);
            }
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private static List<Guid> PurgeReferencesPresentesDansLesSousReferences(List<Guid> allReferencesIdsSelected, List<SousReference> allSousReferencesSelected)
        {
            allReferencesIdsSelected.RemoveAll(x => allSousReferencesSelected.Any(y => y.ReferenceId == x));
            allReferencesIdsSelected = allReferencesIdsSelected.Distinct().ToList();
            return allReferencesIdsSelected;
        }

        public async Task<IndexMarqueDto> GetUpdateIndexMarqueDtoAsync(Guid idMarque, CancellationToken cancellationToken = default)
        {
            Marque marque = await DbContext.Marques
                            .Where(x => x.Id == idMarque)
                            .Include(x => x.MarqueSousReferenceReferences)
                                .ThenInclude(t => t.Reference)
                            .Include(x => x.MarqueSousReferenceReferences)
                                .ThenInclude(t => t.SousReference)
                            .FirstAsync(cancellationToken);

            List<Reference> allReferences = marque.MarqueSousReferenceReferences.Select(x => x.Reference).ToList();
            List<SousReference> allSousReferences = marque.MarqueSousReferenceReferences.Select(x => x.SousReference).ToList();
            allSousReferences.RemoveAll(x => x == null);

            IndexMarqueDto updateIndexMarqueDto = Mapper.Map<IndexMarqueDto>(marque);
            PopulateIndexMarqueDtoWithReferences(marque, allReferences, updateIndexMarqueDto);
            PopulateIndexMarqueDtoWithSousReferences(allSousReferences, updateIndexMarqueDto);
            await PopulateTotalElementAChargerAsync(updateIndexMarqueDto, cancellationToken);
            return updateIndexMarqueDto;
        }

        private async Task PopulateTotalElementAChargerAsync(IndexMarqueDto updateIndexMarqueDto, CancellationToken cancellationToken)
        {
            int totalTypeReferences = await DbContext.TypeReferences.CountAsync(cancellationToken);
            int totalReferences = 0;
            totalReferences += updateIndexMarqueDto.SousReferencePays.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceTextes.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceImages.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceCouleurs.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceContours.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceCategories.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceLocalisations.Any() ? 1 : 0;
            totalReferences += updateIndexMarqueDto.SousReferenceTechniques.Any() ? 1 : 0;
            updateIndexMarqueDto.TotalElementACharger = totalTypeReferences + totalReferences;
        }

        private void PopulateIndexMarqueDtoWithSousReferences(List<SousReference> allSousReferences, IndexMarqueDto updateIndexMarqueDto)
        {
            updateIndexMarqueDto.SousReferencePays = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferencePays.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceTextes = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceTextes.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceImages = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceImages.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceCouleurs = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceCouleurs.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceContours = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceContours.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceCategories = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceCategories.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceLocalisations = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceLocalisations.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
            updateIndexMarqueDto.SousReferenceTechniques = Mapper.Map<List<SousReferenceLightDto>>(allSousReferences.Where(x => updateIndexMarqueDto.ReferenceTechniques.Select(y => y.ReferenceId).Contains(x.ReferenceId)));
        }

        private void PopulateIndexMarqueDtoWithReferences(Marque marque, List<Reference> allReferences, IndexMarqueDto updateIndexMarqueDto)
        {
            Func<Reference, bool> predicatNom = x => x.TypeReferenceId == EnumTypeReference.Nom.GetBddId();
            updateIndexMarqueDto.ReferenceNoms = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(predicatNom).ToList());
            updateIndexMarqueDto.ReferencePays = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Pays.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceTextes = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Texte.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceImages = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Image.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceCouleurs = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Couleur.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceTechniques = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Technique.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceLocalisations = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Localisation.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceCategories = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Categorie.GetBddId()).ToList());
            updateIndexMarqueDto.ReferenceContours = Mapper.Map<List<ReferenceLightDto>>(allReferences.Where(x => x.TypeReferenceId == EnumTypeReference.Contour.GetBddId()).ToList());
            updateIndexMarqueDto.NomPrincipal = Mapper.Map<ReferenceLightDto>(marque.MarqueSousReferenceReferences.Where(x => x.IsPrincipal).Select(x => x.Reference).ToList().Where(predicatNom).SingleOrDefault());
        }

        public async Task<IQueryable<MarqueLightDto>> GetMarquesAssocieesByReferenceIdAsync(Guid referenceId, Guid? sousReferenceId, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Reference>.CheckIdExistAsync(DbContext.References, referenceId, cancellationToken);
            if (sousReferenceId.HasValue)
            {
                await DbSetHelper<SousReference>.CheckIdExistAsync(DbContext.SousReferences, sousReferenceId.Value, cancellationToken);
                return DbContext.Marques.Where(x => x.MarqueSousReferenceReferences.Any(y => y.SousReferenceId == sousReferenceId))
                                        .ProjectTo<MarqueLightDto>(Mapper.ConfigurationProvider);
            }

            return (await DbContext.Marques.Where(x => x.MarqueSousReferenceReferences.Any(y => y.ReferenceId == referenceId))
                                           .ProjectTo<MarqueLightDto>(Mapper.ConfigurationProvider)
                                           .ToListAsync(cancellationToken))
                                               .DistinctBy(x => x.IdMarque)
                                               .AsQueryable();
        }

        public IQueryable<MarqueReferenceLibreDto> GetMarqueReferenceLibresByTypeEtMarqueId(EnumTypeMarqueReferenceLibre type, Guid marqueId)
        {
            return DbContext.MarqueReferenceLibres.Where(x => x.MarqueId == marqueId)
                                                  .Where(x => x.Type == type)
                                                  .ProjectTo<MarqueReferenceLibreDto>(Mapper.ConfigurationProvider);
        }

        public async Task<Guid> InsertMarqueReferenceLibreAsync(MarqueReferenceLibreDto marqueReferenceLibre, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueReferenceLibre.IdMarque, cancellationToken);
            CheckChampsRequiredMarqueReferenceLibre(marqueReferenceLibre);

            MarqueReferenceLibre nouvelleMarqueReferenceLibre = Mapper.Map<MarqueReferenceLibre>(marqueReferenceLibre);
            await DbContext.MarqueReferenceLibres.AddAsync(nouvelleMarqueReferenceLibre, cancellationToken);

            await MajDateMajMarqueAsync(nouvelleMarqueReferenceLibre.MarqueId, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return nouvelleMarqueReferenceLibre.Id;
        }

        public async Task UpdateMarqueReferenceLibreAsync(MarqueReferenceLibreDto marqueReferenceLibreModifiee, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueReferenceLibreModifiee.IdMarque, cancellationToken);
            CheckChampsRequiredMarqueReferenceLibre(marqueReferenceLibreModifiee);
            if (!marqueReferenceLibreModifiee.IsModifiable)
            {
                throw new BusinessException(BusinessExceptionsResources.ELEMENT_NON_MODIFIABLE);
            }

            MarqueReferenceLibre marqueReferenceLibre = await DbContext.MarqueReferenceLibres.AsTracking().SingleAsync(x => x.Id == marqueReferenceLibreModifiee.Id, cancellationToken);
            marqueReferenceLibre.Texte = marqueReferenceLibreModifiee.Texte;
            marqueReferenceLibre.TexteTransLitLowerFr = StringsHelpers.HtmlToPlainText(marqueReferenceLibreModifiee.Texte).Transliterate().ToLower();

            await MajDateMajMarqueAsync(marqueReferenceLibreModifiee.IdMarque, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task DeleteMarqueReferenceLibreAsync(Guid marqueReferenceLibreId, Guid marqueId, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            MarqueReferenceLibre marqueReferenceLibreASupprimer = await DbContext.MarqueReferenceLibres.AsTracking().SingleAsync(x => x.Id == marqueReferenceLibreId, cancellationToken);
            DbContext.MarqueReferenceLibres.Remove(marqueReferenceLibreASupprimer);

            await MajDateMajMarqueAsync(marqueId, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private static void CheckChampsRequiredMarqueReferenceLibre(MarqueReferenceLibreDto marqueReferenceLibre)
        {
            if (string.IsNullOrWhiteSpace(marqueReferenceLibre.Texte))
            {
                throw new BusinessException(BusinessExceptionsResources.TEXTE_MARQUE_REFERENCE_LIBRE_REQUIRED);
            }
        }
    }
}
