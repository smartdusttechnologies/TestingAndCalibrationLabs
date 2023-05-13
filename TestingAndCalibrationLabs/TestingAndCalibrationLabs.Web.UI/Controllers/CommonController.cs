using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
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

        private readonly ILogger<CommonController> _logger;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IWorkflowStageService _workflowStageService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        public CommonController(IGoogleDriveService googleDriveService, ILogger<CommonController> logger, ICommonService commonService, IMapper mapper, IWorkflowStageService workflowStageService)
        {
            _logger = logger;
            _commonService = commonService;
            _mapper = mapper;
            _googleDriveService = googleDriveService;
            _workflowStageService = workflowStageService;
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
            AttachmentModel attachmentModel = new AttachmentModel();
            attachmentModel.DataUrl = Request.Form.Files.FirstOrDefault();
            var result = _googleDriveService.Upload(attachmentModel);
            if (result.IsSuccessful)
            {
                var imageId = result.RequestedObject.FilePath;
                return Ok(imageId);
            }
            else
            {
                return BadRequest();
            }
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
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create(int id = 1)
        {
            var pageMetadata = _commonService.GetUiPageMetadataCreate(id);
            var select = MultipleValue();
            var result = _mapper.Map<RecordModel, RecordDTO>(pageMetadata);
            return base.View(result);

        }
        [HttpGet]
        public ActionResult MultipleValue()
        {
            
            List<multiselectvaluesModel> Multi = new List<multiselectvaluesModel>();
            Multi.Add(new multiselectvaluesModel { ParentId = 0,Orders=0,  Id = 4, Name = "Horse" });
            Multi.Add(new multiselectvaluesModel { ParentId = 4, Orders = 0, Id = 6, Name = "Birds" });
            //Multi.Add(new multiselectvaluesModel { ParentId = 4, Id = 9, title = "dog" });
            Multi.Add(new multiselectvaluesModel { ParentId = 0, Orders = 0, Id = 10, Name = "dog" });
            Multi.Add(new multiselectvaluesModel { ParentId = 10, Orders = 0, Id = 7, Name = "dog" });
            //Multi.Add(new multiselectvaluesModel { ParentId = 7, Id = 2, title = "dog" });
           // Multi.Add(new multiselectvaluesModel { ParentId = 7, Id = 8, title = "dog" });
            //Multi.Add(new multiselectvaluesModel { ParentId = 2, Id = 3, title = "dog" });
            //Multi.Add(new multiselectvaluesModel { ParentId = 8, Id = 5, title = "dog" });

            //var pageMetadata = _commonService.Multilectal(Multi);
            jsonData = "[";
            for (var i = 0; i < Multi.ToArray().Length; i++)
            {
                if (Multi[i].ParentId == 0)
                {
                    if (jsonData != "[") jsonData += ",";
                    jsonData += "{id:" + Multi[i].Id + ",title:`" + Multi[i].Name + "`";
                    for (var j = i + 1; j < Multi.ToArray().Length; j++)
                    {
                        if (Multi[i].Id == Multi[j].ParentId)
                        {
                            jsonData += ",subs:[";
                            while (j < Multi.ToArray().Length)
                            {
                                if (Multi[i].Id == Multi[j].ParentId)
                                {
                                    if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                                    jsonData += "{id:" + Multi[j].Id + ",title:`" + Multi[j].Name + "`";
                                    //Check for child
                                    returnChildern(Multi[j].Id, j);
                                    jsonData += "}";
                                }
                                j++;
                            }
                            jsonData += "]";
                        }
                    }
                    jsonData += "}";
                }

            }
            jsonData += "]";

            ViewBag.jsonData = jsonData;

            //var result = _mapper.Map<MultiselectDropdownModel, MultiselectDropdownDTO>(pageMetadata);

            //string jsonString = JsonSerializer.Serialize(jsonData);
            //ViewBag.data = jsonData;

            return View(jsonData);

            
        }
        public void returnChildern(int id, int index)
        {
            List<multiselectvaluesModel> Multi = new List<multiselectvaluesModel>();
            Multi.Add(new multiselectvaluesModel { ParentId = 0, Orders = 0, Id = 4, Name = "Horse" });
            Multi.Add(new multiselectvaluesModel { ParentId = 1, Orders = 0, Id = 6, Name = "Birds" });
            //Multi.Add(new multiselectvaluesModel { ParentId = 4, Id = 9, title = "dog" });
            Multi.Add(new multiselectvaluesModel { ParentId = 9, Orders = 0, Id = 10, Name = "dog" });
            Multi.Add(new multiselectvaluesModel { ParentId = 10, Orders = 0, Id = 7, Name = "dog" });

            for (var i = index + 1; i < Multi.ToArray().Length; i++)
            {
                if (id == Multi[i].ParentId)
                {
                    jsonData += ",subs:[";
                    while (i < Multi.ToArray().Length)
                    {
                        if (Multi[i].ParentId == id)
                        {
                            if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                            jsonData += "{id:" + Multi[i].Id + ",title:`" + Multi[i].Name + "`";
                            //Check for child
                            returnChildern(Multi[i].Id, index + 1);
                            jsonData += "}";
                        }
                        i++;
                    }
                    jsonData += "]";
                }
            }
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
