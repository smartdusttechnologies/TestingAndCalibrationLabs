using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

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
            var pageMetadata = _commonService.GetRecordsIndex(id.Value);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").ToList();
            return View(records);
        }
        /// <summary>
        /// Method To Upload Images in Database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FileUpload()
        {
            List<string> imageId = new List<string>();

            foreach (var imagelenth in Request.Form.Files)
            {
                if (imagelenth != null)
                {
                    if (imagelenth.Length > 0)
                    {
                        //Getting FileName
                        var ImageName = Path.GetFileName(imagelenth.FileName);
                        //Getting file Extension
                        var ImageExtension = Path.GetExtension(ImageName);
                        // concatenating  FileName + FileExtension
                        var NewImageName = String.Concat(Convert.ToString(Guid.NewGuid()), ImageExtension);
                        var ObjImage = new FileUploadModel()
                        {
                            Name= NewImageName,
                            FileType = ImageExtension,
                            CreatedOn = DateTime.Now
                        };
                        using (var target = new MemoryStream())
                        {
                            imagelenth.CopyTo(target);
                            ObjImage.DataFiles = target.ToArray();
                        }
                       var Imagecollection = _commonService.ImageUpload(ObjImage);
                        imageId.Add(NewImageName.ToString());
                    }
                }
            }
            return Ok(imageId);
        }
        /// <summary>
        /// Method To download Images 
        /// </summary>
        /// <returns></returns>
        public IActionResult DownloadImage(string ImageValue)
        {
           
            FileUploadModel attachment = _commonService.DownloadImage(ImageValue);
           
            if (attachment != null)
            {
                 return File(new MemoryStream(attachment.DataFiles),Helpers.GetMimeTypes()[attachment.FileType] , attachment.Name);
            }
            return Ok("Can't find the Image");
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
        public ActionResult MultiValueControlGrid(int id, int moduleLayoutId, int UipagetypeId)
        {
            var pageMetadata = _commonService.GetMultiControlValue(id, moduleLayoutId, UipagetypeId);
            var records = _mapper.Map<RecordsModel, RecordsDTO>(pageMetadata);
            //TODO: this is the temporary work later we will change it confiqq kendo ui
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").ToList();
            return PartialView("~/Views/Common/Components/Grid/_gridTemplate1.cshtml", records);
        }
        [HttpPost]
        public ActionResult TemplateGenerate(int recordId, int metadataId,string email,bool send, int moduleLayoutId, int UipagetypeId)
        {
            var reportByte = _commonService.TemplateGenerate(recordId, metadataId,email,send, moduleLayoutId, UipagetypeId);
            
            if (send)
            {
                return Ok("Sent Succsefully");
            }
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
        /// <summary>
        /// To Create Record For multiplevalues in Common Page
        /// </summary>
        /// <param name="lookupCategoryId"></param>
        /// <returns></returns>
        public ActionResult MultipleValue(int lookupCategoryId  )
        {
            var lookupList = _lookupService.GetByCategoryId(lookupCategoryId);
           
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
                result.Id = records.Id;
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
        /// <summary>
        /// generate Id in Record
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>

        public ActionResult GenerateRecord(int moduleId,int  workflowStageId)
        {
            var recordId = _commonService.GenerateRecordId(moduleId, workflowStageId);
            return Ok(recordId);
        }
    }
}
