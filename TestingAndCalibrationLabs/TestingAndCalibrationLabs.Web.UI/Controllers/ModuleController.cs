using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ModuleController : Controller
    {
       
        public readonly IModuleService _ModuleService;
        public readonly IMapper _mapper;
         public readonly IApplicationService _ApplicationService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="moduleService"></param>
        /// <param name="mapper"></param>
        /// <param name="applicationService"></param>
        public ModuleController(IMapper mapper, IModuleService moduleService, IApplicationService applicationService)
        {
            _ModuleService = moduleService;
            _mapper = mapper;
             _ApplicationService = applicationService;
            
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<ModuleModel> page = _ModuleService.Get();
            var pageData = _mapper.Map<List<ModuleModel>, List<ModuleDTO>>(page);
            return View(pageData.AsEnumerable());
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
            var applicationlist = _ApplicationService.Get();
            var applicationdatas = _mapper.Map<List<ApplicationModel>, List<ApplicationDTO>>(applicationlist);
            ViewBag.Application = applicationdatas;

            var getByIdPageModel = _ModuleService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<ModuleModel, ModuleDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In Module
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var applicationlist = _ApplicationService.Get();
            var applicationdatas = _mapper.Map<List<ApplicationModel>, List<ApplicationDTO>>(applicationlist);
             ViewBag.Application = applicationdatas;


            return base.View(new ModuleDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Module
        /// </summary>
        /// <param name="ModuleDTO"></param>
        /// <returns></returns>
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
            ModuleModel getByIdPageModel = _ModuleService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<ModuleModel, ModuleDTO>(getByIdPageModel);
            return View(pageModel);
        }
        /// <summary>
        /// To Delete Record In Module
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
            _ModuleService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}
