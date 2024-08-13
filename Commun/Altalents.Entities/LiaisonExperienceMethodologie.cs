namespace Altalents.Entities
{
    public partial class LiaisonExperienceMethodologie : BaseEntity
    {
        public LiaisonExperienceMethodologie()
        {
        }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
        public Guid MethodologieId { get; set; }
        public Reference Methodologie { get; set; }
        public int Niveau { get; set; }
    }
}
