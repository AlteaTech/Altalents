using System.Threading;
using Altalents.Commun.Enums;
using Altalents.Commun.Settings;
using Altalents.Entities;
using Altalents.MVC.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Altalents.MVC.Controllers.Admin
{
    public class TableauDeBordController : AdminController
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerTableauDeBord;
        private readonly IDossierTechniqueService _dossierTechniqueService;
        public readonly GlobalSettings _globalSettings;


        public TableauDeBordController(ILogger<TableauDeBordController> logger, IDossierTechniqueService dossierTechniqueService, IOptionsMonitor<GlobalSettings> globalSettings) : base(logger)
        {
            _dossierTechniqueService = dossierTechniqueService;
            _globalSettings = globalSettings.CurrentValue;
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

        //[HttpPost]
        //public async Task<IActionResult> UpdateStatutAsync([DataSourceRequest] DataSourceRequest request, Guid id, Guid statutId)
        //{
        //    return await this.CallWithActionSecurisedAsync(request, UpdateStatutRunnerAsync(request, id, statutId));
        //}

        public async Task<IActionResult> GetDtsCreesLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetLastsDtByEtatLimitedRunnerAsync(request, CodeReferenceEnum.Cree));
        }

        public async Task<IActionResult> GetDtsAValiderLimitedReal([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetLastsDtByEtatLimitedRunnerAsync(request, CodeReferenceEnum.AValider));
        }

        private async Task<IActionResult> GetLastsDtByEtatLimitedRunnerAsync(DataSourceRequest request, CodeReferenceEnum statutsCode)
        {

            IQueryable<DossierTechniqueForAdminDto> query = _dossierTechniqueService.GetQueryDtForKendoUi();

            query = query.Where(e => e.StatutCode == statutsCode.ToString());
            query = query.OrderByDescending(e => e.DateUpdate);
            query = query.Take(8);

            DataSourceResult bibliothequeDossierTechniques = await query.ToDataSourceResultAsync(request);

           return base.Json(bibliothequeDossierTechniques);
        }

        //private async Task<IActionResult> UpdateStatutRunnerAsync(DataSourceRequest request, Guid id, Guid statutId)
        //{
        //    await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, CancellationToken.None);
        //    return Json(new[] { id }.ToDataSourceResultAsync(request));

        //}
    }
}
