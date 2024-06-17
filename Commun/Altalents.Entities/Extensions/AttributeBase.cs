namespace Altalents.Entities.Extensions
{
    public class AttributeBase : Attribute
    {
        public AttributeBase(long ticks)
        {
            DateCreation = new DateTime(ticks);
        }

        public DateTime DateCreation { get; set; }
    }
}
