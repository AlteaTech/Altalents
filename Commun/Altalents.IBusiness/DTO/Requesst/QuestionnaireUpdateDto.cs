namespace Altalents.IBusiness.DTO.Requesst
{
    public class QuestionnaireUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Reponse { get; set; }
    }
}
