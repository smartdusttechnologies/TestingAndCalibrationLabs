using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core;
namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// a base class for view
    /// </summary>

    public class CommonController : Controller
    {
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="hostingEnvironment"></param>
        public CommonController(ILogger<CommonController> logger, ICommonService commonService, IMapper mapper)
        {
            _logger = logger;
            _commonService = commonService;
            _mapper = mapper;
        }
        /// <summary>
        /// for getting old page index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int? id = 0)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<Business.Core.Model.RecordsModel, Models.RecordsDTO>(pageMetadata);
            records.Fields = records.Fields.Take(10).ToList();
            return View(records);
        }

        /// <summary>
        /// Inseting details for common
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var uiPageId = id;
            var pageMetadata = _commonService.GetUiPageMetadata(uiPageId);
            var result = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
           
            return base.View(result);
        }
        /// <summary>
        /// for creating data
        /// </summary>
        /// <param name="common"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Models.RecordDTO record)
        {
            var records = _mapper.Map<UI.Models.RecordDTO, Business.Core.Model.RecordModel>(record);
            var adddata = _commonService.Add(records);
            var pageMetadata = _commonService.GetUiPageMetadata(record.UiPageId);
            var result = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(result);  
            }
            result.FieldValues = record.FieldValues;

            result.ErrorMessage = _mapper.Map<Business.Common.ValidationMessage, Web.UI.Models.ValidationMessage>(adddata.ValidationMessages.FirstOrDefault());
            return BadRequest(result);    
        }
        
        /// <summary>
        /// Edit deatils of common
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pageMetadata = _commonService.GetRecordById(id);
            Models.RecordDTO record = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            return View(record);
        }
        /// <summary>
        /// Edit and binding with business project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="common"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Models.RecordDTO record)
        {
            var records = _mapper.Map<UI.Models.RecordDTO, Business.Core.Model.RecordModel>(record);
            var adddata= _commonService.Update(records);
            var pageMetadata = _commonService.GetRecordById(record.Id);
            Models.RecordDTO recordModel = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(recordModel);
                //  return Json(result);
            }
            recordModel.FieldValues = record.FieldValues;
            recordModel.ErrorMessage = _mapper.Map<Business.Common.ValidationMessage, Web.UI.Models.ValidationMessage>(adddata.ValidationMessages.FirstOrDefault());
            return BadRequest(recordModel);
        }

        /// <summary>
        ///  Delete Details of common
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var pageMetadata = _commonService.GetRecordById(id);
            Models.RecordDTO record = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _commonService.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}
