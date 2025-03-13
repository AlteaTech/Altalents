namespace Altalents.IBusiness.DTO
{
    public class DossierTechniqueForAdminDto
    {
        [Required]
        public Guid Id { get; set; }
        public int NumeroDt { get; set; }
        public string PrenomCandidat { get; set; }
        public string NomCandidat { get; set; }
        public string IdBoond { get; set; }
        public string PosteVoulu { get; set; }
        public DateTime DateCrea { get; set; }
        public DateTime DateUpdate { get; set; }
        public string Commercial { get; set; }
        public string Statut { get; set; }
        public string StatutCode { get; set; }
        public string TokenAccesRapide { get; set; } 
    }
}
