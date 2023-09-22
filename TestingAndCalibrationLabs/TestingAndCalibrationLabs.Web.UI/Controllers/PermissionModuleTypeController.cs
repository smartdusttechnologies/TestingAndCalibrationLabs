using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class PermissionModuleTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPermissionModuleTypeService _permissionModuleTypeService;

        public PermissionModuleTypeController(IPermissionModuleTypeService permissionModuleTypeService, IMapper mapper)
        {
            _permissionModuleTypeService = permissionModuleTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<PermissionModuleTypeModel> permissionModuleType = _permissionModuleTypeService.Get();
            var permissionModuleTypeData = _mapper.Map<List<PermissionModuleTypeModel>, List<PermissionModuleTypeDTO>>(permissionModuleType);
            return View(permissionModuleTypeData);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.PermissionModuleTypeDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Permission Module Type
        /// </summary>
        /// <param name="permissionModuleTypeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PermissionModuleTypeDTO permissionModuleTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var permissionModuleTypeData = _mapper.Map<PermissionModuleTypeDTO, PermissionModuleTypeModel>(permissionModuleTypeDTO);
                _permissionModuleTypeService.Create(permissionModuleTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionModuleTypeDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionModuleType"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _permissionModuleTypeService.GetById((int)id);
            if (result == null)
            {
                return NotFound();
            }
            var permissionModuleTypeData = _mapper.Map<PermissionModuleTypeModel, PermissionModuleTypeDTO>(result);

            return View(permissionModuleTypeData);
        }
        /// <summary>
        /// To Edit Record In Permission Module Type 
        /// </summary>
        /// <param name="permissionModuleType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] PermissionModuleTypeDTO permissionModuleTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var permissionModuleTypeData = _mapper.Map<PermissionModuleTypeDTO, PermissionModuleTypeModel>(permissionModuleTypeDTO);
                _permissionModuleTypeService.Update(id, permissionModuleTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionModuleTypeDTO);
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
            PermissionModuleTypeModel getByIdControlType = _permissionModuleTypeService.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<PermissionModuleTypeModel, PermissionModuleTypeDTO>(getByIdControlType);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Delete Record From Permission Module Type
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
            _permissionModuleTypeService.Delete((int)id);
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }
}

