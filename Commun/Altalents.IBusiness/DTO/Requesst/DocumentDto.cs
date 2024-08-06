namespace Altalents.IBusiness.DTO.Requesst
{
    public class DocumentDto : DocumentInfoDto
    {
        [Required]
        public byte[] Data { get; set; }
    }
}
