using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;


namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// This class will perform the Crud operation for datatype
    /// </summary>
    public class DataTypeController : Controller
    {
        public readonly IDataTypeService _dataTypeService;
        public readonly IMapper _mapper;
        /// <summary>
        /// passing parameter  varibales for establishing connection
        /// </summary>
        /// <param name="dataTypeService"></param>
        /// <param name="mapper"></param>
        public DataTypeController(IDataTypeService dataTypeService, IMapper mapper)
        {
            _dataTypeService = dataTypeService;
            _mapper = mapper;
        }
        /// <summary>
        /// Get All The Dataype Record From DataBase
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            var dataTypes = _dataTypeService.Get();
            var dataTypeList = _mapper.Map<List<Business.Core.Model.DataTypeModel>, List<Models.DataTypeModel>>(dataTypes);

            return View(dataTypeList.AsEnumerable());
        }
        /// <summary>
        /// To Create a New Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        

        public IActionResult Create(int id)
        {
            return base.View(new Models.DataTypeModel { Id=id});
        }
        /// <summary>
        /// To Create Record in DataType
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([Bind] Models.DataTypeModel dataTypeModel)
        {
            if(ModelState.IsValid)
            {
                var dataType= _mapper.Map<Models.DataTypeModel,Business.Core.Model.DataTypeModel>(dataTypeModel);
                _dataTypeService.Create(dataType);
                TempData["IsTrue"]= true;
                return RedirectToAction("Index");
            }
            return View(dataTypeModel);
        }
        /// <summary>
        /// To Edit Record View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            { return NotFound(); }
            var dataType = _dataTypeService.GetById((int)id);
            if (dataType == null)
            { return NotFound(); }
            var dataTypeById = _mapper.Map<Business.Core.Model.DataTypeModel, Models.DataTypeModel>(dataType);
            return View(dataTypeById);
        }
        /// <summary>
        /// To Edit Record In DataType
        /// </summary>
        /// <param name="dataTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit([Bind] Models.DataTypeModel dataTypeModel)
        {
            if(ModelState.IsValid)
            {
                var dataType = _mapper.Map<Models.DataTypeModel, Business.Core.Model.DataTypeModel>(dataTypeModel);
                _dataTypeService.Edit(dataType);
                return RedirectToAction("Index");
            }
            return View(dataTypeModel);
        }
        /// <summary>
        /// To Delete Record View 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if(id==null)
            { return NotFound(); }
            var dataType = _dataTypeService.GetById((int) id);
            if(dataType == null)
            { return NotFound(); }
            var dataTypeById = _mapper.Map<Business.Core.Model.DataTypeModel, Models.DataTypeModel>(dataType);
            return View(dataTypeById);

        }
        /// <summary>
        /// To Delete Record in DataType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
