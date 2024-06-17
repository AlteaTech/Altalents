namespace Altalents.IBusiness.DTO
{
    public class ReferenceLightDto
    {
        [Required]
        public Guid ReferenceId { get; set; }
        public string Libelle2 { get; set; }
        public string LibelleFr { get; set; }
    }
}
