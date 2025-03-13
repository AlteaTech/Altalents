namespace Altalents.MVC.Controllers.Admin
{
    public class DataControleController : AdminController
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerDataControle;
        private readonly IReferencesService _referencesService;

        public DataControleController(IReferencesService referencesService, ILogger<DataControleController> logger) : base(logger)
        {
            _referencesService = referencesService;
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            ViewData["isDataControle"] = true;
            return View();
        }

        public async Task<IActionResult> GetReferencesAsync([DataSourceRequest] DataSourceRequest request, bool showOnlyDataAValider)
        {
            return await this.CallWithActionSecurisedAsync(request, GetReferencesRunnerAsync(request, !showOnlyDataAValider));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReferenceAsync([DataSourceRequest] DataSourceRequest request, ReferenceRequestDto reference)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateReferenceRunnerAsync(request, reference));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReferenceAsync([DataSourceRequest] DataSourceRequest request, Guid refId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteReferenceRunnerAsync(request, refId));
        }


        private async Task<IActionResult> GetReferencesRunnerAsync(DataSourceRequest request, bool showAll)
        {
            DataSourceResult references = await _referencesService.GetReferencesAValider(showAll).ToDataSourceResultAsync(request);
            return base.Json(references);
        }

        private async Task<IActionResult> UpdateReferenceRunnerAsync(DataSourceRequest request, ReferenceRequestDto reference)
        {
            await _referencesService.UpdateReferenceAsync(reference, CancellationToken.None);
            return Json(new[] { reference }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> DeleteReferenceRunnerAsync(DataSourceRequest request, Guid refId)
        {
            await _referencesService.DeleteReference(refId, CancellationToken.None);
            return Json(new[] { refId }.ToDataSourceResultAsync(request));
        }

    }
}
