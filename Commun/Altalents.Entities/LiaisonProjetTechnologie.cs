namespace Altalents.Entities
{
    public partial class LiaisonProjetTechnologie : BaseEntity
    {
        public LiaisonProjetTechnologie()
        {
        }

        public Guid ProjetOrMissionClientId { get; set; }
        public ProjetOrMissionClient ProjetOrMissionClient { get; set; }
        public Guid TechnologieId { get; set; }
        public Reference Technologie { get; set; }
        public int Niveau { get; set; }
    }
}
