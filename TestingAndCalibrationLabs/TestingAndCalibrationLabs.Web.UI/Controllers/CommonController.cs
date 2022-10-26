using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using System;
using TestingAndCalibrationLabs.Business.Common;
using System.Security.Cryptography.X509Certificates;
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
        private readonly IWebHostEnvironment _hostingEnviroment;
        private readonly IListSorterService _listSorterService;
        /// <summary>
        /// 
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="commonService"></param>
        /// <param name="hostingEnvironment"></param>
        public CommonController(IWebHostEnvironment webHostingEnviroment, ILogger<CommonController> logger, ICommonService commonService, IMapper mapper, IListSorterService listSorterService)
        {
            _logger = logger;
            _commonService = commonService;
            _mapper = mapper;
            _listSorterService = listSorterService;
            _hostingEnviroment = webHostingEnviroment;
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
        /// sending record to axaj to show grid control
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GridList(int? id = 0)
        {
            var pageMetadata = _commonService.GetRecords(id.Value);
            var records = _mapper.Map<Business.Core.Model.RecordsModel, Models.RecordsDTO>(pageMetadata);
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
        public ActionResult CreateLayout(int id)
        {
            string data;
            //StreamReader r = new StreamReader(Path.Combine(_hostingEnviroment.WebRootPath, "CUIJson.json"));


            //   data = r.ReadToEnd();
            //source = JsonSerializer.Deserialize<List<Person>>(json);
            var uiPageId = id;
            var pageMetadata = _commonService.GetUiPageMetadata(uiPageId);

            var hierarchy = pageMetadata.Fields.Hierarchize(
             0, // The "root level" key. We're using -1 to indicate root level.
             f => f.Id, // The ID property on your object
             f => f.ParentId,// The property on your object that points to its parent
            f => f.Position // The property on your object that specifies the order within its parent

             );

            var records = _commonService.GetRecords(id);
            var record= _mapper.Map<Business.Core.Model.RecordsModel, Models.RecordsDTO>(records);
            //record.Fields = record.Fields.Take(10).ToList();

            //var resultJson = JsonConvert.DeserializeObject(json);
            var result = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            result.Layout = hierarchy;
            result.FieldValuesForGrid = record.FieldValues;
            return base.View(result);
        }[HttpGet]
        public ActionResult SampleProgressStatus(int id)
        {
            //string data;
            ////StreamReader r = new StreamReader(Path.Combine(_hostingEnviroment.WebRootPath, "CUIJson.json"));


            ////   data = r.ReadToEnd();
            ////source = JsonSerializer.Deserialize<List<Person>>(json);
            //var uiPageId = id;
            //var pageMetadata = _commonService.GetUiPageMetadata(uiPageId);

            //var hierarchy = pageMetadata.Fields.Hierarchize(
            // 0, // The "root level" key. We're using -1 to indicate root level.
            // f => f.Id, // The ID property on your object
            // f => f.ParentId,// The property on your object that points to its parent
            //f => f.Position // The property on your object that specifies the order within its parent

            // );

            //var records = _commonService.GetRecords(id);
            //var record= _mapper.Map<Business.Core.Model.RecordsModel, Models.RecordsDTO>(records);
            ////record.Fields = record.Fields.Take(10).ToList();

            ////var resultJson = JsonConvert.DeserializeObject(json);
            //var result = _mapper.Map<Business.Core.Model.RecordModel, Models.RecordDTO>(pageMetadata);
            //result.Layout = hierarchy;
            //result.FieldValuesForGrid = record.FieldValues;
            var progressModel = new List<ProgressDTO>();
            progressModel.Add(new ProgressDTO { Id = 1, DisplayName = "Raj 1" });
            progressModel.Add(new ProgressDTO { Id = 2, DisplayName = "Raj 2" });
            progressModel.Add(new ProgressDTO { Id = 3, DisplayName = "Raj 3" });
            progressModel.Add(new ProgressDTO { Id = 4, DisplayName = "Raj 4" });
            progressModel.Add(new ProgressDTO { Id = 10, DisplayName = "Raj 5" });
            //progressModel.Add(new ProgressDTO { Id = 15, DisplayName = "Raj 5k" });
            //progressModel.Add(new ProgressDTO { Id = 140, DisplayName = "Raj 5j" });
            return base.View(progressModel);
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
            var adddata = _commonService.Update(records);
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
