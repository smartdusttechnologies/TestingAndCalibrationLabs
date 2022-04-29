using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using TestingAndCalibrationLabs.Business.Common;
using TestingAndCalibrationLabs.Business.Core.Interfaces.MetirialTest;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class TestingCategoryLookupController : Controller
    {

        private readonly ILogger<TestingCategoryLookupController> _logger;
        private readonly ITestingCategoryLookupService _testingCategoryLookupService;
        private readonly IMapper _mapper;
        /// <summary>
        /// passing parameter via varibales for establing connection
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="TestingCategoryLookupService"></param>
        /// <param name="hostingEnvironment"></param>
        public TestingCategoryLookupController(ILogger<TestingCategoryLookupController> logger, ITestingCategoryLookupService testingCategoryLookupService, IMapper mapper)
        {
            _logger = logger;
            _testingCategoryLookupService = testingCategoryLookupService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult test()
        {
           

            List<Business.Core.Model.MetirialTest.TestingCategoryLookupModel> testlists = _testingCategoryLookupService.GetTests();
            var tests = _mapper.Map<List<Business.Core.Model.MetirialTest.TestingCategoryLookupModel>, List<Models.MeterialTests.TestingCategoryLookupModelDTO>>(testlists);
            var hierarchy = tests.Hierarchize(
             0, // The "root level" key. We're using -1 to indicate root level.
             f => f.Id, // The ID property on your object
             f => f.ParentId,// The property on your object that points to its parent
            f => f.Position // The property on your object that specifies the order within its parent
 
             );
     

            var jsonData = "[";
            for (var i = 0; i < tests.ToArray().Length; i++) {
                if (tests[i].ParentId == 0) {
                    if (jsonData != "[") jsonData += ",";
                    jsonData += "{id:"+ tests[i].Id + ",title:`"+tests[i].Name+"`";
                    for (var j = i + 1; j < tests.ToArray().Length; j++) {
                        if (tests[i].Id == tests[j].ParentId)
                        {
                            jsonData += ",subs:[";
                            while(j< tests.ToArray().Length)
                            {
                                if (tests[i].Id == tests[j].ParentId)
                                {
                                    if (jsonData.Substring(jsonData.Length - 6) != "subs:[") jsonData += ",";
                                    jsonData += "{id:" + tests[j].Id + ",title:`" + tests[j].Name + "`}";
                                }
                                j++;
                            }
                            jsonData +="]";
                        }
                    }
                    jsonData += "}";
                }

            }
            jsonData+= "]";

            ViewBag.jsonData = jsonData;
            return View(tests);
        }
        public IActionResult TestingCategoryLookup1()
        {
            return View();
        }



    }
}
