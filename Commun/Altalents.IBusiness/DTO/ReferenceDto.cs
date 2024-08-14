namespace Altalents.IBusiness.DTO
{
    public class ReferenceDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Libelle { get; set; }
        public string CommentaireFun { get; set; }
    }
}
