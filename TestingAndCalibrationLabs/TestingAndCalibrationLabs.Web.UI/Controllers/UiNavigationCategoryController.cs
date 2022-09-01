using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiNavigationCategoryController : Controller
    {
        private readonly IUiNavigationCategoryService _navigationCategoryService;
        private readonly IMapper _mapper;
        public UiNavigationCategoryController(IUiNavigationCategoryService navigationCategoryService, IMapper mapper)
        {
            _navigationCategoryService = navigationCategoryService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Updex()
        {
           var page = _navigationCategoryService.Get();
            var pageData = _mapper.Map<List<Business.Core.Model.UiNavigationCategoryModel>, List<Models.UiNavigationCategoryModel>>(page);
            if (pageData != null)
            {
                return Ok(pageData);
            }
            return BadRequest(pageData);
        }
    }
}
