using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataTypeController : Controller
    {
        public readonly IUiPageMetadataTypeService _uiPageMetadataTypeService;
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IMapper _mapper;
        public UiPageMetadataTypeController(IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataTypeService uiPageMetadataTypeService)
        {
            _uiPageMetadataTypeService = uiPageMetadataTypeService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
        }

        

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageMetadataModel>pageCon = _uiPageMetadataTypeService.GetAll();
            var pageCons = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(pageCon);
            
            return View(pageCons.AsEnumerable());
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List < Business.Core.Model.UiControlTypeModel>control = _uiPageTypeService.GetUiControlType();
            List<Business.Core.Model.DataTypeModel> data = _uiPageTypeService.GetDataType();
            var pagess = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var controless = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(control);
            var datass = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.UiDataTypeModel>>(data);
            ViewBag.Control = controless.ToList();
            ViewBag.Data= datass.ToList();
            ViewBag.Page = pagess.ToList();
            
            return base.View(new Models.UiPageMetadataDTO { Id = id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageMetadataDTO pageModel)
        {
            if (ModelState.IsValid)
            {
                var createMeta = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(pageModel);
                _uiPageMetadataTypeService.Create(createMeta);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }
        
        [HttpGet]
        public IActionResult Edit(int? id,int pId,int cId,int dId)
        {
            if(id == null)
            {
                return NotFound();
            }
            ViewBag.cid = cId;
            ViewBag.did = dId;
            ViewBag.pid = pId;
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List<Business.Core.Model.UiControlTypeModel> control = _uiPageTypeService.GetUiControlType();
            List<Business.Core.Model.DataTypeModel> data = _uiPageTypeService.GetDataType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var controlList = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(control);
            var dataList = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.UiDataTypeModel>>(data);
            ViewBag.Control = controlList.ToList();
            ViewBag.Data = dataList.ToList();
            ViewBag.page = pageList.ToList();
            Business.Core.Model.UiPageMetadataModel pMeta = _uiPageMetadataTypeService.GetById((int)id);
            var pageCons = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(pMeta);
            return View(pageCons);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Models.UiPageMetadataDTO pageModel)
        {
            if (id != pageModel.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var editMeta = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(pageModel);
                _uiPageMetadataTypeService.Update(id, editMeta);
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }
        public IActionResult Delete(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Business.Core.Model.UiPageMetadataModel pcon = _uiPageMetadataTypeService.GetById((int)id);
            var deleteM = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(pcon);
            return View(deleteM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            _uiPageMetadataTypeService.Delete((int)id);
            return RedirectToAction("Index");
        }

    }
}
