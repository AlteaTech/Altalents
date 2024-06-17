namespace Altalents.Entities.Extensions
{
    public sealed class TypeReferenceAttribute : AttributeBase
    {
        public TypeReferenceAttribute(long ticks, int ordre, bool withSecondeLangue, bool withSousReference) : base(ticks)
        {
            Ordre = ordre;
            WithSecondeLangue = withSecondeLangue;
            WithSousReference = withSousReference;
        }

        public int Ordre { get; set; }
        public bool WithSecondeLangue { get; set; }
        public bool WithSousReference { get; set; }
    }
}
