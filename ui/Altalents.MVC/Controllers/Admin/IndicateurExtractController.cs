namespace Altalents.MVC.Controllers.Admin
{
    public class IndicateurExtractController : AdminController
    {
        public static string ControllerName = "IndicateurExtract";

        public IndicateurExtractController(ILogger<IndicateurExtractController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            ViewData["isIndicateurExtract"] = true;
            return View();
        }
    }
}
