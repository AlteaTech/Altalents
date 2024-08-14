using Altalents.Commun.Enums;

namespace Altalents.IBusiness.DTO
{
    public class ReferenceAValiderDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Libelle { get; set; }
        public string CommentaireFun { get; set; }
        public TypeReferenceEnum TypeReference { get; set; }
        public string TypeReferenceString => TypeReference.ToString();
        public int NbDtAssocie { get; set; }
    }
}
