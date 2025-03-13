namespace Altalents.IBusiness.DTO
{
    public class ReferenceRequestDto
    {

        public Guid? Id { get; set; }

        public string TypeReference { get; set; }

        public bool IsValide { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Libelle ne doit pas faire plus de 250 caractères")]
        public string Libelle { get; set; }

        public string Commentaire { get; set; }
    }
}
