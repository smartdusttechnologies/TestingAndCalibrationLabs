using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataCharacteristicsController : Controller
    {
        private readonly IUiPageMetadataCharacteristicsService _uiPageMetadataCharacteristicsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiPageMetadataCharacteristicsService"></param>
        public UiPageMetadataCharacteristicsController(IUiPageMetadataCharacteristicsService uiPageMetadataCharacteristicsService)
        {
           _uiPageMetadataCharacteristicsService = uiPageMetadataCharacteristicsService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// To Get All PageMetadataCharacteristics By PageMetadataId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get(int id)
        {
            var list = _uiPageMetadataCharacteristicsService.GetByPageMetadataId(id);
            return Ok(list);
        }
    }
}
