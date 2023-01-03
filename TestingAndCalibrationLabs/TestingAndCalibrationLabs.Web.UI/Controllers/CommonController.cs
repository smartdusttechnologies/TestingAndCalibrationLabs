using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

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
        private readonly IGoogleDriveService _googleDriveService;
        private readonly IWorkflowStageService _workflowStageService;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        public CommonController(IGoogleDriveService googleDriveService,ILogger<CommonController> logger, ICommonService commonService, IMapper mapper, IWorkflowStageService workflowStageService)
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
            var records = _mapper.Map<RecordsModel,RecordsDTO>(pageMetadata);
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
            records.Fields = records.Fields.Where(x => x.ControlCategoryName == "DataControl").Take(5).ToList();
            return PartialView(controlCategoryTypeTemplate, records);
        }
        /// <summary>
        /// sending record to axaj to show grid control
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GridList(int? id= 0)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<RecordsModel,RecordsDTO>(pageMetadata);
            //records.Fields = records.Fields.Take(10).ToList();
            if(records.Fields != null)
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
            var result = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
            return base.View(result);
        }

        /// <summary>
        /// for creating data
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(RecordDTO record)
         {
            var records = _mapper.Map<RecordDTO,RecordModel>(record);
            var adddata = _commonService.Add(records);
            var pageMetadata = _commonService.GetUiPageMetadataCreate(record.ModuleId);
            var result = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(result);
            }
            result.FieldValues = record.FieldValues;
            result.ErrorMessage = _mapper.Map<Business.Common.ValidationMessage,ValidationMessage>(adddata.ValidationMessages.FirstOrDefault());
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
            RecordDTO record = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
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
            var records = _mapper.Map<RecordDTO,RecordModel>(record);
            var adddata = _commonService.Update(records);
            var pageMetadata = _commonService.GetRecordById(record.Id);
            Models.RecordDTO recordModel = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
            if (adddata.IsSuccessful)
            {
                return Ok(recordModel);
                //  return Json(result);
            }
            recordModel.FieldValues = record.FieldValues;
            recordModel.ErrorMessage = _mapper.Map<Business.Common.ValidationMessage,ValidationMessage>(adddata.ValidationMessages.FirstOrDefault());
            return BadRequest(recordModel);
        }
        /// <summary>
        ///  Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var pageMetadata = _commonService.GetRecordByIdForDelete(id);
            RecordDTO record = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
            return View(record);
        }

        /// <summary>
        /// Delete Confirmed
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id,int moduleId)
        {
            if (id == null)
            {
                return NotFound();
            }
            _commonService.Delete((int)id);
            return RedirectToAction("Index", new { id = moduleId});
        }
    }
}
