namespace Altalents.Entities
{
    public partial class LiaisonProjetMethodologie : BaseEntity
    {
        public LiaisonProjetMethodologie()
        {
        }

        public Guid ProjetOrMissionClientId { get; set; }
        public ProjetOrMissionClient ProjetOrMissionClient { get; set; }
        public Guid MethodologieId { get; set; }
        public Reference Methodologie { get; set; }
        public int Niveau { get; set; }
    }
}
