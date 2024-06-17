namespace Altalents.Entities
{
    public partial class MarqueImage : BaseEntity
    {
        public string NomFichier { get; set; }
        public string FullPath { get; set; }
        public int Ordre { get; set; }
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
    }
}
