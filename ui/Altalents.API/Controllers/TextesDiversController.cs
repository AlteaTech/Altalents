using Altalents.Entities.Enum;
using Altalents.IBusiness.Enums;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TextesDiversController : Controller
    {
        private readonly ITexteDiversService _texteDiversService;

        public TextesDiversController(ITexteDiversService texteDiversService)
        {
            _texteDiversService = texteDiversService;
        }

        [HttpGet("{langue}/{typeTexteDivers}", Name = "GetTextesDiversByLangueByType")]
        public async Task<List<TexteDiversByLangueDto>> GetTextesDiversByLangueByTypeAsync([FromRoute] EnumLangue langue, [FromRoute] EnumTypeTexteDivers typeTexteDivers, CancellationToken cancellationToken)
        {
            return await _texteDiversService.GetTextesDiversByLangueByTypeAsync(langue, typeTexteDivers, cancellationToken);
        }
    }
}
