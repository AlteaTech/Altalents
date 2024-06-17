namespace Altalents.IBusiness.DTO
{
    public class SousReferenceLightDto
    {
        [Required]
        public Guid SousReferenceId { get; set; }
        public string Libelle2 { get; set; }
        public string LibelleFr { get; set; }
    }
}
