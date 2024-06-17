using Altalents.Entities.Enum;
using Altalents.IBusiness.Enums;

namespace Altalents.Business.Services
{
    public partial class TexteDiversService : BaseAppService<CustomDbContext>, ITexteDiversService
    {
        public async Task<List<TexteDiversByLangueDto>> GetTextesDiversByLangueByTypeAsync(EnumLangue langue, EnumTypeTexteDivers typeTexteDivers, CancellationToken cancellationToken = default)
        {
            IQueryable<TexteDiversDto> textesDivers = DbContext.TexteDivers.Where(w => w.Type == typeTexteDivers).ProjectTo<TexteDiversDto>(Mapper.ConfigurationProvider);
            List<TexteDiversByLangueDto> textesDiversByLangue = new();

            switch (langue)
            {
                case EnumLangue.Français:
                default:
                {
                    textesDivers = textesDivers.OrderBy(x => x.TitreFr);
                    await textesDivers.ForEachAsync(x => textesDiversByLangue.Add(new()
                    {
                        Id = x.Id,
                        Titre = x.TitreFr,
                        Detail = x.DetailFr
                    }), cancellationToken);
                    break;
                }
                case EnumLangue.SecondeLangue:
                {
                    textesDivers = textesDivers.OrderBy(x => x.TitreEn);
                    await textesDivers.ForEachAsync(x => textesDiversByLangue.Add(new()
                    {
                        Id = x.Id,
                        Titre = x.TitreEn,
                        Detail = x.DetailEn
                    }), cancellationToken);
                    break;
                }
            };
            return textesDiversByLangue;
        }
    }
}
