using Altalents.IBusiness.Enums;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntroductionsController : Controller
    {
        private readonly IIntroductionService _introductionService;

        public IntroductionsController(IIntroductionService introductionService)
        {
            _introductionService = introductionService;
        }

        [HttpGet("{langue}", Name = "GetIntroductionsByLangue")]
        public async Task<List<IntroductionByLangueDto>> GetIntroductionsByLangueAsync([FromRoute] EnumLangue langue, CancellationToken cancellationToken)
        {
            return await _introductionService.GetIntroductionsByLangueAsync(langue, cancellationToken);
        }
    }
}
