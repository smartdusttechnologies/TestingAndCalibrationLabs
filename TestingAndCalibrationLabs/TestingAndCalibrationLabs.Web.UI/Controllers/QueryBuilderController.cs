
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Interfaces.QueryBuilder;
using TestingAndCalibrationLabs.Web.UI.Models;

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
       public IActionResult QueryGenerator(List<Array> data)
        {
          // List<QueryGenerator> models = JsonConvert.DeserializeObject<List<QueryGenerator>>(datainfo);

            return Ok();
        }
    }
}
