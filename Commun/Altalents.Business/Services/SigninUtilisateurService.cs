using AlteaTools.Application.Core.Helper;
using AlteaTools.Session;
using AlteaTools.Session.Dto;
using AlteaTools.Session.Extension;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Altalents.Business.Services
{
    public class SigninUtilisateurService : SignInManager<Utilisateur>
    {
        public IMapper Mapper { get; }
        private readonly CustomDbContext _dbContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public SigninUtilisateurService(CustomDbContext dbContext, IMapper mapper,
            UserManager<Utilisateur> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<Utilisateur> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<Utilisateur>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<Utilisateur> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
            this.Mapper = mapper;
            _dbContext = dbContext;
            _contextAccessor = contextAccessor;
        }

        public override async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(string login, string motDePasse, bool isPersistent, bool lockoutOnFailure)
        {
            bool isConnectable = false;
            string mdpCrypte = MotDePasseHelper.GetHashedMotDePasse(motDePasse);
            UtilisateurDto utilisateur = await _dbContext.Utilisateurs.Where(x => x.Email == login)
                                                                      .Where(x => x.IsActif)
                                                                      .ProjectTo<UtilisateurDto>(Mapper.ConfigurationProvider)
                                                                      .SingleOrDefaultAsync();

            if (utilisateur != null)
            {
                isConnectable = MotDePasseHelper.VerifyHashedMotDePasse(utilisateur.MotDePasse, motDePasse);
                if (isConnectable)
                {
                    _contextAccessor.HttpContext.Session.Set(SessionKeyConstantes.IsLogged, true);
                    _contextAccessor.HttpContext.Session.Set(SessionKeyConstantes.UserLogged, new UserLoggedDto()
                    {
                        Nom = utilisateur.Nom,
                        Login = utilisateur.Email
                    });
                }
            }

            return new CustomSignInResult(!isConnectable, !isConnectable, false, isConnectable);
        }
    }
}
