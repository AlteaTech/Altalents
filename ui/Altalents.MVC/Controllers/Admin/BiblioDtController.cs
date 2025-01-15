namespace Altalents.MVC.Controllers.Admin
{
    public class BiblioDtController : AdminController
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerBiblioDt;
        private readonly IDossierTechniqueService _dossierTechniqueService;

        public BiblioDtController(IDossierTechniqueService dossierTechniqueService, ILogger<BiblioDtController> logger) : base(logger)
        {
            _dossierTechniqueService = dossierTechniqueService;
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            ViewData["isGestionDt"] = true;
            ViewData["isBiblioDT"] = true;
            return View();
        }

        public async Task<IActionResult> GetBiblioDtsAsync([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetBiblioDtsRunnerAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatutAsync([DataSourceRequest] DataSourceRequest request, Guid id, Guid statutId)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateStatutRunnerAsync(request, id, statutId));
        }


        private async Task<IActionResult> UpdateStatutRunnerAsync(DataSourceRequest request, Guid id, Guid statutId)
        {

            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, CancellationToken.None);
            return Json(new[] { id }.ToDataSourceResultAsync(request));

        }

        private async Task<IActionResult> GetBiblioDtsRunnerAsync(DataSourceRequest request)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetQueryDtForKendoUi().ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }
    }
}
