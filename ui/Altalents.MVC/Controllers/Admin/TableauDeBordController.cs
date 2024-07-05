using Altalents.Commun.Enums;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Altalents.MVC.Controllers.Admin
{
    public class TableauDeBordController : AdminController
    {
        public static string ControllerName = "TableauDeBord";
        private readonly IDossierTechniqueService _dossierTechniqueService;

        public TableauDeBordController(ILogger<TableauDeBordController> logger, IDossierTechniqueService dossierTechniqueService) : base(logger)
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
            ViewData["isTableauDeBord"] = true;
            return View();
        }

        public async Task<IActionResult> GetDtsEnCoursLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetDtsEnCoursLimitedRunnerAsync(request, EnumEtatFiltreDt.InProgress));
        }
        public async Task<IActionResult> GetDtsAControllerLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetDtsEnCoursLimitedRunnerAsync(request, EnumEtatFiltreDt.AController));
        }

        private async Task<IActionResult> GetDtsEnCoursLimitedRunnerAsync(DataSourceRequest request, EnumEtatFiltreDt etat)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetDtsEnCours(etat).Take(6).ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }
    }
}
