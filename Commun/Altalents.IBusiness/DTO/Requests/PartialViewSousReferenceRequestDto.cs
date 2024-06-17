namespace Altalents.IBusiness.DTO.Requests
{
    public class PartialViewSousReferenceRequestDto
    {
        public List<Guid> ReferenceIds { get; set; } = new();
        public List<Guid> SousReferenceIdsSelected { get; set; } = new();
        public string MultiSelectId { get; set; }
        public string OnChangeAction { get; set; }
    }
}
