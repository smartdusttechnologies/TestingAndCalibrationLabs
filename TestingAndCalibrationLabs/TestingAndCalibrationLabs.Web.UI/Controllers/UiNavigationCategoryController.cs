using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiNavigationCategoryController : Controller
    {
        private readonly IUiNavigationCategoryService _navigationCategoryService;
        private readonly IMapper _mapper;
        private readonly IUiPageTypeService _uiPageTypeService;
        public UiNavigationCategoryController(IUiNavigationCategoryService navigationCategoryService, IMapper mapper, IUiPageTypeService pageTypeService)
        {
            _navigationCategoryService = navigationCategoryService;
            _mapper = mapper;
            _uiPageTypeService = pageTypeService; 
        }

        [HttpPost]
        public IActionResult Updex()
        {

           var page = _navigationCategoryService.GetNavigationCategoryWithPageTypes();
            var mapped = _mapper.Map<List<UiPageNavigationModel>,List< Models.UiPageNavigationDTO >> (page);
            
            if (mapped != null && mapped.Count > 0)
            {
                return Ok(mapped);
            }
            return BadRequest();
        }
    }
}
