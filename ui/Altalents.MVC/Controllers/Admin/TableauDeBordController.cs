using System.Threading;
using Altalents.Commun.Enums;
using Altalents.Entities;
using Altalents.MVC.Extension;

namespace Altalents.MVC.Controllers.Admin
{
    public class TableauDeBordController : AdminController
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerTableauDeBord;
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



        public async Task<IActionResult> GetDtsCreesLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetLastsDtByEtatLimitedRunnerAsync(request, EtatFiltreDtEnum.Cree));
        }

        public async Task<IActionResult> GetDtsAValiderLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetLastsDtByEtatLimitedRunnerAsync(request, EtatFiltreDtEnum.AValider));
        }

        public async Task<IActionResult> GetDtsTermineesLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetLastsDtByEtatLimitedRunnerAsync(request, EtatFiltreDtEnum.Terminee));
        }


        
        private async Task<IActionResult> GetLastsDtByEtatLimitedRunnerAsync(DataSourceRequest request, EtatFiltreDtEnum etat)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetDtsByStatus(etat, 8).ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }

        private async Task<IActionResult> UpdateStatutRunnerAsync(DataSourceRequest request, Guid id, Guid statutId)
        {

            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, CancellationToken.None);
            return Json(new[] { id }.ToDataSourceResultAsync(request));

        }
    }
}
