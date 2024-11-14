namespace Altalents.IBusiness.DTO.Request
{
    public class QuestionnaireUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Reponse { get; set; }
    }
}
