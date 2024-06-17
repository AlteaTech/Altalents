namespace Altalents.Entities
{
    public class MarqueRenvois : BaseEntity
    {
        public Guid MarqueId1 { get; set; }
        public Guid MarqueId2 { get; set; }
        public Marque Marque1 { get; set; }
        public Marque Marque2 { get; set; }
    }
}
