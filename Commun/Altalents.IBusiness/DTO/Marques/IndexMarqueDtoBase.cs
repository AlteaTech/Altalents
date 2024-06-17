using Altalents.Commun.Helpers;

namespace Altalents.IBusiness.DTO.Marques
{
    public class IndexMarqueDtoBase : MarqueDtoBase
    {
        public double? Haut => string.IsNullOrEmpty(Hauteur) ? null : DoubleHelper.ParseDouble(Hauteur);
        public string Hauteur { get; set; }
        public double? Larg => string.IsNullOrEmpty(Largeur) ? null : DoubleHelper.ParseDouble(Largeur);
        public string Largeur { get; set; }
        public string Initiales { get; set; }
        public bool IsFinalize { get; set; }
    }
}
