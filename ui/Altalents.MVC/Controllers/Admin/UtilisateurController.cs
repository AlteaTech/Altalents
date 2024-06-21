namespace Altalents.MVC.Controllers.Admin
{
    public class UtilisateurController : AdminController
    {
        public static string ControllerName = "Utilisateur";
        private readonly IUtilisateurService _utilisateurService;

        public UtilisateurController(IUtilisateurService utilisateurService, ILogger<UtilisateurController> logger) : base(logger)
        {
            _utilisateurService = utilisateurService;
        }

        public IActionResult Index()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            ViewData["isUtilisateur"] = true;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUtilisateurAsync([DataSourceRequest] DataSourceRequest request, UtilisateurDto utilisateur)
        {
            return await this.CallWithActionSecurisedAsync(request, CreateUtilisateurRunnerAsync(request, utilisateur));
        }

        public async Task<IActionResult> GetUtilisateursAsync([DataSourceRequest] DataSourceRequest request)
        {
            return await this.CallWithActionSecurisedAsync(request, GetUtilisateursRunnerAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUtilisateurAsync([DataSourceRequest] DataSourceRequest request, UtilisateurDto utilisateur)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateUtilisateurRunnerAsync(request, utilisateur));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUtilisateurAsync([DataSourceRequest] DataSourceRequest request, Guid utilisateurId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteUtilisateurRunnerAsync(request, utilisateurId));
        }

        private async Task<IActionResult> CreateUtilisateurRunnerAsync(DataSourceRequest request, UtilisateurDto utilisateur)
        {
            return Json(new[] { await _utilisateurService.InsertUtilisateurAsync(utilisateur) }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> GetUtilisateursRunnerAsync(DataSourceRequest request)
        {
            DataSourceResult utilisateurs = await _utilisateurService.GetUtilisateursActifs().ToDataSourceResultAsync(request);
            return base.Json(utilisateurs);
        }

        private async Task<IActionResult> UpdateUtilisateurRunnerAsync(DataSourceRequest request, UtilisateurDto utilisateur)
        {
            await _utilisateurService.UpdateUtilisateurAsync(utilisateur);
            return Json(new[] { utilisateur }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> DeleteUtilisateurRunnerAsync(DataSourceRequest request, Guid utilisateurId)
        {
            await _utilisateurService.DeleteUtilisateurAsync(utilisateurId);
            return Json(new[] { utilisateurId }.ToDataSourceResultAsync(request));
        }
    }
}
