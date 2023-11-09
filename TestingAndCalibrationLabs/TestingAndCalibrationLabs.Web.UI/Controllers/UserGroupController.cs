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

    public class UserGroupController : Controller
    {
        private readonly IUserGroupServices _iUserGroupServices;
        private readonly IGroupService _iGroupService;
        private readonly IAuthenticationService _iAuthenticationService;
        private readonly IMapper _mapper;
        public UserGroupController(IUserGroupServices userGroupServices, IMapper mapper, IAuthenticationService authenticationService, IGroupService groupService)
        {
            _iUserGroupServices = userGroupServices;
            _mapper = mapper;
            _iAuthenticationService = authenticationService;
            _iGroupService = groupService;
        }
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var groupList = _iUserGroupServices.Get();
            var pageNavigationList = _mapper.Map<List<UserGroupModel>, List<UserGroupDTO>>(groupList);

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
            var pagegroup = _iUserGroupServices.Get();
            var pagegroup1 = _mapper.Map<List<UserGroupModel>, List<UserGroupDTO>>(pagegroup);
            return View(pagegroup1.AsEnumerable());
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>///
        [HttpGet]
        public IActionResult Create()
        {
            List<UserModel> user = _iAuthenticationService.Get();
            user = user.Where(x => x.Id != (int)Helpers.None.Id).ToList();
            List<GroupModel> group = _iGroupService.Get();
            var userList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var groupList = _mapper.Map<List<GroupModel>, List<GroupDTO>>(group);
            ViewBag.User = userList;
            ViewBag.Group = groupList;
            return View(new UserGroupDTO {  });
        }
        /// <summary>
        /// To Create Record In User Group
        /// </summary>
        /// <param name="userGroupDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UserGroupDTO userGroupDTO)
        {
            if (ModelState.IsValid)
            {
                var createGroup = _mapper.Map<UserGroupDTO,UserGroupModel>(userGroupDTO);
                _iUserGroupServices.Create(createGroup);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userGroupDTO);
        }
        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id, int GroupId, int UserId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.User = UserId;
            ViewBag.Group = GroupId;
            List<UserModel> user = _iAuthenticationService.Get();
            List<GroupModel> group = _iGroupService.Get();
            var userList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var groupList = _mapper.Map<List<GroupModel>, List<GroupDTO>>(group);
            ViewBag.User = userList;
            ViewBag.Group = groupList;
            var getByIdUser = _iUserGroupServices.GetById((int)id);
            if (getByIdUser == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<UserGroupModel, UserGroupDTO>(getByIdUser);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In User Group
        /// </summary>///
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UserGroupDTO userGroupDTO)
        {
            if (ModelState.IsValid)
            {
                var editUserGroup = _mapper.Map<UserGroupDTO,UserGroupModel>(userGroupDTO);
                _iUserGroupServices.Update(id, editUserGroup);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userGroupDTO);
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
            UserGroupModel userGroupModel = _iUserGroupServices.GetById((int)id);
            var delete = _mapper.Map<UserGroupModel, UserGroupDTO>(userGroupModel);
            return View(delete);
        }
        /// <summary>
        /// To Delete Record In User Group
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
            _iUserGroupServices.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
