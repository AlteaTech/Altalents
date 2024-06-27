namespace Altalents.MVC.Controllers.Admin
{
    public class UpdateCandidatController : AdminController
    {
        public static string ControllerName = "UpdateCandidat";

        public UpdateCandidatController(ILogger<UpdateCandidatController> logger) : base(logger)
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
            ViewData["isUpdateCandidat"] = true;
            return View();
        }
    }
}
