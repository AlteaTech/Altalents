namespace Altalents.Entities.BaseEntities
{
    public class BaseFormationEntity : BaseEntity
    {
        public string Libelle { get; set; }
        public string Niveau { get; set; }
        public string Organisme { get; set; }
        public DateTime DateObtention { get; set; }
    }
}
