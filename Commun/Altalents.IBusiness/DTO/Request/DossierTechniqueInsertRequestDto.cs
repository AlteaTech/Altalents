namespace Altalents.IBusiness.DTO.Request
{
    public class DossierTechniqueInsertRequestDto : BaseRequestDto
    {
        [Required]
        [MaxLength(250)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(10)]
        public string Prenom { get; set; }
        [Required]
        [MaxLength(250)]
        public string Trigramme { get; set; }
        [Required]
        public string IdBoond { get; set; }
        [Required]
        [MaxLength(250)]
        public string AdresseMail { get; set; }
        [Required]
        public Guid DisponibiliteId { get; set; }
        public string Telephone { get; set; }
        public string Poste { get; set; }
        public decimal? TarifJournalier { get; set; }
        public List<QuestionInsertDto> Questionnaires { get; set; }
        public List<DocumentDto> Documents { get; set; }
    }
}
