namespace Altalents.IBusiness.DTO
{
    public class DossierTechniqueDto
    {
        [Required]
        public Guid Id { get; set; }
        public int NumeroDt { get; set; }
        public string PrenomCandidat { get; set; }
        public string NomCandidat { get; set; }
        public string IdBoond { get; set; }
        public string PosteVoulu { get; set; }
        public DateTime DateUpdate { get; set; }
        public string Commercial { get; set; }
    }
}
