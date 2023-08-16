
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Web.UI.Models;
using System.Text.Json;
using System;
using TestingAndCalibrationLabs.Business.Core.Model;
using CloudinaryDotNet.Actions;
using TestingAndCalibrationLabs.Business.Common;
using Newtonsoft.Json.Linq;
using AutoMapper.Execution;

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
        
       public IActionResult QueryGenerator(string jsonData ,string JoinData,string ConditionData,string TemplateName)
        {
            //List<string> list = JsonSerializer.Serialize(jsonData);
          
            List<UiQueryBuilderColumn> Person = JsonSerializer.Deserialize<List<UiQueryBuilderColumn>>(jsonData);
            List<JoinModel> Join = JsonSerializer.Deserialize<List<JoinModel>>(JoinData);
            List<ConditionModelDTO> ConditionInfo = JsonSerializer.Deserialize<List<ConditionModelDTO>>(ConditionData);

            //var  emptydata = Object.entries(datainfo); 


            for (var  item = 0; item < Person.Count; item++)
            {
                if (item + 65 + 1 <= 91)
                {

                    Person[item].Alias = Convert.ToChar(item + 65); 

                }
                    
                    
            }
            var Records = _mapper.Map<List<Models.UiQueryBuilderColumn>, List<Business.Core.Model.UiQueryGenerator>>(Person);


            var recordJoin = _mapper.Map<List<Models.JoinModel>, List<Business.Core.Model.QueryBuilder.JoinModelDTO>>(Join);
            var  ConditionJoin = _mapper.Map<List<Models.ConditionModelDTO>, List<Business.Core.Model.QueryBuilder.ConditionModel>>(ConditionInfo);


            var Value = _querybuilderService.UiToJsonQueryBuilder(Records, recordJoin,ConditionJoin, TemplateName);
            // List<QueryGenerator> models = JsonConvert.DeserializeObject<List<QueryGenerator>>(datainfo);

            return Ok();
        }
    }
}
