namespace Altalents.MVC.Models.Marque
{
    public class PartialViewSousReferenceModel
    {
        public List<SousReferenceLightDto> SousReferencesSelected { get; set; } = new();
        public List<SousReferenceLightDto> SousReferencesSelectable { get; set; } = new();
        public string MultiSelectId { get; set; }
        public string OnChangeAction { get; set; }
    }
}
