using AlteaTools.Api.Core.Extensions;

using AnyAscii;

using Altalents.Entities.Enum;

namespace Altalents.Business.Extensions
{
    public static class IQueryableMarqueExtension
    {
        public static IQueryable<Marque> ApplyFilterNom(this IQueryable<Marque> query, Guid? nomId, string nomFullText)
        {
            if (nomId.HasValue)
            {
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.Reference.TypeReferenceId == EnumTypeReference.Nom.GetBddId()
                                                                          && y.ReferenceId == nomId));
            }
            else if (!string.IsNullOrEmpty(nomFullText))
            {
                nomFullText = nomFullText.Transliterate();
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.Reference.TypeReferenceId == EnumTypeReference.Nom.GetBddId()
                                                                          && (y.Reference.LibelleTransLitLowerFr.Contains(nomFullText.ToLower()) || y.Reference.LibelleTransLitLower2.Contains(nomFullText.ToLower()))));
            }
            return query;
        }

        public static IQueryable<Marque> ApplyFilterLieu(this IQueryable<Marque> query, Guid? lieuId, string lieuFullText)
        {
            if (lieuId.HasValue)
            {
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.Reference.TypeReferenceId == EnumTypeReference.Pays.GetBddId()
                                                                          && (y.ReferenceId == lieuId || y.SousReferenceId == lieuId)));
            }
            else if (!string.IsNullOrEmpty(lieuFullText))
            {
                lieuFullText = lieuFullText.Transliterate();
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.Reference.TypeReferenceId == EnumTypeReference.Pays.GetBddId()
                                                                          && (y.Reference.LibelleTransLitLowerFr.Contains(lieuFullText.ToLower()) || y.Reference.LibelleTransLitLower2.Contains(lieuFullText.ToLower()) ||
                                                                            y.SousReference.LibelleTransLitLowerFr.ToLower().Contains(lieuFullText.ToLower()) || y.SousReference.LibelleTransLitLower2.Contains(lieuFullText.ToLower()))));
            }
            return query;
        }

        public static IQueryable<Marque> ApplyFilterReferences(this IQueryable<Marque> query, ReferenceRechercheRequestDto referenceRechercheRequestDto)
        {
            if ((referenceRechercheRequestDto?.ReferenceId).HasValue)
            {
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.ReferenceId == referenceRechercheRequestDto.ReferenceId));
            }
            if ((referenceRechercheRequestDto?.SousReferenceId).HasValue)
            {
                query = query.Where(x => x.MarqueSousReferenceReferences.Any(y => y.SousReferenceId == referenceRechercheRequestDto.SousReferenceId));
            }

            if (referenceRechercheRequestDto?.ReferenceId == EnumReference.Initiale.GetBddId() && !string.IsNullOrEmpty(referenceRechercheRequestDto.Texte))
            {

                List<string> all = referenceRechercheRequestDto.Texte.Where(Char.IsLetter)
                    .Select(x => x.ToString().ToLower().Transliterate())
                    .ToList();

                List<string> lowerInitiales = referenceRechercheRequestDto.Texte.Where(Char.IsLetter)
                    .Select(x => x.ToString().ToLower().Transliterate())
                    .Distinct()
                    .ToList();

                foreach (string initiale in lowerInitiales)
                {
                    int countInitialeRecherche = all.Count(x => x == initiale);
                    string initialeTransliterate = initiale;
                    query = query.Where(x => x.VueMarqueInitialesSearchs.Any(marqueReferenceLibre => initialeTransliterate == marqueReferenceLibre.TexteTransLitLowerFr && marqueReferenceLibre.Total >= countInitialeRecherche));
                }
            }

            if (referenceRechercheRequestDto?.ReferenceId == EnumReference.Mot.GetBddId() && !string.IsNullOrEmpty(referenceRechercheRequestDto.Texte))
            {
                List<string> motRecherches = referenceRechercheRequestDto.Texte.ToLower().Split(' ').ToList();
                motRecherches.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                motRecherches = motRecherches.Distinct().ToList();

                foreach (string motRecherche in motRecherches)
                {
                    string motRechercheTransliterate = motRecherche.Transliterate();
                    query = query.Where(x => x.MarqueReferenceLibres.Any(marqueReferenceLibre => marqueReferenceLibre.Type == EnumTypeMarqueReferenceLibre.MotLatin && marqueReferenceLibre.TexteTransLitLowerFr.Contains(motRechercheTransliterate)));
                }
            }

            return query;
        }
    }
}
