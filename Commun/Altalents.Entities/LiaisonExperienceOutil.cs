namespace Altalents.Entities
{
    public partial class LiaisonExperienceOutil : BaseEntity
    {
        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public Guid OutilId { get; set; }
        public Reference Outil { get; set; }
        public int Niveau { get; set; }
    }
}
