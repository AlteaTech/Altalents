namespace Altalents.Entities
{
    public partial class Introduction : BaseEntity
    {
        public Introduction()
        {

        }

        public string TitreFr { get; set; }
        public string TitreEn { get; set; }
        public string DetailFr { get; set; }
        public string DetailEn { get; set; }
        public int OrdreFr { get; set; }
        public int OrdreEn { get; set; }
    }
}
