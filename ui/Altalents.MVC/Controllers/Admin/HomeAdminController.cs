namespace Altalents.MVC.Controllers
{
    public class HomeAdminController : Controller
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerHomeAdmin;
        private readonly ILogger<HomeAdminController> _logger;

        public HomeAdminController(ILogger<HomeAdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PartialViewLoadingDialog()
        {
            return base.PartialView("PartialViewLoadingDialog");
        }
    }
}
