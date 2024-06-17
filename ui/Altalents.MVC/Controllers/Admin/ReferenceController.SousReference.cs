using Altalents.MVC.Controllers.Admin;

namespace Altalents.MVC.Controllers
{
    public partial class ReferenceController : AdminController
    {
        [HttpPost]
        public async Task<IActionResult> CreateSousReferenceAsync([DataSourceRequest] DataSourceRequest request, [FromQuery] Guid referenceId, SousReferenceDto sousReference)
        {
            sousReference.ReferenceId = referenceId;
            return await this.CallWithActionSecurisedAsync(request, CreateSousReferenceRunnerAsync(request, sousReference));
        }

        public async Task<IActionResult> GetSousReferencesAsync([DataSourceRequest] DataSourceRequest request, Guid referenceId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetSousReferencesRunnerAsync(request, referenceId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSousReferenceAsync([DataSourceRequest] DataSourceRequest request, SousReferenceDto sousReference)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateSousReferenceRunnerAsync(request, sousReference));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSousReferenceAsync([DataSourceRequest] DataSourceRequest request, Guid sousReferenceId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteSousReferenceRunnerAsync(request, sousReferenceId));
        }

        private async Task<IActionResult> CreateSousReferenceRunnerAsync(DataSourceRequest request, SousReferenceDto sousReference)
        {
            return Json(new[] { await _sousReferenceService.InsertSousReferenceAsync(sousReference) }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> GetSousReferencesRunnerAsync(DataSourceRequest request, Guid referenceId)
        {
            DataSourceResult sousReferences = await (await _sousReferenceService.GetSousReferencesByReferenceIdAsync(referenceId)).ToDataSourceResultAsync(request);
            return base.Json(sousReferences);
        }

        private async Task<IActionResult> UpdateSousReferenceRunnerAsync(DataSourceRequest request, SousReferenceDto sousReference)
        {
            await _sousReferenceService.UpdateSousReferenceAsync(sousReference);
            return Json(new[] { sousReference }.ToDataSourceResult(request));
        }

        private async Task<IActionResult> DeleteSousReferenceRunnerAsync(DataSourceRequest request, Guid sousReferenceId)
        {
            await _sousReferenceService.DeleteSousReferenceAsync(sousReferenceId);
            return Json(new[] { sousReferenceId }.ToDataSourceResultAsync(request));
        }
    }
}
