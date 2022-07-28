﻿using System.Collections.Generic;
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

    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ICommonService _sampleService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="sampleService"></param>
        /// <param name="hostingEnvironment"></param>
        public SampleController(ILogger<SampleController> logger, ICommonService sampleService, IMapper mapper)
        {
            _logger = logger;
            _sampleService = sampleService;
            _mapper = mapper;
        }
        /// <summary>
        /// for getting old page index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var pageMetadata = _sampleService.GetRecords();
            var records = _mapper.Map<Business.Core.Model.Common.RecordsModel, Models.RecordsDTO>(pageMetadata);
            records.Fields = records.Fields.Take(10).ToList();
            return View(records);
        }

        /// <summary>
        /// Inseting details for Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id)
        {
            var uiPageId = id;
            var pageMetadata = _sampleService.GetUiPageMetadata(uiPageId);
            var result = _mapper.Map<Business.Core.Model.Common.RecordModel, Models.RecordDTO>(pageMetadata);
           
            return base.View(result);
        }
        /// <summary>
        /// for creating data
        /// </summary>
        /// <param name="sample"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Models.RecordDTO record)
        {
            var records = _mapper.Map<UI.Models.RecordDTO, Business.Core.Model.Common.RecordModel>(record);
            var adddata = _sampleService.Add(records);
            var pageMetadata = _sampleService.GetUiPageMetadata(record.UiPageId);
            var result = _mapper.Map<Business.Core.Model.Common.RecordModel, Models.RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(result);  
              //  return Json(result);

            }

            // string message=abc.ValidationMessages.FirstOrDefault()?.Reason;
            result.FieldValues = record.FieldValues;

            result.ErrorMessage = _mapper.Map<Business.Common.ValidationMessage, Web.UI.Models.ValidationMessage>(adddata.ValidationMessages.FirstOrDefault());
            return BadRequest(result);
           // return Json(result);
            
        }
        
        /// <summary>
        /// Edit deatils of Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pageMetadata = _sampleService.GetRecordById(id);
            Models.RecordDTO record = _mapper.Map<Business.Core.Model.Common.RecordModel, Models.RecordDTO>(pageMetadata);
            return View(record);
        }
        /// <summary>
        /// Edit and binding with business project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sample"></param>
        /// <returns></returns>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Models.RecordDTO record)
        {
            var records = _mapper.Map<UI.Models.RecordDTO, Business.Core.Model.Common.RecordModel>(record);
            var adddata= _sampleService.Update(records);
            var pageMetadata = _sampleService.GetRecordById(record.Id);
            Models.RecordDTO recordModel = _mapper.Map<Business.Core.Model.Common.RecordModel, Models.RecordDTO>(pageMetadata);
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
        ///  Delete Details of Sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var pageMetadata = _sampleService.GetRecordById(id);
            Models.RecordDTO record = _mapper.Map<Business.Core.Model.Common.RecordModel, Models.RecordDTO>(pageMetadata);
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
            _sampleService.Delete((int)id);
            return RedirectToAction("Index");
        }
    }
}
