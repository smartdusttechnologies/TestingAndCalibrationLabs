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
    public class UserClaimController : Controller
    {
        private readonly IUserClaimService _iUserClaimService;
        private readonly IAuthenticationService _iAuthenticationService;
        private readonly IPermissionService _iPermissionService;
        private readonly IMapper _mapper;
        private readonly IClaimTypeService _iClaimTypeService;

        public UserClaimController(IUserClaimService userClaimService, IAuthenticationService authenticationService, IPermissionService permissionService, IClaimTypeService claimTypeService, IMapper mapper)
        {
            _iUserClaimService = userClaimService;
            _iAuthenticationService = authenticationService;
            _iPermissionService = permissionService;
            _mapper = mapper;
            _iClaimTypeService = claimTypeService;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From UserClaim And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithUserClaimList = _iUserClaimService.Get();
            var pageNavigationList = _mapper.Map<List<UserClaimModel>, List<UserClaimDTO>>(pageWithUserClaimList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<UserClaimModel> pageNavigationList = _iUserClaimService.Get();
            var pageNavigationModel = _mapper.Map<List<UserClaimModel>, List<UserClaimDTO>>(pageNavigationList);
            return View(pageNavigationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public IActionResult Create()
        {
            List<UserModel> user = _iAuthenticationService.Get();
            user = user.Where(x => x.Id != (int)Helpers.None.Id).ToList();
            List<PermissionModel> permission = _iPermissionService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            var userDataList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var permissionDataList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            var claimTypeDataList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            ViewBag.User = userDataList;
            ViewBag.Permission = permissionDataList;
            ViewBag.ClaimType = claimTypeDataList;
            return View(new UserClaimDTO { });
        }
        /// <summary>
        /// To Create Record In UserClaim
        /// </summary>
        /// <param name="userClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UserClaimDTO userClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<UserClaimDTO, UserClaimModel>(userClaimDTO);
                _iUserClaimService.Create(createPageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userClaimDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="permissionId"></param>
        /// <param name="claimTypeId"></param>
        [HttpGet]
        public IActionResult Edit(int? id, int userId, int permissionId, int claimTypeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.User = userId;
            ViewBag.Permission = permissionId;
            ViewBag.ClaimType = claimTypeId;
            List<UserModel> user = _iAuthenticationService.Get();
            List<PermissionModel> permission = _iPermissionService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            var userList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            var claimTypeList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            ViewBag.User = userList;
            ViewBag.Permission = permissionList;
            ViewBag.ClaimType = claimTypeList;
            var getByIdUserClaimType = _iUserClaimService.GetById((int)id);
            if (getByIdUserClaimType == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<UserClaimModel, UserClaimDTO>(getByIdUserClaimType);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In UserClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UserClaimDTO userClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<UserClaimDTO, UserClaimModel>(userClaimDTO);
                _iUserClaimService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userClaimDTO);
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
            var getByIdPageNavigation = _iUserClaimService.GetById((int)id);
            var pageNavigation = _mapper.Map<UserClaimModel, UserClaimDTO>(getByIdPageNavigation);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From UserClaim
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
            _iUserClaimService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}