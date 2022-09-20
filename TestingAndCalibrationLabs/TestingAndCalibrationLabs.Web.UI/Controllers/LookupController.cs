using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TestingAndCalibrationLabs.Business.Core.Interfaces;
using TestingAndCalibrationLabs.Business.Core.Model;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class LookupController : Controller
    {
        private readonly ILookupService _lookupService;
        private readonly IListSorterService _listSorter;
        public LookupController(ILookupService lookupService,IListSorterService listSorter)
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
            var lookupByCategory = lookupList.Where(x=>x.LookupCategoryId == categoryName).ToList();
            List<ListSorterModel> listSorterDTO = new List<ListSorterModel>();
            foreach (var item in lookupByCategory)
            {
                listSorterDTO.Add(new ListSorterModel { Id = item.Id, Name = item.Name });
            }
            var jsonFormated = _listSorter.SortListToJson(listSorterDTO);
           var jsonObjectConverted = JsonConvert.DeserializeObject(jsonFormated);
            return Ok(jsonObjectConverted);
        }
    }
}
