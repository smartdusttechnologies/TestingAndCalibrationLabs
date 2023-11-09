using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class PermissionTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPermissionTypeService _permissionTypeService;

        public PermissionTypeController(IPermissionTypeService permissionTypeService, IMapper mapper)
        {
            _permissionTypeService = permissionTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<PermissionTypeModel> permissionType = _permissionTypeService.Get();
            var permissionTypeData = _mapper.Map<List<PermissionTypeModel>, List<PermissionTypeDTO>>(permissionType);
            return View(permissionTypeData);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new PermissionTypeDTO {});
        }
        /// <summary>
        /// To Create Record In Permission Type
        /// </summary>
        /// <param name="permissionTypeDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PermissionTypeDTO permissionTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var permissionTypeData = _mapper.Map<PermissionTypeDTO, PermissionTypeModel>(permissionTypeDTO);
                _permissionTypeService.Create(permissionTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionTypeDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionType"></param>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _permissionTypeService.GetById((int)id);
            if (result == null)
            {
                return NotFound();
            }
            var permissionTypeData = _mapper.Map<PermissionTypeModel, PermissionTypeDTO>(result);

            return View(permissionTypeData);
        }
        /// <summary>
        /// To Edit Record In Permission Type 
        /// </summary>
        /// <param name="permissionType"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] PermissionTypeDTO permissionTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var permissionTypeData = _mapper.Map<PermissionTypeDTO, PermissionTypeModel>(permissionTypeDTO);
                _permissionTypeService.Update(id, permissionTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionTypeDTO);
        }

        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PermissionTypeModel getByIdControlType = _permissionTypeService.GetById((int)id);
            if (getByIdControlType == null)
            {
                return NotFound();
            }
            var controlTypeEditModel = _mapper.Map<PermissionTypeModel, PermissionTypeDTO>(getByIdControlType);
            return View(controlTypeEditModel);
        }
        /// <summary>
        /// To Delete Record From Permission Type
        /// </summary>
        /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _permissionTypeService.Delete((int)id);
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }

    }
