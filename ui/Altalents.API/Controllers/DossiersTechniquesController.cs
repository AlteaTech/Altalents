using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altalents.IBusiness.DTO.Requesst;
using Altalents.IBusiness.Enums;

using AlteaTools.Api.Core.Exceptions;
using AlteaTools.Session;
using AlteaTools.Session.Dto;
using AlteaTools.Session.Extension;

using Microsoft.AspNetCore.Http;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DossiersTechniquesController
    {
        private readonly IDossierTechniqueService _dossierTechniqueService;

        public DossiersTechniquesController(IDossierTechniqueService dossierTechniqueService)
        {
            _dossierTechniqueService = dossierTechniqueService;
        }

        [HttpPost("", Name = "AddDossierTechnique")]
        public async Task<Guid> AddDossierTechniqueAsync([FromBody] DossierTechniqueInsertRequestDto dossierTechnique, CancellationToken cancellationToken)
        {
            return await _dossierTechniqueService.AddDossierTechniqueAsync(dossierTechnique, cancellationToken);
        }

        [HttpPut("{id}/statut/{statutId}", Name = "ChangerStatutDossierTechnique")]
        public async Task ChangerStatutDossierTechniqueAsync([FromRoute] Guid id,[FromRoute] Guid statutId, CancellationToken cancellationToken)
        {
            await _dossierTechniqueService.ChangerStatutDossierTechniqueAsync(id, statutId, cancellationToken);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class UserLoggedController
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserLoggedController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpPost("", Name = "GetUserLoggedDto")]
        public CustomUserLoggedDto GetUserLoggedDto()
        {
            CustomUserLoggedDto userLoggedDto = _contextAccessor.HttpContext.Session.Get<CustomUserLoggedDto>(SessionKeyConstantes.UserLogged);
            if (userLoggedDto is null)
            {
                throw new BusinessException("Merci de vous connecter");
            }
            return userLoggedDto;
        }
    }
}
