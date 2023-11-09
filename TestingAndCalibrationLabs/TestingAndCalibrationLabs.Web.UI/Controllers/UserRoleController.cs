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
    public class UserRoleController : Controller
    {
        private readonly IUserRoleService _iUserRoleService;
        private readonly IAuthenticationService _iAuthenticationService;
        private readonly IRoleService _iRoleService;
        private readonly IMapper _mapper;
        public UserRoleController(IUserRoleService userRoleService, IMapper mapper, IAuthenticationService authenticationService, IRoleService roleService)
        {
            _iUserRoleService = userRoleService;
            _mapper = mapper;
            _iAuthenticationService = authenticationService;
            _iRoleService = roleService;
        }
        [HttpPost]
        public IActionResult GetAllPagesWithNavigation()
        {
            var userRoleList = _iUserRoleService.Get();
            var pageNavigationList = _mapper.Map<List<UserRoleModel>, List<UserRoleDTO>>(userRoleList);

            return BadRequest();
        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var pagegroup = _iUserRoleService.Get();
            var userRolegroup = _mapper.Map<List<UserRoleModel>, List<UserRoleDTO>>(pagegroup);
            return View(userRolegroup.AsEnumerable());
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
            List<RoleModel> role = _iRoleService.Get();
            role = role.Where(x => x.Id != (int)Helpers.None.Id).ToList();
            var userList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var roleList = _mapper.Map<List<RoleModel>, List<RoleDTO>>(role);
            ViewBag.User = userList;
            ViewBag.Role = roleList;
            return base.View(new UserRoleDTO {});
        }
        /// <summary>
        /// To Create Record In User Role
        /// </summary>
        /// <param name="userRoleDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] UserRoleDTO userRoleDTO)
        {
            if (ModelState.IsValid)
            {
                var createGroup = _mapper.Map<UserRoleDTO, UserRoleModel>(userRoleDTO);
                _iUserRoleService.Create(createGroup);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userRoleDTO);
        }
        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id, int UserId, int RoleId)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.User = UserId;
            ViewBag.Group = RoleId;
            List<UserModel> user = _iAuthenticationService.Get();
            List<RoleModel> role = _iRoleService.Get();
            var userList = _mapper.Map<List<UserModel>, List<UserDTO>>(user);
            var roleList = _mapper.Map<List<RoleModel>, List<RoleDTO>>(role);
            ViewBag.User = userList;
            ViewBag.Role = roleList;
            var getByIdUser = _iUserRoleService.GetById((int)id);
            if (getByIdUser == null)
            {
                return NotFound();
            }
            var pageNavigationModel = _mapper.Map<UserRoleModel, UserRoleDTO>(getByIdUser);
            return View(pageNavigationModel);
        }
        /// <summary>
        /// To Edit Record In User Role
        /// </summary>///
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] UserRoleDTO userRoleDTO)
        {
            if (ModelState.IsValid)
            {
                var editUserRole = _mapper.Map<UserRoleDTO, UserRoleModel>(userRoleDTO);
                _iUserRoleService.Update(id, editUserRole);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(userRoleDTO);
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
            UserRoleModel userRoleModel = _iUserRoleService.GetById((int)id);
            var delete = _mapper.Map<UserRoleModel, UserRoleDTO>(userRoleModel);
            return View(delete);
        }
        /// <summary>
        /// To Delete Record In User Role
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
            _iUserRoleService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}
