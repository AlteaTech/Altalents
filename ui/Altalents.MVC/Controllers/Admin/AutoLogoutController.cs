namespace Altalents.MVC.Controllers.Admin
{
    public class AutoLogoutController : Controller
    {
        private readonly ILogger<AutoLogoutController> _logger;

        public AutoLogoutController(ILogger<AutoLogoutController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Redirect()
        {
            return View();
        }
    }
}
