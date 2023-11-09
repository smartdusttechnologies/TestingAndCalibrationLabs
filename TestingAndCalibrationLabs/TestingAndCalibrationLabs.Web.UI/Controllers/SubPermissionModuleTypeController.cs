using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class SubPermissionModuleTypeController : Controller
    {
        private readonly ISubPermissionModuleTypeService _isubPermissionModuleTypeServices;
        private readonly IMapper _mapper;
        private readonly IPermissionModuleTypeService _permissionModuleTypeService;

        public SubPermissionModuleTypeController(ISubPermissionModuleTypeService subPermissionModuleTypeServices, IPermissionModuleTypeService permissionModuleTypeService, IMapper mapper)
        {
            _isubPermissionModuleTypeServices = subPermissionModuleTypeServices;
            _mapper = mapper;
            _permissionModuleTypeService = permissionModuleTypeService;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From Permission Module Type With SubPermissionModuleType And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithPermission()
        {
            var pageWithPermissionModuleTypeList = _isubPermissionModuleTypeServices.Get();
            var pageNavigationList = _mapper.Map<List<SubPermissionModuleTypeModel>, List<SubPermissionModuleTypeDTO>>(pageWithPermissionModuleTypeList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<SubPermissionModuleTypeModel> pageWithPermissionModuleTypeList = _isubPermissionModuleTypeServices.Get();
            var SubPermissionModuleTypeModel = _mapper.Map<List<SubPermissionModuleTypeModel>, List<SubPermissionModuleTypeDTO>>(pageWithPermissionModuleTypeList);
            return View(SubPermissionModuleTypeModel);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public IActionResult Create()
        {
            List<PermissionModuleTypeModel> PermissionModuleType = _permissionModuleTypeService.Get();
            var permissionModuleTypeList = _mapper.Map<List<PermissionModuleTypeModel>, List<PermissionModuleTypeDTO>>(PermissionModuleType);
            ViewBag.PermissionModuleType = permissionModuleTypeList;
            return base.View(new SubPermissionModuleTypeDTO {});
        }
        /// <summary>
        /// To Create Record In SubPermissionModuleType
        /// </summary>
        /// <param name="subPermissionModuleTypeDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] SubPermissionModuleTypeDTO subPermissionModuleTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var createPemissionModuletype = _mapper.Map<SubPermissionModuleTypeDTO, SubPermissionModuleTypeModel>(subPermissionModuleTypeDTO);
                _isubPermissionModuleTypeServices.Create(createPemissionModuletype);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(subPermissionModuleTypeDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="permissionModuletypeId"></param>
        [HttpGet]
        public IActionResult Edit(int? id, string Name, int permissionModuletypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.PermissionModuletype = permissionModuletypeId;
            List<PermissionModuleTypeModel> permissionModuletype = _permissionModuleTypeService.Get();
            var permissionModuleTypeList = _mapper.Map<List<PermissionModuleTypeModel>, List<PermissionModuleTypeDTO>>(permissionModuletype);
            ViewBag.PermissionModuletype = permissionModuleTypeList;
            var getByIdPermissionModuletype = _isubPermissionModuleTypeServices.GetById((int)id);
            if (getByIdPermissionModuletype == null)
            {
                return NotFound();
            }
            var permissionModuleTypeModel = _mapper.Map<SubPermissionModuleTypeModel, SubPermissionModuleTypeDTO>(getByIdPermissionModuletype);
            return View(permissionModuleTypeModel);
        }
        /// <summary>
        /// To Edit Record In SubPermissionModuleType
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subPermissionModuleTypeDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] SubPermissionModuleTypeDTO subPermissionModuleTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var subPermissionModuleType = _mapper.Map<SubPermissionModuleTypeDTO, SubPermissionModuleTypeModel>(subPermissionModuleTypeDTO);
                _isubPermissionModuleTypeServices.Update(id, subPermissionModuleType);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(subPermissionModuleTypeDTO);
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
            var getByIdSubPermissionTypeModule = _isubPermissionModuleTypeServices.GetById((int)id);
            var subPermissionModuleType = _mapper.Map<SubPermissionModuleTypeModel, SubPermissionModuleTypeDTO>(getByIdSubPermissionTypeModule);
            return View(subPermissionModuleType);
        }
        /// <summary>
        /// To Delete Record From SubPermissionModuleType
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
            _isubPermissionModuleTypeServices.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}