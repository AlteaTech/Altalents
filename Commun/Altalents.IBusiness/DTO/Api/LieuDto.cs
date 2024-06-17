using Newtonsoft.Json;

namespace Altalents.IBusiness.DTO.Api
{
    public class LieuDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Libelle { get; set; }
        [JsonIgnore]
        public string LibelleTransLit { get; set; }
        [JsonIgnore]
        public string RechercheTransLit { get; set; }
        [JsonIgnore]
        public int Order => LibelleTransLit.ToLower().StartsWith(RechercheTransLit.ToLower()) ? 0 : 1;
    }
}
