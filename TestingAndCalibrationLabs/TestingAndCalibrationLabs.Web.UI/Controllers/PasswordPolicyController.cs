using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// Controller for managing Password Policy related actions
    /// </summary>
    public class PasswordPolicyController : Controller
    {
        public readonly IPasswordPolicyService _PasswordPolicyService;
        public readonly IMapper _mapper;
        private readonly IOrganizationService _organizationService;
        public PasswordPolicyController(IPasswordPolicyService PasswordPolicyService, IMapper mapper, IOrganizationService organizationService)
        {
            _PasswordPolicyService = PasswordPolicyService;
            _mapper = mapper;
            _organizationService = organizationService;
        }
        /// <summary>
        /// Get all Password Policies and display them in the view
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
        /// Display the edit view for a Password Policy record
        /// </summary>
        /// <param name="id">The ID of the record to edit</param>
        /// <param name="orgId">The organization ID</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<Organization> OrganizationType = _organizationService.Get();
            var organizationList = _mapper.Map<List<Organization>, List<OrganizationDTO>>(OrganizationType);
            ViewBag.organization = organizationList;
            var getByIdPageModel = _PasswordPolicyService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<PasswordPolicyModel, PasswordPolicyDTO>(getByIdPageModel);
            ViewBag.orgId = pageData.OrgId;
            return View(pageData);
        }
        /// <summary>
        /// Handle the submission of edits to a Password Policy record
        /// </summary>
        /// <param name="passwordPolicyDTO">The edited Password Policy data</param>
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
            List<Organization> OrganizationType = _organizationService.Get(); 
            var organizationList = _mapper.Map<List<Organization>, List<OrganizationDTO>>(OrganizationType);
            ViewBag.organization = organizationList;
            return View(passwordPolicyDTO);
        }
        /// <summary>
        /// Display the view for creating a new Password Policy record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            List<Organization> OrganizationType = _organizationService.Get();
            var organizationList = _mapper.Map<List<Organization>, List<OrganizationDTO>>(OrganizationType);
            ViewBag.organization = organizationList;
            return base.View(new Models.PasswordPolicyDTO { Id = id });
        }
        /// <summary>
        /// Handle the submission of a new Password Policy record
        /// </summary>
        /// <param name="passwordPolicyDTO">The new Password Policy data</param>
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
        /// Display the view for deleting a Password Policy record
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
        /// Handle the submission of deleting a Password Policy record
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
            TempData["IsTrue"] = false;
            return RedirectToAction("Index");
        }
    }
}