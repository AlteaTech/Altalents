namespace Altalents.Entities
{
    public partial class LiaisonExperienceCompetance : BaseEntity
    {
        public LiaisonExperienceCompetance()
        {
        }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public Guid CompetanceId { get; set; }
        public Reference Competance { get; set; }
        public int Niveau { get; set; }
    }
}
