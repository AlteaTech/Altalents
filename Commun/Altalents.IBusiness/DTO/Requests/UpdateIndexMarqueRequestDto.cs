namespace Altalents.IBusiness.DTO.Requests
{
    public class UpdateIndexMarqueRequestDto : IndexMarqueDtoBase
    {
        public List<Guid> ReferenceNomIds { get; set; } = new List<Guid>();
        public Guid ReferenceNomPrincipalId { get; set; }
        public List<Guid> ReferencePaysIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferencePaysIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceTextesIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceTextesIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceImagesIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceImagesIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceCouleursIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceCouleursIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceTechniquesIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceTechniquesIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceLocalisationsIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceLocalisationsIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceCategoriesIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceCategoriesIds { get; set; } = new List<Guid>();
        public List<Guid> ReferenceContoursIds { get; set; } = new List<Guid>();
        public List<Guid> SousReferenceContoursIds { get; set; } = new List<Guid>();

        public List<Guid> GetAllReferencesIdsSelected()
        {
            List<Guid> allRefidsSelected = new();
            allRefidsSelected.AddRange(ReferenceNomIds);
            allRefidsSelected.AddRange(ReferencePaysIds);
            allRefidsSelected.AddRange(ReferenceTextesIds);
            allRefidsSelected.AddRange(ReferenceImagesIds);
            allRefidsSelected.AddRange(ReferenceCouleursIds);
            allRefidsSelected.AddRange(ReferenceTechniquesIds);
            allRefidsSelected.AddRange(ReferenceLocalisationsIds);
            allRefidsSelected.AddRange(ReferenceCategoriesIds);
            allRefidsSelected.AddRange(ReferenceContoursIds);
            allRefidsSelected.Add(ReferenceNomPrincipalId);
            return allRefidsSelected;
        }

        public List<Guid> GetAllSousReferencesIdsSelected()
        {
            List<Guid> allSousRefidsSelected = new();
            allSousRefidsSelected.AddRange(SousReferencePaysIds);
            allSousRefidsSelected.AddRange(SousReferenceTextesIds);
            allSousRefidsSelected.AddRange(SousReferenceImagesIds);
            allSousRefidsSelected.AddRange(SousReferenceCouleursIds);
            allSousRefidsSelected.AddRange(SousReferenceTechniquesIds);
            allSousRefidsSelected.AddRange(SousReferenceLocalisationsIds);
            allSousRefidsSelected.AddRange(SousReferenceCategoriesIds);
            allSousRefidsSelected.AddRange(SousReferenceContoursIds);
            return allSousRefidsSelected;
        }
    }
}
