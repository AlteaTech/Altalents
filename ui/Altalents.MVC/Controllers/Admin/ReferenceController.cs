using Altalents.MVC.Controllers.Admin;

namespace Altalents.MVC.Controllers
{
    public partial class ReferenceController : AdminController
    {
        public static string ControllerName = "Reference";
        private readonly IReferenceService _referenceService;
        private readonly ISousReferenceService _sousReferenceService;

        public ReferenceController(
            IReferenceService referenceService,
            ISousReferenceService sousReferenceService,
            ILogger<ReferenceController> logger)
            : base(logger)
        {
            _referenceService = referenceService;
            _sousReferenceService = sousReferenceService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            List<TypeReferenceDto> types = await _referenceService.GetTypeReferencesAsync();
            return View(types);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewGridReferencesAsync(Guid typeId)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            TypeReferenceDto typeReference = await _referenceService.GetTypeReferenceByIdAsync(typeId);
            PartialViewGridReferencesModel model = new()
            {
                TypeId = typeId,
                WithSecondeLangue = typeReference.WithSecondeLangue,
                WithSousReference = typeReference.WithSousReference
            };
            return base.PartialView("PartialViewGridReferences", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewGridSousReferencesAsync(Guid idReference)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            TypeReferenceDto typeReference = await _referenceService.GetTypeReferenceByIdReferenceAsync(idReference);
            PartialViewGridSousReferencesModel model = new()
            {
                ReferenceId = idReference,
                WithSecondeLangue = typeReference.WithSecondeLangue
            };
            return base.PartialView("PartialViewGridSousReferences", model);
        }
    }
}
