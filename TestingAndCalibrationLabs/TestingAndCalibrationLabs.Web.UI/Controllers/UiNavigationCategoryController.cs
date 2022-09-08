using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiNavigationCategoryController : Controller
    {
        private readonly IUiNavigationCategoryService _navigationCategoryService;
        private readonly IMapper _mapper;
        private readonly IUiPageTypeService _uiPageTypeService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="navigationCategoryService"></param>
        /// <param name="mapper"></param>
        /// <param name="pageTypeService"></param>
        public UiNavigationCategoryController(IUiNavigationCategoryService navigationCategoryService, IMapper mapper, IUiPageTypeService pageTypeService)
        {
            _navigationCategoryService = navigationCategoryService;
            _mapper = mapper;
            _uiPageTypeService = pageTypeService;
        }
        /// <summary>
        /// Get All Records From Ui Page Type With Navigation Category And Pass It TO Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Updex()
        {
            var page = _navigationCategoryService.GetNavigationCategoryWithPageTypes();
            var mapped = _mapper.Map<List<UiPageNavigationModel>, List<Models.UiPageNavigationDTO>>(page);

            if (mapped != null && mapped.Count > 0)
            {
                var data = mapped.GroupBy(x => new { x.UiNavigationCategoryId, x.UiNavigationCategoryName }).Select(x => new { Id = x.Key.UiNavigationCategoryId, Name = x.Key.UiNavigationCategoryName, Childrens = x.ToList() });
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
