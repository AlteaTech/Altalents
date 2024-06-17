namespace Altalents.Entities.Extensions
{
    public sealed class OngletNoticeMarqueAttribute : AttributeBase
    {
        public OngletNoticeMarqueAttribute(string libelle, int ordre, bool isDefaultCreation, long ticks) : base(ticks)
        {
            Libelle = libelle;
            Ordre = ordre;
            IsDefaultCreation = isDefaultCreation;
        }

        public string Libelle { get; set; }
        public int Ordre { get; set; }
        public bool IsDefaultCreation { get; set; }
    }
}
