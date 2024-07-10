namespace Altalents.IBusiness.DTO.Requesst
{
    public class DossierTechniqueInsertRequestDto
    {
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        [MaxLength(3)]
        public string Trigramme { get; set; }
        [Required]
        public string IdBoond { get; set; }
        [Required]
        public string AdresseMail { get; set; }
        [Required]
        public Guid DisponibiliteId { get; set; }

        public string Telephone { get; set; }
        public string Poste { get; set; }
        public decimal? TarifJournalier { get; set; }
    }
}
