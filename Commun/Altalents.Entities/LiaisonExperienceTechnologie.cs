namespace Altalents.Entities
{
    public partial class LiaisonExperienceTechnologie : BaseEntity
    {
        public LiaisonExperienceTechnologie()
        {
        }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public Guid TechnologieId { get; set; }
        public Reference Technologie { get; set; }
        public int Niveau { get; set; }
    }
}
