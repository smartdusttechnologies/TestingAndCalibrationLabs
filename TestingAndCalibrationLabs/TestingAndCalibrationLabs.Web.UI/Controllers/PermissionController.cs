using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class PermissionController : Controller
    {
        private readonly IPermissionService _iPermissionService;
        private readonly IPermissionTypeService _iPermissionTypeService;
        private readonly IMapper _mapper;
        private readonly IPermissionModuleTypeService _iPermissionModuleTypeService;

        public PermissionController(IPermissionService ipermissionService, IPermissionTypeService iPermissionTypeService, IPermissionModuleTypeService iPermissionModuleTypeService, IMapper mapper)
        {
            _iPermissionService = ipermissionService;
            _iPermissionTypeService = iPermissionTypeService;
            _mapper = mapper;
            _iPermissionModuleTypeService = iPermissionModuleTypeService;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From Permission With PermissionModuleType And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithPermissionList = _iPermissionService.Get();
            var pageNavigationList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(pageWithPermissionList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<PermissionModel> pageNavigationList = _iPermissionService.Get();
            var pageNavigationModel = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(pageNavigationList);
            return View(pageNavigationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public IActionResult Create()
        {
            List<PermissionTypeModel> permissionType = _iPermissionTypeService.Get();
            List<PermissionModuleTypeModel> permissionModuleType = _iPermissionModuleTypeService.Get();
            var metaDataList = _mapper.Map<List<PermissionTypeModel>, List<PermissionTypeDTO>>(permissionType);
            var validationList = _mapper.Map<List<PermissionModuleTypeModel>, List<PermissionModuleTypeDTO>>(permissionModuleType);
            ViewBag.PermissionType = metaDataList;
            ViewBag.PermissionModuleType = validationList;
            return View(new PermissionDTO {});
        }
        /// <summary>
        /// To Create Record In Permission
        /// </summary>
        /// <param name="permissionDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PermissionDTO permissionDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<PermissionDTO, PermissionModel>(permissionDTO);
                _iPermissionService.Create(createPageNavigation);
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
        [HttpGet]
        public IActionResult Edit(int? id, string Name, int permissionModuleTypeId, int permissionTypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.PermissionType = permissionTypeId;
            ViewBag.PermissionModuleType = permissionModuleTypeId;
            List<PermissionTypeModel> permissionType= _iPermissionTypeService.Get();
            List<PermissionModuleTypeModel> permissionModuleType = _iPermissionModuleTypeService.Get();
            var permissionTypeList = _mapper.Map<List<PermissionTypeModel>, List<PermissionTypeDTO>>(permissionType);
            var permissionModuleTypeList = _mapper.Map<List<PermissionModuleTypeModel>, List<PermissionModuleTypeDTO>>(permissionModuleType);
            ViewBag.PermissionType = permissionTypeList;
            ViewBag.PermissionModuleType = permissionModuleTypeList;
            var getByIdPermissionType = _iPermissionService.GetById((int)id);
            if (getByIdPermissionType == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<PermissionModel, PermissionDTO>(getByIdPermissionType);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In Permission
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissionDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] PermissionDTO permissionDTO)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<PermissionDTO, PermissionModel>(permissionDTO);
                _iPermissionService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(permissionDTO);
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
            var getByIdPageNavigation = _iPermissionService.GetById((int)id);
            var pageNavigation = _mapper.Map<PermissionModel, PermissionDTO>(getByIdPageNavigation);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From Permission
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
            _iPermissionService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
