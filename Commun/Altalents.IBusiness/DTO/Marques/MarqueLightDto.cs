namespace Altalents.IBusiness.DTO.Marques
{
    public class MarqueLightDto : MarqueDtoBase
    {
        public string NomPrincipalLibelleFr { get; set; }
        public int NombreRenvois { get; set; }

        public string LibelleDropDownMarqueRenvois => $"{ReferenceLugt} - {NomPrincipalLibelleFr} ({NombreRenvois} marque(s) associée(s))";
        public bool IsSupprimable => true;
        public bool IsModifiable => false;
    }
}
