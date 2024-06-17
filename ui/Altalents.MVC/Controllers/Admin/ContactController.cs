using Altalents.Entities.Enum;

namespace Altalents.MVC.Controllers.Admin
{
    public class ContactController : AdminController
    {
        public static string ControllerName = "Contact";
        private readonly ITexteDiversService _texteDiversService;

        public ContactController(ITexteDiversService texteDiversService, ILogger<ContactController> logger) : base(logger)
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
            List<TexteDiversDto> textesDivers = await _texteDiversService.GetTextesDiversByTypeAsync(EnumTypeTexteDivers.Contact);
            return View("Index", textesDivers.Single());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContactAsync([DataSourceRequest] DataSourceRequest request, Guid contactId, string detailFr, string detailEn, string titreFr, string titreEn)
        {
            TexteDiversDto texteDivers = new()
            {
                Id = contactId,
                DetailFr = detailFr,
                DetailEn = detailEn,
                TitreFr = titreFr,
                TitreEn = titreEn
            };
            return await this.CallWithActionSecurisedAsync(request, UpdateContactRunnerAsync(texteDivers));
        }

        private async Task<IActionResult> UpdateContactRunnerAsync(TexteDiversDto texteDivers)
        {
            await _texteDiversService.UpdateTexteDiversAsync(texteDivers);
            return Json(new[] { texteDivers });
        }
    }
}
