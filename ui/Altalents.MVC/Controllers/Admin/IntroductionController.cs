namespace Altalents.MVC.Controllers.Admin
{
    public class IntroductionController : AdminController
    {
        public static string ControllerName = "Introduction";
        private readonly IIntroductionService _introductionService;

        public IntroductionController(IIntroductionService introductionService, ILogger<IntroductionController> logger) : base(logger)
        {
            _introductionService = introductionService;
        }

        public async Task<IActionResult> IndexAsync([FromQuery] Guid? introductionId)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }

            var model = new IntroductionIndexModel()
            {
                IntroductionId = introductionId,
                Introductions = await _introductionService.GetIntroductionsAsync()
            };
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult PartialViewAddIntroduction()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            return base.PartialView("PartialViewAddIntroduction");
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewDetailIntroductionAsync(Guid introductionId)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            IntroductionDto introduction = await _introductionService.GetIntroductionByIdAsync(introductionId);
            return base.PartialView("PartialViewDetailIntroduction", introduction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIntroductionAsync([DataSourceRequest] DataSourceRequest request, IntroductionDto introduction)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            Guid introId = await _introductionService.InsertIntroductionAsync(introduction);
            return new RedirectResult(url: $"/Admin/{ControllerName}/Index?introductionId={introId}", permanent: true,
                            preserveMethod: false);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIntroductionAsync([DataSourceRequest] DataSourceRequest request, Guid introductionId, string titreFr, string detailFr, string titreEn, string detailEn, int ordreFr, int ordreEn)
        {
            IntroductionDto introduction = new()
            {
                Id = introductionId,
                OrdreFr = ordreFr,
                OrdreEn = ordreEn,
                TitreFr = titreFr,
                DetailFr = detailFr,
                TitreEn = titreEn,
                DetailEn = detailEn
            };
            return await this.CallWithActionSecurisedAsync(request, UpdateIntroductionRunnerAsync(introduction));
        }

        private async Task<IActionResult> UpdateIntroductionRunnerAsync(IntroductionDto introduction)
        {
            await _introductionService.UpdateIntroductionAsync(introduction);
            return Json(new[] { introduction });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteIntroductionAsync([DataSourceRequest] DataSourceRequest request, Guid introductionId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteIntroductionRunnerAsync(request, introductionId));
        }

        private async Task<IActionResult> DeleteIntroductionRunnerAsync(DataSourceRequest request, Guid introductionId)
        {
            await _introductionService.DeleteIntroductionAsync(introductionId);
            return Json(new[] { introductionId }.ToDataSourceResultAsync(request));
        }
    }
}
