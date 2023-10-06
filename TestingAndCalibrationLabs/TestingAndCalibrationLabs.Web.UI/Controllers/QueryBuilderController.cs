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
using AspNetCore;

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
            //List<string> list = JsonSerializer.Serialize(jsonData);

            //List<UiQueryBuilderColumn> Person = JsonSerializer.Deserialize<List<UiQueryBuilderColumn>>(jsonData);
            //List<JoinModel> Join = JsonSerializer.Deserialize<List<JoinModel>>(JoinData);
            //List<ConditionModelDTO> ConditionInfo = JsonSerializer.Deserialize<List<ConditionModelDTO>>(ConditionData);

            //for (var item = 0; item < Person.Count; item++)
            //{
            //    if (item + 65 + 1 <= 91)
            //    {

            //        Person[item].Alias = Convert.ToChar(item + 65);

            //    }
            //}
            //var Records = _mapper.Map<List<Models.UiQueryBuilderColumn>, List<Business.Core.Model.UiQueryGenerator>>(Person);
            //var recordJoin = _mapper.Map<List<Models.JoinModel>, List<Business.Core.Model.QueryBuilder.JoinModelDTO>>(Join);
            //var ConditionJoin = _mapper.Map<List<Models.ConditionModelDTO>, List<Business.Core.Model.QueryBuilder.ConditionModel>>(ConditionInfo);

            //var Value = _querybuilderService.UiToJsonQueryBuilder(Records, recordJoin, ConditionJoin, "");
            //var data = Value.ToDictionary(row => (string)row.itemdata, row => (string)row.itemtype);
            // List<QueryGenerator> models = JsonConvert.DeserializeObject<List<QueryGenerator>>(datainfo);
            var data = CommonMethod(jsonData, JoinData, ConditionData, TemplateName);


            return PartialView("~/Views/Common/Components/Grid/_commongrid.cshtml", data);
        }


        public IActionResult ExportExcel(string jsonData, string JoinData, string ConditionData, string TemplateName)
        {
            try
            {
                var records = CommonMethod(jsonData, JoinData, ConditionData, TemplateName);
                if (records != null && records.Dictionary != null)
                {

                    using (var stream = new MemoryStream())
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage(stream))
                        {
                            var worksheet = package.Workbook.Worksheets.Add("DataSheet");


                            int rowIndex = 1;
                            int columnIndex = 1;

                            // Loop through the dictionary
                            foreach (var keyValuePair in records.Dictionary)
                            {
                                worksheet.Cells[1, columnIndex].Value = keyValuePair.Key;

                                // Loop through the values in the dictionary
                                int valueIndex = rowIndex;
                                foreach (var value in keyValuePair.Value)
                                {
                                    worksheet.Cells[valueIndex, columnIndex].Value = value;
                                    valueIndex++;
                                }

                                columnIndex++;

                            }

                            var fileName = $"ExportedData_{DateTime.Now:yyyyMMddHHmmss}.xls"; // Use .xlsx extension
                            package.Save();

                            //  package.SaveAs(stream);
                            // byte[] excelBytes = stream.ToArray();

                            //  return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

                          //  byte[] bytedata = System.Text.Encoding.ASCII.GetBytes(worksheet.Cells.Value.ToString());
                            var dataValue = worksheet.Cells.Value.ToString() ;
                            return File(dataValue, " application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);

                            //var FileBytesArray = package.GetAsByteArray();
                            //return File(FileBytesArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName + ".xls");

                            //var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                            //FileStreamResult FSR = new FileStreamResult(stream, contentType);
                            //FSR.FileDownloadName = fileName;
                            //return FSR;

                        }
                    }
                }
                else
                {
                    // Handle the case where 'dashboardDTO' or 'dashboardDTO.Dictionary' is null
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                return BadRequest($"Error: {ex.Message}");
            }
        }


        public DashboardDTO CommonMethod (string jsonData, string JoinData, string ConditionData, string TemplateName)
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

    }
}