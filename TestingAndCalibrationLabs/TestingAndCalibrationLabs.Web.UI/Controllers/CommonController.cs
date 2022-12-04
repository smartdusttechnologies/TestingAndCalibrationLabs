using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;

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
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="listSorterService"></param>
        public CommonController(IGoogleDriveService googleDriveService,ILogger<CommonController> logger, ICommonService commonService, IMapper mapper, IListSorterService listSorterService)
        {
            _logger = logger;
            _commonService = commonService;
            _mapper = mapper;
            _googleDriveService = googleDriveService;
        }
        /// <summary>
        /// for getting old page index
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(int? id)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<RecordsModel,RecordsDTO>(pageMetadata);
            records.Fields = records.Fields.Take(10).ToList();
            return View(records);
        }
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
        [HttpGet]
        public ActionResult Create(int id = 1)
        {
            var uiPageId = id;
            var pageMetadata = _commonService.GetUiPageMetadataHierarchy(uiPageId);
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
            var pageMetadata = _commonService.GetUiPageMetadata(record.UiPageId);
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
            var Layout = _commonService.GetUiPageMetadataHierarchy(pageMetadata.UiPageId);
            pageMetadata.Layout = Layout.Layout;
            Layout.FieldValues = pageMetadata.FieldValues;
            Layout.Id = pageMetadata.Id;
            Models.RecordDTO record = _mapper.Map<RecordModel,RecordDTO>(Layout);
            return View(record);
        }
        /// <summary>
        /// Edit and binding with business project
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Models.RecordDTO record)
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
        ///  Delete Details of common
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var pageMetadata = _commonService.GetRecordById(id);
            Models.RecordDTO record = _mapper.Map<RecordModel,RecordDTO>(pageMetadata);
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
            return Redirect("/");
            //return RedirectToAction("Index");
        }
    }
}
