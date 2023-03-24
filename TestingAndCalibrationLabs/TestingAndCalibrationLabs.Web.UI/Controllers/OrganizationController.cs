using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class OrganizationController : Controller
    {
        public readonly IOrganizationService _organizationService;
        public readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="organizationService"></param>
        

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            _organizationService = organizationService;
            _mapper = mapper;
           
        }

        /// <summary>
        /// Get All The Pages From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
           // ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<Organization> organizationPage = _organizationService.Get();
            var organizationData = _mapper.Map<List<Organization>, List<OrganizationDTO>>(organizationPage);
            return View(organizationData.AsEnumerable());
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
            var getByIdPageModel = _organizationService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<Organization, OrganizationDTO>(getByIdPageModel);

            return View(pageData);
        }

        /// <summary>
        /// To Edit Record In Organization
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] OrganizationDTO organizationDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<OrganizationDTO, Organization>(organizationDTO);
                _organizationService.Update(pageModel);
             //   TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(organizationDTO);
        }

        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.OrganizationDTO { Id = id });
        }

        /// <summary>
        /// To Create Record In Organization
        /// </summary>
        /// <param name="organizationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] OrganizationDTO organizationDTO)
        {
            if (ModelState.IsValid)
            {

                var pageModel = _mapper.Map<OrganizationDTO, Organization>(organizationDTO);
                _organizationService.Create(pageModel);
               // TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(organizationDTO);
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
            Organization getByIdPageModel = _organizationService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<Organization, OrganizationDTO>(getByIdPageModel);
            return View(pageModel);
        }
        /// <summary>
        /// To Delete Record In Organization
        /// </summary>
        /// <returns></returns>

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _organizationService.Delete((int)id);
          //  TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }
    }
}