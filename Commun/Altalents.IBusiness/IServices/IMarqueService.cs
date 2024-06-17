namespace Altalents.IBusiness.IServices
{
    public partial interface IMarqueService : IInjectableService
    {
        Task CheckMarqueExistAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task<Guid> InsertNouvelleMarqueAsync(CancellationToken cancellationToken = default);
        Task<bool> MarqueExistAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> GetMarqueIsFinalized(Guid idMarque, CancellationToken cancellationToken = default);
        Task<string> GetReferenceLugtByMarqueIdAsync(Guid idMarque, bool isLight = false, CancellationToken cancellationToken = default);
        Task<DateTime?> GetDatePublicationByMarqueIdAsync(Guid idMarque, CancellationToken cancellationToken = default);
        Task<List<MarqueDtoBase>> GetMarquesFinaliseesAsync(string text, CancellationToken cancellationToken = default);
        Task<byte[]> ExporterAsync(CancellationToken cancellationToken = default);
        Task<byte[]> PublierAsync(CancellationToken cancellationToken = default);
        void RepriseDeDonneesReferenceLugtLightEtNoticesTextesBruts();
        void RepriseDeDonneesReferenceSousRefTransliteration();
        void RepriseDeDonneesReferenceLibreMarquesTransliteration();
        void RepriseDeDonneesInitialesMarquesTransliteration();
        void RepriseDeDonneesInitiales();
    }
}
