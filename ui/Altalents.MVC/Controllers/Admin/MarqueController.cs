using AlteaTools.Api.Core.Exceptions;

using Altalents.Commun.Settings;
using Altalents.Entities.Enum;
using Altalents.IBusiness.DTO.Requests;
using Altalents.MVC.Models.Marque;

using Microsoft.Extensions.Options;

namespace Altalents.MVC.Controllers.Admin
{
    public class MarqueController : AdminController
    {
        public static string ControllerName = "Marque";
        private readonly IMarqueService _marqueService;
        private readonly ISousReferenceService _sousReferenceService;
        private readonly MarqueSettings _marqueSettings;

        public MarqueController(IMarqueService marqueService,
            ISousReferenceService sousReferenceService,
            IOptionsMonitor<MarqueSettings> marqueSettings,
            ILogger<MarqueController> logger) : base(logger)
        {
            _sousReferenceService = sousReferenceService;
            _marqueService = marqueService;
            _marqueSettings = marqueSettings.CurrentValue;
        }

        [HttpPost]
        public IActionResult PartialViewGestionMarqueReferenceLibre(Guid marqueId, EnumTypeMarqueReferenceLibre type)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            PartialViewGestionMarqueReferenceLibreModel model = new()
            {
                MarqueId = marqueId,
                Type = type
            };
            return base.PartialView("PartialViewGestionMarqueReferenceLibre", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewSousReferenceAsync(PartialViewSousReferenceRequestDto request)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            List<SousReferenceLightDto> sousReferencesSelectable = await _sousReferenceService.GetAllSousReferencesAsync(request.ReferenceIds);
            PartialViewSousReferenceModel model = new()
            {
                SousReferencesSelected = sousReferencesSelectable.Where(x => request.SousReferenceIdsSelected.Contains(x.SousReferenceId)).ToList(),
                SousReferencesSelectable = sousReferencesSelectable,
                MultiSelectId = request.MultiSelectId,
                OnChangeAction = request.OnChangeAction
            };
            return base.PartialView("PartialViewSousReference", model);
        }

        [HttpPost]
        public IActionResult PartialViewGridMarques(Guid? idReference = null, Guid? idSousReference = null, Guid? marqueId = null)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            PartialViewGridMarquesModel model = new()
            {
                ReferenceId = idReference,
                SousReferenceId = idSousReference,
                MarqueId = marqueId
            };
            return base.PartialView("PartialViewGridMarques", model);
        }

