using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class RoleClaimController : Controller
    {
        private readonly IRoleClaimService _iRoleClaimService;
        private readonly IRoleService _iRoleService;
        private readonly IPermissionService _iPermissionService;
        private readonly IMapper _mapper;
        private readonly IClaimTypeService _iClaimTypeService;

        public RoleClaimController(IRoleClaimService roleClaimService, IRoleService roleService, IPermissionService permissionService, IClaimTypeService claimTypeService, IMapper mapper)
        {
            _iRoleClaimService = roleClaimService;
            _iRoleService = roleService;
            _iPermissionService = permissionService;
            _mapper = mapper;
            _iClaimTypeService = claimTypeService;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From RoleClaim And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithRoleClaimList = _iRoleClaimService.Get();
            var pageNavigationList = _mapper.Map<List<RoleClaimModel>, List<RoleClaimDTO>>(pageWithRoleClaimList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<RoleClaimModel> pageNavigationList = _iRoleClaimService.Get();
            var pageNavigationModel = _mapper.Map<List<RoleClaimModel>, List<RoleClaimDTO>>(pageNavigationList);
            return View(pageNavigationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public IActionResult Create()
        {
            List<RoleModel> role = _iRoleService.Get();
            role = role.Where(x => x.Id != (int)Helpers.None.Id).ToList();
            List<PermissionModel> permission = _iPermissionService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            var roleDataList = _mapper.Map<List<RoleModel>, List<RoleDTO>>(role);
            var permissionDataList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            var claimTypeDataList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            ViewBag.Role = roleDataList;
            ViewBag.Permission = permissionDataList;
            ViewBag.ClaimType = claimTypeDataList;
            return base.View(new RoleClaimDTO {});
        }
        /// <summary>
        /// To Create Record In RoleClaim
        /// </summary>
        /// <param name="roleClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] RoleClaimDTO roleClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<RoleClaimDTO, RoleClaimModel>(roleClaimDTO);
                _iRoleClaimService.Create(createPageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(roleClaimDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleId"></param>
        /// <param name="permissionId"></param>
        /// <param name="claimTypeId"></param>
        [HttpGet]
        public IActionResult Edit(int? id, int roleId, int permissionId, int claimTypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Role = roleId;
            ViewBag.Permission = permissionId;
            ViewBag.ClaimType = claimTypeId;
            List<RoleModel> role = _iRoleService.Get();
            List<PermissionModel> permission = _iPermissionService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            var roleList = _mapper.Map<List<RoleModel>, List<RoleDTO>>(role);
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            var claimTypeList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            ViewBag.Role = roleList;
            ViewBag.Permission = permissionList;
            ViewBag.ClaimType = claimTypeList;
            var getByIdRoleClaimType = _iRoleClaimService.GetById((int)id);
            if (getByIdRoleClaimType == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<RoleClaimModel, RoleClaimDTO>(getByIdRoleClaimType);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In RoleClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] RoleClaimDTO roleClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<RoleClaimDTO, RoleClaimModel>(roleClaimDTO);
                _iRoleClaimService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(roleClaimDTO);
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
            var getByIdPageNavigation = _iRoleClaimService.GetById((int)id);
            var pageNavigation = _mapper.Map<RoleClaimModel, RoleClaimDTO>(getByIdPageNavigation);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From RoleClaim
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
            _iRoleClaimService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}