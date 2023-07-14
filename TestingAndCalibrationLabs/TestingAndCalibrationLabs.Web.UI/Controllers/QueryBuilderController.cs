
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

        public IActionResult Index()
        {
            List<Business.Core.Model.QueryBuilder.QueryBuilderModel> tableName = _querybuilderService.GetTableNames();
            var queryBuilderMetaData = _querybuilderService.GetColoumsNames(tableName);
            var records = _mapper.Map<Business.Core.Model.QueryBuilder.QueryRecordModel, Models.QueryBuilderRecordDTO>(queryBuilderMetaData);
            return View(records);
        }
        [HttpPost]
       public IActionResult QueryGenerator(string jsonData ,string JoinData)
        {
            //List<string> list = JsonSerializer.Serialize(jsonData);
          
            List<UiQueryBuilderColumn> person = JsonSerializer.Deserialize<List<UiQueryBuilderColumn>>(jsonData);
            List<JoinModel> Join = JsonSerializer.Deserialize<List<JoinModel>>(JoinData);

            //var  emptydata = Object.entries(datainfo); 


            for(var  item = 0; item < person.Count; item++)
            {
                if (item + 65 + 1 <= 91)
                {
                   
                    person[item].Alias = Convert.ToChar(item + 65); 

                }
                    
                    
            }
            var records = _mapper.Map<List<Models.UiQueryBuilderColumn>, List<Business.Core.Model.UiQueryGenerator>>(person);


            var recordJoin = _mapper.Map<List<Models.JoinModel>, List<Business.Core.Model.QueryBuilder.JoinModelDTO>>(Join);


            var value = _querybuilderService.UiToJsonQueryBuilder(records,recordJoin);
            // List<QueryGenerator> models = JsonConvert.DeserializeObject<List<QueryGenerator>>(datainfo);

            return Ok();
        }
    }
}
