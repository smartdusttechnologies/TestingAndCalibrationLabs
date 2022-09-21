using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Data.Repository.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataCharacteristicsController : Controller
    {
        private readonly IUiPageMetadataCharacteristicsService _uiPageMetadataCharacteristicsService;
        public UiPageMetadataCharacteristicsController(IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService)
        {
           _uiPageMetadataCharacteristicsService = uiPageMetadataCharacteristicsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Get(int id)
        {
            var list = _uiPageMetadataCharacteristicsService.Get(id);
            return Ok(list);
        }
    }
}
