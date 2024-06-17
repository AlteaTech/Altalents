namespace Altalents.IBusiness.DTO.Marques
{
    public class NoticeMarqueDto
    {
        public string Texte { get; set; }
        public bool IsPublie { get; set; }
        public Guid MarqueId { get; set; }
        public Guid Id { get; set; }
        public string OngletName { get; set; }
        public int OngletOrdre { get; set; }
    }
}
