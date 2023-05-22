using Microsoft.AspNetCore.Mvc;
using TestingAndCalibrationLabs.Business.Common;

namespace TestingAndCalibrationLabs.Web.UI.Controllers
{
    public class JsonToSqlConverterController : Controller
    {
        public IActionResult Index( string QueryJson)
        {
            var result = SqlConverter.JsonToSql(QueryJson);
            ViewBag.IsSuccess = TempData["IsTrue"] != null ? TempData["IsTrue"] : false;
            return View();
        }
    }
}
