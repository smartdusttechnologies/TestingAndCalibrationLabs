using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;
//using TestingAndCalibrationLabs.Web.UI.Models.Common;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ModuleController : Controller
    {
       // private readonly IApplicationservice _IApplicationservice;
        // private readonly IConnectionFactory _connectionFactory;
        public readonly IModuleService _ModuleService;
        public readonly IMapper _mapper;
         public readonly IApplicationService _ApplicationService;
        // private readonly IApplicationService _ApplicationService;
        public ModuleController(IMapper mapper, IModuleService moduleService, IApplicationService applicationService)
        {
            _ModuleService = moduleService;
            _mapper = mapper;
             _ApplicationService = applicationService;
            // _connectionFactory = connectionFactory;
            //_connectionFactory = connectionFactory;
            //_uiNavigationCategoryService = uiNavigationCategoryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<ModuleModel> page = _ModuleService.Get();
            var pageData = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(page);
            return View(pageData.AsEnumerable());
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicationlist = _ApplicationService.Get();
            var applicationdatas = _mapper.Map<List<ApplicationModel>, List<ApplicationDTO>>(applicationlist);
            ViewBag.Application = applicationdatas;

            var getByIdPageModel = _ModuleService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<ModuleModel, ModuleDTO>((ModuleModel)getByIdPageModel);

            return View(pageData);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] ModuleDTO ModuleDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<ModuleDTO, ModuleModel>(ModuleDTO);
                _ModuleService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(ModuleDTO);
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            var applicationlist = _ApplicationService.Get();
            var applicationdatas = _mapper.Map<List<ApplicationModel>, List<ApplicationDTO>>(applicationlist);
             ViewBag.Application = applicationdatas;


            return base.View(new ModuleDTO { Id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ModuleDTO ModuleDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<ModuleDTO, ModuleModel>(ModuleDTO);
                _ModuleService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(ModuleDTO);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ModuleModel getByIdPageModel = (ModuleModel)_ModuleService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<ModuleModel, ModuleDTO>(getByIdPageModel);
            return View(pageModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _ModuleService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}
