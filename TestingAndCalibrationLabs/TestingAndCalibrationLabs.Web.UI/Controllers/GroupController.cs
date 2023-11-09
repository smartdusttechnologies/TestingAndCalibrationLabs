using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class GroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<GroupModel> Group = _groupService.Get();
            var groupData = _mapper.Map<List<GroupModel>, List<GroupDTO>>(Group);
            return View(groupData);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new GroupDTO {});
        }
        /// <summary>
        /// To Create Record In Group
        /// </summary>
        /// <param name="groupDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] GroupDTO groupDTO)
        {
            if (ModelState.IsValid)
            {
                var groupData = _mapper.Map<GroupDTO, GroupModel>(groupDTO);
                _groupService.Create(groupData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(groupDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="group"></param>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _groupService.GetById((int)id);
            if (result == null)
            {
                return NotFound();
            }
            var groupData = _mapper.Map<GroupModel, GroupDTO>(result);

            return View(groupData);
        }
        /// <summary>
        /// To Edit Record In Group
        /// </summary>
        /// <param name="group"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] GroupDTO groupDTO)
        {
            if (ModelState.IsValid)
            {
                var groupData = _mapper.Map<GroupDTO, GroupModel>(groupDTO);
                _groupService.Update(id, groupData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(groupDTO);
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
            GroupModel getByIdGroup = _groupService.GetById((int)id);
            if (getByIdGroup == null)
            {
                return NotFound();
            }
            var groupEditModel = _mapper.Map<GroupModel, GroupDTO>(getByIdGroup);
            return View(groupEditModel);
        }
        /// <summary>
        /// To Delete Record From Group
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
            _groupService.Delete((int)id);
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }
    }
