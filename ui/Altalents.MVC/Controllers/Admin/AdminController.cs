using System.Globalization;

using Altalents.MVC.Constantes;

using AlteaTools.Session;
using AlteaTools.Session.Dto;
using AlteaTools.Session.Extension;

namespace Altalents.MVC.Controllers.Admin
{
    public class AdminController : Controller
    {
        protected readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;

            CultureInfo ci = new CultureInfo("fr-FR");

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public IActionResult? GetNotLoggedReturnPage()
        {
            string returnUrl = Url.Content(RedirectionConstantes.ForceLogout);
            bool isLogged = GetIsLogged();
            _logger.LogInformation("User not logged in.");
            if (!isLogged)
            {
                return LocalRedirect(returnUrl);
            }
            return null;
        }

        protected bool GetIsLogged()
        {
            return HttpContext.Session.Get<bool>(SessionKeyConstantes.IsLogged) &&
                HttpContext.Session.Get<UserLoggedDto>(SessionKeyConstantes.UserLogged) != null;
        }
    }
}
