namespace Altalents.IBusiness.DTO.Request
{
    public class DocumentDto : DocumentInfoDto
    {
        [Required]
        public byte[] Data { get; set; }
    }
}
