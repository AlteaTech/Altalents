using Altalents.Commun.Enums;

namespace Altalents.Entities
{
    public partial class Reference : BaseEntity
    {
        public Reference()
        {
        }

        public string Libelle { get; set; }
        public string CommentaireFun { get; set; }
        public TypeReferenceEnum Type { get; set; }
        public SousTypeReferenceEnum? SousType { get; set; }
        public string Code { get; set; }
        public int OrdreTri { get; set; }
        public bool IsValide { get; set; }
        public List<DossierTechnique> DossierTechniquesByDisponibilite { get; set; }
        public List<DossierTechnique> DossierTechniquesByStatut { get; set; }
        public List<Personne> Personnes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Document> Documents { get; set; }
        public List<DossierTechniqueLangue> PersonneLangues { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<LiaisonExperienceTechnologie> LiaisonExperienceTechnologies { get; set; }
        public List<LiaisonExperienceCompetance> LiaisonExperienceCompetances { get; set; }
    }
}
