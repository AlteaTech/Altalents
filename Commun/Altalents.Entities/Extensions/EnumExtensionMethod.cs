using System.Reflection;

namespace Altalents.Entities.Extensions
{
    public static partial class EnumExtensionMethod
    {
        // ATTRIBUTE BASE
        public static DateTime GetDateCreation(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<AttributeBase>()
                            .DateCreation;
        }
    }
}
