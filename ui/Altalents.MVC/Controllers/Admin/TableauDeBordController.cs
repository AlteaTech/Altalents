using System.Threading;
using Altalents.Commun.Enums;
using Altalents.Entities;
using Altalents.MVC.Extension;

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

        [HttpPost]
        public async Task<IActionResult> UpdateStatutAsync([DataSourceRequest] DataSourceRequest request, Guid id, Guid statutId)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateStatutRunnerAsync(request, id, statutId));
        }


        public async Task<IActionResult> GetDtsEnCoursLimitedRealAsync([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetDtsEnCoursLimitedRunnerAsync(request, EtatFiltreDtEnum.InProgress));
        }

        public async Task<IActionResult> GetDtsAControllerLimitedRealAsync([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetDtsEnCoursLimitedRunnerAsync(request, EtatFiltreDtEnum.AController));
        }

        private async Task<IActionResult> GetDtsEnCoursLimitedRunnerAsync(DataSourceRequest request, EtatFiltreDtEnum etat)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetDtsEnCours(etat).Take(6).ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }

        private async Task<IActionResult> UpdateStatutRunnerAsync(DataSourceRequest request, Guid id, Guid statutId)
        {

            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, CancellationToken.None);
            return Json(new[] { id }.ToDataSourceResultAsync(request));

        }
    }
}
