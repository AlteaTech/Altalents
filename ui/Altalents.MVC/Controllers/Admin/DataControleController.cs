namespace Altalents.MVC.Controllers.Admin
{
    public class DataControleController : AdminController
    {
        public static string ControllerName = "DataControle";

        public DataControleController(ILogger<DataControleController> logger) : base(logger)
        {
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
    }
}
