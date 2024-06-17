using Altalents.Entities.Enum;

namespace Altalents.Business.Services
{
    public partial class TexteDiversService : BaseAppService<CustomDbContext>, ITexteDiversService
    {
        public TexteDiversService(
            ILogger<TexteDiversService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
        }

        public async Task<List<TexteDiversDto>> GetTextesDiversByTypeAsync(EnumTypeTexteDivers type, CancellationToken cancellationToken = default)
        {
            return await DbContext.TexteDivers
                            .Where(w => w.Type == type)
                            .OrderBy(x => x.TitreFr)
                            .ProjectTo<TexteDiversDto>(Mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
        }

        public async Task UpdateTexteDiversAsync(TexteDiversDto texteDiversModifie, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<TexteDivers>.CheckIdExistAsync(DbContext.TexteDivers, texteDiversModifie.Id, cancellationToken);
            TexteDivers texteDivers = await DbContext.TexteDivers.AsTracking()
                                                                 .SingleAsync(x => x.Id == texteDiversModifie.Id, cancellationToken);

            if (texteDiversModifie.TitreFr != null && texteDiversModifie.TitreEn != null)
            {
                texteDivers.TitreFr = texteDiversModifie.TitreFr;
                texteDivers.TitreEn = texteDiversModifie.TitreEn;
            }
            texteDivers.DetailFr = texteDiversModifie.DetailFr;
            texteDivers.DetailEn = texteDiversModifie.DetailEn;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }
    }
}
