namespace Altalents.IBusiness.DTO
{
    public class ReferenceRequestDto
    {
        [Required]
        public string TypeReference { get; set; }
        [Required]
        [MaxLength(250, ErrorMessage = "Libelle ne doit pas faire plus de 250 caractères")]
        public string Libelle { get; set; }
    }
}
