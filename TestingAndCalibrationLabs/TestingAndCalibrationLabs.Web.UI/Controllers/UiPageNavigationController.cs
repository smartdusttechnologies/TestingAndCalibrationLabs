using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageNavigationController : Controller
    {
        private readonly IUiPageNavigationService _uiPageNavigationService;
        private readonly IMapper _mapper;

        public UiPageNavigationController(IUiPageNavigationService uiPageNavigationService, IMapper mapper)
        {
            _uiPageNavigationService = uiPageNavigationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Records From Ui Page Type With Navigation Category And Pass It TO Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithNavigationCategoryList = _uiPageNavigationService.Get();
            var pageTypeList = _mapper.Map<List<UiPageNavigationModel>, List<UiPageNavigationDTO>>(pageWithNavigationCategoryList);

            if (pageTypeList != null && pageTypeList.Count > 0)
            {
                var dataAfterSorting = pageTypeList.GroupBy(x => new { x.UiNavigationCategoryId, x.UiNavigationCategoryName, x.Orders }).Select(x => new { Id = x.Key.UiNavigationCategoryId, Name = x.Key.UiNavigationCategoryName, Orders = x.Key.Orders, Childrens = x.ToList() });
                return Ok(dataAfterSorting);
            }
            return BadRequest();
        }
    }
}