        [HttpPost]
        public IActionResult PartialViewAddNomMarque(Guid marqueId)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            return base.PartialView("PartialViewAddNomMarque", marqueId);
        }

        [HttpPost]
        public async Task<IActionResult> LoadMarqueRenvoisInMarqueRenvoisTemporairesAsync(Guid marqueId)
        {
            await _marqueService.LoadMarqueRenvoisInMarqueRenvoisTemporairesAsync(marqueId);
            return base.Json(new { });
        }

        public async Task<IActionResult> AddFileAsync(IEnumerable<IFormFile> filesUploadFileMarque, Guid idMarque)
        {
            try
            {
                IActionResult? page = GetNotLoggedReturnPage();
                if (page != null)
                {
                    return page;
                }

                await _marqueService.AddFileAsync(filesUploadFileMarque, idMarque);
                return Json(new BusinessErrorForKendo { HasErreur = false });
            }
            catch (BusinessException ex)
            {
                return Json(new BusinessErrorForKendo { HasErreur = true, Message = ex.BusinessMessages.FirstOrDefault() });
            }
        }

        public async Task<IActionResult> CreateAsync(Guid? idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }

            if (idMarque.HasValue)
            {
                await CheckMarqueExistAsync(idMarque);
                return View(idMarque);
            }
            Guid nouvelleMarqueId = await _marqueService.InsertNouvelleMarqueAsync();
            return View(nouvelleMarqueId);
        }

        public async Task<IActionResult> UpdateAsync(Guid? idMarque, CancellationToken cancellationToken = default)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            UpdateMarqueModel model = new()
            {
                MarqueId = idMarque,
                ReferenceLugt = idMarque != null ? await _marqueService.GetReferenceLugtByMarqueIdAsync(idMarque.Value, cancellationToken: cancellationToken) : ""
            };
            return View(model);
        }

        private async Task CheckMarqueExistAsync(Guid? idMarque)
        {
            await _marqueService.CheckMarqueExistAsync(idMarque.Value);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewUpdateMarque(Guid idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            await CheckMarqueExistAsync(idMarque);

            PartialViewUpdateMarqueModel model = new()
            {
                IdMarque = idMarque,
                Settings = _marqueSettings,
                DatePublication = await _marqueService.GetDatePublicationByMarqueIdAsync(idMarque),
            };
            return base.PartialView("PartialViewUpdateMarque", model);
        }

        [HttpPut]
        public async Task UpdateIndexMarqueAsync(UpdateIndexMarqueRequestDto data)
        {
            await _marqueService.UpdateIndexMarqueAsync(data);
        }

        [HttpPut]
        public async Task UpdateNoticesMarqueAsync(Dictionary<Guid, UpdateNoticeRequestDto> data)
        {
            await _marqueService.UpdateNoticesMarqueAsync(data);
        }

        [HttpPut]
        public async Task UpdateMarqueRenvoisAsync(Guid marqueId)
        {
            await _marqueService.UpdateMarqueRenvoisAsync(marqueId);
        }

        [HttpPut]
        public async Task UpdateOrdresImagesMarqueAsync(List<ImageDto> images)
        {
            await _marqueService.UpdateOrdresImagesMarqueAsync(images);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewImageMarque(Guid idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            await CheckMarqueExistAsync(idMarque);

            PartialViewImageMarqueModel model = new()
            {
                Images = await _marqueService.GetImagesAsync(idMarque)
            };
            return base.PartialView("PartialViewImageMarque", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewNoticesMarqueAsync(Guid idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            await CheckMarqueExistAsync(idMarque);

            PartialViewNoticesMarqueModel model = new()
            {
                IsFinalized = await _marqueService.GetMarqueIsFinalized(idMarque),
                IdMarque = idMarque,
                Notices = await _marqueService.GetNoticesMarquesDto(idMarque),
            };

            return base.PartialView("PartialViewNoticesMarque", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewIndexMarque(Guid idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            await CheckMarqueExistAsync(idMarque);

            IndexMarqueDto model = await _marqueService.GetUpdateIndexMarqueDtoAsync(idMarque);

            return base.PartialView("PartialViewIndexMarque", model);
        }

        [HttpPost]
        public async Task<IActionResult> PartialViewUploadFileToMarque(Guid idMarque)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            await CheckMarqueExistAsync(idMarque);

            PartialViewUploadFileToMarqueModel model = new()
            {
                IdMarque = idMarque,
                IsEnabled = !await _marqueService.HasMaxImageAsync(idMarque),
                AllowedExtensions = _marqueSettings.AllowedExtensions
            };

            return base.PartialView("PartialViewUploadFileToMarque", model);
        }

        public async Task<IActionResult> GetMarquesAssocieesReferenceAsync([DataSourceRequest] DataSourceRequest request, Guid referenceId, Guid? sousReferenceId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetMarquesAssocieesReferenceRunnerAsync(request, referenceId, sousReferenceId));
        }

        public async Task<IActionResult> GetMarquesRenvoisByMarqueIdAsync([DataSourceRequest] DataSourceRequest request, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetMarquesRenvoisByMarqueIdRunnerAsync(request, marqueId));
        }

        private async Task<IActionResult> GetMarquesRenvoisByMarqueIdRunnerAsync(DataSourceRequest request, Guid marqueId)
        {
            DataSourceResult marques = await (await _marqueService.GetMarquesRenvoisByMarqueIdAsync(marqueId)).ToDataSourceResultAsync(request);
            return base.Json(marques);
        }

        public async Task<List<MarqueDtoBase>> GetMarquesAsync(string text)
        {
            return await _marqueService.GetMarquesFinaliseesAsync(text);
        }

        public async Task<List<MarqueLightDto>> GetMarquesAjoutablesMarqueRenvoisAsync(string text, Guid marqueId)
        {
            return await _marqueService.GetMarquesAjoutablesMarqueRenvoisAsync(text, marqueId);
        }

        private async Task<IActionResult> GetMarquesAssocieesReferenceRunnerAsync(DataSourceRequest request, Guid referenceId, Guid? sousReferenceId)
        {
            DataSourceResult marques = await (await _marqueService.GetMarquesAssocieesByReferenceIdAsync(referenceId, sousReferenceId)).ToDataSourceResultAsync(request);
            return base.Json(marques);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNoticeMarqueAsync(OngletNoticeMarqueDto ongletNoticeMarque, Guid marqueId)
        {
            IActionResult? page = GetNotLoggedReturnPage();
            if (page != null)
            {
                return page;
            }
            Guid noticeMarqueId = await _marqueService.InsertOngletNoticeMarqueAsync(ongletNoticeMarque, marqueId);
            return base.Json(noticeMarqueId);
        }

        public async Task<IActionResult> GetMarqueReferenceLibresAsync([DataSourceRequest] DataSourceRequest request, EnumTypeMarqueReferenceLibre type, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetMarqueReferenceLibresRunnerAsync(request, type, marqueId));
        }

        private async Task<IActionResult> GetMarqueReferenceLibresRunnerAsync(DataSourceRequest request, EnumTypeMarqueReferenceLibre type, Guid marqueId)
        {
            DataSourceResult marqueReferenceLibres = await _marqueService.GetMarqueReferenceLibresByTypeEtMarqueId(type, marqueId).ToDataSourceResultAsync(request);
            return base.Json(marqueReferenceLibres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarqueReferenceLibreMotLatinAsync(DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, CreateMarqueReferenceLibreAsync(request, marqueReferenceLibre, EnumTypeMarqueReferenceLibre.MotLatin, marqueId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarqueReferenceLibreInitialeLatin(DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, CreateMarqueReferenceLibreAsync(request, marqueReferenceLibre, EnumTypeMarqueReferenceLibre.InitialeLatin, marqueId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarqueReferenceLibreAsync(DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre, EnumTypeMarqueReferenceLibre type, Guid marqueId)
        {
            marqueReferenceLibre.IdMarque = marqueId;
            marqueReferenceLibre.Type = type;
            return await this.CallWithActionSecurisedAsync(request, CreateMarqueReferenceLibreRunnerAsync(request, marqueReferenceLibre));
        }

        private async Task<IActionResult> CreateMarqueReferenceLibreRunnerAsync(DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre)
        {
            return Json(new[] { await _marqueService.InsertMarqueReferenceLibreAsync(marqueReferenceLibre) }.ToDataSourceResult(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMarqueReferenceLibreAsync([DataSourceRequest] DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre)
        {
            return await this.CallWithActionSecurisedAsync(request, UpdateMarqueReferenceLibreRunnerAsync(request, marqueReferenceLibre));
        }

        private async Task<IActionResult> UpdateMarqueReferenceLibreRunnerAsync(DataSourceRequest request, MarqueReferenceLibreDto marqueReferenceLibre)
        {
            await _marqueService.UpdateMarqueReferenceLibreAsync(marqueReferenceLibre);
            return Json(new[] { marqueReferenceLibre }.ToDataSourceResult(request));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMarqueReferenceLibreAsync([DataSourceRequest] DataSourceRequest request, Guid marqueReferenceLibreId, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteMarqueReferenceLibreRunnerAsync(request, marqueReferenceLibreId, marqueId));
        }

        private async Task<IActionResult> DeleteMarqueReferenceLibreRunnerAsync(DataSourceRequest request, Guid marqueReferenceLibreId, Guid marqueId)
        {
            await _marqueService.DeleteMarqueReferenceLibreAsync(marqueReferenceLibreId, marqueId);
            return Json(new[] { marqueReferenceLibreId }.ToDataSourceResultAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMarqueRenvoisAsync([DataSourceRequest] DataSourceRequest request, Guid marqueIdASupprimer, Guid marqueIdTravail)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteMarqueRenvoisRunnerAsync(request, marqueIdASupprimer, marqueIdTravail));
        }

        private async Task<IActionResult> DeleteMarqueRenvoisRunnerAsync(DataSourceRequest request, Guid marqueIdASupprimer, Guid marqueIdTravail)
        {
            await _marqueService.DeleteMarqueRenvoisAsync(marqueIdASupprimer, marqueIdTravail);
            return Json(new[] { marqueIdASupprimer, marqueIdTravail }.ToDataSourceResultAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> InsertMarqueRenvoisAsync([DataSourceRequest] DataSourceRequest request, Guid marqueIdAAjouter, Guid marqueIdTravail)
        {
            return await this.CallWithActionSecurisedAsync(request, InsertMarqueRenvoisRunnerAsync(request, marqueIdAAjouter, marqueIdTravail));
        }

        private async Task<IActionResult> InsertMarqueRenvoisRunnerAsync(DataSourceRequest request, Guid marqueIdAAjouter, Guid marqueIdTravail)
        {
            return Json(new[] { await _marqueService.InsertMarqueRenvoisAsync(marqueIdAAjouter, marqueIdTravail) }.ToDataSourceResultAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImagesMarqueAsync([DataSourceRequest] DataSourceRequest request, Guid imageId)
        {
            return await this.CallWithActionSecurisedAsync(request, DeleteImagesMarqueRunnerAsync(request, imageId));
        }

        private async Task<IActionResult> DeleteImagesMarqueRunnerAsync(DataSourceRequest request, Guid imageId)
        {
            await _marqueService.DeleteImagesMarqueAsync(imageId);
            return Json(new[] { imageId }.ToDataSourceResultAsync(request));
        }

        public async Task<IActionResult> GetNombreMarqueAssociesByMarqueIdAsync([DataSourceRequest] DataSourceRequest request, Guid marqueId)
        {
            return await this.CallWithActionSecurisedAsync(request, GetNombreMarqueAssociesByMarqueIdRunnerAsync(request, marqueId));
        }

        private async Task<IActionResult> GetNombreMarqueAssociesByMarqueIdRunnerAsync(DataSourceRequest request, Guid marqueId)
        {
            return Json(new[] { await _marqueService.GetNombreMarqueAssociesByMarqueIdAsync(marqueId) }.ToDataSourceResultAsync(request));
        }
    }
}
