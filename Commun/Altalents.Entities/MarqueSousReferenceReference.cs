namespace Altalents.Entities
{
    public partial class MarqueSousReferenceReference : BaseEntity
    {
        public Guid ReferenceId { get; set; }
        public Guid? SousReferenceId { get; set; }
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
        public Reference Reference { get; set; }
        public SousReference SousReference { get; set; }
        public bool IsPrincipal { get; set; }
    }
}
