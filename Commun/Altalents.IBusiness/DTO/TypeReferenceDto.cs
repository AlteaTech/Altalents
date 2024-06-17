namespace Altalents.IBusiness.DTO
{
    public class TypeReferenceDto
    {
        [Required]
        public Guid TypeReferenceId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public int Ordre { get; set; }
        [Required]
        public bool WithSecondeLangue { get; set; }
        [Required]
        public bool WithSousReference { get; set; }
    }
}
