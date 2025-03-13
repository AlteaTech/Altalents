namespace Altalents.IBusiness.DTO.Request
{
    public class QuestionInsertDto
    {
        public int Ordre { get; set; }
        public bool IsObligatoire { get; set; }
        public bool IsShowDt { get; set; }
        public string Question { get; set; }
    }
}
