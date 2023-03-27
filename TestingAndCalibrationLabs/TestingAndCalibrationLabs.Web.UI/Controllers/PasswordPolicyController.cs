using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class PasswordPolicyController : Controller
    {
        private readonly IPasswordPolicyService _PasswordPolicyService;
        private readonly IOrganizationService _OrganizationService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="PasswordPolicyService"></param>
        /// <param name="mapper"></param>
        /// <param name="OrganizationService"></param>

        public PasswordPolicyController(IMapper mapper, IPasswordPolicyService PasswordPolicyService, IOrganizationService OrganizationService)
        {
            _PasswordPolicyService = PasswordPolicyService;
            _mapper = mapper;
            _OrganizationService = OrganizationService;

        }
        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<PasswordPolicyModel> page = _PasswordPolicyService.Get();
            var pageData = _mapper.Map<List<PasswordPolicyModel>, List<PasswordPolicyDTO>>(page);
            return View(pageData.AsEnumerable());
        }

        /// <summary>
        /// For Edit Records View
        /// </summary>
        /// <param name="id"></param>   
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var OrganizationList = _OrganizationService.Getby();
            ViewBag.Organization = OrganizationList;

            var getByIdPageModel = _PasswordPolicyService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<PasswordPolicyModel, PasswordPolicyDTO>(getByIdPageModel);

            return View(pageData);
        }
        /// <summary>
        /// To Edit Record In PasswordPolicy
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] PasswordPolicyDTO passwordPolicyDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<PasswordPolicyDTO, PasswordPolicyModel>(passwordPolicyDTO);
                _PasswordPolicyService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(passwordPolicyDTO);
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var organizationList = _OrganizationService.Getby();
            ViewBag.Organization = organizationList;

            return base.View(new PasswordPolicyDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In PasswordPolicy
        /// </summary>
        /// <param name="passwordPolicyDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] PasswordPolicyDTO passwordPolicyDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<PasswordPolicyDTO, PasswordPolicyModel>(passwordPolicyDTO);
                _PasswordPolicyService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(passwordPolicyDTO);
        }
        /// <summary>
        /// For Delete Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PasswordPolicyModel getByIdPageModel = _PasswordPolicyService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<PasswordPolicyModel, PasswordPolicyDTO>(getByIdPageModel);
            return View(pageModel);
        }
        /// <summary>
        /// To Delete Record In PasswordPolicy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _PasswordPolicyService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }
}
