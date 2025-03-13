using AlteaTools.Session.Dto;

namespace Altalents.IBusiness.DTO
{
    public class CustomUserLoggedDto : UserLoggedDto
    {
        public Guid UserId { get; set; }
    }
}
