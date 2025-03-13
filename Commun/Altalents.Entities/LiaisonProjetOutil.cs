namespace Altalents.Entities
{
    public partial class LiaisonProjetOutil : BaseEntity
    {

        public LiaisonProjetOutil()
        {
        }

        public Guid ProjetOrMissionClientId { get; set; }
        public ProjetOrMissionClient ProjetOrMissionClient { get; set; }
        public Guid OutilId { get; set; }
        public Reference Outil { get; set; }
        public int Niveau { get; set; }
    }
}
