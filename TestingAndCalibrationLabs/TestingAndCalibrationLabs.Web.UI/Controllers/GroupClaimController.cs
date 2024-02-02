using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class GroupClaimController : Controller
    {
        private readonly IGroupClaimService _iGroupClaimService;
        private readonly IGroupService _iGroupService;
        private readonly IClaimTypeService _iClaimTypeService;
        private readonly IMapper _mapper;
        private readonly IPermissionService _iPermissionService;

        public GroupClaimController(IGroupClaimService iGroupClaimService, IGroupService iGroupService, IClaimTypeService iClaimTypeService, IPermissionService ipermissionService, IMapper mapper)
        {
            _iGroupClaimService = iGroupClaimService;
            _iGroupService = iGroupService;
            _iClaimTypeService = iClaimTypeService;
            _iPermissionService = ipermissionService;
            _mapper = mapper;
        }
        #region Public methods
        /// <summary>
        /// Get All Records From GroupClaim And Pass It TO Ajax Call
        /// </summary>
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var pageWithGroupClaimList = _iGroupClaimService.Get();
            var pageNavigationList = _mapper.Map<List<GroupClaimModel>, List<GroupClaimDTO>>(pageWithGroupClaimList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<GroupClaimModel> pageNavigationList = _iGroupClaimService.Get();
            var pageNavigationModel = _mapper.Map<List<GroupClaimModel>, List<GroupClaimDTO>>(pageNavigationList);
            return View(pageNavigationModel.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public IActionResult Create()
        {
            List<GroupModel> group = _iGroupService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            List<PermissionModel> permission = _iPermissionService.Get();
            var groupDataList = _mapper.Map<List<GroupModel>, List<GroupDTO>>(group);
            var claimTypeDataList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            ViewBag.Group = groupDataList;
            ViewBag.ClaimType = claimTypeDataList;
            ViewBag.Permission = permissionList;
            return View(new GroupClaimDTO {});
        }
        /// <summary>
        /// To Create Record In GroupClaim
        /// </summary>
        /// <param name="groupClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] GroupClaimDTO groupClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var createPageNavigation = _mapper.Map<GroupClaimDTO, GroupClaimModel>(groupClaimDTO);
                _iGroupClaimService.Create(createPageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(groupClaimDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupId"></param>
        /// <param name="claimTypeId"></param>
        /// <param name="permissionId"></param>
        [HttpGet]
        public IActionResult Edit(int? id, int groupId, int claimTypeId, int permissionId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Group = groupId;
            ViewBag.ClaimType = claimTypeId;
            ViewBag.Permission = permissionId;
            List<GroupModel> group = _iGroupService.Get();
            List<ClaimTypeModel> claimType = _iClaimTypeService.Get();
            List<PermissionModel> permission = _iPermissionService.Get();
            var groupList = _mapper.Map<List<GroupModel>, List<GroupDTO>>(group);
            var claimTypeList = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            var permissionList = _mapper.Map<List<PermissionModel>, List<PermissionDTO>>(permission);
            ViewBag.Group = groupList;
            ViewBag.ClaimType = claimTypeList;
            ViewBag.Permission = permissionList;
            var getByIdGroupClaim = _iGroupClaimService.GetById((int)id);
            if (getByIdGroupClaim == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<GroupClaimModel, GroupClaimDTO>(getByIdGroupClaim);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In GroupClaim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupClaimDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] GroupClaimDTO groupClaimDTO)
        {
            if (ModelState.IsValid)
            {
                var pageNavigation = _mapper.Map<GroupClaimDTO, GroupClaimModel>(groupClaimDTO);
                _iGroupClaimService.Update(id, pageNavigation);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(groupClaimDTO);
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
            var getByIdGroupClaim = _iGroupClaimService.GetById((int)id);
            var pageNavigation = _mapper.Map<GroupClaimModel, GroupClaimDTO>(getByIdGroupClaim);
            return View(pageNavigation);
        }
        /// <summary>
        /// To Delete Record From GroupClaim
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
            _iGroupClaimService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
        #endregion
    }
}
