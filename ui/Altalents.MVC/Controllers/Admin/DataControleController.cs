namespace Altalents.MVC.Controllers.Admin
{
    public class DataControleController : AdminController
    {
        public static string ControllerName = "DataControle";
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

        public async Task<IActionResult> GetReferencesAsync([DataSourceRequest] DataSourceRequest request, bool showAll)
        {
            return await this.CallWithActionSecurisedAsync(request, GetReferencesRunnerAsync(request, showAll));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReferenceAsync([DataSourceRequest] DataSourceRequest request, ReferenceAValiderDto reference)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateReferenceRunnerAsync(request, reference));
        }

        private async Task<IActionResult> GetReferencesRunnerAsync(DataSourceRequest request, bool showAll)
        {
            DataSourceResult references = await _referencesService.GetReferencesAValider(showAll).ToDataSourceResultAsync(request);
            return base.Json(references);
        }

        private async Task<IActionResult> UpdateReferenceRunnerAsync(DataSourceRequest request, ReferenceAValiderDto reference)
        {
            await _referencesService.UpdateReferenceAsync(reference);
            return Json(new[] { reference }.ToDataSourceResult(request));
        }
    }
}
