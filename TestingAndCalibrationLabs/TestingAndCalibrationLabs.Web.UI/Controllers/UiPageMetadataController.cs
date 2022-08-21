using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using TestingAndCalibrationLabs.Business.Core.Interfaces;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class UiPageMetadataController : Controller
    {
        public readonly IUiPageMetadataService _uiPageMetadataService;
        public readonly IUiPageTypeService _uiPageTypeService;
        public readonly IUiControlTypeService _uiControlTypeService;
        public readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="uiControlTypeService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiPageTypeService"></param>
        /// <param name="uiPageMetadataTypeService"></param>
        public UiPageMetadataController(IUiControlTypeService uiControlTypeService, IMapper mapper, IUiPageTypeService uiPageTypeService ,IUiPageMetadataService uiPageMetadataService)
        {
            _uiPageMetadataService = uiPageMetadataService;
            _uiPageTypeService = uiPageTypeService;
            _mapper = mapper;
            _uiControlTypeService = uiControlTypeService;
        }
        /// <summary>
        /// To List All Record
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Business.Core.Model.UiPageMetadataModel>pageCon = _uiPageMetadataService.GetAll();
            var pageCons = _mapper.Map<List<Business.Core.Model.UiPageMetadataModel>, List<Models.UiPageMetadataDTO>>(pageCon);
            
            return View(pageCons.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            
            List<Business.Core.Model.UiPageTypeModel> page = _uiPageTypeService.GetAll();
            List < Business.Core.Model.UiControlTypeModel>control = _uiControlTypeService.GetAll();
            List<Business.Core.Model.DataTypeModel> data = _uiPageTypeService.GetDataType();
            var pagess = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var controless = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(control);
            var datass = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.UiDataTypeModel>>(data);
            ViewBag.Control = controless.ToList();
            ViewBag.Data= datass.ToList();
            ViewBag.Page = pagess.ToList();
            
            return base.View(new Models.UiPageMetadataDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="pageModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Models.UiPageMetadataDTO pageModel)
        {
            if (ModelState.IsValid)
            {
                var createMeta = _mapper.Map<Models.UiPageMetadataDTO, Business.Core.Model.UiPageMetadataModel>(pageModel);
                _uiPageMetadataService.Create(createMeta);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(pageModel);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pId"></param>
        /// <param name="cId"></param>
        /// <param name="dId"></param>
        /// <returns></returns>
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
            List<Business.Core.Model.UiControlTypeModel> control = _uiControlTypeService.GetAll();
            List<Business.Core.Model.DataTypeModel> data = _uiPageTypeService.GetDataType();
            var pageList = _mapper.Map<List<Business.Core.Model.UiPageTypeModel>, List<Models.UiPageTypeModel>>(page);
            var controlList = _mapper.Map<List<Business.Core.Model.UiControlTypeModel>, List<Models.UiControlTypeModel>>(control);
            var dataList = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.UiDataTypeModel>>(data);
            ViewBag.Control = controlList.ToList();
            ViewBag.Data = dataList.ToList();
            ViewBag.page = pageList.ToList();
            Business.Core.Model.UiPageMetadataModel pMeta = _uiPageMetadataService.GetById((int)id);
            var pageCons = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(pMeta);
            return View(pageCons);
        }
        /// <summary>
        /// To Edit Record In Ui Page Metadata Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageModel"></param>
        /// <returns></returns>
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
                _uiPageMetadataService.Update(id, editMeta);
                return RedirectToAction("Index");
            }
            return View(pageModel);
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
            Business.Core.Model.UiPageMetadataModel pcon = _uiPageMetadataService.GetById((int)id);
            var deleteM = _mapper.Map<Business.Core.Model.UiPageMetadataModel, Models.UiPageMetadataDTO>(pcon);
            return View(deleteM);
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
            return RedirectToAction("Index");
        }

    }
}
