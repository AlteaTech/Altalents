namespace Altalents.MVC.Models
{
    public class IntroductionIndexModel
    {
        public Guid? IntroductionId { get; set; }
        public List<IntroductionDto> Introductions { get; set; }
    }
}
