﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataController : Controller
    {
        private readonly IUiPageMetadataService _uiPageMetadataService;
        private readonly IUiPageTypeService _uiPageTypeService;
        private readonly IUiControlTypeService _uiControlTypeService;
        private readonly IMapper _mapper;
        private readonly IDataTypeService _dataTypeService;
        private readonly ILookupService _lookupService;
        private readonly ILookupCategoryService _lookupCategoryService;
        private readonly IListSorter pageType;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="uiPageMetadataService"></param>
        /// <param name="lookupService"></param>
        public UiPageMetadataController(ILookupCategoryService lookupCategory,IListSorter _listSorter,ILookupService lookupService,IDataTypeService dataTypeService, IUiControlTypeService uiControlTypeService, IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataService uiPageMetadataService)
        {
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _uiControlTypeService = uiControlTypeService;
            _dataTypeService = dataTypeService;
            _lookupService = lookupService;
            pageType = _listSorter;
            _lookupCategoryService = lookupCategory;
        }
        /// <summary>
        /// To List All Record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageMetadataModel>pageMetadata = _uiPageMetadataService.Get();
            var pageMetadatas = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(pageMetadata);
            
            return View(pageMetadatas.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
           var pageList = _uiPageTypeService.Get();
           var controlList = _uiControlTypeService.Get();
           var  dataList = _dataTypeService.Get();
            var lookupCategoryList = _lookupCategoryService.Get();
            var pages = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(pageList);
            var controles = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeDTO>>(controlList);
            var datas = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.DataTypeDTO>>(dataList);
            var categories = _mapper.Map<List<Business.Core.Model.LookupCategoryModel>, List<Models.LookupCategoryDTO>>(lookupCategoryList);
            var dropdownssss =    categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.UiControlTypes = controles;
            ViewBag.DataTypes = datas;
            ViewBag.UiPageTypes = pages;
            ViewBag.Lookups = dropdownssss;
            return base.View(new Models.UiPageMetadataDTO { Id = id});
        }
        /// <summary>
        /// To Create Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="uiPageMetadataDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageMetadataDTO uiPageMetadataDTO)
        {
            if (ModelState.IsValid)
            {
                var newDTO = new List<UiPageMetadataCharacteristicsModel>();
                uiPageMetadataDTO.SelectedLookupId.ForEach(x => newDTO.Add(new UiPageMetadataCharacteristicsModel { LookupId = x }));
                uiPageMetadataDTO.uiPageMetadataCharacteristics = newDTO;
                var createMetadataModel = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(uiPageMetadataDTO);
                
                _uiPageMetadataService.Create(createMetadataModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataDTO);
        }
        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageTypeId"></param>
        /// <param name="uiControlTypeId"></param>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id,int uiPageTypeId,int uiControlTypeId,int dataTypeId)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.UiControlTypeId = uiControlTypeId;
            ViewBag.DataTypeId = dataTypeId;
            ViewBag.UiPageTypeId = uiPageTypeId;
            List<Business.Core.Model.UiPageTypeModel> pages = _uiPageTypeService.Get();
            List<Business.Core.Model.UiControlTypeModel> controls = _uiControlTypeService.Get();
            List<Business.Core.Model.DataTypeModel> datas = _dataTypeService.Get();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeDTO>>(pages);
            var controlList = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeDTO>>(controls);
            var dataList = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.DataTypeDTO>>(datas);
            ViewBag.UiControlTypes = controlList;
            ViewBag.DataTypes = dataList;
            ViewBag.UiPageTypes = pageList;
            Business.Core.Model.UiPageMetadataModel pageMetadataModel = _uiPageMetadataService.GetById((int)id);
            var pageMetadata = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(pageMetadataModel);
            return View(pageMetadata);
        }
        /// <summary>
        /// To Edit Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageMetadataDTO uiPageMetadataDTO)
        {
            if (id != uiPageMetadataDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var editMetadata = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(uiPageMetadataDTO);
                _uiPageMetadataService.Update(id, editMetadata);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(uiPageMetadataDTO);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Business.Core.Model.UiPageMetadataModel uiPageMetadataModel = _uiPageMetadataService.GetById((int)id);
            var deleteMetadata = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(uiPageMetadataModel);
            return View(deleteMetadata);
        }
        /// <summary>
        /// To Delete Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _uiPageMetadataService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}
