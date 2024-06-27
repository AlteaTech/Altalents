using Altalents.Commun.Enums;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Altalents.MVC.Controllers.Admin
{
    public class TableauDeBordController : AdminController
    {
        public static string ControllerName = "TableauDeBord";

        public TableauDeBordController(ILogger<TableauDeBordController> logger) : base(logger)
        {
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            ViewData["isTableauDeBord"] = true;
            return View();
        }
    }
}
