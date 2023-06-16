﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;
using TestingAndCalibrationLabs.Web.UI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    /// <summary>
    /// a base class for view
    /// </summary>
    public class CommonController : Controller
    {
        public string jsonData;
        private readonly ILookupService _lookupService;
        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IWorkflowStageService _workflowStageService;
        private readonly IListSorterService _listSorterService;
         
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        public CommonController(IGoogleDriveService googleDriveService, ILogger<CommonController> logger, ICommonService commonService, IMapper mapper, IWorkflowStageService workflowStageService, IListSorterService listSorterService, ILookupService lookupService)
        {
            _logger = logger;
            _commonService = commonService;
            _mapper = mapper;
            _googleDriveService = googleDriveService;
            _workflowStageService = workflowStageService;
            _listSorterService = listSorterService;
            _lookupService = lookupService;
        }

        /// <summary>
        /// Default Action of the Common Controller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").Take(4).ToList();
            return View(records);
        }
        /// <summary>
        /// Method To Upload Images in Google Drive And Return The Url Of File
        /// </summary>
        /// <returns></returns>
        [HttpPost]

        public IActionResult FileUpload()
        {

            List<string> imageId = new List<string>();
            
            foreach (var item in Request.Form.Files)
            {
                AttachmentModel attachmentModel = new AttachmentModel();
                attachmentModel.DataUrl = item;

                var result = _googleDriveService.Upload(attachmentModel);
                imageId.Add(result.RequestedObject.FilePath);

                //if (result.IsSuccessful)
                //{


                    
                //    return Ok(imageId);
                //}
                
                //else
                //{
                //    return BadRequest();
                //}
            }
            return Ok(imageId);
        }
        /// <summary>
        /// Method To load Grid by given page Id And Template Details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="controlCategoryTypeTemplate"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoadGrid(int? id, string controlCategoryTypeTemplate)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            //TODO: this is the temporary work later we will change it confiqq kendo ui
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").Take(4).ToList();
            return PartialView(controlCategoryTypeTemplate, records);
        }
        [HttpGet]
        public ActionResult MultiValueControlGrid(int id)
        {
            var pageMetadata = _commonService.GetMultiControlValue(id);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            //TODO: this is the temporary work later we will change it confiqq kendo ui
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").ToList();
            return PartialView("~/Views/Common/Components/Grid/_gridTemplate1.cshtml", records);
            

        }
        [HttpGet]
        public ActionResult TemplateGenerate(int recordId, int metadataId)
        {
            var reportByte = _commonService.TemplateGenerate(recordId, metadataId);
            return File(reportByte, "application/pdf");
        }
        /// <summary>
        /// sending record to axaj to show grid control
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GridList(int? id = 0)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            //records.Fields = records.Fields.Take(10).ToList();
            if (records.Fields != null)
            {
                return Ok(records);
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// To Create Record For Common Page
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lookupCategoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id = 1)
        {
            var pageMetadata = _commonService.GetUiPageMetadataCreate(id);
            var result = _mapper.Map<RecordModel, RecordDTO>(pageMetadata);
            
            return base.View(result);

        }
        [HttpGet]
        /// <param name="lookupCategoryId"></param>
        public ActionResult MultipleValue(int lookupCategoryId  )
        {
            var lookupList = _lookupService.GetLookupCategoryId(lookupCategoryId);
           
            List<ListSorterModel> listSorterDTOs = new List<ListSorterModel>();
            foreach (var item in lookupList)
            {
                listSorterDTOs.Add(new ListSorterModel { Id = item.Id, Name = item.Name, ParentId = item.ParentId });
            }
            var jsonFormated = _listSorterService.SortListToJson(listSorterDTOs);
            var jsonObjectConverted = JsonConvert.DeserializeObject(jsonFormated);
            return Json(jsonObjectConverted);
        }
        /// <summary>
        /// for creating data
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(RecordDTO record)
        {
           
            var records = _mapper.Map<RecordDTO, RecordModel>(record);
            var adddata = _commonService.Add(records);
            var pageMetadata = _commonService.GetUiPageMetadataCreate(record.ModuleId);
            var result = _mapper.Map<RecordModel, RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(result);
            }
            result.FieldValues = record.FieldValues;
            result.ErrorMessage = _mapper.Map<IList<Business.Common.ValidationMessage>, IList<Models.ValidationMessage>>(adddata.ValidationMessages);
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
            RecordDTO record = _mapper.Map<RecordModel, RecordDTO>(pageMetadata);
            return View(record);
        }

        /// <summary>
        /// Edit and binding with business project
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(RecordDTO record)
        {
            var records = _mapper.Map<RecordDTO, RecordModel>(record);
            var adddata = _commonService.Save(records);
            var pageMetadata = _commonService.GetRecordById(record.Id);
            Models.RecordDTO recordModel = _mapper.Map<RecordModel, RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(recordModel);
            }
            recordModel.FieldValues = record.FieldValues;
            recordModel.ErrorMessage = _mapper.Map<IList<Business.Common.ValidationMessage>, IList<Models.ValidationMessage>>(adddata.ValidationMessages);
            return BadRequest(recordModel);

        }
        /// <summary>
        ///  Delete Record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Delete(int? id, int moduleId)
        {
            if (id == null)
            {
                return NotFound();
            }
            _commonService.Delete((int)id);
            return RedirectToAction("Index", new { id = moduleId });
        }
        /// <summary>
        /// Delete Multi Record
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public ActionResult DeleteMultiValue(RecordModel record)
        {
            var result = _commonService.DeleteMultiValue(record);
            if (result.IsSuccessful)
            {
                return RedirectToAction("Edit", new { id = record.Id });
            }
            return BadRequest();
        }
    }

    
}
