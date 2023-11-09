using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class ClaimTypeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IClaimTypeService _claimTypeService;

        public ClaimTypeController(IClaimTypeService claimTypeService, IMapper mapper)
        {
            _claimTypeService = claimTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<ClaimTypeModel> claimType = _claimTypeService.Get();
            var claimTypeData = _mapper.Map<List<ClaimTypeModel>, List<ClaimTypeDTO>>(claimType);
            return View(claimTypeData);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ClaimTypeDTO {});
        }
        /// <summary>
        /// To Create Record In Claim Type
        /// </summary>
        /// <param name="claimTypeDTO"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ClaimTypeDTO claimTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var claimTypeData = _mapper.Map<ClaimTypeDTO, ClaimTypeModel>(claimTypeDTO);
                _claimTypeService.Create(claimTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(claimTypeDTO);
        }
        /// <summary>
        /// For Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <param name="claimType"></param>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _claimTypeService.GetById((int)id);
            if (result == null)
            {
                return NotFound();
            }
            var claimTypeData = _mapper.Map<ClaimTypeModel, ClaimTypeDTO>(result);

            return View(claimTypeData);
        }
        /// <summary>
        /// To Edit Record In Claim Type 
        /// </summary>
        /// <param name="claimType"></param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] ClaimTypeDTO claimTypeDTO)
        {
            if (ModelState.IsValid)
            {
                var claimTypeData = _mapper.Map<ClaimTypeDTO, ClaimTypeModel>(claimTypeDTO);
                _claimTypeService.Update(id, claimTypeData);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(claimTypeDTO);
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
            ClaimTypeModel getByIdClaimType = _claimTypeService.GetById((int)id);
            if (getByIdClaimType == null)
            {
                return NotFound();
            }
            var claimTypeEditModel = _mapper.Map<ClaimTypeModel, ClaimTypeDTO>(getByIdClaimType);
            return View(claimTypeEditModel);
        }
        /// <summary>
        /// To Delete Record From Claim Type
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
            _claimTypeService.Delete((int)id);
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }
}
