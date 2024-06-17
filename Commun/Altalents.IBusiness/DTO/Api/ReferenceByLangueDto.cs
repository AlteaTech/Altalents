using Newtonsoft.Json;

namespace Altalents.IBusiness.DTO.Api
{
    public class ReferenceByLangueDto
    {
        [Required]
        public Guid ReferenceId { get; set; }
        [Required]
        public string Libelle { get; set; }
        [Required]
        public bool HasSousReference { get; set; }
        [JsonIgnore]
        public string LibelleFr { get; set; }
        [JsonIgnore]
        public string Libelle2 { get; set; }
        [JsonIgnore]
        public int OrdreFr { get; set; }
        [JsonIgnore]
        public int Ordre2 { get; set; }

    }
}
