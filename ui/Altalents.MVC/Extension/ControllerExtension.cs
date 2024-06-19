using Altalents.MVC.Controllers.Admin;

using AlteaTools.Api.Core.Exceptions;

namespace Altalents.MVC.Extension
{
    public static class ControllerExtension
    {
        public static async Task<IActionResult> CallWithActionSecurisedAsync(this AdminController controller, DataSourceRequest request, Task<IActionResult> task)
        {
            IActionResult? page = controller.GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }

            try
            {
                return await task;
            }
            catch (BusinessException ex)
            {
                controller.ModelState.Clear();
                controller.ModelState.AddModelError(BusinessExceptionsResources.BUSINESS_EXCEPTION, ex.BusinessMessages?.FirstOrDefault() ?? ex.Message);
            }
            catch (Exception ex)
            {
                controller.ModelState.Clear();
                controller.ModelState.AddModelError(ExceptionsConstantes.TECHNICAL_EXCEPTION, ex.Message);
            }
            return controller.Json(new[] { "" }.ToDataSourceResult(request, controller.ModelState));
        }
    }
}
