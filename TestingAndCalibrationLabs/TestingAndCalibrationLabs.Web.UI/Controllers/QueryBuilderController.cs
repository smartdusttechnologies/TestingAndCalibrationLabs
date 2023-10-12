using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Web.UI.Models;
using System.Text.Json;
using System;
using TestingAndCalibrationLabs.Business.Core.Model.Dashboard;
using OfficeOpenXml;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Document = iTextSharp.text.Document;
using Paragraph = iTextSharp.text.Paragraph;
using System.Windows.Markup;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class QueryBuilderController : Controller
    {
        private readonly IQueryBuilderService _querybuilderService;
        private readonly IMapper _mapper;

        public QueryBuilderController(IQueryBuilderService querybuilderService, IMapper mapper)
        {
            _querybuilderService = querybuilderService;
            _mapper = mapper;
        }
        /// <summary>
        /// This method will show Table to the QueryBuilder Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Business.Core.Model.QueryBuilder.QueryBuilderModel> tableName = _querybuilderService.GetTableNames();
            var queryBuilderMetaData = _querybuilderService.GetColoumsNames(tableName);
            var records = _mapper.Map<Business.Core.Model.QueryBuilder.QueryRecordModel, Models.QueryBuilderRecordDTO>(queryBuilderMetaData);
            return View(records);
        }
        /// <summary>
        /// This method will  me Common Query Builder method 
        /// </summary>
        /// <returns></returns>
        public DashboardDTO CommonQueryGenerator(string jsonData, string JoinData, string ConditionData, string TemplateName)
        {
            List<UiQueryBuilderColumn> Person = JsonSerializer.Deserialize<List<UiQueryBuilderColumn>>(jsonData);
            List<JoinModel> Join = JsonSerializer.Deserialize<List<JoinModel>>(JoinData);
            List<ConditionModelDTO> ConditionInfo = JsonSerializer.Deserialize<List<ConditionModelDTO>>(ConditionData);

            for (var item = 0; item < Person.Count; item++)
            {
                if (item + 65 + 1 <= 91)
                {

                    Person[item].Alias = Convert.ToChar(item + 65);

                }
            }
            var Records = _mapper.Map<List<Models.UiQueryBuilderColumn>, List<Business.Core.Model.UiQueryGenerator>>(Person);
            var recordJoin = _mapper.Map<List<Models.JoinModel>, List<Business.Core.Model.QueryBuilder.JoinModelDTO>>(Join);
            var ConditionJoin = _mapper.Map<List<Models.ConditionModelDTO>, List<Business.Core.Model.QueryBuilder.ConditionModel>>(ConditionInfo);

            var Value = _querybuilderService.UiToJsonQueryBuilder(Records, recordJoin, ConditionJoin, "");
            var records = _mapper.Map<DashboardModel, DashboardDTO>(Value);
            return records;

        }

        /// <summary>
        /// This method will take the Detail from Query Builder
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="JoinData"></param>
        /// <param name="ConditionData"></param>
        /// <param name="TemplateName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult QueryGenerator(string jsonData, string JoinData, string ConditionData, string TemplateName)
        {
            var data = CommonQueryGenerator(jsonData, JoinData, ConditionData, TemplateName);
            return PartialView("~/Views/Common/Components/Grid/_commongrid.cshtml", data);
        }
        /// <summary>
        /// This method will take the  Export to Excel 
        /// </summary>
        public IActionResult ExportExcel(string jsonData, string JoinData, string ConditionData, string TemplateName)
        {
            try
            {
                var records = CommonQueryGenerator(jsonData, JoinData, ConditionData, TemplateName);
                var stream = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.Add("SampleData");

                    int rowIndex = 1;
                    int columnIndex = 1;

                    foreach (var keyValuePair in records.Dictionary)
                    {
                        // worksheet.Cells[1, columnIndex].Value = keyValuePair.Key;
                        worksheet.Cells[1, columnIndex].Value = keyValuePair.Key;
                        rowIndex++;

                        // Loop through the values in the dictionary
                        int valueIndex = rowIndex;
                        foreach (var value in keyValuePair.Value)
                        {
                            worksheet.Cells[valueIndex, columnIndex].Value = value;

                            valueIndex++;
                        }

                        columnIndex++;
                    }

                    worksheet.Cells.AutoFitColumns();
                    package.Save();
                }

                // stream.Seek(0, SeekOrigin.Begin);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "SampleData.xlsx");

            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                return BadRequest($"Error: {ex.Message}");
            }
        }


        /// <summary>
        /// This method will take the  Export to PDF
        /// </summary>
        public IActionResult ExportPDF(string jsonData, string JoinData, string ConditionData, string TemplateName)
        {
            try
            {
                var records = CommonQueryGenerator(jsonData, JoinData, ConditionData, TemplateName);

                Document document = new Document(PageSize.A4);
                var stream = new MemoryStream();
                var pdfFileName = "Data.pdf";
                PdfWriter.GetInstance(document, stream);
                document.Open();

                foreach (var entry in records.Dictionary)
                {
                    document.Add(new Paragraph(entry.Key));

                    if (entry.Value != null)
                    {
                        PdfPTable table = new PdfPTable(1); // 1 column, you can change this as needed

                        foreach (var value in entry.Value)
                        {
                            if (value != null)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(value.ToString()));
                                table.AddCell(cell);
                            }
                        }

                        document.Add(table);
                    }
                }

                document.Close();

                // Return the generated PDF as a downloadable file
                return File(stream.ToArray(), "application/pdf", pdfFileName);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                return Content($"Error: {ex.Message}");
            }
        }

    }
}