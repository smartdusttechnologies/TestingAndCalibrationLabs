using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ModuleLayoutController : Controller
    { 
        private readonly IModuleLayoutService _moduleLayoutService;
        public readonly IMapper _mapper;
        public readonly ILayoutService _layoutService;
        private readonly IModuleService _moduleService;

        public ModuleLayoutController(IModuleLayoutService moduleLayoutService, IMapper mapper, ILayoutService layoutService, IModuleService moduleService)
        {
            _moduleLayoutService = moduleLayoutService;
            _mapper = mapper;
            _layoutService = layoutService;
            _moduleService = moduleService;

        }
        /// <summary>
        /// Get All The Record From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<ModuleLayoutModel> controlTypeListModel = _moduleLayoutService.Get();
            var controlTypeList = _mapper.Map<List<ModuleLayoutModel>, List<ModuleLayoutDTO>>(controlTypeListModel);
            return View(controlTypeList.AsEnumerable());
        }
        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ModuleLayoutModel controlTypeModel = _moduleLayoutService.GetById((int)id);
            var controlCategoryType = _layoutService.Get();
            var controlCategoryTypeList = _mapper.Map<List<Layout2Model>, List<Layout2DTO>>(controlCategoryType);
            var pageModule = _moduleService.Get();
            var ModuleTypeList = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(pageModule);
            if (controlTypeModel == null)
            {
                return NotFound();
            }
            ViewBag.ControlCategoryName = controlCategoryTypeList;
            ViewBag.DisplayName = ModuleTypeList;
            var controlTypeEditModel = _mapper.Map<ModuleLayoutModel, ModuleLayoutDTO>(controlTypeModel);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Edit Record In ModuleLayout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] ModuleLayoutDTO moduleLayoutDTO)
        {
            if (ModelState.IsValid)
            {
                var controlTypeEditModel = _mapper.Map<ModuleLayoutDTO, ModuleLayoutModel>(moduleLayoutDTO);
                _moduleLayoutService.Update(controlTypeEditModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(moduleLayoutDTO);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var pageModule = _moduleService.Get();
            var ModuleTypeList = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(pageModule);

            var controlCategoryType = _layoutService.Get();
            var LayoutTypeList = _mapper.Map<List<Layout2Model>, List<Layout2DTO>>(controlCategoryType);
            ViewBag.ModuleName = ModuleTypeList;
            ViewBag.LayoutName = LayoutTypeList;

            return base.View(new ModuleLayoutDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In ModuleLayout
        /// </summary>
        /// <param name="moduleLayoutDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ModuleLayoutDTO moduleLayoutDTO)
        {
            if (ModelState.IsValid)
            {
                var controlTypeCreateModel = _mapper.Map<ModuleLayoutDTO, ModuleLayoutModel>(moduleLayoutDTO);
                _moduleLayoutService.Create(controlTypeCreateModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(moduleLayoutDTO);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ModuleLayoutModel getByIdControlType = _moduleLayoutService.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<ModuleLayoutModel, ModuleLayoutDTO>(getByIdControlType);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Delete Record In ModuleLayout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _moduleLayoutService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
