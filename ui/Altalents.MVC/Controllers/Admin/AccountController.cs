using Altalents.Entities;
using Altalents.MVC.Constantes;

using AlteaTools.Session;
using AlteaTools.Session.Dto;
using AlteaTools.Session.Extension;

using Microsoft.AspNetCore.Identity;

namespace Altalents.MVC.Controllers.Admin
{
    public class AccountController : AdminController
    {
        public static string ControllerName = RoutesNamesConstantes.MvcControllerAccount;
        private readonly SignInManager<Utilisateur> _signInManager;
        private readonly IUtilisateurService _utilisateurService;
        private readonly ILogger<LoginModel> _loggerLogin;

        public AccountController(SignInManager<Utilisateur> signInManager, IUtilisateurService utilisateurService, ILogger<AccountController> logger, ILogger<LoginModel> loggerLogin) : base(logger)
        {
            _signInManager = signInManager;
            _loggerLogin = loggerLogin;
            _utilisateurService = utilisateurService;
        }

        // GET: AccountController
        public ActionResult Login(string? errorMessage = null)
        {
            if (!GetIsLogged())
            {
                try
                {
                    LoginModel model = new(_signInManager, _loggerLogin)
                    {
                        ErrorMessage = errorMessage
                    };
                    return View("Login", model);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                string returnUrl = Url.Content(RedirectionConstantes.LoggedHome);
                return LocalRedirect(returnUrl);
            }
        }
        // GET: AccountController
        public ActionResult MdpOublie(string? errorMessage = null)
        {
                try
                {
                    return View("MdpOublie", new RegenMdpDto());
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        // GET: AccountController
        public ActionResult Index()
        {
            string returnUrl = Url.Content(RedirectionConstantes.LoginPage);
            return LocalRedirect(returnUrl);
        }

        // GET: AccountController
        public ActionResult LogoutAsync()
        {
            try
            {
                string returnUrl = Url.Content(RedirectionConstantes.ReLogin);
                HttpContext.Session.Set(SessionKeyConstantes.IsLogged, false);
                HttpContext.Session.Set<UserLoggedDto>(SessionKeyConstantes.UserLogged, null);
                return LocalRedirect(returnUrl);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginInputModel loginInputModel)
        {

            var ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginInputModel.Login, loginInputModel.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    string returnUrl = Url.Content(RedirectionConstantes.LoggedHome);
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
            }

            // If we got this far, something failed, redisplay form
            return Login(LibellesResources.LoginFailed);
        }

        [HttpPost]
        public async Task<IActionResult> MdpOublieAsync(RegenMdpDto regenMdpDto, CancellationToken cancellationToken)
        {
            await _utilisateurService.RegenMdpAsync(regenMdpDto, cancellationToken);
            return Login(null);
        }
    }
}
