using Altalents.Entities;

using Microsoft.AspNetCore.Identity;

namespace Altalents.IBusiness.IServices
{
    public interface IUtilisateurService : IInjectableService, IUserStore<Utilisateur>
    {
        Task<Guid> InsertUtilisateurAsync(UtilisateurDto utilisateur, CancellationToken cancellationToken = default);
        Task DeleteUtilisateurAsync(Guid id, CancellationToken cancellationToken = default);
        Task UpdateUtilisateurAsync(UtilisateurDto utilisateurModifie, CancellationToken cancellationToken = default);
        IQueryable<UtilisateurDto> GetUtilisateursActifs();
    }
}
