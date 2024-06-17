namespace Altalents.IBusiness.DTO.Api
{
    public class TypeReferenceLightDto
    {
        public Guid TypeReferenceId { get; set; }
        public string Libelle { get; set; }
        public bool WithSousReference { get; set; }
    }
}
