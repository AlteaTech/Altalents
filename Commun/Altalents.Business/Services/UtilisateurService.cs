using Altalents.Commun.Settings;
using Altalents.Entities;
using Altalents.IBusiness.DTO;

using AlteaTools.Application.Core.Helper;
using AlteaTools.Session;
using AlteaTools.Session.Dto;
using AlteaTools.Session.Extension;

using DocumentFormat.OpenXml.Spreadsheet;

using Hangfire;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Altalents.Business.Services
{
    public class UtilisateurService : BaseAppService<CustomDbContext>, IUtilisateurService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmailService _emailService;
        private readonly GlobalSettings _globalSettings;

        public UtilisateurService(IHttpContextAccessor contextAccessor,
            ILogger<UtilisateurService> logger,
            CustomDbContext dbContext,
            IMapper mapper,
            IEmailService emailService,
            IOptionsMonitor<GlobalSettings> globalSettings,
            IServiceProvider serviceProvider)
            : base(logger, dbContext, mapper, serviceProvider)
        {
            _contextAccessor = contextAccessor;
            _emailService = emailService;
            _globalSettings = globalSettings.CurrentValue;
        }

        public async Task DeleteUtilisateurAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Utilisateur>.CheckIdExistAsync(DbContext.Utilisateurs, id, cancellationToken);
            Utilisateur utilisateur = await DbContext.Utilisateurs.AsTracking()
                                                                  .SingleAsync(x => x.Id == id, cancellationToken);
            CheckUtilisateurIsSupprimable(utilisateur);

            utilisateur.IsActif = false;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        private void CheckUtilisateurIsSupprimable(Utilisateur utilisateur)
        {
            if (!utilisateur.IsSupprimable)
            {
                throw new BusinessException(BusinessExceptionsResources.UTILISATEUR_NON_SUPPRIMABLE);
            }

            UserLoggedDto userLoggedDto = _contextAccessor.HttpContext.Session.Get<UserLoggedDto>(SessionKeyConstantes.UserLogged);
            if (userLoggedDto.Login == utilisateur.Email)
            {
                throw new BusinessException(BusinessExceptionsResources.UTILISATEUR_NON_SUPPRIMABLE_CONNECTE);
            }
        }

        public async Task<Guid> InsertUtilisateurAsync(UtilisateurDto utilisateur, CancellationToken cancellationToken = default)
        {
            await CheckLoginExistAsync(utilisateur.Email, cancellationToken);
            Utilisateur nouvelUtilisateur = Mapper.Map<Utilisateur>(utilisateur);
            nouvelUtilisateur.MotDePasseCrypte = MotDePasseHelper.GetHashedMotDePasse(utilisateur.MotDePasse);
            nouvelUtilisateur.IsActif = true;
            nouvelUtilisateur.IsModifiable = true;
            nouvelUtilisateur.IsSupprimable = true;
            nouvelUtilisateur.Email = nouvelUtilisateur.Email.ToLower();



            await DbContext.Utilisateurs.AddAsync(nouvelUtilisateur, cancellationToken);
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);

            string htmlContent = _emailService.LoadEmailTemplateWithCss(
                FilesNamesConstantes.EmailCreationCompte_HtmlTemplate_FileNameWithExt,
                FilesNamesConstantes.EmailTemplate_CssStyle_FileNameWithExt,
                new Dictionary<string, string>
                {
            { "baseUrl", _globalSettings.BaseUrl },
            { "UserNom", utilisateur.Nom.ToUpper() },
            { "mdp", utilisateur.MotDePasse } // Ajout des liens ici
                }
            );

            await _emailService.SendEmailWithRetryAsync(
                  utilisateur.Email,
                  "Nouveau compte Altalent",
                  htmlContent, false
              );

            return nouvelUtilisateur.Id;
        }

        public async Task UpdateUtilisateurAsync(UtilisateurDto utilisateurModifie, CancellationToken cancellationToken = default)
        {
            await DbSetHelper<Utilisateur>.CheckIdExistAsync(DbContext.Utilisateurs, utilisateurModifie.Id, cancellationToken);
            Utilisateur utilisateur = await DbContext.Utilisateurs.AsTracking().SingleAsync(x => x.Id == utilisateurModifie.Id, cancellationToken);

            if (!utilisateur.IsModifiable)
            {
                throw new BusinessException(BusinessExceptionsResources.UTILISATEUR_NON_MODIFIABLE);
            }

            if (utilisateur.IsModifiable)
            {
                utilisateur.Nom = utilisateurModifie.Nom;
                utilisateur.Email = utilisateurModifie.Email;
                utilisateur.IsSupprimable = utilisateurModifie.IsSupprimable;
                utilisateur.IsModifiable = utilisateurModifie.IsModifiable;
                utilisateur.TypeCompte = utilisateurModifie.TypeCompteSelected.Value;
                utilisateur.Telephone = utilisateurModifie.Telephone;
                utilisateur.Poste = utilisateurModifie.Poste;

                if (!string.IsNullOrEmpty(utilisateurModifie.NouveauMotDePasse))
                {
                    utilisateur.MotDePasseCrypte = MotDePasseHelper.GetHashedMotDePasse(utilisateurModifie.NouveauMotDePasse);
                }
            }
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);
        }

        public IQueryable<UtilisateurDto> GetUtilisateursActifs()
        {
            return DbContext.Utilisateurs.Where(x => x.IsActif)
                                         .ProjectTo<UtilisateurDto>(Mapper.ConfigurationProvider);
        }

        private async Task CheckLoginExistAsync(string login, CancellationToken cancellationToken = default)
        {
            IQueryable<Utilisateur> queryable = DbContext.Utilisateurs.AsQueryable();

            if (await queryable.AnyAsync(x => x.Email == login, cancellationToken))
            {
                throw new BusinessException($"Le login '{login}' existe déjà pour un utilisateur (actif ou non).");
            }
        }

        public Task<string> GetUserIdAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(Utilisateur user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(Utilisateur user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Utilisateur user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Utilisateur> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Utilisateur> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public async Task RegenMdpAsync(RegenMdpDto regenMdpDto, CancellationToken cancellationToken)
        {
            Task<Utilisateur> utilisateurTask = DbContext.Utilisateurs.Where(x => x.Email == regenMdpDto.AdressEmail).AsTracking().SingleAsync(cancellationToken);
            string newMdp = Guid.NewGuid().ToString();
            string crypted = MotDePasseHelper.GetHashedMotDePasse(newMdp);
            Utilisateur user = await utilisateurTask;
            user.MotDePasseCrypte = crypted;
            await DbContext.SaveBaseEntityChangesAsync(cancellationToken);

            string htmlContent = _emailService.LoadEmailTemplateWithCss(
                FilesNamesConstantes.EmailResetmdp_HtmlTemplate_FileNameWithExt,
                FilesNamesConstantes.EmailTemplate_CssStyle_FileNameWithExt,
                new Dictionary<string, string>
                {
            { "baseUrl", _globalSettings.BaseUrl },
            { "UserNom", user.Nom.ToUpper() },
            { "mdp", newMdp } // Ajout des liens ici
                }
            );

            await _emailService.SendEmailWithRetryAsync(
                  regenMdpDto.AdressEmail,
                  "Demande de Reset de mdp",
                  htmlContent,false
              );
        }
    }
}
