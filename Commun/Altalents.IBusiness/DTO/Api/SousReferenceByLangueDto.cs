namespace Altalents.IBusiness.DTO.Api
{
    public class SousReferenceByLangueDto
    {
        [Required]
        public Guid SousReferenceId { get; set; }
        [Required]
        public string Libelle { get; set; }
    }
}
