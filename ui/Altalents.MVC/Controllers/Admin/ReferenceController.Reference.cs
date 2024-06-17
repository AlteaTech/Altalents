using AlteaTools.Api.Core.Extensions;

using Altalents.Entities.Enum;
using Altalents.MVC.Controllers.Admin;

namespace Altalents.MVC.Controllers
{
    public partial class ReferenceController : AdminController
    {
        [HttpPost]
        public async Task<IActionResult> CreateReferenceAsync([DataSourceRequest] DataSourceRequest request, [FromQuery] Guid typeId, ReferenceDto reference)
        {
            reference.TypeReferenceId = typeId;
            return await this.CallWithActionSecurisedAsync(request, CreateReferenceRunnerAsync(request, reference));
        }

        [HttpPost]
        public async Task<IActionResult> CreationNomMarqueAsync([DataSourceRequest] DataSourceRequest request, string libelleFr, int ordreFr)
        {
            ReferenceDto reference = new()
            {
                TypeReferenceId = EnumTypeReference.Nom.GetBddId(),
                LibelleFr = libelleFr,
                OrdreFr = ordreFr
            };
            return await this.CallWithActionSecurisedAsync(request, CreateReferenceRunnerAsync(request, reference));
        }

        public async Task<IActionResult> GetReferencesAsync([DataSourceRequest] DataSourceRequest request, Guid typeId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetReferencesRunnerAsync(request, typeId));
        }

        public async Task<List<ReferenceLightDto>> GetReferencesTypeAsync(string text, EnumTypeReference type)
        {
            return await _referenceService.GetReferencesByTypeAsync(text, type);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReferenceAsync([DataSourceRequest] DataSourceRequest request, ReferenceDto reference)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateReferenceRunnerAsync(request, reference));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReferenceAsync([DataSourceRequest] DataSourceRequest request, Guid referenceId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteReferenceRunnerAsync(request, referenceId));
        }

        private async Task<IActionResult> CreateReferenceRunnerAsync(DataSourceRequest request, ReferenceDto reference)
        {
            return Json(new[] { await _referenceService.InsertReferenceAsync(reference) }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> GetReferencesRunnerAsync(DataSourceRequest request, Guid typeId)
        {
            DataSourceResult references = await (await _referenceService.GetReferencesByTypeReferenceIdAsync(typeId)).ToDataSourceResultAsync(request);
            return base.Json(references);
        }

        private async Task<IActionResult> UpdateReferenceRunnerAsync(DataSourceRequest request, ReferenceDto reference)
        {
            await _referenceService.UpdateReferenceAsync(reference);
            return Json(new[] { reference }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> DeleteReferenceRunnerAsync(DataSourceRequest request, Guid referenceId)
        {
            await _referenceService.DeleteReferenceAsync(referenceId);
            return Json(new[] { referenceId }.ToDataSourceResultAsync(request));
        }

        public async Task<IActionResult> CheckListeReferencesHasAnySousReferenceAsync(List<Guid> referenceIds)
        {
            return Json(await _referenceService.CheckListeReferencesHasAnySousReferenceAsync(referenceIds));
        }
    }
}
