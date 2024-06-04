using Microsoft.AspNetCore.Mvc;
using System.IO;
using TestingAndCalibrationLabs.Web.UI.Models;
using TestingAndCalibrationLabs.Business.Core.Interfaces.BackOffice;
using AutoMapper;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Model.Common;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SelectPdf;
using System;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Business.Services;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TemplateController : Controller
    {

        public readonly ITemplateService _templateService;
        public readonly IMapper _mapper;
        private readonly ICommonService _commonService;
        private readonly IDocumentService _documentService;

        public TemplateController(ITemplateService templateService, IMapper mapper, ICommonService commonService, IDocumentService documentService)
        {
            _templateService = templateService;
            _mapper = mapper;
            _commonService = commonService;
            _documentService = documentService;
        }
        /// <summary>
        /// This method is to Take the list of Template 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<TemplateModel> page = _templateService.Get();
            var pageData = _mapper.Map<List<TemplateModel>, List<TemplateDTO>>(page);
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                
                return Json(pageData);
            }
            return View(pageData.AsEnumerable());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            var value = new TemplateDTO();
            return View(value);
        }
        [HttpPost]
        public IActionResult Create([Bind]TemplateDTO Template)
        {

            if (Template.DataUrl == null)
                return View(Template);

            var ObjImg = _documentService.FileUpload(Template.DataUrl);
            Template.FileId = _commonService.ImageUpload(ObjImg);
           
            var templateModel = _mapper.Map<TemplateDTO, TemplateModel>(Template);


            if (Template.FileId != 0)
            {
                _templateService.Create(templateModel);
            }


             return RedirectToAction("Index"); 
        }
        /// <summary>
        /// This method will convert File into a PDF
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult FileToPdf(IFormFile file)
        {
            var value = "";

            using (var streamReader = new StreamReader(file.OpenReadStream()))
            {
                value = streamReader.ReadToEnd();
            }

            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(value);

            var pdfByte = doc.Save();

           
            doc.Close();
            string base64String = Convert.ToBase64String(pdfByte);

            return Ok(base64String);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            TemplateModel page = _templateService.GetById(Id);
           // page.DataUrl = _documentService.FileConverter(page.FileId);

            var pageData = _mapper.Map<TemplateModel, TemplateDTO>(page);
            return View(pageData);
        }

        [HttpPost]
        public IActionResult Edit([Bind]TemplateDTO template)
        {
           

            if (ModelState.IsValid)
            {
                _documentService.ImageFileUpdate(template.Id, template.DataUrl);
                var pageData = _mapper.Map<TemplateDTO, TemplateModel>(template);
                _templateService.Update(pageData);
                
                TempData["IsTrue"] = true;
                return RedirectToAction("Index");
            }
            return View(template);


        }

        public IActionResult Delete(int id)
        {
            TemplateModel page = _templateService.GetById(id);
            page.DataUrl = _documentService.FileConverter(page.FileId);

            var pageData = _mapper.Map<TemplateModel, TemplateDTO>(page);
            return View(pageData);
        }

        /// <summary>
        /// To Delete Record From Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _templateService.Delete(id);
            TempData["IsTrue"] = true;
            return RedirectToAction("Index");
        }

    }

}


