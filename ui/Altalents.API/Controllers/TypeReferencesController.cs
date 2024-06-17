namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeReferencesController : Controller
    {
        private readonly IReferenceService _referenceService;

        public TypeReferencesController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }

        [HttpGet("", Name = "GetTypeReferencesLight")]
        public async Task<List<TypeReferenceLightDto>> GetTypeReferencesLightAsync(CancellationToken cancellationToken)
        {
            return await _referenceService.GetTypeReferencesLightAsync(cancellationToken);
        }
    }
}
