﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageNavigationController : Controller
    {
        private readonly IUiNavigationCategoryService _uiNavigationCategoryService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiNavigationCategoryService"></param>
        /// <param name="mapper"></param>
        public UiPageNavigationController(IUiNavigationCategoryService uiNavigationCategoryService, IMapper mapper)
        {
            _uiNavigationCategoryService = uiNavigationCategoryService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All Records From Ui Page Type With Navigation Category And Pass It TO Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithNavigationCategoryList = _uiNavigationCategoryService.GetNavigationCategoryWithPageTypes();
            var pageTypeList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(pageWithNavigationCategoryList);

            if (pageTypeList != null && pageTypeList.Count > 0)
            {
                var dataAfterSorting = pageTypeList.GroupBy(x => new { x.UiNavigationCategoryId, x.UiNavigationCategoryName,x.Orders }).Select(x => new { Id = x.Key.UiNavigationCategoryId, Name = x.Key.UiNavigationCategoryName, Orders = x.Key.Orders, Childrens = x.ToList() });
                return Ok(dataAfterSorting);
            }
            return BadRequest();
        }
    }
}
