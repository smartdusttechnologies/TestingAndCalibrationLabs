using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class CustomerDetailsController : Controller
    {
        public readonly ICustomerDetailsService _customerDetailsService;
        public readonly IMapper _mapper;
        private readonly IUiPageNavigationService _uiNavigationCategoryService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="LookupCategoryService"></param>
        /// <param name="mapper"></param>
        /// <param name="uiNavigationCategoryService"></param>

        public CustomerDetailsController(ICustomerDetailsService customerDetailsService, IMapper mapper)
        {
            _customerDetailsService = customerDetailsService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All The Record From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<CustomerDetailsModel> page = _customerDetailsService.Get();
            var pageData = _mapper.Map<List<CustomerDetailsModel>, List<CustomerDetailsDTO>>(page);
            return View(pageData.AsEnumerable());
            //return View();
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
            var getByIdPageModel = _customerDetailsService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageData = _mapper.Map<CustomerDetailsModel, CustomerDetailsDTO>(getByIdPageModel);

            return View(pageData);
            //return View();
        }
        /// <summary>
        /// To Edit Record In CustomerDetails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] CustomerDetailsDTO customerDetailsDTO)
        {

            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<CustomerDetailsDTO, CustomerDetailsModel>(customerDetailsDTO);
                _customerDetailsService.Update(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(customerDetailsDTO);
            //return View();
        }
        /// <summary>
        /// For Create Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            return base.View(new Models.CustomerDetailsDTO { Id = id });
        }
        /// <summary>
        /// To Create Record In CustomerDetails
        /// </summary>
        /// <param name="customerDetailsDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] CustomerDetailsDTO customerDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                var pageModel = _mapper.Map<CustomerDetailsDTO, CustomerDetailsModel>(customerDetailsDTO);
                _customerDetailsService.Create(pageModel);
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(customerDetailsDTO);
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
            CustomerDetailsModel getByIdPageModel = _customerDetailsService.GetById((int)id);
            if (getByIdPageModel == null)
            {
                return NotFound();
            }
            var pageModel = _mapper.Map<CustomerDetailsModel, CustomerDetailsDTO>(getByIdPageModel);
            return View(pageModel);
            //return View();
        }
        /// <summary>
        /// To Delete Record In CustomerDetails
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
            _customerDetailsService.Delete((int)id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [HttpGet]
        public IActionResult GetAllCustomerDetails()
        {
            List<CustomerDetailsModel> page = _customerDetailsService.Get();

            //var customers = _dbContext.CustomerDetails.Select(c => new
            //{
            //    c.Email,
            //    c.Name,
            //    c.Address,
            //    c.Mobile
            //}).ToList();

            return Json(page);
        }
        public IActionResult GetbyIdCustomer(int customerId)
        {

            CustomerDetailsModel Customer = _customerDetailsService.GetById(customerId);

            return Json(Customer);

        }

    }
}