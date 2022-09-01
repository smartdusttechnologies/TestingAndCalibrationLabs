using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class DataTypeController : Controller
    {
        public readonly IDataTypeService _dataTypeService;
        public readonly IMapper _mapper;

        public DataTypeController(IDataTypeService dataTypeService, IMapper mapper)
        {
            _dataTypeService = dataTypeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            List<DataTypeModel>data= _dataTypeService.Get();
            var pageData = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.DataTypeModel>>(data);

            return View(pageData.AsEnumerable());
        }

        [HttpGet]

        public IActionResult Create(int id)
        {
            return base.View(new Models.DataTypeModel { Id=id});
        }
        [HttpPost]
        public IActionResult Create([Bind] Models.DataTypeModel dataTypeModel)
        {
            if(ModelState.IsValid)
            {
                var dataModel= _mapper.Map<Models.DataTypeModel,Business.Core.Model.DataTypeModel>(dataTypeModel);
                _dataTypeService.Create(dataModel);
                TempData["IsTrue"]= true;
                return RedirectToAction("Index");
            }
            return View(dataTypeModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var getByIdDataModel = _dataTypeService.GetById((int)id);
            if (getByIdDataModel == null)
            { return NotFound(); }
            var pageData = _mapper.Map<Business.Core.Model.DataTypeModel, Models.DataTypeModel>(getByIdDataModel);
            return View(pageData);
        }

        [HttpPost]
        public IActionResult Edit([Bind] Models.DataTypeModel dataTypeModel)
        {
            if(ModelState.IsValid)
            {
                var dataModel = _mapper.Map<Models.DataTypeModel, Business.Core.Model.DataTypeModel>(dataTypeModel);
                _dataTypeService.Edit(dataModel);
                return RedirectToAction("Index");
            }
            return View(dataTypeModel);
        }

        public IActionResult Delete(int? id)
        {
            if(id==null)
            { return NotFound(); }
            Business.Core.Model.DataTypeModel getByIdModel = _dataTypeService.GetById((int) id);
            if(getByIdModel==null)
            { return NotFound(); }
            var dataModel = _mapper.Map<Business.Core.Model.DataTypeModel, Models.DataTypeModel>(getByIdModel);
            return View(dataModel);

        }
        [HttpPost,ActionName("delete")]
        public IActionResult DeleteConfirmed(int? id)
        {
            if(id==null)
            {    return NotFound();  }

            _dataTypeService.Delete((int)id);
            return RedirectToAction("Index"); 
        }
     }
}
