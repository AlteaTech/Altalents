namespace Altalents.Entities
{
    public partial class LiaisonExperienceCompetence : BaseEntity
    {
        public LiaisonExperienceCompetence()
        {
        }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public Guid CompetenceId { get; set; }
        public Reference Competance { get; set; }
        public int Niveau { get; set; }
    }
}
