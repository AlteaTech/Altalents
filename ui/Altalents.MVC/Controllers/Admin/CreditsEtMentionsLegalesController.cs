using Altalents.Entities.Enum;

namespace Altalents.MVC.Controllers.Admin
{
    public class CreditsEtMentionsLegalesController : AdminController
    {
        public static string ControllerName = "CreditsEtMentionsLegales";
        private readonly ITexteDiversService _texteDiversService;

        public CreditsEtMentionsLegalesController(ITexteDiversService texteDiversService, ILogger<CreditsEtMentionsLegalesController> logger) : base(logger)
        {
            _texteDiversService = texteDiversService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            List<TexteDiversDto> textesDivers = await _texteDiversService.GetTextesDiversByTypeAsync(EnumTypeTexteDivers.CreditsEtMentionsLegales);
            return View("Index", textesDivers.Single());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCreditsEtMentionsLegalesAsync([DataSourceRequest] DataSourceRequest request, Guid creditsEtMentionsLegalesId, string titreFr, string detailFr, string titreEn, string detailEn)
        {
            TexteDiversDto texteDivers = new()
            {
                Id = creditsEtMentionsLegalesId,
                TitreFr = titreFr,
                DetailFr = detailFr,
                TitreEn = titreEn,
                DetailEn = detailEn
            };
            return await this.CallWithActionSecurisedAsync(request, UpdateCreditsEtMentionsLegalesRunnerAsync(texteDivers));
        }

        private async Task<IActionResult> UpdateCreditsEtMentionsLegalesRunnerAsync(TexteDiversDto texteDivers)
        {
            await _texteDiversService.UpdateTexteDiversAsync(texteDivers);
            return Json(new[] { texteDivers });
        }
    }
}
