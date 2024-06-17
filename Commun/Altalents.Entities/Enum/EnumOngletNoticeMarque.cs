using Altalents.Entities.Extensions;

namespace Altalents.Entities.Enum
{
    public enum EnumOngletNoticeMarque
    {
        [OngletNoticeMarque("2010", 1, true, 638182053590000000)]
        [Bdd("6F00D3F0-9DB6-48F9-8F4A-D5BD899BBD16")]
        Annee2010 = 1,
        [OngletNoticeMarque("1921", 3, false, 638182053590000000)]
        [Bdd("4229A88D-140D-484E-B42D-780A30592FD8")]
        Annee1921 = 2,
        [OngletNoticeMarque("1956", 2, false, 638182053590000000)]
        [Bdd("02D328E1-8E9A-45D6-A5CA-D503DDF5BA77")]
        Annee1956 = 3,
    }
}
