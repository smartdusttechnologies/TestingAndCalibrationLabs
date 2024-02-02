using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class RoleController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<RoleModel> role = _roleService.Get();
            var roleData = _mapper.Map<List<RoleModel>, List<RoleDTO>>(role);
            return View(roleData);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new RoleDTO {});
        }
        /// <summary>
        /// To Create Record In Role
        /// </summary>
        /// <param name="roleDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                var roleData = _mapper.Map<RoleDTO, RoleModel>(roleDTO);
                _roleService.Create(roleData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(roleDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _roleService.GetById((int)id);
            if (result == null)
            {
                return NotFound();
            }
            var roleData = _mapper.Map<RoleModel, RoleDTO>(result);

            return View(roleData);
        }
        /// <summary>
        /// To Edit Record In Role 
        /// </summary>
        /// <param name="role"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] RoleDTO roleDTO)
        {
            if (ModelState.IsValid)
            {
                var roleData = _mapper.Map<RoleDTO, RoleModel>(roleDTO);
                _roleService.Update(id, roleData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(roleDTO);
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
            RoleModel getByRoleId = _roleService.GetById((int)id);
            if (getByRoleId == null)
            {
                return NotFound();
            }
            var roleEditModel = _mapper.Map<RoleModel, RoleDTO>(getByRoleId);
            return View(roleEditModel);
        }
        /// <summary>
        /// To Delete Record From Role
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
            _roleService.Delete((int)id);
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }
}
