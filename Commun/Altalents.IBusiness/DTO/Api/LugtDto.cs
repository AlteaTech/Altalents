using Newtonsoft.Json;

namespace Altalents.IBusiness.DTO.Api
{
    public class LugtDto : IEquatable<LugtDto>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public string ReferenceLugtLight { get; set; }

        public bool Equals(LugtDto other)
        {
            return Id == other.Id && Libelle.Equals(other.Libelle);
        }
    }
}
