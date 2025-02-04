namespace Altalents.Entities
{
    public partial class Experience : BaseEntity
    {

        public Experience()
        {
        }

        public string IntitulePoste { get; set; }
        public string NomEntreprise { get; set; }
        public bool IsEntrepriseEsnOrInterim { get; set; }
        public string LieuEntreprise { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public Guid? DomaineMetierId { get; set; }
        public Reference DomaineMetier { get; set; }

        public Guid DossierTechniqueId { get; set; }
        public DossierTechnique DossierTechnique { get; set; }

        public Guid TypeContratId { get; set; }
        public Reference TypeContrat { get; set; }

        public List<ProjetOrMissionClient> ProjetsOrMissionsClient { get; set; }

    }
}
