namespace Altalents.Entities.BaseEntities
{
    public class FileEntity : BaseEntity
    {
        public string Nom { get; set; }
        public byte[] Data { get; set; }
        public string MimeType { get; set; }
    }
}
