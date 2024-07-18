using AlteaTools.Api.Core.Exceptions;
using AlteaTools.Session;
using AlteaTools.Session.Extension;

using Microsoft.AspNetCore.Http;

namespace Altalents.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLoggedController
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserLoggedController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet("", Name = "GetUserLoggedDto")]
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
