namespace Altalents.IBusiness.DTO.Requesst
{
    public class GetTrigrammeRequestDto
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set;}
    }
}
