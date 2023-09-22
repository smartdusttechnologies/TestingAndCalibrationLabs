using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionService _iPermissionService;
        private readonly ISubPermissionModuleTypeService _isubPermissionModuleTypeService;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionService iPermissionService, ISubPermissionModuleTypeService isubPermissionModuleTypeService, IMapper mapper)
        {
            _iPermissionService = iPermissionService;
            _isubPermissionModuleTypeService = isubPermissionModuleTypeService;
            _mapper = mapper;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From Permission With SubPermissionModuleType And Pass It TO Ajax Call
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithPermissionList = _iPermissionService.Get();
            var permissionData = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(pageWithPermissionList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<PermissionModel> permissionList = _iPermissionService.Get();
            var permissiondata = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permissionList);
            return View(permissiondata);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create(int id)
        {
            List<SubPermissionModuleTypeModel> subPermissionModuleType = _isubPermissionModuleTypeService.Get();
            var subPermissionList = _mapper.Map<List<SubPermissionModuleTypeModel>, List<SubPermissionModuleTypeDTO>>(subPermissionModuleType);
            ViewBag.subPermissionModuleType = subPermissionList;
            List<PermissionModel> Permission = _iPermissionService.Get();
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(Permission);
            ViewBag.Permission = permissionList;
            return base.View(new PermissionDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In Permission
        /// </summary>
        /// <param name="permissionDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PermissionDTO permissionDTO)
        {
            if (ModelState.IsValid)
            {
                var createPermission = _mapper.Map<PermissionDTO, PermissionModel>(permissionDTO);
                _iPermissionService.Create(createPermission);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="permissionModuleTypeId"></param>
        /// <param name="permissionTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id, string Name, int permissionModuleTypeId, int permissionTypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Permission = permissionModuleTypeId;
            ViewBag.subPermissionModuleType = permissionTypeId;
            List<PermissionModel> permission = _iPermissionService.Get();
            List<SubPermissionModuleTypeModel> subPermissionModuleType = _isubPermissionModuleTypeService.Get();
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            var subPermissionList = _mapper.Map<List<SubPermissionModuleTypeModel>, List<SubPermissionModuleTypeDTO>>(subPermissionModuleType);
            ViewBag.Permission = permissionList;
            ViewBag.subPermissionModuleType = subPermissionList;
            var getByIdPermissionType = _iPermissionService.GetById((int)id);
            if (getByIdPermissionType == null)
            {
                return NotFound();
            }
            var permissionModel = _mapper.Map<PermissionModel, PermissionDTO>(getByIdPermissionType);
            return View(permissionModel);
        }
        /// <summary>
        /// To Edit Record In Permission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissiondDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] PermissionDTO permissionDTO)
        {
            if (ModelState.IsValid)
            {
                var permission = _mapper.Map<PermissionDTO, PermissionModel>(permissionDTO);
                _iPermissionService.Update(id, permission);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionDTO);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var getByIdPermission = _iPermissionService.GetById(id);
            var PermissionData = _mapper.Map<PermissionModel, PermissionDTO>(getByIdPermission);
            return View(PermissionData);
        }
        /// <summary>
        /// To Delete Record From Permission
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
            _iPermissionService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
