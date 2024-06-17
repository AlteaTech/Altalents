namespace Altalents.MVC.Controllers.Admin
{
    public class PublicationController : AdminController
    {
        public static string ControllerName = "Publication";
        private readonly IMarqueService _marqueService;

        public PublicationController(IMarqueService marqueService, ILogger<PublicationController> logger) : base(logger)
        {
            _marqueService = marqueService;
        }

        public async Task<IActionResult> IndexAsync(CancellationToken cancellationToken = default)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            PublicationIndexModel model = new PublicationIndexModel()
            {
                MarqueNonPubliees = await _marqueService.GetMarquesNonPublieesAsync(cancellationToken)
            };
            return View("Index", model);
        }

        public async Task<ContentResult> PublierAsync()
        {
            string fileData = Convert.ToBase64String(await _marqueService.PublierAsync());
            return Content(fileData);
        }
    }
}
