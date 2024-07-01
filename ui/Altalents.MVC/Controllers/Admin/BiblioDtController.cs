namespace Altalents.MVC.Controllers.Admin
{
    public class BiblioDtController : AdminController
    {
        public static string ControllerName = "BiblioDt";
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

        private async Task<IActionResult> GetBiblioDtsRunnerAsync(DataSourceRequest request)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetBibliothequeDossierTechniques().ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }
    }
}
