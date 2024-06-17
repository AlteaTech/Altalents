using System.Reflection;

namespace Altalents.Entities.Extensions
{
    public static class EnumExtensionMethod
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

        // TYPE REFERENCE ATTRIBUTE
        public static int GetOrdreForTypeReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TypeReferenceAttribute>()
                            .Ordre;
        }

        public static bool GetWithSecondeLangueForTypeReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TypeReferenceAttribute>()
                            .WithSecondeLangue;
        }

        public static bool GetWithSousReferenceForTypeReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TypeReferenceAttribute>()
                            .WithSousReference;
        }

        // REFERENCE ATTRIBUTE
        public static string GetLibelleFrForReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<ReferenceAttribute>()
                            .LibelleFr;
        }

        public static string GetLibelle2ForReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<ReferenceAttribute>()
                            .Libelle2;
        }

        public static int GetOrdreFrForReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<ReferenceAttribute>()
                            .OrdreFr;
        }

        public static int GetOrdre2ForReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<ReferenceAttribute>()
                            .Ordre2;
        }

        public static Guid GetTypeReferenceIdForReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<ReferenceAttribute>()
                            .TypeReferenceId;
        }

        // SOUS REFERENCE ATTRIBUTE
        public static string GetLibelleFrForSousReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<SousReferenceAttribute>()
                            .LibelleFr;
        }

        public static string GetLibelle2ForSousReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<SousReferenceAttribute>()
                            .Libelle2;
        }

        public static int GetOrdreFrForSousReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<SousReferenceAttribute>()
                            .OrdreFr;
        }

        public static int GetOrdre2ForSousReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<SousReferenceAttribute>()
                            .Ordre2;
        }

        public static Guid GetReferenceIdForSousReferenceAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<SousReferenceAttribute>()
                            .ReferenceId;
        }

        // ONGLET NOTICE MARQUE ATTRIBUTE
        public static string GetLibelleForOngletNoticeMarqueAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<OngletNoticeMarqueAttribute>()
                            .Libelle;
        }

        public static int GetOrdreForOngletNoticeMarqueAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<OngletNoticeMarqueAttribute>()
                            .Ordre;
        }

        public static bool GetIsDefaultCreationForOngletNoticeMarqueAttribute(this System.Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<OngletNoticeMarqueAttribute>()
                            .IsDefaultCreation;
        }
    }
}
