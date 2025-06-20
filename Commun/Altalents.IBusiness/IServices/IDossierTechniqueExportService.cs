using Altalents.Commun.Enums;
using Altalents.IBusiness.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace Altalents.IBusiness.IServices
{
    public interface IDossierTechniqueExportService : IInjectableService
    {
        Task<DocumentDto> GenereateDtWithOpenXmlAsync(Guid tokenAccesRapide, CancellationToken cancellationToken);
    }
}
