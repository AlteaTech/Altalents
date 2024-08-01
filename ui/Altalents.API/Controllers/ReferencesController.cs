namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReferencesController
    {
        private readonly IReferencesService _referencesService;

        public ReferencesController(IReferencesService referencesService)
        {
            _referencesService = referencesService;
        }

        [HttpGet("", Name = "GetReferencesAsync")]
        public async Task<List<ReferenceDto>> GetReferencesAsync([FromQuery] string typeReferenceCode, [FromQuery] string startWith, CancellationToken cancellationToken)
        {
            return await _referencesService.GetReferencesAsync(typeReferenceCode, startWith, cancellationToken);
        }
    }
}
