using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Crmf;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
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
        private readonly IUiControlCategoryTypeService _uiControlCategoryTypeService;
        private IModuleLayoutService _moduleLayoutService;

        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="uiPageMetadataService"></param>
        /// <param name="lookupService"></param>
        public UiPageMetadataController(IUiControlCategoryTypeService uiControlCategoryTypeService,ILookupCategoryService lookupCategory,IListSorterService listSorter,ILookupService lookupService,IDataTypeService dataTypeService, IUiControlTypeService uiControlTypeService, IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataService uiPageMetadataService, IModuleLayoutService moduleLayoutService)
        {
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _uiControlTypeService = uiControlTypeService;
            _dataTypeService = dataTypeService;
            _uiControlCategoryTypeService = uiControlCategoryTypeService;
            _moduleLayoutService = moduleLayoutService;

        }
        /// <summary>
        /// To List All Record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var pageMetadata = _uiPageMetadataService.Get();
            var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadata);
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
            var controlCategoryType = _uiControlCategoryTypeService.Get();
            var pageMetadata = _uiPageMetadataService.Get();
            var Module = _moduleLayoutService.Get();
            var getdisplayName = _uiPageMetadataService.GetDisplayName();
            var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadata);
            var getdisplay = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(getdisplayName);
            var controlCategoryTypeList = _mapper.Map<List<UiControlCategoryTypeModel>, List<UiControlCategoryTypeDTO>>(controlCategoryType);
            var pages = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageList);
            var controles = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(controlList);
            var datas = _mapper.Map<List<DataTypeModel>, List<DataTypeDTO>>(dataList);
            ViewBag.UiControlTypes = controles;
            ViewBag.DataTypes = datas;
            ViewBag.UiPageTypes = pages;
            ViewBag.UiControlCategoryType = controlCategoryTypeList;
            ViewBag.UiPageMetadata = pageMetadatas;
            ViewBag.Modulelist = Module;
            ViewBag.displayName = getdisplay;

            return base.View(new Models.UiPageMetadataDTO { Id = id});
        }

        /// <summary>
        /// To Create Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="uiPageMetadataDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UiPageMetadataDTO uiPageMetadataDTO)
        {
            if (ModelState.IsValid)
            {
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
        /// <param name="LookupCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id,int parentId,int uiPageTypeId,int metadataModuleBridgeId, int uiControlTypeId,int dataTypeId , int uiControlCategoryTypeId)
        {
            if(id == null)
            {
                return NotFound();
            }
            var pageList = _uiPageTypeService.Get();
            var controlList = _uiControlTypeService.Get();
            var dataList = _dataTypeService.Get();
            var controlCategoryType = _uiControlCategoryTypeService.Get();
            var pageMetadata = _uiPageMetadataService.Get();
            var Module = _moduleLayoutService.Get();
            var getdisplayName = _uiPageMetadataService.GetDisplayName();
            var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadata);
            var getdisplay = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(getdisplayName);
            var controlCategoryTypeList = _mapper.Map<List<UiControlCategoryTypeModel>, List<UiControlCategoryTypeDTO>>(controlCategoryType);
            var pages = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageList);
            var controles = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(controlList);
            var datas = _mapper.Map<List<DataTypeModel>, List<DataTypeDTO>>(dataList);
            ViewBag.UiControlTypes = controles;
            ViewBag.DataTypes = datas;
            ViewBag.UiPageTypes = pages;
            ViewBag.UiControlCategoryType = controlCategoryTypeList;
            ViewBag.UiPageMetadata = pageMetadatas;
            ViewBag.Modulelist = Module;
            ViewBag.displayName = getdisplay;
            UiPageMetadataModel pageMetadataModel = _uiPageMetadataService.GetByPageId((int)id, uiPageTypeId, metadataModuleBridgeId);
            var pageMetadataas = _mapper.Map<UiPageMetadataModel,UiPageMetadataDTO>(pageMetadataModel);
            return View(pageMetadataas);
        }
        /// <summary>
        /// To Edit Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="metadataModuleBridgeId"></param>
        /// <param name="uiPageMetadataDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, int uiPageTypeId, int metadataModuleBridgeId, [Bind] UiPageMetadataDTO uiPageMetadataDTO)
        {
            if (id != uiPageMetadataDTO.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                
                var editMetadata = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(uiPageMetadataDTO);
                _uiPageMetadataService.Update(editMetadata);
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
        public IActionResult Delete(int id, int uiPageTypeId, int metadataModuleBridgeId)
        {
            if(id == null)
            {
                return NotFound();
            }
            UiPageMetadataModel uiPageMetadataModel = _uiPageMetadataService.GetByPageId((int)id, uiPageTypeId, metadataModuleBridgeId);
            var deleteMetadata = _mapper.Map<UiPageMetadataModel, UiPageMetadataDTO>(uiPageMetadataModel);
            return View(deleteMetadata);
        }
        /// <summary>
        /// To Delete Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id, int uiPageTypeId, int metadataModuleBridgeId)
        {
            if(id == null)
            {
                return NotFound();
            }
            _uiPageMetadataService.Delete((int)id, uiPageTypeId, metadataModuleBridgeId);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetExistingResult( int moduleLayoutId)
        {
            var uiPageMetadataModel = _uiPageMetadataService.GetResult(moduleLayoutId);
            var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(uiPageMetadataModel);
            return Ok(pageMetadatas);
        }
    }
}
