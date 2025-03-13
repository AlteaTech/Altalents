using Altalents.IBusiness.DTO.Request;
using DocumentFormat.OpenXml.Office2010.Excel;

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

        public async Task<IActionResult> GetPrivateDataAsync([DataSourceRequest] DataSourceRequest request, Guid id)
        {
            return await this.CallWithActionSecurisedAsync(request, GetPrivateDatasRunnerAsync(request, id));
        }

        public async Task<IActionResult> UpdatePrivateDataAsync([DataSourceRequest] DataSourceRequest request, PrivatesDatasRequestDto privatesSataRequestDto)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdatePrivateDatasRunnerAsync(request, privatesSataRequestDto));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatutAsync([DataSourceRequest] DataSourceRequest request, Guid id, Guid statutId)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateStatutRunnerAsync(request, id, statutId));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDtAsync([DataSourceRequest] DataSourceRequest request, Guid dossierTechniqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteDtRunnerAsync(request, dossierTechniqueId));
        }

        private async Task<IActionResult> UpdateStatutRunnerAsync(DataSourceRequest request, Guid id, Guid statutId)
        {
            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, CancellationToken.None);
            return Json(new[] { id }.ToDataSourceResultAsync(request));
        }

        private async Task<IActionResult> GetPrivateDatasRunnerAsync(DataSourceRequest request, Guid id)
        {
            PrivatesDatasDto dtoPrivateData = await _dossierTechniqueService.GetPrivateDatasDossierTechniqueAsync(id, CancellationToken.None);
            return base.Json(dtoPrivateData);
        }

        private async Task<IActionResult> UpdatePrivateDatasRunnerAsync(DataSourceRequest request, PrivatesDatasRequestDto privatesSataRequestDto)
        {
            await _dossierTechniqueService.UpdatePrivateDatasDossierTechniqueAsync(privatesSataRequestDto, CancellationToken.None);
            return Json(new[] { privatesSataRequestDto.DtId }.ToDataSourceResultAsync(request));
        }

        private async Task<IActionResult> GetBiblioDtsRunnerAsync(DataSourceRequest request)
        {
            DataSourceResult bibliothequeDossierTechniques = await _dossierTechniqueService.GetQueryDtForKendoUi().ToDataSourceResultAsync(request);
            return base.Json(bibliothequeDossierTechniques);
        }

        private async Task<IActionResult> DeleteDtRunnerAsync(DataSourceRequest request, Guid idDossierTechnique)
        {
            await _dossierTechniqueService.DeleteDossierTechniqueAndPersonne(idDossierTechnique, CancellationToken.None);
            return Json(new[] { idDossierTechnique }.ToDataSourceResultAsync(request));
        }
    }
}
