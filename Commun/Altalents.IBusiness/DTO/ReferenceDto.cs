namespace Altalents.IBusiness.DTO
{
    public class ReferenceDto : BaseUpdatableDto
    {
        [Required]
        public Guid ReferenceId { get; set; }
        [Required]
        public Guid TypeReferenceId { get; set; }
        [Required(ErrorMessage = "La seconde langue est obligatoire")]
        public string Libelle2 { get; set; }
        [Required(ErrorMessage = "La langue française est obligatoire")]
        public string LibelleFr { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        [Required(ErrorMessage = "L'ordre français est obligatoire")]
        public int? OrdreFr { get; set; }
        [Required(ErrorMessage = "L'ordre seconde langue est obligatoire")]
        public int? Ordre2 { get; set; }
        [Required]
        public int NombreSousReference { get; set; }
        [Required]
        public int NombreMarque { get; set; }
        public bool HasSousReference => NombreSousReference != 0;

        public new bool IsSupprimable => NombreSousReference == 0 && NombreMarque == 0;
        public new bool IsModifiable => true;
    }
}
