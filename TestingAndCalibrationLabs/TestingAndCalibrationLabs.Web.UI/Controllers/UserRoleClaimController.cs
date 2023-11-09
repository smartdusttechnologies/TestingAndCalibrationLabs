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
    public class UserRoleClaimController : Controller
    {
        private readonly IUserRoleClaimService _iUserRoleClaimService;
        private readonly IRoleService _iRoleService;
        private readonly IPermissionService _iPermissionService;
        private readonly IMapper _mapper;
        private readonly IClaimTypeService _iClaimTypeService;

        public UserRoleClaimController(IUserRoleClaimService userRoleClaimService, IRoleService roleService, IPermissionService permissionService, IClaimTypeService claimTypeService, IMapper mapper)
        {
            _iUserRoleClaimService = userRoleClaimService;
            _iRoleService = roleService;
            _iPermissionService = permissionService;
            _mapper = mapper;
            _iClaimTypeService = claimTypeService;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From UserRoleClaim And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithUserRoleClaimList = _iUserRoleClaimService.Get();
            var pageNavigationList = _mapper.Map<List<UserRoleClaimModel>, List<UserRoleClaimDTO>>(pageWithUserRoleClaimList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UserRoleClaimModel> pageNavigationList = _iUserRoleClaimService.Get();
            var pageNavigationModel = _mapper.Map<List<UserRoleClaimModel>, List<UserRoleClaimDTO>>(pageNavigationList);
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
            return base.View(new UserRoleClaimDTO {});
        }
        /// <summary>
        /// To Create Record In UserRoleClaim
        /// </summary>
        /// <param name="userRoleClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UserRoleClaimDTO userRoleClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<UserRoleClaimDTO, UserRoleClaimModel>(userRoleClaimDTO);
                _iUserRoleClaimService.Create(createPageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userRoleClaimDTO);
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
            var getByIdUserRoleClaimType = _iUserRoleClaimService.GetById((int)id);
            if (getByIdUserRoleClaimType == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<UserRoleClaimModel, UserRoleClaimDTO>(getByIdUserRoleClaimType);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In UserRoleClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userRoleClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UserRoleClaimDTO userRoleClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<UserRoleClaimDTO, UserRoleClaimModel>(userRoleClaimDTO);
                _iUserRoleClaimService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userRoleClaimDTO);
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
            var getByIdPageNavigation = _iUserRoleClaimService.GetById((int)id);
            var pageNavigation = _mapper.Map<UserRoleClaimModel, UserRoleClaimDTO>(getByIdPageNavigation);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From UserRoleClaim
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
            _iUserRoleClaimService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}