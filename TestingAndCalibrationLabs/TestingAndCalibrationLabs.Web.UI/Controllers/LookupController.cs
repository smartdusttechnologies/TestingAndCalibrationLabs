using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;
using TestingAndCalibrationLabs.Web.UI.Models;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;
        private readonly IListSorter _listSorter;
        public LookupController(ILookupService lookupService,IListSorter listSorter)
        {
            _lookupService = lookupService;
            _listSorter = listSorter;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LookupByCategory(int categoryName)
        {
            var lookupList = _lookupService.Get();
            var sf = lookupList.Where(x=>x.LookupCategoryId == categoryName).ToList();
            List<ListSorterModel> listSorterDTOs = new List<ListSorterModel>();
            foreach (var item in sf)
            {
                listSorterDTOs.Add(new ListSorterModel { Id = item.Id, Name = item.Name });
            }
            var jsonFormated = _listSorter.MethodName(listSorterDTOs);
           var jsonObjectConverted = JsonConvert.DeserializeObject(jsonFormated);
            return Ok(jsonObjectConverted);
        }
    }
}
