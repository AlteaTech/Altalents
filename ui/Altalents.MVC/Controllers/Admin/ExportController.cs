namespace Altalents.MVC.Controllers.Admin
{
    public class ExportController : AdminController
    {
        public static string ControllerName = "Export";
        private readonly IMarqueService _marqueService;

        public ExportController(IMarqueService marqueService, ILogger<ExportController> logger) : base(logger)
        {
            _marqueService = marqueService;
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            return View("Index");
        }

        public async Task<ContentResult> ExporterAsync()
        {
            string fileData = Convert.ToBase64String(await _marqueService.ExporterAsync());
            return Content(fileData);
        }
    }
}
