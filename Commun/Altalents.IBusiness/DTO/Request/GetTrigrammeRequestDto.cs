namespace Altalents.IBusiness.DTO.Request
{
    public class GetTrigrammeRequestDto
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set;}
    }
}
