namespace Altalents.IBusiness.IServices
{
    // PARTIAL RENVOIS
    public partial interface IMarqueService : IInjectableService
    {
        Task<IQueryable<MarqueLightDto>> GetMarquesRenvoisByMarqueIdAsync(Guid marqueId, CancellationToken cancellationToken = default);
        Task DeleteMarqueRenvoisAsync(Guid marqueIdASupprimer, Guid marqueIdTravail, CancellationToken cancellationToken = default);
        Task<Guid> InsertMarqueRenvoisAsync(Guid marqueIdAAjouter, Guid marqueIdTravail, CancellationToken cancellationToken = default);
        Task<List<MarqueLightDto>> GetMarquesAjoutablesMarqueRenvoisAsync(string text, Guid marqueId, CancellationToken cancellationToken = default);
        Task LoadMarqueRenvoisInMarqueRenvoisTemporairesAsync(Guid marqueId, CancellationToken cancellationToken = default);
        Task UpdateMarqueRenvoisAsync(Guid marqueIdTravail, CancellationToken cancellationToken = default);
        void PurgeMarquesRenvoisTemporaires();
        Task<MarqueNombreRenvoisDto> GetNombreMarqueAssociesByMarqueIdAsync(Guid marqueId, CancellationToken cancellationToken = default);
    }
}
