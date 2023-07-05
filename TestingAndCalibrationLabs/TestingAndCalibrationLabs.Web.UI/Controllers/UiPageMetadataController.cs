using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private readonly IListSorterService _listSorter;
        private readonly IUiControlCategoryTypeService _uiControlCategoryTypeService;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="uiPageMetadataService"></param>
        /// <param name="lookupService"></param>
        public UiPageMetadataController(IUiControlCategoryTypeService uiControlCategoryTypeService,ILookupCategoryService lookupCategory,IListSorterService listSorter,ILookupService lookupService,IDataTypeService dataTypeService, IUiControlTypeService uiControlTypeService, IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataService uiPageMetadataService, ILogger<UiPageMetadataController> logger)
        {
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _uiControlTypeService = uiControlTypeService;
            _dataTypeService = dataTypeService;
            _lookupService = lookupService;
            _listSorter = listSorter;
            _lookupCategoryService = lookupCategory;
            _uiControlCategoryTypeService = uiControlCategoryTypeService;
            _logger = logger;
        }

        /// <summary>
        /// To List All Record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            try
            {              
                ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
                var pageMetadata = _uiPageMetadataService.Get();
                var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadata);
                _logger.LogInformation("UiPageMetadata index has been successfully accessed");
                return View(pageMetadatas.AsEnumerable());               
            }
            catch(Exception exception)
            {
                _logger.LogError(""+exception.Message);
            }

            return View();
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            try
            {             
                var pageList = _uiPageTypeService.Get();
                var controlList = _uiControlTypeService.Get();
                var dataList = _dataTypeService.Get();
                var controlCategoryType = _uiControlCategoryTypeService.Get();
                var pageMetadata = _uiPageMetadataService.Get();
                var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadata);
                var controlCategoryTypeList = _mapper.Map<List<UiControlCategoryTypeModel>, List<UiControlCategoryTypeDTO>>(controlCategoryType);
                var pages = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pageList);
                var controles = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(controlList);
                var datas = _mapper.Map<List<DataTypeModel>, List<DataTypeDTO>>(dataList);
                // var dropdownssss =    categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
                ViewBag.UiControlTypes = controles;
                ViewBag.DataTypes = datas;
                ViewBag.UiPageTypes = pages;
                ViewBag.UiControlCategoryType = controlCategoryTypeList;
                ViewBag.UiPageMetadata = pageMetadatas;
                _logger.LogInformation("UiPageMetadata create get method has been successfully accessed");
                return base.View(new Models.UiPageMetadataDTO { Id = id });
            }
           catch(Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();
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
            try
            {
                
                if (ModelState.IsValid)
                {

                    var createMetadataModel = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(uiPageMetadataDTO);

                    _uiPageMetadataService.Create(createMetadataModel);
                    TempData["IsTrue"] = true;
                    _logger.LogInformation("UiPageMetadata create post has been accessed");
                    return RedirectToAction("Index");
                }
                _logger.LogError("you are unauthorized");
                return View(uiPageMetadataDTO);
            }
            catch(Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();
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
        public IActionResult Edit(int? id,int parentId,int uiPageTypeId,int uiControlTypeId,int dataTypeId , int uiControlCategoryTypeId)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();

                }
                ViewBag.UiControlTypeId = uiControlTypeId;
                ViewBag.DataTypeId = dataTypeId;
                ViewBag.UiPageTypeId = uiPageTypeId;
                ViewBag.UiPageMetadataId = parentId;
                ViewBag.UiControlCategoryTypeId = uiControlCategoryTypeId;
                var pages = _uiPageTypeService.Get();
                var controls = _uiControlTypeService.Get();
                var datas = _dataTypeService.Get();
                var controlCategoryType = _uiControlCategoryTypeService.Get();
                var pageMetadataList = _uiPageMetadataService.Get();
                var pageMetadatas = _mapper.Map<List<UiPageMetadataModel>, List<UiPageMetadataDTO>>(pageMetadataList);
                var controlCategoryTypeList = _mapper.Map<List<UiControlCategoryTypeModel>, List<UiControlCategoryTypeDTO>>(controlCategoryType);

                var pageList = _mapper.Map<List<UiPageTypeModel>, List<UiPageTypeDTO>>(pages);
                var controlList = _mapper.Map<List<UiControlTypeModel>, List<UiControlTypeDTO>>(controls);
                var dataList = _mapper.Map<List<DataTypeModel>, List<DataTypeDTO>>(datas);
                ViewBag.UiControlTypes = controlList;
                ViewBag.DataTypes = dataList;
                ViewBag.UiPageTypes = pageList;
                ViewBag.UiControlCategoryType = controlCategoryTypeList;
                ViewBag.UiPageMetadata = pageMetadatas;
                UiPageMetadataModel pageMetadataModel = _uiPageMetadataService.GetById((int)id);
                var pageMetadata = _mapper.Map<UiPageMetadataModel, UiPageMetadataDTO>(pageMetadataModel);
                _logger.LogInformation("UiPageMetadata edit get has been accessed");
                return View(pageMetadata);
            }
            catch (Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();

        }

        /// <summary>
        /// To Edit Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uiPageMetadataDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UiPageMetadataDTO uiPageMetadataDTO)
        {
            try
            {
                if (id != uiPageMetadataDTO.Id)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                if (ModelState.IsValid)
                {

                    var editMetadata = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(uiPageMetadataDTO);
                    _uiPageMetadataService.Update(id, editMetadata);
                    TempData["IsTrue"] = true;
                    _logger.LogInformation("UiPageMetadata edit post  has been accessed");
                    return RedirectToAction("Index");
                }
                _logger.LogError("you are unauthorized");
                return View(uiPageMetadataDTO);
            }
            catch (Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();
        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int?id)
        {
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                UiPageMetadataModel uiPageMetadataModel = _uiPageMetadataService.GetById((int)id);
                var deleteMetadata = _mapper.Map<UiPageMetadataModel, UiPageMetadataDTO>(uiPageMetadataModel);
                _logger.LogInformation("UiPageMetadata delete  has been accessed");
                return View(deleteMetadata);
            }
            catch (Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();
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
            try
            {
                if (id == null)
                {
                    _logger.LogError("id is null");
                    return NotFound();
                }
                _uiPageMetadataService.Delete((int)id);
                TempData["IsTrue"] = true;
                _logger.LogInformation("UiPageMetadata delete  has been accessed");
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                _logger.LogError("." + exception.Message);
            }
            return View();
        }
    }
}
