using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Web.UI.Models.Common;

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
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="uiPageMetadataService"></param>
        /// <param name="lookupService"></param>
        public UiPageMetadataController(IUiControlCategoryTypeService uiControlCategoryTypeService,ILookupCategoryService lookupCategory,IListSorterService listSorter,ILookupService lookupService,IDataTypeService dataTypeService, IUiControlTypeService uiControlTypeService, IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataService uiPageMetadataService)
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
            var gridDto = new GridDTO();
            gridDto.Columns = typeof(UiPageMetadataDTO).GetProperties().Select(x => x.Name).ToList();
            gridDto.Values = new List<GridRow>();
            foreach (var row in pageMetadatas)
            {
                var rowValue = new GridRow();
                rowValue.Id = row.Id;
                
                rowValue.Values = new List<string>();
                rowValue.Values.Add(row.Id.ToString());
                rowValue.Values.Add(row.Name);
                rowValue.Values.Add(row.UiPageTypeId.ToString());
                rowValue.Values.Add(row.UiPageTypeName);
                rowValue.Values.Add(row.UiControlTypeId.ToString());
                rowValue.Values.Add(row.UiControlTypeName);
                rowValue.Values.Add(row.IsRequired.ToString());
                rowValue.Values.Add(row.UiControlDisplayName);
                rowValue.Values.Add(row.DataTypeId.ToString());
                rowValue.Values.Add(row.DataTypeName);
                rowValue.Values.Add(row.LookupCategoryId.ToString());
                rowValue.Values.Add(row.LookupCategoryName);
                rowValue.Values.Add(row.ControlCategoryId.ToString());
                rowValue.Values.Add(row.ControlCategoryName);
                rowValue.Values.Add(row.UiControlCategoryTypeId.ToString());
                rowValue.Values.Add(row.UiControlCategoryTypeName);
                rowValue.Values.Add(row.UiControlCategoryTypeTemplate);
                rowValue.Values.Add(row.ParentId.ToString());
                rowValue.Values.Add(row.ModuleId.ToString());
                rowValue.Values.Add(row.Position.ToString());
                rowValue.Values.Add(row.MultiValueControl.ToString());

                gridDto.Values.Add(rowValue);
            }
            var uiData = new IndexPageDTO();
            uiData.PageTitle = "UI Page Metadata";
            uiData.GridData = gridDto;
            return View(uiData);
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
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
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
            var pageMetadata = _mapper.Map<UiPageMetadataModel,UiPageMetadataDTO>(pageMetadataModel);
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
        public IActionResult Edit(int id, [Bind] UiPageMetadataDTO uiPageMetadataDTO)
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
            UiPageMetadataModel uiPageMetadataModel = _uiPageMetadataService.GetById((int)id);
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
