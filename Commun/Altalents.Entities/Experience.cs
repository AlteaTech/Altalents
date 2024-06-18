namespace Altalents.Entities
{
    public partial class Experience : BaseEntity
    {
        public Experience()
        {
        }

        public string IntitulePoste { get; set; }
        public string Entreprise { get; set; }
        public string Lieu { get; set; }
        public string Description { get; set; }
        public string DomaineMetier { get; set; }
        public decimal? Budget { get; set; }
        public string ClientFinal { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public Guid PersonneId { get; set; }
        public Personne Personne { get; set; }
        public Guid TypeContratId { get; set; }
        public Reference TypeContrat { get; set; }

        public List<LiaisonExperienceTechnologie> LiaisonExperienceTechnologies { get; set; }
        public List<LiaisonExperienceCompetance> LiaisonExperienceCompetances { get; set; }
    }
}
