namespace Altalents.Entities
{
    public partial class LiaisonProjetCompetence : BaseEntity
    {
        public LiaisonProjetCompetence()
        {
        }

        public Guid ProjetOrMissionClientId { get; set; }
        public ProjetOrMissionClient ProjetOrMissionClient { get; set; }
        public Guid CompetenceId { get; set; }
        public Reference Competence { get; set; }
        public int Niveau { get; set; }
    }
}
