using AlteaTools.Api.Core.Extensions;

using Altalents.Business.Helpers;
using Altalents.Commun.Helpers;
using Altalents.Entities.Enum;
using Altalents.IBusiness.DTO.Requests;

namespace Altalents.Business.Services
{
    // PARTIAL NOTICES
    public partial class MarqueService : BaseAppService<CustomDbContext>, IMarqueService
    {
        public async Task<List<NoticeMarqueDto>> GetNoticesMarquesDto(Guid idMarque, CancellationToken cancellationToken = default)
        {
            return await DbContext.MarqueNotices
                .Where(x => x.MarqueId == idMarque)
                .ProjectTo<NoticeMarqueDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateNoticesMarqueAsync(Dictionary<Guid, UpdateNoticeRequestDto> data, CancellationToken cancellationToken = default)
        {
            if (data.Any(x => string.IsNullOrWhiteSpace(x.Value.Text)))
            {
                throw new BusinessException(BusinessExceptionsResources.TEXTE_NOTICE_REQUIRED);
            }

            List<MarqueNotice> marqueNotices = await DbContext.MarqueNotices
                .Where(x => data.Keys.Contains(x.Id))
                .Include(x => x.Marque)
                .AsTracking()
                .ToListAsync(cancellationToken);

            Guid marqueId = marqueNotices.First().MarqueId;
            Marque marque = await DbContext.Marques.AsTracking().FirstAsync(x => x.Id == marqueId, cancellationToken);

            marqueNotices.ForEach(marqueNotice =>
            {
                marqueNotice.Marque.IsFinalize = true;
                marqueNotice.Texte = data[marqueNotice.Id].Text;
                marqueNotice.TexteBrut = StringsHelpers.HtmlToPlainText(data[marqueNotice.Id].Text);
                if (!marqueNotice.IsPublie && data[marqueNotice.Id].IsPublished)
                {
                    marque.DatePublication = DateTime.UtcNow;
                }
                marqueNotice.IsPublie = data[marqueNotice.Id].IsPublished;
            });

            await CheckMarqueExistAsync(marqueId, cancellationToken);
            await MajDateMajMarqueAsync(marqueId, cancellationToken);

            DateTime? datePublicationMarque = await DbContext.Marques.Where(x => x.Id == marqueId)
                                                                     .Select(x => x.DatePublication)
                                                                     .SingleAsync(cancellationToken);
            if (datePublicationMarque.HasValue)
            {
                CheckMarqueIsPubliableNotices(marqueNotices);
            }
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public async Task<Guid> InsertOngletNoticeMarqueAsync(OngletNoticeMarqueDto ongletNoticeMarque, Guid marqueId, CancellationToken cancellationToken = default)
        {
            await CheckMarqueExistAsync(marqueId, cancellationToken);
            await CheckOngletAjoutableAsync(ongletNoticeMarque, marqueId, cancellationToken);

            MarqueNotice nouvelleMarqueNotice = new()
            {
                MarqueId = marqueId,
                OngletNoticeMarqueId = EnumOngletNoticeMarque.Annee2010.GetBddId(),
            };
            await DbContext.MarqueNotices.AddAsync(nouvelleMarqueNotice, cancellationToken);

            await MajDateMajMarqueAsync(marqueId, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
            return nouvelleMarqueNotice.Id;
        }

        private async Task CheckOngletAjoutableAsync(OngletNoticeMarqueDto ongletNoticeMarque, Guid marqueId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(ongletNoticeMarque.Libelle))
            {
                throw new BusinessException(BusinessExceptionsResources.LIBELLE_ONGLET_NOTICE_MARQUE_REQUIRED);
            }

            if (ongletNoticeMarque.Ordre < 1)
            {
                throw new BusinessException(BusinessExceptionsResources.ORDRE_APPARITION_REQUIRED);
            }

            if (await DbContext.MarqueNotices.Where(x => x.MarqueId == marqueId).AnyAsync(x => x.OngletNoticeMarqueId == EnumOngletNoticeMarque.Annee2010.GetBddId(), cancellationToken))
            {
                throw new BusinessException(BusinessExceptionsResources.LIBELLE_ONGLET_NOTICE_MARQUE_EXIST);
            }
        }
    }
}
