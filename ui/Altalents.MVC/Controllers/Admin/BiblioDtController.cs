namespace Altalents.MVC.Controllers.Admin
{
    public class BiblioDtController : AdminController
    {
        public static string ControllerName = "BiblioDt";

        public BiblioDtController(ILogger<BiblioDtController> logger) : base(logger)
        {
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
    }
}
