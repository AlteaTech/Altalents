namespace Altalents.IBusiness.DTO
{
    public class QuestionnaireDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsObligatoire { get; set; }
        public string Question { get; set; }
        public string Reponse { get; set; }
    }
}
