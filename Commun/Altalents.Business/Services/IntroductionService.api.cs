using Altalents.IBusiness.Enums;

namespace Altalents.Business.Services
{
    public partial class IntroductionService : BaseAppService<CustomDbContext>, IIntroductionService
    {
        public async Task<List<IntroductionByLangueDto>> GetIntroductionsByLangueAsync(EnumLangue langue, CancellationToken cancellationToken = default)
        {
            IQueryable<IntroductionDto> introductions = DbContext.Introductions.ProjectTo<IntroductionDto>(Mapper.ConfigurationProvider);
            List<IntroductionByLangueDto> introductionsByLangue = new();

            switch (langue)
            {
                case EnumLangue.Français:
                default:
                {
                    introductions = introductions.OrderBy(x => x.OrdreFr).ThenBy(x => x.TitreFr);
                    await introductions.ForEachAsync(x => introductionsByLangue.Add(new()
                    {
                        Id = x.Id,
                        Titre = x.TitreFr,
                        Detail = x.DetailFr
                    }), cancellationToken);
                    break;
                }
                case EnumLangue.SecondeLangue:
                {
                    introductions = introductions.OrderBy(x => x.OrdreEn).ThenBy(x => x.TitreEn);
                    await introductions.ForEachAsync(x => introductionsByLangue.Add(new()
                    {
                        Id = x.Id,
                        Titre = x.TitreEn,
                        Detail = x.DetailEn
                    }), cancellationToken);
                    break;
                }
            };
            return introductionsByLangue;
        }
    }
}
